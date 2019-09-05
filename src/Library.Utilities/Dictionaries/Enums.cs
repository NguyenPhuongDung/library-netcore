using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Library.Utilities.Dictionaries
{
    public class Item
    {
        public string Value { get; set; }
        public string Name { get; set; }
    }
    public static class Enums
    {
        public static string GetDescription(this System.Enum value)
        {
            Type type = value.GetType();
            var memInfo = type.GetMember(value.ToString());

            if (memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return value.ToString();
        }
        public static Item GetItem<T>(this int value)
        {
            return Enum.GetValues(typeof(T)).Cast<Enum>().Where(e => Convert.ChangeType(e, TypeCode.Int32)?.ToString() == value.ToString()).Select(e => new Item
            {
                Value = value.ToString(),
                Name = e.GetDescription()
            }).FirstOrDefault();
        }
        public static IEnumerable<Item> ToEnumSelectList<T>()
        {
            return System.Enum.GetValues(typeof(T)).Cast<System.Enum>().Select(e => new Item
            {
                Value = Convert.ChangeType(e, TypeCode.Int32)?.ToString(),
                Name = e.GetDescription()
            }).ToList();
        }
        public enum LoginStatus
        {
            Success = 0,
            Failed = 1,
            UserLocked = 2,
            UserLockedTemporary = 3,
            UnsupportedVersion = 4,
            NotAuthorized = 5,
            RequiresTwoFactor = 6,
        }
        public enum SortType
        {
            Ascending = 1,
            Descending = -1
        }
    }

}