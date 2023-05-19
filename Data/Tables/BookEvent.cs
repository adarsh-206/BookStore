using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.Tables
{
    public class BookEvent
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        public Enum Type { get; set; }

        public int DurationInHours { get; set; }

        public string Description { get; set; }

        public string OtherDetails { get; set; }

        public string InviteByEmail { get; set; }
    }

    public enum Type
    {
        MALE = 1,
        FEMALE = 2
    }
}
