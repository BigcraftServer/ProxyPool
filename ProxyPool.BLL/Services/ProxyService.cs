using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProxyPool.BLL.InputModel;
using ProxyPool.DAL;
using ProxyPool.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPool.BLL.Services {
  public class ProxyService : IService<Proxy, ProxyInput> {
    private ProxyDBContext proxyDBContext {
      get {
        return (this as IService<Proxy, ProxyInput>).proxyDBContext;
      }
      set {
        (this as IService<Proxy, ProxyInput>).proxyDBContext = value;
      }
    }
    public ProxyService(ProxyDBContext proxyDBContext) {
      this.proxyDBContext = proxyDBContext;
    }

    ProxyDBContext IService<Proxy, ProxyInput>.proxyDBContext { get; set; }


    public Proxy Create(ProxyInput t) {
      Proxy savedEntity = t;
      savedEntity.CreateTime = DateTime.Now;
      return proxyDBContext.Proxies.Add(savedEntity)?.Entity;
    }

    public bool Delete(ProxyInput t) {
      throw new NotImplementedException();
    }

    public Proxy Get(ProxyInput inputModel) {
      throw new NotImplementedException();
    }

    public IList<Proxy> GetList(ProxyInput proxyInput) {
      throw new NotImplementedException();
    }
    public Proxy Get(object id) {
      Guid _id = new Guid(id.ToString());
      return this.proxyDBContext.Proxies.FirstOrDefault(c => c.Id == _id);
    }

  }
}
