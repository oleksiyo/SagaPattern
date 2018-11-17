using System;
using SagaApp.Activities;

namespace SagaApp.Work
{
    public abstract class WorkItem
    {
        private readonly WorkItemArguments arguments;

        public WorkItem(WorkItemArguments arguments)
        {
            this.arguments = arguments;
        }

        public WorkItemArguments Arguments => arguments;
        public abstract Type ActivityType { get; }
    }

    public class WorkItem<T> : WorkItem where T : IActivity
    {
        public WorkItem(WorkItemArguments arguments) : base(arguments)
        {
        }

        public override Type ActivityType => typeof(T);
    }
}