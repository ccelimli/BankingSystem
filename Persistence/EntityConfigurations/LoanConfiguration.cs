using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("Loans").HasKey(loan => loan.Id);

            builder.Property(loan => loan.Id).HasColumnName("Id").IsRequired();
            builder.Property(loan => loan.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(loan => loan.InterestRate).HasColumnName("InterestRates").IsRequired();
            builder.Property(loan => loan.Avail).HasColumnName("Avails").IsRequired();
            builder.Property(loan => loan.NumberOfInstallments).HasColumnName("NumberOfInstallments").IsRequired();
            builder.Property(loan => loan.NumberOfRemainingInstallments).HasColumnName("NumberOfRemainingInstallments").IsRequired();
            builder.Property(loan => loan.TotalRate).HasColumnName("TotalRates").IsRequired();
            builder.Property(loan => loan.MonthlyPaymentAmount).HasColumnName("MonthlyPaymentAmounts").IsRequired();
            builder.Property(loan => loan.RequestedLoanAmount).HasColumnName("RequestedLoanAmounts").IsRequired();
            builder.Property(loan => loan.TotalPaymentAmount).HasColumnName("TotalPaymentAmounts").IsRequired();
            builder.Property(loan => loan.MonthlyPaymentDate).HasColumnName("MonthlyPaymentDates").IsRequired();
            builder.Property(loan => loan.LoanStatus).HasColumnName("LoanStatuses").IsRequired();
            builder.Property(loan => loan.UserId).HasColumnName("UserId").IsRequired();
           
            builder.Property(loan => loan.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(loan => loan.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(loan => loan.DeletedDate).HasColumnName("DeletedDate");

            
            builder.HasOne(loan => loan.User);

            builder.HasQueryFilter(loan => !loan.DeletedDate.HasValue);
        }
    }
}
