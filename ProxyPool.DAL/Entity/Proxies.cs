using System;
using System.Collections.Generic;
using System.Net;

namespace ProxyPool.DAL.Entity {
  public partial class Proxies {
    public Guid Id { get; set; }
    public IPAddress IpAddress { get; set; }
    public int Port { get; set; }
    public string Type { get; set; }
    public string AnonymousType { get; set; }
    public string CountryCode { get; set; }
    public DateTime CreateTime { get; set; }

    public ProxyCountries CountryCodeNavigation { get; set; }
  }
}
