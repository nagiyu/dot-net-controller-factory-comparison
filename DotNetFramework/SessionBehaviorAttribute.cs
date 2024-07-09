using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace DotNetFramework
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class SessionBehaviorAttribute : Attribute
    {
        public SessionStateBehavior Behavior { get; }

        public SessionBehaviorAttribute(SessionStateBehavior behavior)
        {
            Behavior = behavior;
        }
    }
}