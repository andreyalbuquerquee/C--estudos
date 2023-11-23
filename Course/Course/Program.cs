
namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> cookies = new Dictionary<string, string>();

            cookies["user"] = "Maria";
            cookies["email"] = "maria@gmail.com";
            cookies["phone"] = "99775522";
            cookies["phone"] = "76545451";

            Console.WriteLine(cookies["phone"]);

            cookies.Remove("email");

            Console.WriteLine(cookies.ContainsKey("email"));

            foreach (KeyValuePair<string, string> item in cookies) 
            {
                Console.WriteLine(item.Key + " : " + item.Value);
            }
        }
    }
}
