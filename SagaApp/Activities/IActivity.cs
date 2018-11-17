using System;

namespace SagaApp.Activities
{
    public interface IActivity
    {
        Uri WorkItemQueueAddress { get; }

        Uri CompensationQueueAddress { get; }

        object Do(string name);

        bool Compensate(object item);
    }
}