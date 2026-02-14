using MinhaSolutionTransacoesAPI.Models;
namespace MinhaSolutionTransacoesAPI.Repositories;

public interface IContaRepository
{
    //Contratos: QUAIS METODOS TERAM O REPOSITORY
    
    
    //Listar Todos os Contas
    Task<IList<Conta>> GetAll();
    
    //Adicionar Conta
    Task Add(Conta conta);
    
    //Realizar Atualização no cadastro de Conta
    Task Update(Conta conta);
    
    //Remover Conta
    Task Delete(int id);
    
    //BUSCAR Conta
    Task<Conta> GetById(int id);
}