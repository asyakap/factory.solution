using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
    public class Machine
    {
        public int MachineId { get; set; }

        [Required(ErrorMessage = "The machine's Title can't be empty!")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "The machine's Status can't be empty!")]
        public Status Status { get; set; }

        public List<EngineerMachine> JoinEntities { get; set; }
    }

    public enum Status
    { 
      operational,
      malfunctioning,
      under_repairment    
    }
}