using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace TaskMangmentSystem.ConfigtrationClasses
{
    public class TaskManagementConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> TI)
        {
            TI.Property(TI => TI.Title )
                .HasMaxLength(100);
            TI.Property(TI => TI.Description)
                .HasMaxLength(500);
            TI.Property(TI => TI.CreateAt)
                .HasDefaultValueSql("getdate()");
        }
    }
}
