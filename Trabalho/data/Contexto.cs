using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.Models;
using Microsoft.EntityFrameworkCore;

namespace Trabalho.Data
{
    public class AdmContext : DbContext
    {
        public AdmContext(DbContextOptions<AdmContext> options) : base(options){
            
        }
        public DbSet<Adm> Adm { get; set; }
    }
}