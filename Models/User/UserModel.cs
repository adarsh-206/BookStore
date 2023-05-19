using BookStore.Data.Entity;
using BookStore.Models.Comment;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.User
{
    public class UserModel: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<BookEventEntity> BookEvents { get; set; }

        public ICollection<CommentEntity> Comments { get; set; }

    }
}
