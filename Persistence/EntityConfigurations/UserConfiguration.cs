using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(user => user.Id);

        builder.Property(user => user.Id).HasColumnName("Id").IsRequired();
        builder.Property(user => user.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(user => user.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(user => user.Email).HasColumnName("Email").IsRequired();
        builder.Property(user => user.Password).HasColumnName("Password").IsRequired();
        builder.Property(user => user.NationalityNo).HasColumnName("NationalityNo").IsRequired();
        builder.Property(user => user.PhoneNumber).HasColumnName("PhoneNumber").IsRequired();
        builder.Property(user => user.Address).HasColumnName("Address").IsRequired();
        builder.Property(user => user.FindexScore).HasColumnName("FindexScore").IsRequired();
        builder.Property(user => user.UserType).HasColumnName("Type").IsRequired();

        builder.Property(user => user.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(user => user.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(user => user.DeletedDate).HasColumnName("DeletedDate");

        builder.Property(user => user.PasswordHash).HasColumnName("PasswordHash");
        builder.Property(user => user.PasswordSalt).HasColumnName("PasswordSalt");
        builder.Property(user => user.Status).HasColumnName("Status");
        builder.Property(user => user.Role).HasColumnName("Role");

        builder.HasIndex(indexExpression: user => user.Email, name: "UK_Users_Email").IsUnique();
        builder.HasIndex(indexExpression: user => user.NationalityNo, name: "UK_Users_NationalityNo").IsUnique();
        builder.HasIndex(indexExpression: user => user.PhoneNumber, name: "UK_Users_PhoneNumber").IsUnique();

        builder.HasMany(user => user.Accounts);

        builder.HasQueryFilter(user => !user.DeletedDate.HasValue);
    }
}
