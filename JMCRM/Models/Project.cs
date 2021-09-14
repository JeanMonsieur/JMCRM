using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JMCRM.Models
{
    public class Project
    {
        [Key]
        public string ProjectId { get; set; }
        [Required]
        public string Version { get; set; }
        [Required]
        public bool Control { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Storyline> Storylines { get; set; }
    }
}
