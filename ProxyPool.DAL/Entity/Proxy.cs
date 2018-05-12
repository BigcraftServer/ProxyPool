using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using Newtonsoft.Json;
using ProxyPool.DAL.Converters;

namespace ProxyPool.DAL.Entity {
  [Table("Proxies")]
  public partial class Proxy {
    [Column("id")]
    [Key]
    public Guid Id { get; set; }
    [Column("ip_address")]
    [JsonConverter(typeof(IPAddressConverter))]
    public IPAddress IpAddress { get; set; }
    [Column("port")]
    public int Port { get; set; }
    [Column("type")]
    public string Type { get; set; }
    [Column("anonymous_type")]
    public string AnonymousType { get; set; }
    [Column("country_code")]
    public string CountryCode { get; set; }
    [Column("create_time")]
    public DateTime CreateTime { get; set; }

    public ProxyCountry CountryCodeNavigation { get; set; }
  }
}
