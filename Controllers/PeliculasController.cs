using backendnet.Data;
using backendnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace backendnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController(IdentityContext context) : Controller
    {
        // GET: api/peliculas?s=titulo
        [HttpGet]
        [Authorize(Roles = "Usuario,Administrador")]
        public async Task<ActionResult<IEnumerable<Pelicula>>> GetPeliculas(string? s)
        {
            if (string.IsNullOrEmpty(s))
                return await context.Pelicula.Include(i => i.Categorias).AsNoTracking().ToListAsync();
            
            return await context.Pelicula.Include(i => i.Categorias).Where(c => c.Titulo.Contains(s)).AsNoTracking().ToArrayAsync();
        }

        // GET: api/peliculas/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Usuario,Administrador")]
        public async Task<ActionResult<Pelicula>> GetPelicula(int id)
        {
            var pelicula = await context.Pelicula.Include(i => i.Categorias).AsNoTracking().FirstOrDefaultAsync(s => s.PeliculaId == id);
            if (pelicula == null) return NotFound();

            return pelicula;
        }

        // POST: api/peliculas
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<Pelicula>> PostPelicula(PeliculaDTO peliculaDTO)
        {
            Pelicula pelicula = new()
            {
                Titulo = peliculaDTO.Titulo,
                Sinopsis = peliculaDTO.Sinopsis,
                Anio = peliculaDTO.Anio,
                Poster = peliculaDTO.Poster,
                Categorias = []
            };

            context.Pelicula.Add(pelicula);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPelicula), new { id = pelicula.PeliculaId}, pelicula);
        }

        // PUT: api/peliculas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPelicula(int id, PeliculaDTO peliculaDTO)
        {
            if (id != peliculaDTO.PeliculaId) return BadRequest();

            var pelicula = await context.Pelicula.FirstOrDefaultAsync(s => s.PeliculaId == id);
            if (pelicula == null) return NotFound();

            pelicula.Titulo = peliculaDTO.Titulo;
            pelicula.Sinopsis = peliculaDTO.Sinopsis;
            pelicula.Anio = peliculaDTO.Anio;
            pelicula.Poster = peliculaDTO.Poster;
            await context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/peliculas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePelicula(int id)
        {
            var pelicula = await context.Pelicula.FindAsync(id);
            if (pelicula == null) return NotFound();

            context.Pelicula.Remove(pelicula);
            await context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/peliculas/5/categoria
        [HttpPost("{id}/categoria")]
        public async Task<IActionResult> PostCategoriaPelicula(int id, AsignaCategoriaDTO itemToAdd)
        {
            Categoria? categoria = await context.Categoria.FindAsync(itemToAdd.CategoriaId);
            if(categoria == null) return NotFound();

            var pelicula = await context.Pelicula.Include(i => i.Categorias).FirstOrDefaultAsync(s => s.PeliculaId == id);
            if (pelicula == null) return NotFound();

            if(pelicula?.Categorias?.FirstOrDefault(categoria) != null)
            {
                pelicula.Categorias.Add(categoria);
                await context.SaveChangesAsync();
            }

            return NoContent();
        }

        // DELETE: api/peliculas/5/categoria/1
        [HttpDelete("{id}/categoria/{categoriaid}")]
        public async Task<IActionResult> DeleteCategoriaPelicula(int id, int categoriaid)
        {
            Categoria? categoria = await context.Categoria.FindAsync(categoriaid);
            if(categoria == null) return NotFound();

            var pelicula = await context.Pelicula.Include(i => i.Categorias).FirstOrDefaultAsync(s => s.PeliculaId == id);
            if (pelicula == null) return NotFound();

            if(pelicula?.Categorias?.FirstOrDefault(categoria) != null)
            {
                pelicula.Categorias.Remove(categoria);
                await context.SaveChangesAsync();
            }

            return NoContent();
        }
    }
}
