using MinhaSolutionTransacoesAPI.Enuns;
namespace MinhaSolutionTransacoesAPI.Models;

public class Conta
{
    public int Id { get; set; }
    
    public int Id_Cliente { get; set; }
    
    public TipoConta Id_TipoConta { get; set; }
    
    public DateTime Dt_Criacao { get; set; }
    
    public bool Ativo { get; set; }
    
    public decimal Saldo { get; set; }
}