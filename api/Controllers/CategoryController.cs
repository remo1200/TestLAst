using api.DTOs;
using api.Models;
using api.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAll()
        {
            var categorys = await _categoryRepository.GetAll();
            var categorysDTO = _mapper.Map<List<CategoryDTO>>(categorys);
            return Ok(categorysDTO);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetById(int id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category != null)
            {
                var categoryDTO = _mapper.Map<CategoryDTO>(category);
                return Ok(categoryDTO);

            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Create(CategoryCreateDTO categoryCreateDTO)
        {


            var category = _mapper.Map<Category>(categoryCreateDTO);
            await _categoryRepository.Create(category);
            var categoryDTO = _mapper.Map<CategoryDTO>(category);

            return CreatedAtAction(nameof(GetById), new { Id = category.Id }, categoryDTO);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryUpdateDTO categoryUpdateDTO)
        {
            var category = await _categoryRepository.GetById(id);
            if (category != null)
            {
                var category_ = _mapper.Map(categoryUpdateDTO, category);
                await _categoryRepository.Update(category_);
                return NoContent();

            }
            return NotFound();
        }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     var category = await _categoryRepository.GetById(id);
        //     if (category != null)
        //     {
        //         await _categoryRepository.Delete(id);
        //         return NoContent();

        //     }
        //     return NotFound();
        // }



    }

}