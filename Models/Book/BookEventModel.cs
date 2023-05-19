using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using BookStore.Data;
using Type = BookStore.Data.Entity.Type;

namespace BookStore.Models.Book
{
    public class BookEventModel
    {

        public int Id;

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Invalid date")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date")]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(30)]
        public string Location { get; set; }

        [Required(ErrorMessage = "Invalid date")]
        [DataType(DataType.Time,ErrorMessage = "Invalid time")]
        public DateTime StartTime { get; set; }

        [Required]
        public Type Type { get; set; }
       

        [DataType(DataType.Duration)]
        [Range(1, 4)]
        public byte? Duration { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }


        [MaxLength(255)]
        public string OtherDetails { get; set; }
        
        [MaxLength(255)]
        public string InviteByEmail { get; set; }

    }
}
