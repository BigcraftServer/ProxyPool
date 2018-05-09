using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPool.BLL {
  public interface IService<T, Q> where T : class, new() {
    Task<T> GetAsync(Q query);
    Task<IList<T>> GetListAsync(Q query);
    Task<bool> DeleteAsync(Q query);
    Task<T> CreateAsync(T t);
  }
}
