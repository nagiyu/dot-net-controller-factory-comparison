using DotNetFramework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace DotNetFramework
{
    public class CustomControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, $"Controller not found for path {requestContext.HttpContext.Request.Path}");
            }

            // カスタム属性に基づいてセッションビヘイビアを設定
            var sessionBehavior = GetControllerSessionBehavior(requestContext, controllerType);
            if (sessionBehavior != SessionStateBehavior.Default)
            {
                // セッションビヘイビアに基づいてカスタムロジックを追加
                Console.WriteLine($"Controller {controllerType.Name} has custom session behavior: {sessionBehavior}");
            }

            return base.GetControllerInstance(requestContext, controllerType);
        }

        protected override SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new ArgumentNullException(nameof(controllerType));
            }

            var attribute = (SessionBehaviorAttribute)Attribute.GetCustomAttribute(controllerType, typeof(SessionBehaviorAttribute));
            return attribute?.Behavior ?? SessionStateBehavior.Default;
        }
    }
}