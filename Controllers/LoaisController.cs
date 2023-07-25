using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_web_API.Data;
using My_web_API.Models;
using System.Linq;

namespace My_web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : Controller
    {
        private readonly MyDbContext _context;

        public LoaisController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var dsLoai = _context.Loais.ToList();
                return Ok(dsLoai);
            }
            catch
            {

                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loai = _context.Loais.FirstOrDefault(item => item.MaLoai == id);
            if (loai != null)
            {
                return Ok(loai);
            }
            else
            {
                return NotFound(); 
            }
            
        }
        [HttpPost]
        [Authorize]
        public IActionResult CreateNew(LoaiModel model)
        {
            try
            {
                var loai = new Loai()
                {
                    TenLoai = model.TenLoai
                };

                _context.Add(loai);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, loai);
            }
            catch
            {
                return BadRequest();
                
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateLoaiById(int id, LoaiModel loai)
        {
            try
            {
                var loaiFind = _context.Loais.SingleOrDefault(item => item.MaLoai == id);
                if(loaiFind != null)
                {
                    loaiFind.TenLoai = loai.TenLoai;
                    _context.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();

            }
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveKLoaiById(int id)
        {
            var loai = _context.Loais.FirstOrDefault(item => item.MaLoai == id);
            if (loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return NotFound();
            }

        }

    }
}
