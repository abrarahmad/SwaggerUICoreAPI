using ApplicationService.Interfaces;
using AutoMapper;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using SwaggerUI.API.Models;
using System.Net;
using System.Threading.Tasks;

namespace SwaggerUI.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    [ApiExplorerSettings(GroupName = "SupplierApi")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierService"></param>
        /// <param name="mapper"></param>
        public SupplierController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllSupplier", Name = "GetAllSupplier")]
        public async Task<IActionResult> GetAllSupplierAsync()
        {
            try
            {

                var result = await _supplierService.GetAllSupplierAsync();
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        /// <summary>
        /// Get Supplier in format by his/her id
        /// </summary>
        /// <param name="id">The id of supplier want to get information</param>
        /// <returns>An ActionResult of type Supplier</returns>
        /// <response code="200">Get Supplier by Supplier id</response>

        [ProducesDefaultResponseType]
        [HttpGet(" GetSupplier/{id}", Name = " GetSupplier")]
        public async Task<IActionResult> GetSupplierAsync(int id)
        {
            try
            {
                var result = await _supplierService.GetSupplierAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<SupplierModel>(result));
            }
            catch (System.Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        [HttpPost("AddSupplier", Name = "AddSupplier")]
        public async Task<IActionResult> AddSupplierAsync([FromBody] SupplierModel supplier)
        {
            try
            {
                if (supplier == null)
                {
                    return NotFound();
                }
                var result = await _supplierService.AddAsync(_mapper.Map<SupplierDto>(supplier));
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        [HttpPost("EditSupplier", Name = "EditSupplier")]
        public async Task<IActionResult> EditSupplierAsync([FromBody] SupplierModel supplier)
        {
            try
            {
                if (supplier == null)
                {
                    return NotFound();
                }
                var result = await _supplierService.UpdateAsync(_mapper.Map<SupplierDto>(supplier));
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteSupplier/{id}", Name = "DeleteSupplier")]
        public async Task<IActionResult> DeleteSupplierAsync(int id)
        {
            try
            {
                var result = await _supplierService.DeleteAsync(id);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}