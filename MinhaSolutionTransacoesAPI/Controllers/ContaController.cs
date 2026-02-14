using Microsoft.AspNetCore.Mvc;
using MinhaSolutionTransacoesAPI.Enuns;
using MinhaSolutionTransacoesAPI.Models;
using MinhaSolutionTransacoesAPI.Repositories;
using MinhaSolutionTransacoesAPI.Requests;

namespace MinhaSolutionTransacoesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ContaController: ControllerBase
{
    private readonly IContaRepository _contaRepository;
    
    public ContaController(IContaRepository contaRepository)
    {
        _contaRepository = contaRepository;
    }
    
    //RETORNAR TODOS OS Contas:
    [HttpGet]
    public async Task<ActionResult<List<Conta>>> GetAll()
    {
        var ListConta = await _contaRepository.GetAll();
        return Ok(ListConta);
    }

    [HttpGet("/Contas/{id}")]
    public async Task<ActionResult<Conta>> GetById(int id)
    {
        var ContaBuscada = await _contaRepository.GetById(id);
        
        return Ok(ContaBuscada);
    }
    
    //ADICIONAR CONTA
    [HttpPost("/AddConta")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Conta>> Post([FromBody] ContaRequest contaRequest)
    {
        var conta = new Conta();
        
        conta.Id_Cliente = contaRequest.Id_Cliente;
        conta.Id_TipoConta = contaRequest.Id_TipoConta;
        conta.Dt_Criacao = DateTime.Now;
        conta.Ativo = contaRequest.Ativo;
        conta.Saldo = contaRequest.Saldo;
        
        await _contaRepository.Add(conta);
        return Ok(conta);
    }
    
    //ATUALIZA OS CONTAS
    [HttpPut("/UpdateConta/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Conta>> Put(int id, [FromBody] ContaRequest contaRequest)
    {
        var contaUpdate = await _contaRepository.GetById(id);

        if (contaUpdate is null)
            return NotFound(); // Retorna status 404 Not Found se o produto não for encontrado
        
        contaUpdate.Id_Cliente = contaRequest.Id_Cliente;
        contaUpdate.Id_TipoConta = contaRequest.Id_TipoConta;
        contaUpdate.Dt_Criacao = DateTime.Now;
        contaUpdate.Ativo = contaRequest.Ativo;
        contaUpdate.Saldo = contaRequest.Saldo;
        
        await _contaRepository.Update(contaUpdate);
        
        return Ok(contaUpdate);
    }
    
    [HttpDelete("/DeleteConta/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var contaExcluir = await _contaRepository.GetById(id);

        if (contaExcluir is null)
            return NotFound();
        
        await _contaRepository.Delete(id);
        return NoContent();
    }
}