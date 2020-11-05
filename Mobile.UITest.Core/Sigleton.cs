using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.UITest.Core
{
    public abstract class Singleton<T> where T : Singleton<T>
    {
        private static readonly Lazy<T> instance;

        static Singleton()
        {
            instance = new Lazy<T>(() =>
            {
                var ctor = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
                return (T)ctor.Invoke(null);
            });

        }

        public static T Instance => instance.Value;
    }
}
