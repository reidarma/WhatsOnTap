using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WhatsOnTap.Models;
using Microsoft.AspNetCore.Mvc;

namespace WhatsOnTap.Controllers
{
    [Route("api/[controller]")]
    public class SettingController : Controller
    {
        private readonly WhatsOnTapContext _context;

        public SettingController(WhatsOnTapContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Setting> GetAll()
        {
            return _context.Setting.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var item = _context.Setting.FirstOrDefault(t => t.id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Setting item)
        {
            if (item == null || id == 0)
            {
                return BadRequest();
            }

            var setting = _context.Setting.FirstOrDefault(t => t.id == id);
            if (setting == null)
            {
                return NotFound();
            }

            foreach(PropertyInfo prop in item.GetType().GetProperties()){
                if (prop.Name != "id"){
                    prop.SetValue(setting, prop.GetValue(item));
                }
            }

            _context.Setting.Update(setting);
            _context.SaveChanges();
            return Ok( new { message= "Setting is updated successfully."});
        }
    }
}