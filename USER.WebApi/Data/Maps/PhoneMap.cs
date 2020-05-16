using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USER.WebApi.Domain.Models;

namespace USER.WebApi.Data.Maps
{
    public class PhoneMap : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            #region Relationship
            builder.HasOne(x => x.User).WithMany(x => x.Phones).HasForeignKey(x => x.UserId);
            #endregion
        }
    }
}
