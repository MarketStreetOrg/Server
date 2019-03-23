using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Katale_Server_Final.Utilities.AOP
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method)]
    public class LoggingAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            System.Diagnostics.Debug.WriteLine("Hello Aspect Oriented Programming");
        }

        public override void OnException(MethodExecutionArgs args)
        {
            base.OnException(args);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            base.OnExit(args);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            base.OnSuccess(args);
        }
    }

}