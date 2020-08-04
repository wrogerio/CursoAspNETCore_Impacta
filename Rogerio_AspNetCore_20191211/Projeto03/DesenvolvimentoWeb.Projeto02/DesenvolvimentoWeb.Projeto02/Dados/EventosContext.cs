using DesenvolvimentoWeb.Projeto02.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesenvolvimentoWeb.Projeto02.Dados
{
    public class EventosContext: DbContext
    {
        //Construtor
        public EventosContext(DbContextOptions<EventosContext> opcoes) : base(opcoes)
        {

        }

        //DbSet
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Participante> Participantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>().ToTable("TBEvento");

            modelBuilder.Entity<Evento>()
                .Property(x => x.Descricao)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Evento>()
                .Property(x => x.Local)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Evento>()
                .Property(x => x.Data)
                .IsRequired();

            modelBuilder.Entity<Evento>()
                .Property(x => x.Preco)
                .IsRequired();

            modelBuilder.Entity<Evento>()
                .Property(x => x.Preco)
                .HasMaxLength(30);

            modelBuilder.Entity<Participante>().ToTable("TBParticipantes");

            modelBuilder.Entity<Participante>()
                .Property(x => x.Cpf)
                .HasMaxLength(11)
                .IsRequired();

            modelBuilder.Entity<Participante>()
                .Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Participante>()
                .Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Participante>()
                .Property(x => x.DataNascimento)
                .IsRequired();

            modelBuilder.Entity<Evento>()
                .Property(x => x.Preco)
                .HasMaxLength(30);
        }

    }
}
