using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineApp.Models.Classes
{
    public class Current
    {
        [Key]
        public int CurrentId { get; set; }

        [Display(Name = "Current Name")]
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="You have to type 30 characters!")]
        public string CurrentName { get; set; }

        [Display(Name = "Current Surname")]
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage ="Required Field !")]
        [StringLength(30)]
        public string CurrentSurname { get; set; }

        [Display(Name = "City")]
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CurrentCity { get; set; }

        [Display(Name = "Email")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CurrentMail { get; set; }

        
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CurrentPassword { get; set; }

        public bool Situation { get; set; }

        public ICollection<SalesTransaction> SalesTransactions { get; set; }
    }
}