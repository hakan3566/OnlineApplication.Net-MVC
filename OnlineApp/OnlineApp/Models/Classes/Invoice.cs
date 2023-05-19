using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineApp.Models.Classes
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [Display(Name = "Invoice Serial Number")]
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string InvoiceSerialNumber { get; set; }

        [Display(Name = "Invoice Order Number")]
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string InvoiceOrderNumber { get; set; }
        public DateTime InvoiceDate { get; set; }

        [Display(Name = "Tax Administration")]
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxAdministration { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Time { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Deliverer { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Recipient { get; set; }

        public decimal Total { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }

    }
}