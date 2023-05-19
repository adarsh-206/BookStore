using BookStore.Models.User;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models.Comment;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Data.Entity
{
    public class BookEventEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(30)]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required]
        public Type Type { get; set; }


        [DataType(DataType.Duration)]
        public byte? Duration { get; set; }

        [MaxLength(255)]

        public string Description { get; set; }
        
        [MaxLength(255)]
        public string OtherDetails { get; set; }

        [MaxLength(255)]

        public string InviteByEmail { get; set; }

        [Required]
        public UserModel User { get; set; }

        public ICollection<CommentEntity> Comments { get; set; }

    }

    public enum Type
    {
        Public,
        Private
    }

}
