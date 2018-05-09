using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProxyPool.DAL;
using ProxyPool.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPool.BLL.Services {
  public class ProxyService : IService<Proxies, Proxies> {
    private ProxyDBContext ProxyDBContext;
    public ProxyService(ProxyDBContext proxyDBContext) {
      this.ProxyDBContext = proxyDBContext;
    }

    public async Task<Proxies> Create(Proxies t) {
      return (await ProxyDBContext.Proxies.AddAsync(t)).Entity;
    }

    public bool Delete(Proxies query) {
      throw new NotImplementedException();
    }

    public Proxies Get(Proxies query) {
      throw new NotImplementedException();
    }

    public IList<Proxies> GetList(Proxies query) {
      throw new NotImplementedException();
    }

  }
}
