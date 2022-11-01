using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentTask.Data;
using RecruitmentTask.Dto;

namespace RecruitmentTask.Controllers
{
    /// <summary>Invoices controller</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext; 
        private readonly IMapper _mapper;

        /// <summary>Invoices controller constructor</summary>
        /// <param name="dbContext">DbContext dependency</param>
        /// <param name="mapper">AutoMapper dependency</param>
        public InvoiceController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        /// <summary>Get all invoices</summary>
        /// <returns>Collection of InvoiceDto</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetAll()
        {
            try
            {
                var invoices = await _dbContext.Invoices
                    .Include(i => i.Items)
                    .ToListAsync();
                return Ok(_mapper.Map<List<InvoiceDto>>(invoices));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while fetching data from database.");
            }
        }

        /// <summary>Get invoice by Id</summary>
        /// <param name="invoiceId">Invoice id</param>
        /// <returns>InvoiceDto</returns>
        [HttpGet("{invoiceId}")]
        public async Task<ActionResult<InvoiceDto>> GetById(int invoiceId)
        {
            try
            {
                var invoice = await _dbContext.Invoices
                    .Include(i => i.Items)
                    .FirstOrDefaultAsync(i => i.Id == invoiceId);
                return Ok(_mapper.Map<InvoiceDto>(invoice));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while fetching data from database.");
            }
        }
    }
}
