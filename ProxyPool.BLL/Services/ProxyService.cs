using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProxyPool.DAL;
using ProxyPool.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPool.BLL.Services {
  public class ProxyService : Service<Proxies, Proxies> {
    private ProxyDBContext ProxyDBContext;
    public ProxyService(ProxyDBContext proxyDBContext) : base(proxyDBContext) {
      this.ProxyDBContext = proxyDBContext;
    }

  }
}
