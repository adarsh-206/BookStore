using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using BookStore.Data;
using BookStore.Data.Entity;
using BookStore.Models.User;

namespace BookStore.Models.Comment
{
    
    public class CommentEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(4096)]
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }


        [Required]
        public string UserId { get; set;}
        [ForeignKey("UserId")]

        [Required]

        public UserModel User { get; set; }        

        [Required]
        public int BookEventId { get; set;}
        [Required]
        [ForeignKey("BookEventId")]
        public BookEventEntity BookEvent { get; set; }


        
    }
}
