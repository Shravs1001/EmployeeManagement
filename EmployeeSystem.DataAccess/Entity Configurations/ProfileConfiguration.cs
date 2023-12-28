using EmployeeManagement.DataAccess.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Entity_Configurations
{
    [ExcludeFromCodeCoverage]
    public class ProfileConfiguration: IEntityTypeConfiguration<ProfileEntity>
    {
        public void Configure(EntityTypeBuilder<ProfileEntity> builder)
        {
            builder.Property(x => x.FileThumbnail).IsRequired();
            
            builder.HasOne(s => s.Employee)
                  .WithMany()
                  .HasForeignKey(ad => ad.EmployeeId)
                  .IsRequired();

        }
    }
}
