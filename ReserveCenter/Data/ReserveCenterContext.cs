using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReserveCenter.Models;

namespace ReserveCenter.Data
{
    public class ReserveCenterContext : DbContext
    {
        public ReserveCenterContext (DbContextOptions<ReserveCenterContext> options)
            : base(options)
        {
        }

        public DbSet<ReserveCenter.Models.LocationSpaces> LocationSpaces { get; set; } = default!;
    }
}
