using EntityModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Configuration
{
    public class AccountConfiguration: IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder) 
        {
            builder.HasKey(e => e.UserId)
                .HasName("user_key");
            builder.Property(e => e.UserId).IsRequired();
            builder.Property(e => e.Username).IsRequired();
            builder.Property(e => e.Password).IsRequired();
            builder.Property(e => e.Name);
            builder.Property(e => e.Info);

        }
    }
}
