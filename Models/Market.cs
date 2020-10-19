using System.ComponentModel.DataAnnotations.Schema;

namespace OptionsTracker.Models
{
    public class Market
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string MarketID { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PointValue { get; set; }

        public string QuoteStyle { get; set; }
    }
}
