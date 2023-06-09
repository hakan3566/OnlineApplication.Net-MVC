﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineApp.Models.Classes
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Display(Name ="Employee Name")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeName { get; set; }

        [Display(Name = "Employee Surname")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeSurname { get; set; }

        [Display(Name = "Image")]
        [Column(TypeName = "Varchar")]
        [StringLength(500)]
        public string EmployeeImage { get; set; }

        public ICollection<SalesTransaction> SalesTransactions { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}