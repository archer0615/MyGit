using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpNote.EnumHelper
{
    public enum Category
    {
        [Display(Name = "電氣")]
        Electric = 0,
        [Display(Name = "服飾")]
        Clothing = 1,
        [Display(Name = "藥品")]
        Medicine = 2,
        [Display(Name = "其他")]
        Others = 999,
    }
    public enum Language
    {
        [Display(Name = "中文")]
        Chinese = 0,
        [Display(Name = "英語")]
        English = 1,
        [Display(Name = "日語")]
        Japanese = 2,
    }
    public enum Country
    {
        [Display(Name = "台灣")]
        Taiwan = 0,
        [Display(Name = "中國")]
        China = 1,
        [Display(Name = "日本")]
        Japan = 2,
        [Display(Name = "韓國")]
        Korea = 3,
    }
    public static class EnumHelper
    {
        public static string GetEnumDisplayName(this Enum enumType)
        {
            return enumType.GetType()
                                .GetMember(enumType.ToString())
                                .First().GetCustomAttributesData()
                                .First().NamedArguments
                                .First().TypedValue.Value.ToString();
        }
    }
}
