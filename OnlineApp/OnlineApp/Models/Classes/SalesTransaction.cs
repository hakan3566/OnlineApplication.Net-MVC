﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineApp.Models.Classes
{
    public class SalesTransaction
    {
        [Key]
        public int SalesId { get; set; }

        public DateTime Date { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }

        [Display(Name = "Aggregate Amount")]
        public decimal AggregateAmount { get; set; }

        public int Productid { get; set; }
        public int CurrentId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Current Current { get; set; }
        public virtual Employee Employee { get; set; }
    }
}