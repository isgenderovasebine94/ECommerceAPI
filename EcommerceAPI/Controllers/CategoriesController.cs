using AutoMapper;
using EcommerceAPI.DAL;
using EcommerceAPI.Entities;
using EcommerceAPI.Entities.Dtos.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly EcommerceDbContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(EcommerceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        [HttpGet]
        [Authorize(Roles ="Admin,User")]
        public async Task<ActionResult<GetCategoryDto>> GetAllCategories()
        {
            
            return Ok (_mapper.Map<List<GetCategoryDto>>(await _context.Categories.ToListAsync()));
            
        }

        
        [HttpGet]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            return Ok(_mapper.Map<GetCategoryDto>(result));
        }
        [HttpDelete]
        public async Task<IActionResult>DeleteCategory(int id)
        {
            var deleted = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            _context.Categories.Remove(deleted);
            await _context.SaveChangesAsync();
            return Ok(deleted);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
        {
         
            await _context.Categories.AddAsync(_mapper.Map<Category>(dto));
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(int id,UpdateCategoryDto update)
        {
            var updated = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            _context.Categories.Update(_mapper.Map(update,updated));
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
