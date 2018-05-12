using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using ProxyPool.BLL.Services;
using ProxyPool.BLL.ViewModel;
using ProxyPool.Grpc;

namespace ProxyPool.WebAPI.Grpc {
  public class ProxyPoolGrpc : ProxyPoolV1.ProxyPoolV1Base {
    private ProxyService proxyService;

    public ProxyPoolGrpc(ProxyService proxyService) {
      this.proxyService = proxyService ?? throw new ArgumentNullException(nameof(proxyService));
    }

    public override Task<Proxy> Create(Proxy request, ServerCallContext context) {
      return Task.FromResult((Proxy)proxyService.Create((ProxyVM)request));
    }

    public override Task<Proxy> Get(Proxy request, ServerCallContext context) {
      return Task.FromResult((Proxy)proxyService.Get(request));
    }

    public override Task<Proxy> GetById(Text request, ServerCallContext context) {
      return Task.FromResult((Proxy)proxyService.Get(request.Value));
    }
  }
}
