using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ProxyPool.DAL.Enum
{
  public class EnumConverter<TEnum> : ValueConverter<TEnum, string>
  where TEnum : struct {
    public static EnumConverter<TEnum> Instance = new EnumConverter<TEnum>();

    private EnumConverter()
        : base(v => ToEnumString(v), v => ToEnum(v)) {
    }

    private static string ToEnumString(TEnum type) {
      var enumType = typeof(TEnum);
      var name = System.Enum.GetName(enumType, type);
      var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
      return enumMemberAttribute.Value;
    }

    private static TEnum ToEnum(string str) {
      var enumType = typeof(TEnum);
      foreach (var name in System.Enum.GetNames(enumType)) {
        var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
        if (enumMemberAttribute.Value == str) {
          return (TEnum)System.Enum.Parse(enumType, name);
        }
      }

      return default;
    }
  }
}
