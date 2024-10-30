using Newtonsoft.Json;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
namespace FirebaseMedium
{
    
    /*public static class Program {
        public static async Task Main(){
            
            Crud ins = new Crud();
            await ins.Insert("Netflix", "Ks@e39Lk2f@a01");
        }
    }*/
    public class Connection{
        //firebase connection Settings
        public static IFirebaseConfig FbConfig = new FirebaseConfig()
        {
           
            BasePath = "https://sexo-9b749-default-rtdb.firebaseio.com/",
            AuthSecret = "f0E2IF0eATEuF8HJLOUv8LMqvHeqsHV48lEyHlsS",

        };

        public IFirebaseClient client {get; set;}
        //Code to warn console if class cannot connect when called.
        public Connection()
        {
            try
            {

                client = new FireSharp.FirebaseClient(FbConfig);
                if (client != null)
                {
                    System.Console.WriteLine("conexão bem sucedida!");
                }
               
            }
            catch (Exception)
            {
                Console.WriteLine("erro tal");
            }
        }
       
    }

    public class Data{
        public string CaracsGenerateds;
        public string PasswordName;
    }
    
    public partial class Crud{
        public async Task Insert(string PasswordName, string CaracsGenerateds){
            Data Dt = new Data(){
                PasswordName = PasswordName,
                CaracsGenerateds = CaracsGenerateds
            };
            try {
                string json = JsonConvert.SerializeObject(Dt);
                PushResponse response = await new Connection().client.PushAsync("v1/", Dt);
            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message} stacktrace: {ex.StackTrace}");

            }
        }

    }
}
