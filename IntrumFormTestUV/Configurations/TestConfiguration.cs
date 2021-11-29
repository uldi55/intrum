
namespace IntrumFormTestUV.Configurations
{
    //test config for different environments (not really needed for the task, but nice to have)
    //maybe should have gone with good and bad configuration...
    public class DevEnvConfiguration : ITestConfiguration
    {
        public string goodNameSurname => "Test Tester";
        public string badNameSurname => "test";
        public string goodPersCode => "11111111-11111";
        public string badPersCode => "test";
        public string badEmail => "test";
        public string goodEmail => "test@test.lv";
        public string address => "test address";
        public string goodPhoneNumber => "21111111";
        public string badPhoneNumber => "test";
        public string testUrl => "https://www.intrum.lv/saistibu-parvaldisana/sazinieties-ar-mums/";
    }

    public class TestEnvConfiguration : ITestConfiguration
    {
        public string goodNameSurname => "Test Tester";
        public string badNameSurname => "test";
        public string goodPersCode => "11111111-11111";
        public string badPersCode => "test";
        public string badEmail => "test";
        public string goodEmail => "test@test.lv";
        public string address => "test address";
        public string goodPhoneNumber => "21111111";
        public string badPhoneNumber => "test";
        public string testUrl => "https://www.intrum.lv/saistibu-parvaldisana/sazinieties-ar-mums/";
    }

    public class PreProdEnvConfiguration : ITestConfiguration
    {
        public string goodNameSurname => "Test Tester";
        public string badNameSurname => "test";
        public string goodPersCode => "11111111-11111";
        public string badPersCode => "test";
        public string badEmail => "test";
        public string goodEmail => "test@test.lv";
        public string address => "test address";
        public string goodPhoneNumber => "21111111";
        public string badPhoneNumber => "test";
        public string testUrl => "https://www.intrum.lv/saistibu-parvaldisana/sazinieties-ar-mums/";
    }

    public class LocalEnvConfiguration : ITestConfiguration
    {
        public string goodNameSurname => "Test Tester";
        public string badNameSurname => "test";
        public string goodPersCode => "11111111-11111";
        public string badPersCode => "test";
        public string badEmail => "test";
        public string goodEmail => "test@test.lv";
        public string address => "test address";
        public string goodPhoneNumber => "21111111";
        public string badPhoneNumber => "test";
        public string testUrl => "https://www.intrum.lv/saistibu-parvaldisana/sazinieties-ar-mums/";
    }
}
