using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ProxyPool.DAL.Converters {
  public class IPAddressConverter : JsonConverter<IPAddress> {
    public override IPAddress ReadJson(JsonReader reader, Type objectType, IPAddress existingValue, bool hasExistingValue, JsonSerializer serializer) {
      return IPAddress.Parse((string)reader.Value);
    }

    public override void WriteJson(JsonWriter writer, IPAddress value, JsonSerializer serializer) {
      writer.WriteValue(value.ToString());
    }
  }
}
