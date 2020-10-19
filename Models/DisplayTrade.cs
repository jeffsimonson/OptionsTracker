using System.ComponentModel.DataAnnotations;

namespace OptionsTracker.Models
{

    //This model is used to add addtional computed fields to the fields from the Trade model for the portfolio display.
    public class DisplayTrade : Trade
    {
        public string Name { get; set; }
        public decimal PointValue { get; set; }
        public string QuoteStyle { get; set; }

        [Display(Name = "Position Value")]
        [DataType(DataType.Currency)]
        public decimal PositionValue { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Profit Loss")]
        public decimal PositionProfitLoss { get; set; }
        public string ProfitLossClassName { get; set; }

        [Display(Name = "Day to Expiration")]
        public int DaysToExpiration { get; set; }

    }

}
