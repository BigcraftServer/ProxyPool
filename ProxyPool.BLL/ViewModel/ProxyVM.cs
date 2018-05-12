using ProxyPool.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ProxyPool.BLL.ViewModel {
  public class ProxyVM {
    public string IpAddress { get; set; }
    public int Port { get; set; }
    public string CountryCode { get; set; }
    public string AnonymousType { get; set; }
    public string Type { get; set; }
    #region DAL.Proxy Convert
    public static implicit operator Proxy(ProxyVM proxyInput) {
      return new Proxy() {
        IpAddress = IPAddress.Parse(proxyInput.IpAddress),
        AnonymousType = proxyInput.AnonymousType,
        CountryCode = proxyInput.CountryCode,
        Type = proxyInput.Type,
        Port = proxyInput.Port
      };
    }
    public static explicit operator ProxyVM(Proxy proxy) {
      return new ProxyVM() {
        IpAddress = proxy.IpAddress.ToString(),
        AnonymousType = proxy.AnonymousType,
        CountryCode = proxy.CountryCode,
        Port = proxy.Port,
        Type = proxy.Type
      };
    }
    #endregion
  }
}
