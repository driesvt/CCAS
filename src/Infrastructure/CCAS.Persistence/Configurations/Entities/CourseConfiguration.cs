using CCAS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Persistence.Configurations.Entities
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData(
                new Course
                {
                    Id = 1,
                    Title = "Mathematics",
                    Credits = 12
                },
                new Course
                {
                    Id = 2,
                    Title = "Biology",
                    Credits = 12
                },
                new Course
                {
                    Id = 3,
                    Title = "Physics",
                    Credits = 12
                }
            );
        }
    }
}
