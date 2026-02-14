using Microsoft.AspNetCore.Mvc;
using MinhaSolutionTransacoesAPI.Enuns;
using MinhaSolutionTransacoesAPI.Models;
using MinhaSolutionTransacoesAPI.Repositories;
using MinhaSolutionTransacoesAPI.Requests;

namespace MinhaSolutionTransacoesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TransacoesController : ControllerBase
{
    private readonly ITransacoesRepository _transacoesRepository;

    public TransacoesController(ITransacoesRepository transacoesRepository)
    {
        _transacoesRepository = transacoesRepository;
    }
    
    //RETORNAR TODOS OS Transações:
    [HttpGet]
    public async Task<ActionResult<List<Transacoes>>> GetAll()
    {
        var ListTransacoes = await _transacoesRepository.GetAll();
        return Ok(ListTransacoes);
    }

    [HttpGet("/Transacao/{id}")]
    public async Task<ActionResult<Transacoes>> GetById(int id)
    {
        var TransacaoBuscada = await _transacoesRepository.GetById(id);
        
        return Ok(TransacaoBuscada);
    }
    
    [HttpPost("/AddTransacao")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Transacoes>> Post([FromBody] TransacoesRequest transacoesRequest)
    {
        var transacao = new Transacoes(); 
        
        transacao.Dt_Transacao = DateTime.Now;
        transacao.ContaOriegemId = transacoesRequest.ContaOriegemId;
        transacao.ContaDestinoId = transacoesRequest.ContaDestinoId;
        transacao.Valor = transacoesRequest.Valor;
        transacao.Tipo = transacoesRequest.Tipo;
        
        await _transacoesRepository.Add(transacao);
        return Ok(transacao);
    }
    
    //ATUALIZA Transação
    [HttpPut("/UpdateTransacao/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Transacoes>> Put(int id, [FromBody] TransacoesRequest transacoesRequest)
    {
        var transacaoUpdate = await _transacoesRepository.GetById(id);

        if (transacaoUpdate is null)
            return NotFound(); // Retorna status 404 Not Found se o produto não for encontrado
        
        transacaoUpdate.Dt_Transacao = DateTime.Now;
        transacaoUpdate.ContaOriegemId = transacoesRequest.ContaOriegemId;
        transacaoUpdate.ContaDestinoId = transacoesRequest.ContaDestinoId;
        transacaoUpdate.Valor = transacoesRequest.Valor;
        transacaoUpdate.Tipo = transacoesRequest.Tipo;

        await _transacoesRepository.Update(transacaoUpdate);
        
        return Ok(transacaoUpdate);
    }
    
    [HttpDelete("/DeleteTransacao/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var TransacaoExcluir = await _transacoesRepository.GetById(id);

        if (TransacaoExcluir is null)
            return NotFound();
        
        await _transacoesRepository.Delete(id);
        return NoContent();
    }
    
}