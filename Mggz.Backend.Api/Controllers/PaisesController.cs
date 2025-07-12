using AutoMapper;
using Mggz.AccessData.ContextDB;
using Mggz.Shared.DTOs.Oficiales;
using Mggz.Shared.Entidades.Oficiales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mggz.Backend.Api.Controllers;

[Route("api/Paises")]
[ApiController]
public class PaisesController(DelabDbContext context, IMapper pMaper) : ControllerBase
{
    private readonly DelabDbContext _context = context;
    private readonly IMapper _Maper = pMaper;

    // POST: api/Paises
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<PaisDto>> PostPais(PaisDtoNew pPais)
    {
        try
        {
            var lPaisEntity = _Maper.Map<Pais>(pPais);
            _context.Paises.Add(lPaisEntity);
            await _context.SaveChangesAsync();
            // Map the created entity back to DTO for the response
            var lPaisDto = _Maper.Map<PaisDto>(lPaisEntity);
            return Ok(lPaisDto);
        }
        catch (Exception eErr)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error al crear el país: {eErr.Message}");
        }
    }

    // GET: api/Paises
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PaisDto>>> ObtenerTodos()
    {

        try
        {
            var lPaises = await _context.Paises.ToListAsync();
            var lPaisesDto = _Maper.Map<List<PaisDto>>(lPaises);
            return Ok(lPaisesDto);
        }
        catch (Exception eErr)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los países: {eErr.Message}");
        }
    }

    // GET: api/Paises/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PaisDto>> OtenerPorID(int id)
    {
        try
        {
            var lPais = await _context.Paises.FindAsync(id);

            if (lPais == null)
            {
                return NotFound();
            }

            var lPaisDto = _Maper.Map<PaisDto>(lPais);

            return lPaisDto;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el país por ID.");
        }
    }

    // PUT: api/Paises/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{pId}")]
    public async Task<IActionResult> Actualiza(int pId, PaisDto pPais)
    {
        try
        {
            if (pId != pPais.Id)
            {
                return BadRequest();
            }
            
            if (!Existe(pId))
            {
                return NotFound();
            }
            // Map the DTO to the entity
            var lPais = _Maper.Map<Pais>(pPais);
            _context.Entry(lPais).State = EntityState.Modified;
            // Update the entity in the context
            await _context.SaveChangesAsync();
        }
        catch (Exception eErr)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar el país: {eErr.Message}");
        }

        return NoContent();
    }

    // DELETE: api/Paises/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> BorrarPais(int id)
    {
        try
        {
            var pais = await _context.Paises.FindAsync(id);
            if (pais == null)
            {
                return NotFound();
            }

            _context.Paises.Remove(pais);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception eErr)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar el país: {eErr.Message}");
        }
    }

    private bool Existe(int id)
    {
        return _context.Paises.Any(e => e.PaisId == id);
    }
}
