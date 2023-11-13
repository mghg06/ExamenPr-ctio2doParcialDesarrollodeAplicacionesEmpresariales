using Libreria1.Context;
using Libreria1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Libreria1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LibrosContext _context;
        public BookController(LibrosContext context)
        {
            _context = context;
        }
        

        //Método GET: busqueda de todos los libros
        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            try
            {
                var listBook = await _context.Books.ToListAsync();
                return Ok(listBook);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // Método GET: busqueda de un libro por el Id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            try
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = book.Id }, book);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
