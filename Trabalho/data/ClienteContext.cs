using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.Models;
using Microsoft.EntityFrameworkCore;

namespace Trabalho.data
{
   
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options){
            
        }
        public DbSet<ClienteModel> Cliente { get; set; }
    }
}