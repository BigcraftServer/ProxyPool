using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPool.BLL {
  public interface IServiceSync<T, Q> where T : class, new() {
    T Get(Q query);
    IList<T> GetList(Q query);
    bool Delete(Q query);
    T Create(T t);
  }
}
