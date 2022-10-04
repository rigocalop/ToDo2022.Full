namespace ToDo2022.Database.Configuration
{
    public class Tarea__Configuration
    {
        public Tarea__Configuration(EntityTypeBuilder<Tarea> entityBuilder)
        {
            //propiedades comunes
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).IsRequired(true).HasColumnType("int");
            entityBuilder.Property(x => x.Name).IsRequired(true).HasMaxLength(80).HasColumnType("nvarchar");
            entityBuilder.Property(x => x.Meta_Id).IsRequired(true).HasDefaultValue(1).HasColumnType("int");
            entityBuilder.Property(x => x.IsCompleted).IsRequired(true).HasDefaultValue(false);
            entityBuilder.Property(x => x.Created).IsRequired(true).HasDefaultValue(DateTime.Now);
            entityBuilder.Property(x => x.IsMarked).IsRequired(true).HasDefaultValue(false);
            entityBuilder.Property(x => x.IsSelected).IsRequired(true).HasDefaultValue(false);
        }
    }
}
