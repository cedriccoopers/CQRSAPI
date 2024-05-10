using AutoMapper;
using CQRS.Api.Queries;
using CQRS.DataService.Repositories.Interfaces;
using CQRS.Entities.DbSet;
using CQRS.Entities.Dtos.Requests;
using CQRS.Entities.Dtos.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Api.Controllers
{
    public class DriversController : BaseController
    {

        private readonly IMediator _mediator;
        public DriversController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator) : base(unitOfWork, mapper)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{driverId:Guid}")]
        public async Task<IActionResult> GetDriver(Guid driverId)
        {
            /* Normal Way 
            var driver = await _unitOfWork.Drivers.GetById(driverId);

            if(driver == null)
                return NotFound();

            var result = _mapper.Map<GetDriverResponse>(driver);

            return Ok(result);
            */

            /* MediatR Way*/

            var query = new GetDriverQuery(driverId);

            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            /* Normal Way 
             * 
            var driver = await _unitOfWork.Drivers.All();            

            var result = _mapper.Map<IEnumerable<GetDriverResponse>>(driver);

            return Ok(result);
            */

            /* MediatR Way*/
            var query = new GetAllDriversQuery();

            var results = await _mediator.Send(query);

            return Ok(results);

        }

        [HttpPost("")]
        public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest driver)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Driver>(driver);
            await _unitOfWork.Drivers.Add(result);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetDriver), new { driverId = result.Id }, result);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest driver)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Driver>(driver);
            await _unitOfWork.Drivers.Update(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> DeleteDriver(Guid driverId)
        {
            var driver = await _unitOfWork.Drivers.GetById(driverId);

            if (driver == null)
                return NotFound();

            await _unitOfWork.Drivers.Delete(driverId);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }


    }
}
