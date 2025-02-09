using Forecaster.Core.Entities.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forecaster.Infrastructure.Database.Configurations
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course", Schemas.Training);
            builder.Property(e => e.Id).HasColumnName("CourseId");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title).IsRequired().HasMaxLength(50);
        }
    }
}
