
using BankingPanel.Domain.ApplicationUserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;


namespace UserManagement.Infrastructure.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.FirstName);

        builder.Property(u => u.LastName);

        builder.Property(u => u.Email);
        builder.Property(u => u.Active);

        builder.Property(u => u.Roles)
               .HasConversion( v=> JsonConvert.SerializeObject(v), 
                               v => JsonConvert.DeserializeObject<List<string>>(v));

        builder.Property("_passwordHash")
            .HasColumnName("PasswordHash");
    }
}
