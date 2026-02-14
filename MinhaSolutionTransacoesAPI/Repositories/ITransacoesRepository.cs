using MinhaSolutionTransacoesAPI.Models;
namespace MinhaSolutionTransacoesAPI.Repositories;

public interface ITransacoesRepository
{
    //Contratos: QUAIS METODOS TERAM O REPOSITORY
    
    
    //Listar Todos os Transações
    Task<IList<Transacoes>> GetAll();
    
    //Adicionar Transações
    Task Add(Transacoes transacoes);
    
    //Realizar Atualização no cadastro de Transações
    Task Update(Transacoes transacoes);
    
    //Remover Transações
    Task Delete(int id);
    
    //BUSCAR Transações
    Task<Transacoes> GetById(int id);
}