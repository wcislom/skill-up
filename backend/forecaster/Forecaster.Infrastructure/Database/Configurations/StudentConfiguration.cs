using Forecaster.Core.Entities.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forecaster.Infrastructure.Database.Configurations
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student", Schemas.Training);
            builder.Property(e => e.Id).HasColumnName("StudentId");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(50);
        }
    }
}
