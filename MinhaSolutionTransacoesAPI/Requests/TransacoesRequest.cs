using MinhaSolutionTransacoesAPI.Enuns;

namespace MinhaSolutionTransacoesAPI.Requests;

public class TransacoesRequest
{
    public int ContaOriegemId { get; set; }
    
    public int ContaDestinoId { get; set; }
    
    public decimal Valor { get; set; }
    
    public TipoTransacao Tipo { get; set; }
}