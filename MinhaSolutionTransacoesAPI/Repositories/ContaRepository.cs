using Microsoft.EntityFrameworkCore;
using MinhaSolutionTransacoesAPI.Data;
using MinhaSolutionTransacoesAPI.Models;

namespace MinhaSolutionTransacoesAPI.Repositories;

public class ContaRepository : IContaRepository
{
    private readonly AppDbContext _context;    // NÂO ENTENDI ESSA LINHA / DA ONDE +VEM? 

    public ContaRepository(AppDbContext context)
    {
        _context = context;
    }
    
    //RETORNA TODOS OS REGISTROS;
    public async Task<IList<Conta>> GetAll()
    {
        var context = await _context.Contas.ToListAsync();
        return context;
    }
    
    //ADICIONA UM Conta
    public async Task Add(Conta conta)
    {
        await _context.Contas.AddAsync(conta); 
        await _context.SaveChangesAsync();
    }
    
    //REALIZA O UPDATE
    public async Task Update(Conta conta)
    {
        _context.Contas.Update(conta);
        await _context.SaveChangesAsync();
    }
    
    //REALIZA O DELETE PELO ID
    public async Task Delete(int id)
    {
        var contaBuscada = await _context.Contas.FindAsync(id);
        
        if  ((id > 0) && (contaBuscada  is not null))
        {
            _context.Contas.Remove(contaBuscada);
            await _context.SaveChangesAsync();
        }
    }
    
    //BUSCA UM ITEM ESPECIFICO
    public async Task<Conta> GetById(int id)
    {
        var conta = await  _context.Contas.FindAsync(id);
        return conta;
    }
}