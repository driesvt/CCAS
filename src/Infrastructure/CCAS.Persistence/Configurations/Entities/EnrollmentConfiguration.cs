﻿using CCAS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAS.Persistence.Configurations.Entities
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
        }
    }
}
