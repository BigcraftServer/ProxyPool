using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProxyPool.BLL.Services;

namespace ProxyPool.WebAPI.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class ProxyController : Controller {
    private ProxyService proxyService;

    public ProxyController(ProxyService proxyService) {
      this.proxyService = proxyService;
    }

    /// <summary>
    /// 获取Proxy列表
    /// </summary>
    /// <returns></returns>
    [HttpGet("proxies")]
    public async Task<OkObjectResult> Get() {
      try {
        var a = await proxyService.GetAsync(null);
        return Ok(a);
      } catch (Exception e) {

      }
      return Ok(null);
    }
  }
}