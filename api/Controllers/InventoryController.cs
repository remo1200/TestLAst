using api.DTOs;
using api.Models;
using api.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly SqlDbContext _sqlDbContext;

        public InventoryController(SqlDbContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;

        }

        [HttpGet("{QuantityId}")]
        public async Task<ActionResult<IEnumerable<InventoryByCategoryId>>> GetAll(int QuantityId)
        {

            return Ok(await _sqlDbContext.SPGetInventoryByCategoryId(QuantityId));
        }



    }
}

