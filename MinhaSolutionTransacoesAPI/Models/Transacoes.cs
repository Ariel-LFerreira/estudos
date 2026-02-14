using MinhaSolutionTransacoesAPI.Enuns;
namespace MinhaSolutionTransacoesAPI.Models;

public class Transacoes
{
    public int Id { get; set; }
    
    public DateTime Dt_Transacao { get; set; }
    
    public int ContaOriegemId { get; set; }
    
    public int ContaDestinoId { get; set; }
    
    public decimal Valor { get; set; }
    
    public TipoTransacao Tipo { get; set; }
}