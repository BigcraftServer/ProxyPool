using System;
using System.Collections.Generic;

namespace ProxyPool.DAL.Entity {
  public partial class ProxyCountries {
    public ProxyCountries() {
      Proxies = new HashSet<Proxies>();
    }

    public string Code { get; set; }
    public string Name { get; set; }

    public ICollection<Proxies> Proxies { get; set; }
  }
}
