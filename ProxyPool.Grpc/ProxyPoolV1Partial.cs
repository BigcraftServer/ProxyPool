using ProxyPool.BLL.ViewModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;

namespace ProxyPool.Grpc {
  public sealed partial class Proxy : pb::IMessage<Proxy> {
    public static implicit operator Proxy(ProxyVM proxyInput) {
      return new Proxy() {
        IpAddress = proxyInput.IpAddress,
        AnonymousType = proxyInput.AnonymousType,
        CountryCode = proxyInput.CountryCode,
        Type = proxyInput.Type,
        Port = proxyInput.Port
      };
    }
    public static explicit operator ProxyVM(Proxy proxy) {
      return new ProxyVM() {
        IpAddress = proxy.IpAddress,
        AnonymousType = proxy.AnonymousType,
        CountryCode = proxy.CountryCode,
        Port = proxy.Port,
        Type = proxy.Type
      };
    }
  }
}
