using api.DTOs;
using api.Models;
using api.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IInventoryRepository _inventoryRepository;

        public ProductController(IProductRepository productRepository, IInventoryRepository inventoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _inventoryRepository = inventoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            var products = await _productRepository.GetAll();
            var productsDTO = _mapper.Map<List<ProductDTO>>(products);
            return Ok(productsDTO);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product != null)
            {
                var productDTO = _mapper.Map<ProductDTO>(product);
                return Ok(productDTO);

            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Create(ProductCreateDTO productCreateDTO)
        {


            var product = _mapper.Map<Product>(productCreateDTO);
            await _productRepository.Create(product);
            var productDTO = _mapper.Map<ProductDTO>(product);


            return CreatedAtAction(nameof(GetById), new { Id = product.Id }, productDTO);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductUpdateDTO productUpdateDTO)
        {
            var product = await _productRepository.GetById(id);
            if (product != null)
            {
                var product_ = _mapper.Map(productUpdateDTO, product);
                await _productRepository.Update(product_);
                return NoContent();

            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product != null)
            {
                await _productRepository.Delete(id);
                return NoContent();

            }
            return NotFound();
        }



    }

}