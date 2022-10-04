namespace ToDo2022.MetasManager.Models
{
    public class Tarea__Dte : EzItemModel
    {
        public bool IsCompleted { get; set; } = false;
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? Created { get; set; }
        public int Meta_Id { get; set; }
        public bool IsMarked { get; set; }
        public bool IsSelected { get; set; }
    }
}
