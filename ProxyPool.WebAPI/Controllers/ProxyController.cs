using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProxyPool.WebAPI.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class ProxyController : Controller {
    /// <summary>
    /// 获取Proxy列表
    /// </summary>
    /// <returns></returns>
    [HttpGet("proxies")]
    public IActionResult Get() {
      return View();
    }
  }
}