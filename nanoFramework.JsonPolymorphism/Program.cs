using System;
using System.Diagnostics;
using System.Threading;

namespace nanoFramework.JsonPolymorphism
{
    public class Program
    {
        public static void Main()
        {
            var type = typeof(MyObject);
            var customAttributes = type.GetCustomAttributes(false);

            Debug.Assert(((JsonDerivedTypeAttribute)customAttributes[0]).Type == typeof(MyObject));

            Thread.Sleep(Timeout.Infinite);
        }
    }

    [JsonDerivedType(typeof(MyDerived))]
    public class MyObject
    {
        public int A { get; set; }
    }

    public class MyDerived : MyObject
    {
        public int B { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class JsonDerivedTypeAttribute : Attribute
    {
        public JsonDerivedTypeAttribute(Type type)
        {
            Type = type;
        }

        public Type Type { get; set; }
    }

}
