using System;
using System.Collections.Generic;
using System.Linq;
using SagaApp.Activities;

namespace SagaApp
{
    public class RoutingConveyor
    {
        readonly Stack<IActivity> completedWorkItems = new Stack<IActivity>();
        private readonly Queue<IActivity> queueActivities = new Queue<IActivity>();

        public RoutingConveyor(IEnumerable<IActivity> activities)
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
                try
                {
                    var result = currentItem.Do("some args");
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
                        item.Compensate("some args");
                    });
                    return false;
                }            
            }
            return true;
        }
    }
}