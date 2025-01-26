using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecaster.Infrastructure.Database.Configurations
{
    internal class CourseTypeConfiguration : IEntityTypeConfiguration<CourseTypeConfiguration>
    {
        public void Configure(EntityTypeBuilder<CourseTypeConfiguration> builder)
        {
            throw new NotImplementedException();
        }
    }
}
