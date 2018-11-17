using System;
using System.Collections.Generic;
using System.Linq;
using SagaApp.Activities;
using SagaApp.Work;

namespace SagaApp
{
    public class RoutingConveyor
    {
        readonly Stack<WorkItem> completedWorkItems = new Stack<WorkItem>();
        private readonly Queue<WorkItem> queueActivities = new Queue<WorkItem>();

        public RoutingConveyor(IEnumerable<WorkItem> activities)
        {
            foreach (var activity in activities)
            {
                queueActivities.Enqueue(activity);
            }
        }

        public bool ProcessNext()
        {

            for (int i = 0; i < queueActivities.Count + 1; i++)
            {
                var currentItem = queueActivities.Dequeue();
                var activity = (IActivity)Activator.CreateInstance(currentItem.ActivityType);
                try
                {
               
                    var result = activity.Do(currentItem);
                    if (result != null)
                    {
                        this.completedWorkItems.Push(currentItem);
                  
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception {0}", e.Message);
                    completedWorkItems.ToList().ForEach(item =>
                    {
                        activity.Compensate("some args");
                    });
                    return false;
                }            
            }
            return true;
        }
    }
}