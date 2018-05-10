using ProxyPool.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPool.BLL {
  public class Service<T, Q> : IServiceSync<T, Q>, IServiceAsync<T, Q> where T : class, new() {
    private ProxyDBContext proxyDBContext;

    public Service(ProxyDBContext proxyDBContext) {
      this.proxyDBContext = proxyDBContext;
    }

    public T Create(T t) {
      throw new NotImplementedException();
    }

    public async Task<T> CreateAsync(T t) {
      throw new NotImplementedException();
    }

    public bool Delete(Q query) {
      throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(Q query) {
      throw new NotImplementedException();
    }

    public T Get(Q query) {
      throw new NotImplementedException();
    }

    public async Task<T> GetAsync(Q query) {
      var a =  proxyDBContext.Proxies.FirstOrDefault();
      return a as T;
    }

    public IList<T> GetList(Q query) {
      throw new NotImplementedException();
    }

    public async Task<IList<T>> GetListAsync(Q query) {
      throw new NotImplementedException();
    }
  }
}
