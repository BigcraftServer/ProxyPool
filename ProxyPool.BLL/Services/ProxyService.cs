using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProxyPool.BLL.ViewModel;
using ProxyPool.DAL;
using ProxyPool.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPool.BLL.Services {
  public class ProxyService : IService<Proxy, ProxyVM> {
    private ProxyDBContext proxyDBContext {
      get {
        return (this as IService<Proxy, ProxyVM>).proxyDBContext;
      }
      set {
        (this as IService<Proxy, ProxyVM>).proxyDBContext = value;
      }
    }
    public ProxyService(ProxyDBContext proxyDBContext) {
      this.proxyDBContext = proxyDBContext;
    }

    ProxyDBContext IService<Proxy, ProxyVM>.proxyDBContext { get; set; }


    public ProxyVM Create(ProxyVM t) {
      Proxy savedEntity = t;
      savedEntity.CreateTime = DateTime.Now;
      return (ProxyVM)proxyDBContext.Proxies.Add(savedEntity)?.Entity;
    }

    public bool Delete(ProxyVM t) {
      throw new NotImplementedException();
    }

    public ProxyVM Get(ProxyVM inputModel) {
      throw new NotImplementedException();
    }

    public IList<ProxyVM> GetList(ProxyVM proxyInput) {
      throw new NotImplementedException();
    }
    public ProxyVM Get(object id) {
      Guid _id = new Guid(id.ToString());
      return (ProxyVM)this.proxyDBContext.Proxies.FirstOrDefault(c => c.Id == _id);
    }

  }
}
