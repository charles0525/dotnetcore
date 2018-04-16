using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiCore.Models;
using Newtonsoft.Json;

namespace ApiCore.Controllers
{
    [Route("api/[controller]")]
    public class MenuController : Controller
    {
        public static MenuContext _context = new MenuContext();

        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            var tmp = _context.Menu.FirstOrDefault(x => x.ModelId == Id);
            return new JsonResult(tmp);
        }
        [HttpGet("list")]
        public IActionResult List()
        {
            var list = _context.Menu.ToList();
            return new JsonResult(new { list });
        }
        /// <summary>
        /// 提交 （Content-Type：application/json）
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost("postadd")]
        public IActionResult Add([FromBody]MenuModel m)
        {
            var tmp = _context.Menu.FirstOrDefault(x => x.ModelId == m.ModelId);
            if (tmp != null)
            {
                return new JsonResult(new { code = -1, msg = "已存在", tmp = tmp });
            }
            m.AddTime = DateTime.Now;
            _context.Menu.Add(m);
            return new JsonResult(new { code = 1, msg = "操作成功" });
        }
        [HttpPost("postupdate")]
        public IActionResult Update(MenuModel m)
        {
            var tmp = _context.Menu.FirstOrDefault(x => x.ModelId == m.ModelId);
            if (tmp == null)
            {
                return new JsonResult(new { code = -1, msg = "参数错误" });
            }
            tmp.ModelName = m.ModelName;
            tmp.SortNumber = m.SortNumber;
            return new JsonResult(new { code = 1, msg = "操作成功" });
        }
        [HttpPost("postremove")]
        public IActionResult Remove(int id)
        {
            var tmp = _context.Menu.FirstOrDefault(x => x.ModelId == id);
            if (tmp == null)
            {
                return new JsonResult(new { code = -1, msg = "参数错误" });
            }
            _context.Menu.Remove(tmp);
            return new JsonResult(new { code = 1, msg = "操作成功" });
        }
    }
}