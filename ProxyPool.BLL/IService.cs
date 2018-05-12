using ProxyPool.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPool.BLL {
  public interface IService<T, ViewModel> where T : class, new() {
    ProxyDBContext proxyDBContext { get; set; }
    ViewModel Create(ViewModel t);
    bool Delete(ViewModel t);
    ViewModel Get(ViewModel inputModel);
    IList<ViewModel> GetList(ViewModel inputModel);

    ViewModel Get(object id);
  }
}
