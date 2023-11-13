using Libreria1.Context;
using Libreria1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Libreria1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly LibrosContext _context;
        public AuthorController(LibrosContext context)
        {
            _context = context;
        }


        //Método GET:  devuelve todos los autores
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listAuthor = await _context.Authors.ToListAsync();
                return Ok(listAuthor);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Método POST : inserta un nuevo autor
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Author author)
        {

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = author.Id }, author);

        }


    }
}