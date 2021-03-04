using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("get")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int id)
        {
            var result = _carImageService.GetByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        //[Route("add/{id}")]
        [HttpPost("add")]
        public IActionResult UploadImage([FromForm] IFormFile files,[FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(carImage, files);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("del")]
        public IActionResult DeleteImage(int id)
        {
            var result = _carImageService.GetById(id);
            var outcome = _carImageService.Delete(result.Data);
            if (outcome.Success)
            {
                return Ok(outcome);
            }
            return BadRequest(outcome);
        }
        [HttpPost("update")]
        public IActionResult UpdateImage(IFormFile file,CarImage carImage)
        {
            var result = _carImageService.Update(file,carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
