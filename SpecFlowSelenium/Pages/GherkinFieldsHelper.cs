using System.Xml;

namespace SpecFlowSelenium.Pages
{
    public class GherkinFieldsHelper
    {
        const string XmlPath = @"C:\ZaplifyUserCredencials.xml";

        public static string GetGherkinObject(string gObject)
        {
            return gObject switch
            {
                "Login Page" => "https://staging.app.zaplify.com/login",
                "Zaplify Main Page" => "https://zaplify.com/",
                "Good Syntax Email" => "GoodEmail@test.com",
                "Bad Syntax Email" => "IncorrectEmail",
                "Invalid email" => "Invalid email address",
                "Wrong Password" => "WrongPassword",
                "Registred User" => GetNodeValue("Username"),
                "Registed User Pwd" => GetNodeValue("Password"),
                "6 digit password" => "123456",
                "5 digit password" => "12345",
                "To many invalid info" => "Too many invalid requests, please try again later",
                "Short password info" => "Your password must contain at least 6 characters",
                "No password info" => "You must type in a password",
                "Required" => "Required",
                "Welcome back" => "Welcome back",
                "Efficient day" => "Let’s have an efficient day. Log in to keep up with new opportunties.",
                _ => throw new NotImplementedException($"\"{gObject}\" is not implemented on Gherkin fields List"),
            };
        }

        public static string GetNodeValue(string nodeName)
        {
            XmlDocument xmlDoc = new();
            if(!File.Exists(XmlPath))
                Console.WriteLine("Config file missing.");

            xmlDoc.Load(XmlPath);
            XmlNodeList? xnList = xmlDoc.SelectNodes($"root/UserCredencials/{nodeName}");

            return xnList.OfType<XmlNode>()
                         .First().InnerText;
        }
    }
}
