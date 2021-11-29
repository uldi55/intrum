using System.Collections.Generic;

namespace IntrumFormTestUV.Helpers
{
    public class TestData
    {
        //pretty much just some test data. Was not sure where to put it so it ended up here
        public List<string> formTexts = new List<string> 
        { "Vārds, uzvārds",
            "Personas kods",
            "Lietas numurs (nav obligāts)",
            "Kontakttālrunis",
            "E-pasta adrese",
            "Adrese",
            "Komentāra/iebildumu būtība"
           // "Kā vēlos saņemt atbildi \nE-pasts\nPasts" //sadly not this time...
        };

        public List<string> errorStrings = new List<string> //form was great at creating TypeErrors so this might come in handy
        {
        "SyntaxError",
        "EvalError",
        "ReferenceError",
        "RangeError",
        "TypeError",
        "URIError"
        };

        public List<string> correctInput = new List<string> //If it only was not in TestConfiguration.
        {
        "Test Tester",
        "11111111-11111",
        "something",
        "21111111",
        "test@test.lv",
        "test address"
         };
    }
}
