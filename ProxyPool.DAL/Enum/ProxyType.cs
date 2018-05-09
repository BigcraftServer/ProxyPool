using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyPool.DAL.Enum {
  public enum ProxyType {
    None = 0x00,
    HTTP = 0x01,
    HTTPS = 0x02,
    SOCKS4 = 0x04,
    SOCKS5 = 0x08
  }
}
