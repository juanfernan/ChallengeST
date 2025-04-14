using Microsoft.AspNetCore.Mvc;
using System.Net;
using Application.Categories.Queries;
using Application.Exeptions;
using Application.DTOs;
namespace Api.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ILogger<CategoriesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var result = await Mediator.Send(new GetCategoriesQuery());

                var response = new CategoriesResponseDto
                {
                    Categories = result.ToList()
                };

                return Ok(response);
            }
            catch (GetCategoriesException ex)
            {
                _logger.LogError("Could not get any category.", ex);
                return NoContent();
            }
        }
    }
}
