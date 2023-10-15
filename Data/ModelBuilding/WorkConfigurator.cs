using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.ModelBuilding
{
    public class WorkConfigurator : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasMany(x => x.Positions)
                .WithOne(x => x.Work)
                .HasForeignKey(x => x.WorkId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}