using Mayracrud.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mayracrud.Data
{
    public class ApplicationDbContext : IdentityDbContext<AplicationUsuario,UsuarioRol,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {    
        }
        public virtual DbSet<Persona> Persona { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Persona>(may =>
            {
                may.HasKey(m => m.Codigo);
                may.Property(m => m.Nombre).HasMaxLength(100).IsUnicode(false);
                may.Property(m => m.Apellido).HasMaxLength(100).IsUnicode(false);
                may.Property(m => m.Direccion).HasMaxLength(250).IsUnicode(false);
                may.Property(m => m.Estado).IsUnicode(false);



                may.HasKey(m => m.Codigo);

            });
        }
    }
}
