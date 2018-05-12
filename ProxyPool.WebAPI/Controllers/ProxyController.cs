using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProxyPool.BLL.ViewModel;
using ProxyPool.BLL.Services;
using ProxyPool.DAL.Entity;

namespace ProxyPool.WebAPI.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class ProxyController : Controller {
    private ProxyService proxyService;

    public ProxyController(ProxyService proxyService) {
      this.proxyService = proxyService;
    }

    /// <summary>
    /// 获取Proxy
    /// </summary>
    /// <returns></returns>
    [HttpGet("proxies")]
    [ProducesResponseType(typeof(DAL.Entity.Proxy), 200)]
    public IActionResult Get(Guid id) {
      return Ok(proxyService.Get(id));
    }

    [HttpPost("")]
    [ProducesResponseType(typeof(DAL.Entity.Proxy), 200)]
    public IActionResult Create(ProxyVM proxyInput) {
      return Ok(proxyService.Create(proxyInput));
    }
  }
}