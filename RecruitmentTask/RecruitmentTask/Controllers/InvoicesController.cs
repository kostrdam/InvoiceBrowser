using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentTask.Data;
using RecruitmentTask.Data.Model;
using RecruitmentTask.Dto;

namespace RecruitmentTask.Controllers
{
    /// <summary>Invoices controller</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        /// <summary>Db context</summary>
        private readonly ApplicationDbContext _dbContext; 

        /// <summary>Automapper</summary>
        private readonly IMapper _mapper;

        /// <summary>Invoices controller constructor</summary>
        /// <param name="dbContext">DbContext dependency</param>
        /// <param name="mapper">AutoMapper dependency</param>
        public InvoicesController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        /// <summary>Get all invoices</summary>
        /// <returns>Collection of InvoiceDto</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetAll([FromQuery] DateParamsDto dateParamsDto)
        {
            try
            {
                var invoices = await _dbContext.Invoices
                    .Where(i => i.InvoiceDate.Date >= dateParamsDto.StartDate.Date && i.InvoiceDate.Date <= dateParamsDto.EndDate.Date)
                    .Include(i => i.InvoiceItems)
                    .ThenInclude(i => i.Item)
                    .AsNoTracking()
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
                    .AsNoTracking()
                    .FirstOrDefaultAsync(i => i.Id.Equals(invoiceId));
                return Ok(_mapper.Map<InvoiceDto>(invoice));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while fetching data from database.");
            }
        }

        /// <summary>Creates new invoice</summary>
        /// <param name="InvoiceDto">Invoice dto</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<InvoiceDto>> Create([FromBody] InvoiceDto InvoiceDto)
        {
            //validation
            try
            {
                var newInvoice = _mapper.Map<Invoice>(InvoiceDto);
                newInvoice.InvoiceDate = DateTime.Now;

                var Ids = newInvoice.InvoiceItems.Select(i => i.ItemId).ToList();
                var items = await _dbContext.Items
                    .Where(i => Ids.Contains(i.Id)).ToListAsync();



                //.Join(newInvoice.InvoiceItems,
                //        item => item.Id,
                //        invoiceItem => invoiceItem.ItemId,
                //        (item, invoiceItem) => new { Item = item, Quantity = invoiceItem.Quantity })
                //    .ToListAsync();

                newInvoice.TotalAmount = newInvoice.InvoiceItems.Sum(invoiceItem =>
                    items.First(item => item.Id.Equals(invoiceItem.ItemId)).Price * invoiceItem.Quantity);
                
                foreach (var invoiceItem in newInvoice.InvoiceItems)
                {
                    
                    invoiceItem.Item = items.FirstOrDefault(i => i.Id == invoiceItem.ItemId);
                }



                //newInvoice.TotalAmount = items.Sum(x => (x.Item.Price * x.Quantity));
                var invoice = await _dbContext.Invoices.AddAsync(newInvoice);
                await _dbContext.SaveChangesAsync();
                //return CreatedAtAction(nameof(GetById), new { id = invoice.Entity.Id }, invoice);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while inserting new entity to database.");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTotalPrice()
        {
            try
            {
                var invoices = await _dbContext.Invoices
                    .Include(i => i.InvoiceItems)
                    .ThenInclude(i => i.Item)
                    .ToListAsync();

                foreach (var invoice in invoices)
                {
                    invoice.TotalAmount = invoice.InvoiceItems.Sum(x => x.Item.Price * x.Quantity);
                }

                _dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
