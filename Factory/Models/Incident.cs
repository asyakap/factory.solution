using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
    public class Incident
    {
        public int IncidentId { get; set; }

        [Required(ErrorMessage = "The Description can't be empty!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The incident's status can't be empty!")]
        public IncidentStatus Status { get; set; }
        public DateTime Date { get; set; }
        public List<IncidentMachine> JoinEntities1 { get; set; }
    }

    public enum IncidentStatus
    { 
      fixed_,
      broken_
    }
}