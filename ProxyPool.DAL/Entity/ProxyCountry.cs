using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProxyPool.DAL.Entity {
  [Table("ProxyCountries")]
  public partial class ProxyCountry {
    public ProxyCountry() {
      Proxies = new HashSet<Proxy>();
    }
    [Column("code")]
    [Key]
    public string Code { get; set; }
    [Column("name")]
    public string Name { get; set; }

    public ICollection<Proxy> Proxies { get; set; }
  }
}
