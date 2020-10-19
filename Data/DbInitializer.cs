using OptionsTracker.Models;
using System;
using System.Linq;

namespace OptionsTracker.Data
{
    public class DbInitializer
    {

        public static void Initialize(OptionsTrackerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Trades data
            if (context.Trades.Any())
            {
                return;   // DB has been seeded
            }


            context.Trades.AddRange(
                new Trade
                {
                    Market = "ZC",
                    ContractMonth = "Z20",
                    ContractType = "Call",
                    StrikePrice = "540",
                    ExpirationDate = DateTime.Parse("2020-11-30"),
                    EntryDate = DateTime.Parse("2020-04-02"),
                    NbrOfContracts = 2,
                    EntryPrice = 35,
                    CurrentPrice = 50,
                    CommissionFees = 13.47M,
                    ExitDate = DateTime.Parse("2020-10-15"),
                    ExitPrice = 50
                },


                new Trade
                {
                    Market = "ZS",
                    ContractMonth = "H21",
                    ContractType = "Put",
                    StrikePrice = "1260",
                    ExpirationDate = DateTime.Parse("2021-02-15"),
                    EntryDate = DateTime.Parse("2020-07-11"),
                    NbrOfContracts = 2,
                    EntryPrice = 51,
                    CurrentPrice = 34,
                    CommissionFees = 12.89M,
                    ExitDate = DateTime.Parse("2020-09-23"),
                    ExitPrice = 49
                },



                new Trade
                {
                    Market = "ZW",
                    ContractMonth = "H21",
                    ContractType = "Put",
                    StrikePrice = "1150",
                    ExpirationDate = DateTime.Parse("2021-02-15"),
                    EntryDate = DateTime.Parse("2020-07-11"),
                    NbrOfContracts = 2,
                    EntryPrice = 51,
                    CurrentPrice = 34,
                    CommissionFees = 12.89M,
                    ExitDate = DateTime.Parse("2020-09-23"),
                    ExitPrice = 49
                }
            );

            context.SaveChanges();



            var market = new Market[]
            {
                new Market{MarketID="A6",Name="Australian Dollar",PointValue=100000,QuoteStyle="R"},
                new Market{MarketID="B6",Name="British Pound",PointValue=62500,QuoteStyle="R"},
                new Market{MarketID="D6",Name="Canadian Dollar",PointValue=100000,QuoteStyle="R"},
                new Market{MarketID="DC",Name="Class III Milk",PointValue=2000,QuoteStyle="R"},
                new Market{MarketID="CC",Name="Cocoa",PointValue=10,QuoteStyle="R"},
                new Market{MarketID="KC",Name="Coffee",PointValue=375,QuoteStyle="R"},
                new Market{MarketID="ZC",Name="Corn",PointValue=50,QuoteStyle="G"},
                new Market{MarketID="CT",Name="Cotton #2",PointValue=500,QuoteStyle="R"},
                new Market{MarketID="CL",Name="Crude Oil WTI",PointValue=1000,QuoteStyle="R"},
                new Market{MarketID="E6",Name="Euro FX",PointValue=125000,QuoteStyle="R"},
                new Market{MarketID="ED",Name="Eurodollar",PointValue=2500,QuoteStyle="R"},
                new Market{MarketID="GF",Name="Feeder Cattle",PointValue=500,QuoteStyle="R"},
                new Market{MarketID="RB",Name="Gasoline RBOB",PointValue=42000,QuoteStyle="R"},
                new Market{MarketID="GC",Name="Gold",PointValue=100,QuoteStyle="R"},
                new Market{MarketID="KE",Name="Hard Red Wheat",PointValue=50,QuoteStyle="G"},
                new Market{MarketID="HG",Name="High Grade Copper",PointValue=25000,QuoteStyle="R"},
                new Market{MarketID="J6",Name="Japanese Yen",PointValue=125000,QuoteStyle="R"},
                new Market{MarketID="HE",Name="Lean Hogs",PointValue=400,QuoteStyle="R"},
                new Market{MarketID="LE",Name="Live Cattle",PointValue=400,QuoteStyle="R"},
                new Market{MarketID="LS",Name="Lumber",PointValue=110,QuoteStyle="R"},
                new Market{MarketID="NG",Name="Natural Gas",PointValue=10000,QuoteStyle="R"},
                new Market{MarketID="ZO",Name="Oats",PointValue=50,QuoteStyle="R"},
                new Market{MarketID="OJ",Name="Orange Juice",PointValue=150,QuoteStyle="R"},
                new Market{MarketID="SI",Name="Silver",PointValue=5000,QuoteStyle="R"},
                new Market{MarketID="ZM",Name="Soybean Meal",PointValue=100,QuoteStyle="R"},
                new Market{MarketID="ZL",Name="Soybean Oil",PointValue=600,QuoteStyle="R"},
                new Market{MarketID="ZS",Name="Soybeans",PointValue=50,QuoteStyle="G"},
                new Market{MarketID="MW",Name="Spring Wheat",PointValue=50,QuoteStyle="G"},
                new Market{MarketID="ISB",Name="Sugar #11",PointValue=1120,QuoteStyle="R"},
                new Market{MarketID="S6",Name="Swiss Franc",PointValue=125000,QuoteStyle="R"},
                new Market{MarketID="DX",Name="U.S. Dollar Index",PointValue=1000,QuoteStyle="R"},
                new Market{MarketID="HO",Name="ULSD NY Harbor",PointValue=42000,QuoteStyle="R"},
                new Market{MarketID="ZW",Name="Wheat",PointValue=50,QuoteStyle="G"}
            };

            context.Markets.AddRange(market);
            context.SaveChanges();
        }

    }
}

