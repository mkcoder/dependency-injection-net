using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace mkcoders_ioc
{
    class MkCoderInjector
    {
        private readonly IDictionary<Type, Func<object>> _injector = new Dictionary<Type, Func<object>>();

        public void bind<TKey, TConcrete>() where TConcrete : TKey
        {
            _injector[typeof(TKey)] = () => ResolveByType(typeof(TConcrete));
        }

        public void bind<T>(T instace)
        {
            _injector[typeof(T)] = () => instace;
        }

        private object ResolveByType(Type type)
        {
            var constructor = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public).Single();
            var paramates = constructor.GetParameters()
                .Select(p => Resolve(p.ParameterType))
                .ToArray();
            return constructor.Invoke(paramates);
        }

        public T resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type argParameterType)
        {
            Func<object> resolvedParamaters;
            if (_injector.TryGetValue(argParameterType, out resolvedParamaters))
            {
                return resolvedParamaters();
            }
            return ResolveByType(argParameterType);
        }

    }
}
