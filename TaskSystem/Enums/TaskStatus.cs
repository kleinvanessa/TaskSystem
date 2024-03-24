using System.ComponentModel;

namespace TaskSystem.Enums
{
    public enum TaskStatus
    {
        [Description("To do")]
        ToDo = 1,
        [Description("Work in Progress")]
        InProgress = 2,
        [Description("Complete")]
        Complete = 3
    }
}
