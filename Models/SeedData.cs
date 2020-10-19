using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OptionsTracker.Data;
using System;
using System.Linq;

namespace OptionsTracker.Models
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OptionsTrackerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<OptionsTrackerContext>>()))
            {
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
                    }

                );
                context.SaveChanges();
            }
        }
    }
}
