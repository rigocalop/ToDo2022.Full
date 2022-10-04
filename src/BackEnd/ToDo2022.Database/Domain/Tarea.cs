using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo2022.Database.Domain
{
    public class Tarea: EzItemModel
    {
        public bool IsCompleted { get; set; } = false;
        public DateTime? Created { get; set; }

        [ForeignKey("Meta_Id")]
        internal Meta? _Meta { get; set; }
        public int Meta_Id { get; set; }
        public bool IsMarked { get; set; }
        public bool IsSelected { get; set; }

    }
}
