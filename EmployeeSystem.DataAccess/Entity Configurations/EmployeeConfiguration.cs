using EmployeeManagement.DataAccess.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeManagement.DataAccess.Entity_Configurations
{
    [ExcludeFromCodeCoverage]
    public class EmployeeConfiguration: IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.Property(x => x.EmployeeId).IsRequired();
            builder.HasKey(x => x.EmployeeId);           
            builder.Property(x => x.Email).IsRequired();
            
        }
    }
}
