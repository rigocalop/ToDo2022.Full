namespace ToDo2022.MetasManager.Models
{
    public class Meta__Dte : EzItemModel
    {
        public int PorcentajeTareasCompleted { get; set; } = 0;
        public int TotalTareas { get; set; } = 0;
        public int TotalTareasCompleted { get; set; } = 0;
        public int TotalTareasSelected { get; set; } = 0;
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? Created { get; set; }
    }
}
