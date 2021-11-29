
namespace IntrumFormTestUV.Configurations
{
    public interface ITestConfiguration 
    {
        //just an interface for test config
        string goodNameSurname { get; }
        string badNameSurname { get; }
        string goodPersCode { get; }
        string badPersCode { get; }
        string badEmail { get; }
        string goodEmail { get; }
        string address { get; }
        string goodPhoneNumber { get; }
        string badPhoneNumber { get; }
        string testUrl { get; }

    }
}
