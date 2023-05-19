using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineApp.Models.Classes
{
    public class ToDo
    {
        [Key]
        public int ToDoId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Title { get; set; }

        [Column(TypeName = "Bit")]        
        public bool Situation { get; set; }

                
    }
}