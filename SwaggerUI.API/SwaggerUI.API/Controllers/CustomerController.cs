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
    [ApiController]
    [Route("api/[controller]")]

    [Produces("application/json", "application/xml")]
    [ApiExplorerSettings(GroupName = "CustomerApi")]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerService"></param>
        /// <param name="mapper"></param>
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        /// <summary>
        /// GetAllCustomerAsync
        /// </summary>
        /// <returns></returns>
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetAllCustomer", Name = "GetAllCustomer")]
        public async Task<IActionResult> GetAllCustomerAsync()
        {
            try
            {

                var result = await _customerService.GetAllCustomerAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        /// <summary>
        /// Get Customer informat by his/her id
        /// </summary>
        /// <param name="id">The id of customer want to get information</param>
        /// <returns>An ActionResult of type Customer</returns>
        /// <response code="200">Get Customer by customer id</response>

        [ProducesDefaultResponseType]
        [HttpGet("GetCustomer/{id}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            try
            {
                var result = await _customerService.GetCustomerAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<CustomerModel>(result));
            }
            catch (System.Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>

        [HttpPost("AddCustomer", Name = "AddCustomer")]
        public async Task<IActionResult> AddCustomerAsync([FromBody] CustomerModel customer)
        {
            try
            {
                if (customer == null)
                {
                    return NotFound();
                }
                var result = await _customerService.AddAsync(_mapper.Map<CustomerDto>(customer));
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
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost("EditCustomer", Name = "EditCustomer")]
        public async Task<IActionResult> EditCustomerAsync([FromBody] CustomerModel customer)
        {
            try
            {
                if (customer == null)
                {
                    return NotFound();
                }
                var result = await _customerService.UpdateAsync(_mapper.Map<CustomerDto>(customer));
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
        [HttpDelete("DeleteCustomer/{id}", Name = "DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomerAsync(int id)
        {
            try
            {
                var result = await _customerService.DeleteAsync(id);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
