using Microsoft.AspNetCore.Mvc;
using petrovsanyaKT_42_20.Database;
using petrovsanyaKT_42_20.Models;
using petrovsanyaKT_42_20.Interfaces;
using petrovsanyaKT_42_20.Filters.PrepodDegreeFilters;
using Microsoft.EntityFrameworkCore;


namespace petrovsanyaKT_42_20.Controllers
{
    [ApiController]
    [Route("controller-degree")]

    public class DegreesController : Controller
    {
        private readonly ILogger<DegreesController> _logger;
        private readonly IDegreesService _degreesService;
        private PrepodDbContext _context;

        public DegreesController(ILogger<DegreesController> logger, IDegreesService degreeService, PrepodDbContext context)
        {
            _logger = logger;
            _degreesService = degreeService;
            _context = context;
        }

        [HttpPost("Получение препода по степени", Name = "GetPrepodsByDegree")]
        public async Task<IActionResult> GetPrepodsByDegreeAsync(PrepodDegreeFilter filter, CancellationToken cancellationToken = default)
        {
            var degrees = await _degreesService.GetPrepodsByDegreeAsync(filter, cancellationToken);

            return Ok(degrees);
        }

        [HttpPost("Добавление степени", Name = "AddDegree")]
        public IActionResult CreateDegree([FromBody] Degree degree)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Degree.Add(degree);
            _context.SaveChanges();
            return Ok(degree);
        }

        [HttpPut("Изменение степени")]
        public IActionResult UpdateDegree(string name_degree, [FromBody] Degree updatedDegree)
        {
            var existingDegree = _context.Degree.FirstOrDefault(g => g.DegreeName == name_degree);

            if (existingDegree == null)
            {
                return NotFound();
            }

            existingDegree.DegreeName = updatedDegree.DegreeName;
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("Удаление степени")]
        public IActionResult DeleteDegree(string name_degree, Degree updatedDegree)
        {
            var existingDegree = _context.Degree.FirstOrDefault(g => g.DegreeName == name_degree);

            if (existingDegree == null)
            {
                return NotFound();
            }
            _context.Degree.Remove(existingDegree);
            _context.SaveChanges();

            return Ok();
        }
    }
}
