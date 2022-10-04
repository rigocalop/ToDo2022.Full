namespace ToDo2022.Database.Dto
{
    public class Tarea__Dto : Tarea
    {
        public void Transfer(ref Tarea to)
        {
            to.Name = this.Name;
            to.Created = this.Created;
            to.IsCompleted = this.IsCompleted;
            to.Meta_Id = this.Meta_Id;
            to.IsMarked = this.IsMarked;
            to.IsSelected = this.IsSelected;

        }
    }
}
