using Forecaster.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forecaster.Infrastructure.Database.Configurations
{
    internal class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollment", Schemas.Training);
            builder.Property(e => e.Id).HasColumnName("EnrollmentId");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Grade)
                   .HasConversion<string>(); // Store enum as string
        }
    }
}
