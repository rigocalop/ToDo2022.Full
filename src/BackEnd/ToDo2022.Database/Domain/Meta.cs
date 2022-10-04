namespace ToDo2022.Database.Domain
{
    public class Meta : EzItemModel
    {
        public DateTime? Created { get; set; }
        internal List<Tarea>? Items { get; set; }
        public int PorcentajeTareasCompleted { get; set; }
        public int TotalTareas { get; set; }
        public int TotalTareasCompleted { get; set; }
        public int TotalTareasSelected { get; set; }

    }
}
