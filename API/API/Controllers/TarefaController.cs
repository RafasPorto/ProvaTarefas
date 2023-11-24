using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using System.IO.Compression;

namespace API.Controllers;

[Route("api/tarefa")]
[ApiController]
public class TarefaController : ControllerBase
{
    private readonly AppDataContext _context;

    public TarefaController(AppDataContext context) =>
        _context = context;

    // GET: api/tarefa/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        try
        {
            List<Tarefa> tarefas = _context.Tarefas.Include(x => x.Categoria).ToList();
            return Ok(tarefas);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // POST: api/tarefa/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Tarefa tarefa)
    {
        try
        {
            Categoria? categoria = _context.Categorias.Find(tarefa.CategoriaId);
            if (categoria == null)
            {
                return NotFound();
            }
            tarefa.Categoria = categoria;
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            return Created("", tarefa);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // PATCH: api/tarefa/alterar
    [HttpPatch("alterar/{id}")]

    public IActionResult AlterarTarefa([FromRoute] int id, [FromBody] Tarefa tarefa)
    {
        try
        {
            Tarefa? tarefa1 = _context.Tarefas.FirstOrDefault(x => x.TarefaId == id);
            if(tarefa1 == null)
            {
                return NotFound();
            }
            tarefa1.Titulo = tarefa.Titulo;
            tarefa1.Descricao = tarefa.Descricao;
            tarefa1.Status = tarefa.Status;
            tarefa1.CriadoEm = tarefa.CriadoEm;
            tarefa1.Categoria = tarefa.Categoria;
                if(tarefa1 == null)
                {
                    return NotFound();
                }
                _context.Tarefas.Update(tarefa1);
                _context.SaveChanges();
                return Ok(tarefa1);
        } catch(System.Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpGet("naoconcluidas")]

    public IActionResult BuscarNaoConcluidas()
    {
        try
        {
            List<Tarefa>? tarefas = 
            _context.Tarefas.ToList();
            if(tarefas == null)
            {
                return NotFound();
            }
            return Ok(tarefas);
        } catch(Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpGet("concluidas")]
    public IActionResult BuscarConcluidas()
    {
        try
        {
            List<Tarefa>? tarefas = 
            _context.Tarefas.ToList();
            if(tarefas == null)
            {
                return NotFound();
            }
            return Ok(tarefas);
        } catch(Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }


}
