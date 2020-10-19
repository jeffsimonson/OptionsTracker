using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OptionsTracker.Data;
using OptionsTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OptionsTracker.Pages.Trades
{
    public class IndexModel : PageModel
    {
        private readonly OptionsTrackerContext _context;

        public IndexModel(OptionsTrackerContext context)
        {
            _context = context;
        }


        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList SelectionMarketsList { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SelectedMarket { get; set; }

        public IList<DisplayTrade> DisplayTradesList { get; set; }

        private IList<Trade> TradeTableList { get; set; }
        private IList<Market> MarketTableList { get; set; }


        [DataType(DataType.Currency)]
        public decimal TotalPortfolioValue { get; set; }
        [DataType(DataType.Currency)]
        public decimal TotalProfitLoss { get; set; }
        public string TotalProfitLossClassName { get; set; }


        public async Task OnGetAsync()
        {
            await GetMarketSelectionList();
            await GetListOfTrades();
            await GetMarketTable();

            BuildDisplayTradeList();
            TallyTotals();
        }

        private async Task GetMarketSelectionList()
        {
            // Use LINQ to get list of markets.
            IQueryable<string> marketQuery = from m in _context.Markets
                                             orderby m.Name
                                             select m.Name + " - " + m.MarketID;

            SelectionMarketsList = new SelectList(await marketQuery.Distinct().ToListAsync());
        }

        private async Task GetListOfTrades()
        {
            var trades = from t in _context.Trades
                         select t;

            if (!string.IsNullOrEmpty(SearchString))
            {
                trades = trades.Where(s => s.Market.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(SelectedMarket))
            {
                trades = trades.Where(x => x.Market == SelectedMarket.Substring(SelectedMarket.Length - 2, 2)); ;
            }

            TradeTableList = await trades.ToListAsync();
        }


        private async Task GetMarketTable()
        {
            var marketTableQuery = from m in _context.Markets
                                   select m;

            MarketTableList = await marketTableQuery.ToListAsync();
        }

        private void BuildDisplayTradeList()
        {

            var leftJoinQuery = from t in TradeTableList
                                join m in MarketTableList
                                on t.Market equals m.MarketID into TradeMarketsGroup
                                from tmg in TradeMarketsGroup.DefaultIfEmpty()
                                select new
                                {
                                    t.ID,
                                    t.Market,
                                    t.ContractMonth,
                                    t.ContractType,
                                    t.StrikePrice,
                                    t.ExpirationDate,
                                    t.EntryDate,
                                    t.NbrOfContracts,
                                    t.EntryPrice,
                                    t.CurrentPrice,
                                    t.CommissionFees,
                                    Name = tmg?.Name ?? "Invalid Symbol",
                                    PointValue = tmg?.PointValue ?? 0,
                                    QuoteStyle = tmg?.QuoteStyle ?? "R"
                                };

            List<DisplayTrade> listOfTrades = new List<DisplayTrade>();

            decimal computedProfitLoss = 0;

            foreach (var t in leftJoinQuery)
            {

                computedProfitLoss = (((t.CurrentPrice - t.EntryPrice) * t.PointValue) * t.NbrOfContracts) - t.CommissionFees;


                listOfTrades.Add(new DisplayTrade
                {
                    ID = t.ID,
                    Market = t.Market,
                    ContractMonth = t.ContractMonth,
                    ContractType = t.ContractType,
                    StrikePrice = t.StrikePrice,
                    ExpirationDate = t.ExpirationDate,
                    EntryDate = t.EntryDate,
                    NbrOfContracts = t.NbrOfContracts,
                    EntryPrice = t.EntryPrice,
                    CurrentPrice = t.CurrentPrice,
                    CommissionFees = t.CommissionFees,
                    Name = t.Name,
                    PointValue = t.PointValue,
                    QuoteStyle = t.QuoteStyle,
                    PositionValue = (t.CurrentPrice * t.PointValue) * t.NbrOfContracts,
                    PositionProfitLoss = computedProfitLoss,
                    ProfitLossClassName = (computedProfitLoss < 0) ? "inTheRed" : "inTheGreen",
                    DaysToExpiration = (int)(t.ExpirationDate.Date - DateTime.Now.Date).Days

                });
            }

            DisplayTradesList = listOfTrades;
        }

        private void TallyTotals()
        {
            TotalPortfolioValue = 0;
            TotalProfitLoss = 0;

            foreach (var t in DisplayTradesList)
            {
                TotalPortfolioValue += t.PositionValue;
                TotalProfitLoss += t.PositionProfitLoss;
            }

            TotalProfitLossClassName = (TotalProfitLoss < 0) ? "inTheRed" : "inTheGreen";
        }


    }

}
