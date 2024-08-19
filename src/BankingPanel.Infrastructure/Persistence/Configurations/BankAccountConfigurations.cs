
using BankingPanel.Domain.ClientAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BankingPanel.Infrastructure.Persistence.Configurations;

public class BankAccountConfigurations : IEntityTypeConfiguration<BankAccount>
{
    public void Configure(EntityTypeBuilder<BankAccount> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.AccountNumber).HasMaxLength(50);
        builder.Property(u =>u.AccountCurrency ).HasConversion(v => v.ToString(), v=> (AccountCurrency)Enum.Parse(typeof(AccountCurrency),v));

        builder.HasOne<Client>().WithMany(u=> u.BankAccounts)
                                .HasForeignKey(u => u.ClientId);
      
    }
}
