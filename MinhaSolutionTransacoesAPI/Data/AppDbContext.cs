using Microsoft.EntityFrameworkCore;
using MinhaSolutionTransacoesAPI.Models;
namespace MinhaSolutionTransacoesAPI.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        //Ainda NADA AQUI NO CONSTRUTOR
    }
    
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Conta> Contas => Set<Conta>();
    public DbSet<Transacoes> Transacoes => Set<Transacoes>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("cliente");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Nome).HasColumnName("nome");
        });
        
        modelBuilder.Entity<Conta>(entity =>
        {
            entity.ToTable("conta");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Id_Cliente).HasColumnName("id_Cliente");
            entity.Property(e => e.Id_TipoConta).HasColumnName("id_TipoConta");
            entity.Property(e => e.Dt_Criacao).HasColumnName("dt_Criacao");
            entity.Property(e => e.Ativo).HasColumnName("ativo");
            entity.Property(e =>e.Saldo).HasColumnName("saldo");
            
        });
        
        modelBuilder.Entity<Transacoes>(entity =>
        {
            entity.ToTable("transacoes");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dt_Transacao).HasColumnName("dt_Transacao");
            entity.Property(e => e.ContaOriegemId).HasColumnName("contaOriegemId");
            entity.Property(e => e.ContaDestinoId).HasColumnName("contaDestinoId");
            entity.Property(e => e.Valor).HasColumnName("valor");
            entity.Property(e => e.Tipo).HasColumnName("tipo_transferencia");
            
        });
    }
}