using Microsoft.EntityFrameworkCore;
using Persona2.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persona2.DAL
{
   public  class Contexto :DbContext
    {
       public  DbSet<Personas> Personas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource = Registrodb");
        }

    }
}
