using Application.DTOs;
using Application.Exeptions;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.Categories.Queries
{
    public class GetCategoriesQueryHandler(IGet<Category> categoryService, IMapper mapper) : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly IGet<Category> _categoryService = categoryService;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var response = await _categoryService.GetAll();

            if (response == null || !response.Any())
                throw new GetCategoriesException();

            return _mapper.Map<IEnumerable<CategoryDto>>(response.OrderBy(category => category.CategoryName));
        }
    }
}
