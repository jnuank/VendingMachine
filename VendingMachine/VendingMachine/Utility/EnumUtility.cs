using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using VendingMachine.Domain;
using VendingMachine.Domain.Drinks;

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
        public static int GetPrice(this DrinkKind kind)
        {
            MemberInfo members = kind.GetType().GetMember(kind.ToString()).FirstOrDefault();
            Attribute attribute = members.GetCustomAttribute(typeof(PriceAttribute), false);
            return ((PriceAttribute)attribute).Price;
        }

        /// <summary>
        /// 飲み物の種類に応じて、Drinkインスタンスを返す
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static Drink GetDrink(this DrinkKind kind)
        {
            if (kind == DrinkKind.COKE)
                return new Drink(DrinkKind.COKE);

            if (kind == DrinkKind.TEA)
                return new Drink(DrinkKind.TEA);

            if (kind == DrinkKind.CIDER)
                return new Drink(DrinkKind.CIDER);

            return null;
        }

    }
}
