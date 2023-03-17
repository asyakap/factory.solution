namespace Factory.Models
{
    public class IncidentMachine
    {
      public int IncidentMachineId { get; set; }
        public int MachineId { get; set; }
        public int IncidentId { get; set; }
        public Incident Incident { get; set; }
        public Machine Machine { get; set; }
    }
}