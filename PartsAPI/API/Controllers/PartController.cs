using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PartsAPI.API.Dtos;
using PartsAPI.Core.Entities;
using PartsAPI.Core.Interfaces;
using PartsAPI.Infrastructure.Data;
using System.Globalization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PartsAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPartRepository _partRepository;

        public PartController(IMapper mapper, IPartRepository partRepository)
        {
            _mapper = mapper;
            _partRepository = partRepository;
        }

        // GET: api/<PartController>
        [HttpGet("GetParts")]
        public async Task<IActionResult> GetParts()
        {
            var parts = await _partRepository.GetAllAsync();
            var partsDto = new List<PartDto>();

            foreach (var part in parts)
                partsDto.Add(_mapper.Map<PartDto>(part));
            return Ok(partsDto);
        }

        // GET api/<PartController>/5
        [HttpGet("GetPart")]
        public async Task<IActionResult> GetPart(string Id)
        {
           var part = await _partRepository.GetByIdAsync(Id);

            if (part == null) return NotFound();

            return Ok(part);
        }

        // POST api/<PartController>
        [HttpPost("CreatePart")]
        public async Task<IActionResult> CreatePart([FromBody] Part part)
        {
            if (part == null)
                return BadRequest(ModelState);

            if (!await _partRepository.CreateAsync(part))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the Part {part.PartNumber}");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return Ok();
        }

        // PUT api/<PartController>/5
        [HttpPut("UpdatePart")]
        public async Task<IActionResult> UpdatePart(string Id, [FromBody] Part part)
        {
            if (Id != part.PartNumber) return BadRequest();
            if(!ModelState.IsValid) return BadRequest(ModelState);

            await _partRepository.UpdateAsync(part);
            return Ok();
        }

        // DELETE api/<PartController>/5
        [HttpDelete("DeletePart")]
        public async Task<IActionResult> DeletePart(string partNumber)
        {
            if (!await _partRepository.Exists(partNumber))
                return NotFound();

            if (!await this._partRepository.DeleteAsync(partNumber))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the Part {partNumber}");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            return Ok();
        }
    }
}
