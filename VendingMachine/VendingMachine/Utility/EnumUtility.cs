using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using VendingMachine.Domain;

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

        /// <summary>
        /// DrinkKindに設定された価格属性を取得します
        /// </summary>
        /// <param name="kind"></param>
        /// <returns></returns>
        public static int GetPrice<T>(this T kind)
        {
            MemberInfo members = kind.GetType().GetMember(kind.ToString()).FirstOrDefault();
            Attribute attribute = members.GetCustomAttribute(typeof(PriceAttribute), false);
            return ((PriceAttribute)attribute).Price;
        }

        /// <summary>
        /// 列挙体の要素の数を返します。MAXとか自前で用意していないときに便利
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerator"></param>
        /// <returns></returns>
        public static int Count(this MoneyKind enumerator)
        {
            string[] names = Enum.GetNames(enumerator.GetType());

            return names.Count();
        }

    }
}
