using Microsoft.AspNetCore.Mvc;
using MinhaSolutionTransacoesAPI.Models;
using MinhaSolutionTransacoesAPI.Repositories;
using MinhaSolutionTransacoesAPI.Requests;

namespace MinhaSolutionTransacoesAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteRepository _clienteRepository;
    
    //CONSTRUTOR
    public ClienteController(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }
    
    //CRIANDO TODOS OS ENDPOINTS ABAIXO
    //RETORNAR TODOS OS CLIENTES:
    [HttpGet]
    public async Task<ActionResult<List<Cliente>>> GetAll()
    {
        var ListCliente = await _clienteRepository.GetAll();
        return Ok(ListCliente);
    }

    [HttpGet("/clientes/{id}")]
    public async Task<ActionResult<Cliente>> GetById(int id)
    {
        var ClienteBuscado = await _clienteRepository.GetById(id);
        
        return Ok(ClienteBuscado);
    }

    [HttpPost("/AddCliente")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Cliente>> Post([FromBody] ClienteRequest clienteRequest)
    {
        var cliente = new Cliente();

        cliente.Nome = clienteRequest.Nome;
        
        await _clienteRepository.Add(cliente);
        return Ok(cliente);
    }
    
    //ATUALIZA OS CLIENTES.
    [HttpPut("/UpdateCliente/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Cliente>> Put(int id, [FromBody] ClienteRequest clienteRequest)
    {
        var clienteUpdate = await _clienteRepository.GetById(id);

        if (clienteUpdate is null)
            return NotFound(); 
        
        clienteUpdate.Nome = clienteRequest.Nome;
        
        await _clienteRepository.Update(clienteUpdate);
        return Ok(clienteUpdate);
    }
    
    [HttpDelete("/DeleteCliente/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var clienteExcluir = await _clienteRepository.GetById(id);

        if (clienteExcluir is null)
            return NotFound();
        
        await _clienteRepository.Delete(id);
        return NoContent();
    }
    
    
    
    
    
}