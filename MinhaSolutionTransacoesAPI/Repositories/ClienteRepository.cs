using Microsoft.EntityFrameworkCore;
using MinhaSolutionTransacoesAPI.Data;
using MinhaSolutionTransacoesAPI.Models;

namespace MinhaSolutionTransacoesAPI.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }
    
    //RETORNA TODOS OS REGISTROS;
    public async Task<IList<Cliente>> GetAll()
    {
        var context = await _context.Clientes.ToListAsync();
        return context;
    }
    
    //ADICIONA UM CLIENTE.
    public async Task Add(Cliente cliente)
    {
        await _context.Clientes.AddAsync(cliente); 
        await _context.SaveChangesAsync();
    }
    
    //REALIZA O UPDATE
    public async Task Update(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
    }
    
    //REALIZA O DELETE PELO ID
    public async Task Delete(int id)
    {
        var clienteBuscado = await _context.Clientes.FindAsync(id);
        
        if  ((id > 0) && (clienteBuscado  is not null))
        {
             _context.Clientes.Remove(clienteBuscado);
            await _context.SaveChangesAsync();
        }
    }
    
    //BUSCA UM ITEM ESPECIFICO
    public async Task<Cliente> GetById(int id)
    {
        var cliente = await  _context.Clientes.FindAsync(id);
        return cliente;
    }

}