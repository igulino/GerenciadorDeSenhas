namespace RandomPos
{
using System.Runtime;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using FirebaseMedium;

public class Randominator
{ 
    
    public static List<string> FinalForm;
    public static Crud connection = new Crud();
    public static void randomize(List<int> result){
        FinalForm = new List<string>{};
        DotNetEnv.Env.Load();
        
        string? Motor1 = Environment.GetEnvironmentVariable("MOTOR1");
        string? Motor2 = Environment.GetEnvironmentVariable("MOTOR2");
        string? Motor3 = Environment.GetEnvironmentVariable("MOTOR3");
        string? Motor4 = Environment.GetEnvironmentVariable("MOTOR4");
        string? Motor5 = Environment.GetEnvironmentVariable("MOTOR5");
        string? NUM_MOTOR6 = Environment.GetEnvironmentVariable("NUM_MOTOR6");

        string a = string.Join("", result);

        var x = 0;
        
        string[] Matriz = {Motor1, Motor2, Motor3, Motor4, Motor5, NUM_MOTOR6};
        List<int> threeNum = new List<int>{};
        
        for (int i = 0; i < a.Length; i++)
        {   
            int a1, a2;
            x++;
            int charac = a.IndexOf("-");
            if (charac != -1)
            {
                a = a.Remove(charac, 1);
            }
            
            int l1 = int.Parse(a[i].ToString());
            threeNum.Add(l1);

            
            if (x == 3)
            {
                x = 0;
                
                threeNum.Sort();
                a1 = threeNum[1] - threeNum[0];
                a2 = threeNum[2] - threeNum[1];

                
                if (a1 > 5)
                {
                    a1 = 5;
                };
                if (a2 > 5)
                {
                    a2 = 5;
                };
                //System.Console.WriteLine("this is a1 e a2: " + a1 +" and " + a2);
                string RandomData = Matriz[a1];
               
                FinalForm.Add(RandomData[a2].ToString());
                
                threeNum.Clear();
            }
        }
        string resultado = string.Join("", FinalForm);
        System.Console.WriteLine("Senha gerada: " + resultado);

    }

    public static async Task Click(){

       
        string resultado = string.Join("", FinalForm);
        await connection.Insert("dsdsd", resultado);
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


}