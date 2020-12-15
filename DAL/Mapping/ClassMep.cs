using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess.Mapping
{
    public class ClassMep : EntityTypeConfiguration<Class>
    {
        public ClassMep()
        {
            HasKey(i => i.ID);
            Property(i => i.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(d => d.Days).IsRequired().HasMaxLength(15);
            Property(h => h.Hours).HasMaxLength(20);

        }
    }
}
