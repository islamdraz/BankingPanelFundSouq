
using BankingPanel.Domain.ClientAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BankingPanel.Infrastructure.Persistence.Configurations;

public class ClientConfigurations : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {   
        builder.ToTable(nameof(Client));
        builder.HasKey(u => u.Id);

        builder.Property(u => u.FirstName).HasMaxLength(60);
        builder.Property(u => u.LastName).HasMaxLength(60);
        builder.Property(u => u.Email).HasMaxLength(150);
        builder.Property(u => u.Sex).HasConversion(u => u.ToString(), u => (Sex)Enum.Parse(typeof(Sex), u));
        builder.Property(u=> u.Photo).HasColumnType("BLOB");

        builder.OwnsOne(x=> x.PhoneNumber , b => {
            b.Property(x => x.CountryCode);
            b.Property(x => x.Number);      
        });

        builder.OwnsOne(x=> x.Address , b => {
            b.Property(x => x.Country);
            b.Property(x => x.City);
            b.Property(x => x.Street);
            b.Property(x => x.ZibCode);
        });
        
        builder.Property(u => u.PersonalId).HasMaxLength(11);

   
    }
}
