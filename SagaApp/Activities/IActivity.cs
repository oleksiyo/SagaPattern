using System;
using SagaApp.Work;

namespace SagaApp.Activities
{
    public interface IActivity
    {
        Uri WorkItemQueueAddress { get; }

        Uri CompensationQueueAddress { get; }

        WorkResult Do(WorkItem workItem);

        bool Compensate(object item);
    }
}