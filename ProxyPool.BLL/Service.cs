using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyPool.BLL {
  public class Service<T, Q> : IService<T, Q> where T : class, new() {
    public T CreateAsync(T t) {
      throw new NotImplementedException();
    }

    public bool DeleteAsync(Q query) {
      throw new NotImplementedException();
    }

    public T GetAsync(Q query) {
      throw new NotImplementedException();
    }

    public IList<T> GetListAsync(Q query) {
      throw new NotImplementedException();
    }
  }
}
