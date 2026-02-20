using Hms.Application.Dtos;
using Hms.Application.Interfaces;
using Hms.Domain.Common;
using Hms.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hms.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchServices _services;
        public BranchController(IBranchServices services)
        {
            _services = services;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<Response>> GetAllAsync()
        {
            var branches = await _services.GetAllAsync();

            if (branches == null || !branches.Any())
            {
                return NotFound(new Response
                {
                    Code = 404,
                    Success = false,
                    Message = "Branches not  Found.",
                    Data = null,
                    Pagination = null,

                });
            }

            return Ok(new Response
            {
                Code = 200,
                Success = true,
                Message = "All Branches Fetched Sucessfully.",
                Data = new {resultSet = branches },
                Pagination = null

            });
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Response>> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new Response
                {
                    Code =400,
                    Success = false,
                    Message = "Invalid Brnach Id.",
                    Data = null,
                    Pagination = null

                });
            }
           var branch = await _services.GetByIdAsync(id);

            if (branch == null)
            {
                return NotFound(new Response
                {
                    Code = 404,
                    Success = false,
                    Message = "Branch not Found.",
                    Data = null,
                    Pagination = null

                });
            }
            return Ok(new Response
            {
                Code = 200,
                Success = true,
                Message = "Branch Fetched Sucessfully.",
                Data = new { resultSet = branch },
                Pagination = null

            });
        }

        [HttpPost]
        public async Task<ActionResult<Response>> CreateAsync(BranchDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response
                {
                    Code = 400,
                    Success = false,
                    Message = "Bad Request",
                    Data = dto,
                    Pagination = null
                });               
            }
            var branch = await _services.CreateAsync(dto);
            dto.BranchID = branch.BranchID;

            return StatusCode(StatusCodes.Status201Created ,new Response
            {
                Code = 201,
                Success = true,
                Message = "Branch Created successfully.",
                Data = new { resultSet = dto },
                Pagination = null
            });

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Response>> UpdateAsync([FromBody] BranchDto dto)
        {
            var branch = await _services.UpdateAsync(dto);

            if(branch == null)
            {
                return NotFound(new Response
                {
                    Code = 404,
                    Success = false,
                    Message = "Branche Not Updated.",
                    Data = null,
                    Pagination = null,

                });
            }
            return Ok(new Response
            {
                Code = 200,
                Success = true,
                Message = "Branche Updated Sucessfully.",
                Data = new { resultSet = branch },
                Pagination = null,
            });
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Response>> DeleteByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new Response
                {
                    Code = 400,
                    Success = false,
                    Message = "Invalid Branch Id.",             
                    Data = null,
                    Pagination = null

                });
            }
            var branch = await _services.DeleteByIdAsync(id);
            if (branch == null)
            {
                return NotFound(new Response
                {
                    Code = 404,
                    Success = false,
                    Message = "Branch not Found.",                 
                    Data = null,
                    Pagination = null

                });
            }
            return Ok(new Response
            {
                Code = 200,
                Success = true,
                Message = "Branch deleted Sucessfully.",
                Data = new { resultSet = branch },
                Pagination = null
            });
        }

    }
}
