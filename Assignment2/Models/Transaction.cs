using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Assignment2.Models;

namespace Assignment2.Models
{
    public class Transaction
    {
        public int AccountNumber { get; set; }
        public decimal MinAmountCredit { get; set; }
        public decimal MaxAmountCredit { get; set; }
        public decimal MinAmountDebit { get; set; }
        public decimal MaxAmountDebit { get; set; }
        public string Description { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ReferenceNumber { get; set; }
    }
}
public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {


        builder.Property(x => x.ReferenceNumber).IsRequired(true);
        builder.Property(x => x.AccountNumber).IsRequired(true);
        builder.Property(x => x.MaxAmountCredit).IsRequired(true).HasPrecision(15, 4).HasDefaultValue(0);
        builder.Property(x => x.MaxAmountDebit).IsRequired(true).HasPrecision(15, 4).HasMaxLength(0);

        builder.Property(x => x.Description).IsRequired(true).HasMaxLength(250);
        builder.Property(x => x.ReferenceNumber).IsRequired(true).HasMaxLength(50);

        builder.HasIndex(x => x.AccountNumber);
        builder.HasIndex(x => x.ReferenceNumber);
    }

}