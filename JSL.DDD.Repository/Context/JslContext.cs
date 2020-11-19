using JSL.DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JSL.DDD.Repository.Context
{
    public class JslContext : DbContext
    {


            public JslContext(DbContextOptions<JslContext> options) : base(options)
            {

            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

  
            }

        public DbSet<Motorista> Motorista { get; set; }

        public DbSet<Caminhao> Caminhao { get; set; }

        public DbSet<Endereco> Endereco { get; set; }


    }
}

