using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Infra.Data.Configuration
{
    public class PhoneNumberTypeConfiguration : IEntityTypeConfiguration<PhoneNumberType>
    {
        public void Configure(EntityTypeBuilder<PhoneNumberType> builder)
        {
            builder.Ignore(b => b.DomainEvents);

            builder.ToTable("PhoneNumberType", "dbo").HasKey(t => t.PhoneNumberTypeId);

            builder.Property(t => t.PhoneNumberTypeId).HasColumnName("BusinessEntityId").IsRequired(true);
            builder.Property(t => t.Name).HasColumnName("Name").IsRequired(true);

            builder.HasData(new PhoneNumberType { PhoneNumberTypeId = 1, Name = "Local phone"  });
            builder.HasData(new PhoneNumberType { PhoneNumberTypeId = 2, Name = "Cellphone" });

        }
    }
}
