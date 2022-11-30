
namespace src.entities
{
    public class AgendaTask
    {
        public int id { get; set; }
        public string Name { get; set;}
        public string Description { get; set; }
        public bool Complete {get; set;} = false;
        public DateTime Date {get; set;}

    }
}