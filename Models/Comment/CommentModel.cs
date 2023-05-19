using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using BookStore.Data;
using BookStore.Data.Entity;
using BookStore.Models.User;

namespace BookStore.Models.Comment
{
    public class CommentModel
    {
        public long Id;

        [Required]
        [MaxLength(4096)]
        public string Text { get; set; }

       
        public UserModel User { get; set; }

        public BookEventEntity Book { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }
}
