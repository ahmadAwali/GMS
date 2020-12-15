using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapping
{
    public class MemberMap : EntityTypeConfiguration<Member>
    {
        public MemberMap()
        {
            HasKey(i => i.ID);
            Property(i => i.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(n => n.Name1).HasMaxLength(50).IsRequired();
            Property(n => n.Name2).HasMaxLength(50).IsRequired();
            Property(n => n.Name3).HasMaxLength(50).IsRequired();
            Property(n => n.Name4).HasMaxLength(50).IsRequired();
            Property(n => n.NationalID).HasMaxLength(50).IsRequired();
            Property(n => n.MartialState).HasMaxLength(10).IsRequired();
            Property(n => n.Address).HasMaxLength(100).IsRequired();
            Property(n => n.PhoneNo1).HasMaxLength(15).IsRequired();
            Property(n => n.PhoneNo2).HasMaxLength(15).IsOptional();
            Property(n => n.Email).HasMaxLength(100).IsOptional();
            Property(n => n.Image).IsOptional();
            Property(n => n.IdentityImage).IsOptional();
        }
    }
}
