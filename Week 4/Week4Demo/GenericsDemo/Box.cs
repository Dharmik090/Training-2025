using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    internal class Box<T1> where T1 : struct
    {
        private T1 content;

        public void Add(T1 item)
        {
            content = item;
        }

        public T1 GetContent()
        {
            return content;
        }

        public T2 ConvertTo<T2>()
        {
            if (typeof(T1) == typeof(string) && typeof(T2) == typeof(int))
            {
                return (T2)(object)Convert.ToInt32(content);
            }

            if (typeof(T1) == typeof(int) && typeof(T2) == typeof(string))
            {
                return (T2)(object)content.ToString();
            }

            return (T2)(object)content!;
        }
    }
}
