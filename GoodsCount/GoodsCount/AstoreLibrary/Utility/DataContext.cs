using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstoreLibrary.Utility
{
    public class DataContext : DbContext 
    {
        
        public DataContext()
            : base("GoodsCount")
        {

        }              

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("DBO");            
        }
    }
}
