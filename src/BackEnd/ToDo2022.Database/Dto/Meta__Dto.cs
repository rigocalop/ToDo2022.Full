namespace ToDo2022.Database.Dto
{
    public class Meta__Dto : Meta
    {
        public void Transfer(ref Meta to)
        {
            to.Name = this.Name;
            to.Created = this.Created;
            to.PorcentajeTareasCompleted = this.PorcentajeTareasCompleted; 
            to.TotalTareasCompleted = this.TotalTareasCompleted;
            to.TotalTareas = this.TotalTareas;
            to.TotalTareasSelected = this.TotalTareasSelected;
        }
    }
}
