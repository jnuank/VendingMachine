using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Utility
{
    public static class EnumUtility
    {
        /// <summary>
        /// EnumのDescription属性を取得します
        /// </summary>
        /// <param name="enumerator"></param>
        /// <returns></returns>
        public static string GetEnumDescription<T>(this T enumerator)
        {
            MemberInfo members = enumerator.GetType().GetMember(enumerator.ToString()).FirstOrDefault();
            Attribute attribute = members.GetCustomAttribute(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)attribute).Description;
        }

    }
}
