using AutoMapper;
using EcommerceAPI.DAL;
using EcommerceAPI.Entities;
using EcommerceAPI.Entities.Dtos.Categories;
using EcommerceAPI.Entities.Dtos.Countries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountriesController:ControllerBase
    {
        private readonly EcommerceDbContext _context;
        private readonly IMapper _mapper;
        public CountriesController(EcommerceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            return Ok(await _context.Countries.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetCountryById(int id)
        {
            return  Ok(await _context.Countries.FirstOrDefaultAsync(c=>c.Id==id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateCountry(CreateCountryDto create)
        {
           var result = _mapper.Map<Country>(create);
            await _context.Countries.AddAsync(result);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var deleted = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
             _context.Countries.Remove(deleted);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCountry(int id,UpdateCategoryDto update)
        {
            var updated = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);

            var result = _mapper.Map(update, updated);
            _context.Countries.Update(updated);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
