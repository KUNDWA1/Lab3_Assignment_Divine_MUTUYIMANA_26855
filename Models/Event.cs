using System;

namespace Lab3Assignment.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public DateTime EventDate { get; set; }
        public decimal Budget { get; set; }
    }
}