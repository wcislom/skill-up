using Forecaster.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forecaster.Infrastructure.Database.Configurations
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(e => e.Id).HasColumnName("CourseId");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title).IsRequired().HasMaxLength(50);
        }
    }
}
