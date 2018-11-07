namespace SagaApp.Activities
{
    public interface IActivity
    {
        object Do(string name);

        bool Compensate(object item);
    }
}
