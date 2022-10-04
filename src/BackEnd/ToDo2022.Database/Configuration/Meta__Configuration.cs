namespace ToDo2022.Database.Configuration
{
    public class Meta__Configuration
    {
        public Meta__Configuration(EntityTypeBuilder<Meta> entityBuilder)
        {
            //propiedades comunes
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).IsRequired(true).HasColumnType("int");
            entityBuilder.HasMany(p => p.Items).WithOne(s => s._Meta).HasForeignKey(s => s.Meta_Id);
            entityBuilder.Property(x => x.Name).IsRequired(true).HasMaxLength(80).HasColumnType("nvarchar");
            entityBuilder.Property(x => x.Created).IsRequired(true).HasDefaultValue(DateTime.Now);
            entityBuilder.Property(x => x.PorcentajeTareasCompleted).IsRequired(true).HasDefaultValue(0).HasColumnType("int");
            entityBuilder.Property(x => x.TotalTareas).IsRequired(true).HasDefaultValue(0).HasColumnType("int");
            entityBuilder.Property(x => x.TotalTareasCompleted).IsRequired(true).HasDefaultValue(0).HasColumnType("int");
            entityBuilder.Property(x => x.TotalTareasSelected).IsRequired(true).HasDefaultValue(0).HasColumnType("int");
        }
    }
}
