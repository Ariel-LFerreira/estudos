using MinhaSolutionTransacoesAPI.Models;

namespace MinhaSolutionTransacoesAPI.Repositories;

public interface IClienteRepository
{
    //Contratos: QUAIS METODOS TERAM O REPOSITORY
    
    
    //Listar Todos os CLIENTES
    Task<IList<Cliente>> GetAll();
    
    //Adicionar CLIENTE
    Task Add(Cliente cliente);
    
    //Realizar Atualização no cadastro de cliente
    Task Update(Cliente cliente);
    
    //Remover CLIENTE
    Task Delete(int id);
    
    //BUSCAR CLIENTE
    Task<Cliente> GetById(int id);
    
    
   
    
    
    



}