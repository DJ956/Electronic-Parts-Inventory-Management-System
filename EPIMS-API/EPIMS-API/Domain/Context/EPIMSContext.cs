using EPIMS_API.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Context
{
    public class EPIMSContext : DbContext
    {
        public DbSet<ProductData> ProductDatas { get; set; }


        public EPIMSContext(DbContextOptions<EPIMSContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductData>().ToTable("Product");
        }
    }
}
