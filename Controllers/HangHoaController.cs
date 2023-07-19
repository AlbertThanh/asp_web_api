using Microsoft.AspNetCore.Mvc;
using My_web_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace My_web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : Controller
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }

        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia
            };

            hangHoas.Add(hanghoa);

            return Ok(new {

                Success = true, Data = hangHoas
            });
        }

        [HttpGet("{id}")]
        public IActionResult getById(string id)
        {
            try
            {
                var hanghoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                return Ok(hanghoa);
            }
            catch
            {
                return BadRequest();

            }

        }
        [HttpPut("{id}")]
        public IActionResult getById(string id, HangHoa hanghoaEdit)
        {
            try
            {
                var hanghoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                //update
                if (id != hanghoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                hanghoa.TenHangHoa = hanghoaEdit.TenHangHoa;
                hanghoa.DonGia = hanghoaEdit.DonGia;

                return Ok(hanghoa);
            }
            catch
            {
                return BadRequest();

            }

        }
        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            try
            {
                var hanghoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                //update
                if (id != hanghoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                hangHoas.Remove(hanghoa);

                return Ok();
            }
            catch
            {
                return BadRequest();

            }

        }






    }
}
