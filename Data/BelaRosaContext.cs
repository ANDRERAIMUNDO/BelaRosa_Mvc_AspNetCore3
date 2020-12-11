using BelaRosa_MVC_AspNetCore3_4.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace BelaRosa_MVC_AspNetCore3_4.Data
{
    public class BelaRosaContext :DbContext
    {
        
        public BelaRosaContext (DbContextOptions<BelaRosaContext> options) 
        : base(options)
        {

        }
       public DbSet<Colaborador> Colaborador{get;set;}
    }
}