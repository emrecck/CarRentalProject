using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalManager;

        public RentalsController(IRentalService rentalManager)
        {
            _rentalManager = rentalManager;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalManager.GetRentals();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _rentalManager.GetRentalById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getcustomerid")]
        public IActionResult GetByCustomerId(int id)
        {
            var result = _rentalManager.GetRentalsByCustomerId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyrent")]
        public IActionResult GetByRentDate(int year,int month,int day)
        {
            var result = _rentalManager.GetRentalsByRentDate(new DateTime(year,month,day));
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyreturn")]
        public IActionResult GetByReturnDate(int year,int month,int day)
        {
            var result = _rentalManager.GetRentalsByReturnDate(new DateTime(year,month,day));
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
