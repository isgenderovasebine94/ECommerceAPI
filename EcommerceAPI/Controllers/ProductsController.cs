using AutoMapper;
using EcommerceAPI.DAL;
using EcommerceAPI.Entities.Dtos.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly EcommerceDbContext _context;
        private readonly IMapper _mapper;
        public ProductsController(EcommerceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<GetProductDto>> GetAllProducts()
        {
            var result = await _context.Products.Include(p=>p.Category).Select(p=>new GetProductDto
            {
                CategoryName=p.Category.Name,
                Desc=p.Desc,
                Name=p.Name,
                CategoryId=p.CategoryId,
                Price=p.Price
            }).ToListAsync();
            return Ok(result);
            
        }
    }
}