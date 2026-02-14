using Microsoft.EntityFrameworkCore;
using MinhaSolutionTransacoesAPI.Data;
using MinhaSolutionTransacoesAPI.Models;

namespace MinhaSolutionTransacoesAPI.Repositories;

public class TransacoesRepository : ITransacoesRepository
{
    private readonly AppDbContext _context;    // NÂO ENTENDI ESSA LINHA / DA ONDE +VEM? 

    public TransacoesRepository(AppDbContext context)
    {
        _context = context;
    }
    
    //RETORNA TODOS OS REGISTROS;
    public async Task<IList<Transacoes>> GetAll()
    {
        var context = await _context.Transacoes.ToListAsync();
        return context;
    }
    
    //ADICIONA UM Transação
    public async Task Add(Transacoes transacoes)
    {
        await _context.Transacoes.AddAsync(transacoes); 
        await _context.SaveChangesAsync();
    }
    
    //REALIZA O UPDATE
    public async Task Update(Transacoes transacoes)
    {
        _context.Transacoes.Update(transacoes);
        await _context.SaveChangesAsync();
    }
    
    //REALIZA O DELETE PELO ID
    public async Task Delete(int id)
    {
        var TransacaoBuscada = await _context.Transacoes.FindAsync(id);
        
        if  ((id > 0) && (TransacaoBuscada  is not null))
        {
            _context.Transacoes.Remove(TransacaoBuscada);
            await _context.SaveChangesAsync();
        }
    }
    
    //BUSCA UM ITEM ESPECIFICO
    public async Task<Transacoes> GetById(int id)
    {
        var transacao = await  _context.Transacoes.FindAsync(id);
        return transacao;
    }
}