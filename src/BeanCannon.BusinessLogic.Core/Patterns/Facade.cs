using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace BeanCannon.BusinessLogic.Core.Patterns
{
	class Facade<T> : RealProxy
	{
		private readonly T _instance;

		private Facade(T instance)
			: base(typeof(T))
		{
			_instance = instance;
		}

		public static T Create(T instance)
		{
			return (T)new Facade<T>(instance).GetTransparentProxy();
		}

		public override IMessage Invoke(IMessage msg)
		{
			var methodCall = (IMethodCallMessage)msg;
			var method = (MethodInfo)methodCall.MethodBase;

			//try
			{
				//Console.WriteLine("Before invoke: " + method.Name);
				var result = method.Invoke(_instance, methodCall.InArgs);
				//Console.WriteLine("After invoke: " + method.Name);

				return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
			}
			//catch (Exception e)
			//{
			//	Console.WriteLine("Exception: " + e);
			//	if (e is TargetInvocationException && e.InnerException != null)
			//	{
			//		return new ReturnMessage(e.InnerException, msg as IMethodCallMessage);
			//	}

			//	return new ReturnMessage(e, msg as IMethodCallMessage);
			//}
		}
	}
}
