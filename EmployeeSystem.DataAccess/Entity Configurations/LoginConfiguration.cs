
using EmployeeManagement.DataAccess.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Entity_Configurations
{
    [ExcludeFromCodeCoverage]
    public class LoginConfiguration: IEntityTypeConfiguration<LoginEntity>
    {
        public void Configure(EntityTypeBuilder<LoginEntity> builder)
        {

            //builder.HasKey(x => x.Id).HasName("pk_UID");
            builder
                .HasOne(bc => bc.Employee)
                .WithMany()
                .HasForeignKey(bc => bc.EmployeeId)
                .IsRequired();

            builder.Property(x =>x.Username).IsRequired();

            builder.Property(x => x.OldPassword).IsRequired();
            

        }
    }
}
