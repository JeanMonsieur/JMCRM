using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JMCRM.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        [ForeignKey("StorylineId")]
        public int StorylineId { get; set; }
        public Contact EventContact { get; set; }
        public DateTime OccurenceDateTime { get; set; }
        public string Description { get; set; }
    }
}
