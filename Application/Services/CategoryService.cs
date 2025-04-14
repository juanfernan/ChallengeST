using Application.Common.Interfaces;
using Application.Exeptions;
using Application.Repositories;
using Application.Services.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class CategoryService : IGet<Category>
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(
            IGenericRepository<Category> categoryRepository,
            IUnitOfWork unitOfWork,
            ILogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            _logger.LogInformation("Get all categories from db");
            IEnumerable<Category> categories = await _categoryRepository.GetAllAsync(includeProperties: "Items");

            if (categories == null || categories.ToList().Count == 0)
                throw new GetCategoriesException();

            return categories;
        }
    }
}
