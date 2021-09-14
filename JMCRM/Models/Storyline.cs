using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JMCRM.Models
{
    public class Storyline
    {
        [Key]
        public int StorylineId { get; set; }
        [ForeignKey("ProjectId")]
        public string ProjectId { get; set; }
        public string Title { get; set; }
        public List<Event> Events { get; set; }
    }
}
