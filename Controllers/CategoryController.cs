using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testeef.Data;
using testeef.Models;

namespace testeef.Controllers
{
    [ApiController]
    // Como não definimos nenhuma rota em Program.cs o programa vi se mapear pela rota do controller
    [Route("v1/categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet] // Se não colocar get vai ser get por padrão
        [Route("")] // Rota vazia para seguir o da classe
        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
        {
            var categories = await context.Categories.ToListAsync();
            return categories;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> Post(
            [FromServices] DataContext context,
            [FromBody] Category model)
        {
            if (ModelState.IsValid) // Se todos os parâmetros da categoria estão corretos
            {
                context.Categories.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}