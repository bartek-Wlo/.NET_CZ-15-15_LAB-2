using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleAppAPI
{
public class APITest {
    public HttpClient client ;
    public async Task GetData () {
        client = new HttpClient () ;
        string call = "https://dummy-json.mock.beeceptor.com/continents";
        string response = await client.GetStringAsync ( call );
        Console . WriteLine ( response );
        }
    }
    internal class Program
    {
        static void Main ( string [] args )
        {
        APITest t = new APITest() ;
        t.GetData().Wait() ;
        }
}
}