using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore
{
    public class CustomControllerActivator : IControllerActivator
    {
        public object Create(ControllerContext context)
        {
            var controllerType = context.ActionDescriptor.ControllerTypeInfo.AsType();

            // カスタム属性に基づいてセッションビヘイビアを設定
            var sessionBehavior = GetControllerSessionBehavior(controllerType);
            if (sessionBehavior != SessionBehavior.Default)
            {
                // セッションビヘイビアに基づいてカスタムロジックを追加
                Console.WriteLine($"Controller {controllerType.Name} has custom session behavior: {sessionBehavior}");
            }

            return ActivatorUtilities.CreateInstance(context.HttpContext.RequestServices, controllerType);
        }

        public void Release(ControllerContext context, object controller)
        {
            (controller as IDisposable)?.Dispose();
        }

        private SessionBehavior GetControllerSessionBehavior(Type controllerType)
        {
            var attribute = (SessionBehaviorAttribute)Attribute.GetCustomAttribute(controllerType, typeof(SessionBehaviorAttribute));
            return attribute?.Behavior ?? SessionBehavior.Default;
        }
    }

    public enum SessionBehavior
    {
        Default,
        Required,
        Disabled
    }
}
