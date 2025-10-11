namespace Core.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description  { get; set; }
        public bool Iscompleted { get; set; }
        public DateTime? CreateAt { get; set; }//Mandatory  
    }
}
