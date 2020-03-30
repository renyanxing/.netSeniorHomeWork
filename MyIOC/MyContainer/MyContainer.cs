using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MyContainer
{
    public class Container
    {
        public Dictionary<string, RegisterInfo> _Container { get; set; }
        public Dictionary<string, object> _SingletonList { get; set; } = new Dictionary<string, object>();
        public object containerLock = new object();
        public Container()
        {
            this._Container = new Dictionary<string, RegisterInfo>();
        }

        public void RegisterType<TFrom, TTo>(LifeTimeType lifeTimeType = LifeTimeType.Transient)
        {
            this._Container[typeof(TFrom).FullName] = new RegisterInfo(typeof(TTo), lifeTimeType);
        }
        public TSource Resolve<TSource>()
        {
            RegisterInfo registerInfo = this._Container[typeof(TSource).FullName];
            return (TSource)this.CreateObject(registerInfo);
        }
        private object CreateObject(RegisterInfo typeInfo)
        {
            ConstructorInfo ctor = GetConstructor(typeInfo.TargetType);
            List<object> paraList = new List<object>();
            switch (typeInfo.LifeTime)
            {
                case LifeTimeType.Transient:
                    {
                        foreach (ParameterInfo item in ctor.GetParameters())
                        {
                            Type paraType = item.ParameterType;
                            RegisterInfo targetRegisterInfo = this._Container[paraType.FullName];
                            paraList.Add(CreateObject(targetRegisterInfo));
                        }
                    }
                    break;
                case LifeTimeType.Singleton:
                    {
                        if (!_SingletonList.ContainsKey(typeInfo.TargetType.FullName))
                        {
                            lock (containerLock)
                            {
                                if (_SingletonList.ContainsKey(typeInfo.TargetType.FullName))
                                {
                                    return _SingletonList[typeInfo.TargetType.FullName];
                                }
                                else
                                {

                                    foreach (ParameterInfo item in ctor.GetParameters())
                                    {
                                        Type paraType = item.ParameterType;
                                        RegisterInfo targetRegisterInfo = this._Container[paraType.FullName];
                                        paraList.Add(CreateObject(targetRegisterInfo));
                                    }
                                    object oValue = Activator.CreateInstance(typeInfo.TargetType, paraList.ToArray());
                                    _SingletonList.Add(typeInfo.TargetType.FullName, oValue);
                                }
                            }

                        }
                        return _SingletonList[typeInfo.TargetType.FullName];
                    }

                case LifeTimeType.PerThread:
                    {
                        object oValue = CallContext.GetData(typeInfo.TargetType.FullName);
                        if (oValue == null)
                        {
                            foreach (ParameterInfo item in ctor.GetParameters())
                            {
                                Type paraType = item.ParameterType;
                                RegisterInfo targetRegisterInfo = this._Container[paraType.FullName];
                                paraList.Add(CreateObject(targetRegisterInfo));
                            }
                            oValue = Activator.CreateInstance(typeInfo.TargetType, paraList.ToArray());
                            CallContext.SetData(typeInfo.TargetType.FullName, oValue);
                        }
                        return oValue;
                    }

                default:
                    break;
            }
            return Activator.CreateInstance(typeInfo.TargetType, paraList.ToArray());
        }
        private ConstructorInfo GetConstructor(Type type)
        {
            ConstructorInfo[] ctorArray = type.GetConstructors();
            ConstructorInfo ctor = null;
            if (ctorArray.Count(c => c.IsDefined(typeof(ContainerAttribute), true)) > 0)
            {
                ctor = ctorArray.OrderByDescending(c => c.GetParameters()).FirstOrDefault(c => c.IsDefined(typeof(ContainerAttribute), true));
            }
            else
            {
                ctor = ctorArray.OrderByDescending(c => c.GetParameters()).FirstOrDefault();
            }
            return ctor;
        }
    }
}