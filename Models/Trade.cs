using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OptionsTracker.Models
{
    public class Trade
    {
        public int ID { get; set; }
        public string Market { get; set; }

        [Display(Name = "Contract Month")]
        public string ContractMonth { get; set; }

        [Display(Name = "Type")]
        public string ContractType { get; set; }

        [Display(Name = "Strike Price")]
        public string StrikePrice { get; set; }

        [Display(Name = "Expiration")]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }


        [Display(Name = "Entry Date")]
        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }

        [Display(Name = "Contracts")]
        public int NbrOfContracts { get; set; }

        [Display(Name = "Entry Price")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.#####}")]
        [Column(TypeName = "decimal(18, 5)")]
        public decimal EntryPrice { get; set; }

        [Display(Name = "Current Price")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.#####}")]
        [Column(TypeName = "decimal(18, 5)")]
        public decimal CurrentPrice { get; set; }

        [Display(Name = " Commission")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CommissionFees { get; set; }

        [DataType(DataType.Date)]

        [Display(Name = "Exit Date")]
        public DateTime? ExitDate { get; set; }

        [Display(Name = "Exit Price")]
        [Column(TypeName = "decimal(18, 5)")]
        public decimal? ExitPrice { get; set; }

    }
}
