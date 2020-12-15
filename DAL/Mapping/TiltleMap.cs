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
    public class TiltleMap : EntityTypeConfiguration<Title>
    {
        public TiltleMap()
        {
            HasKey(i => i.ID);
            Property(i => i.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(n => n.Name).HasMaxLength(50);
            Property(a => a.ModifiedBy).IsOptional();
            Property(a => a.ModifiedOn).IsOptional();
            Property(a => a.IsSport).IsRequired();
        }
    }
}
