using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiContaVirtual.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }

        public DbSet<Conta> Conta { get; set; }
        public DbSet<Movimentacao> Movimentacao { get; set; }
        public DbSet<TipoMovimentacao> TipoMovimentacao { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Carregando Conta padrão
            modelBuilder.Entity<Conta>().HasData(new Conta { IdConta = 1, NomeCliente = "Renato Fiorezze Silva", Saldo = 0 });

            //Carregando tipos de movimentação padrão
            modelBuilder.Entity<TipoMovimentacao>().HasData(new TipoMovimentacao { IdTipoMovimentacao = 1, Descricao = "Crédito" });
            modelBuilder.Entity<TipoMovimentacao>().HasData(new TipoMovimentacao { IdTipoMovimentacao = 2, Descricao = "Débito" });

        }
    }
}
