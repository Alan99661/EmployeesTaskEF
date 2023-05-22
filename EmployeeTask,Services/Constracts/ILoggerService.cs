namespace EmployeeTask_Services.Constracts
{
    public interface ILoggerService
    {
        string CheckingNullMessage(IEnumerable<object> objects);
        string CheckNullMessageForSingleItem(object item);
        string Log(int option);
    }
}