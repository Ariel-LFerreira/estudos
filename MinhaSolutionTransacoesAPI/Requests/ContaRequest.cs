using MinhaSolutionTransacoesAPI.Enuns;
namespace MinhaSolutionTransacoesAPI.Requests;

public class ContaRequest
{
    public int Id_Cliente { get; set; }
    
    public TipoConta Id_TipoConta { get; set; }
    
    public bool Ativo { get; set; }
    
    public decimal Saldo { get; set; }
}