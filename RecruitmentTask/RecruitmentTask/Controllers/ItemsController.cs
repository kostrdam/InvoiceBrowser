using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentTask.Data;
using RecruitmentTask.Dto;

namespace RecruitmentTask.Controllers
{
    /// <summary>Items controller</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        /// <summary>Db context</summary>
        private readonly ApplicationDbContext _dbContext;

        /// <summary>Automapper</summary>
        private readonly IMapper _mapper;

        /// <summary>Constructor</summary>
        /// <param name="dbContext">Db context dependency</param>
        /// <param name="mapper">Mapper dependency</param>
        public ItemsController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Get all items</summary>
        /// <returns>Collection of ItemDto</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetAll()
        {
            try
            {
                var items = await _dbContext.Items
                    .AsNoTracking()
                    .ToListAsync();
                return Ok(_mapper.Map<List<ItemDto>>(items));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while fetching data from database.");
            }
        }

        /// <summary>Get item by id</summary>
        /// <param name="itemId">Item id</param>
        /// <returns>ItemDto</returns>
        [HttpGet("{itemId}")]
        public async Task<ActionResult<ItemDto>> GetById(int itemId)
        {
            try
            {
                var item = await _dbContext.Items
                    .AsNoTracking()
                    .FirstOrDefaultAsync(i => i.Id.Equals(itemId));
                return Ok(_mapper.Map<ItemDto>(item));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while fetching data from database.");
            }
        }

        /// <summary>Get items for an invoice</summary>
        /// <param name="invoiceId">Invoice id</param>
        /// <returns>Collection of ItemDto</returns>
        [HttpGet("getByInvoice/{invoiceId}")]
        public async Task<ActionResult<ItemDto>> GetByInvoice(int invoiceId)
        {
            try
            {
                var item = await _dbContext.InvoiceItems
                    .Where(ii => ii.InvoiceId.Equals(invoiceId))
                    .Include(ii => ii.Item)
                    .AsNoTracking()
                    .ToListAsync();
                return Ok(_mapper.Map<ItemDto>(item));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while fetching data from database.");
            }
        }
    }
}
