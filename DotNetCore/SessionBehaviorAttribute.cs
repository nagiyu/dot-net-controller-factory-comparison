namespace DotNetCore
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class SessionBehaviorAttribute : Attribute
    {
        public SessionBehavior Behavior { get; }

        public SessionBehaviorAttribute(SessionBehavior behavior)
        {
            Behavior = behavior;
        }
    }
}
