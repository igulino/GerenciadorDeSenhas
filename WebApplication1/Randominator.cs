namespace RandomPos
{
using System.Runtime;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class Randominator
{ 
    private static char[] Motor1 = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j'];
    private static char[] Motor2 = ['k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't'];

    public static void randomize(List<int> result){
        
      
        string a = string.Join(", ", result);
        System.Console.WriteLine("aaaa: " + a);
    }
}


public class Desserilize {
     public static async Task<List<int>> A2(HttpContext context)
        {
            using var reader = new StreamReader(context.Request.Body);
            var body = await reader.ReadToEndAsync();
            var coordinates = JsonSerializer.Deserialize<List<int>>(body);
            
            return coordinates ?? new List<int>();
        }
}

public class invLogic{
    
}

public class User
{
    public List<int> InfoSausage { get; set; }
}


    
}