
using FireSharp.Config;
using FireSharp.Interfaces;
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
            AuthSecret = "8X8AVZ0tTbKcIZJJPtbHnXoitTdstbDoUm4ub3Lh",
            BasePath = "https://gerenciadordesenhapapito-default-rtdb.firebaseio.com/"
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
            System.Console.WriteLine(PasswordName +" "+ CaracsGenerateds);
            Data Dt = new Data(){
                PasswordName = PasswordName,
                CaracsGenerateds = CaracsGenerateds
            };
            try {
                
               Connection a = new Connection();
               a.client.Set("/Registrar", Dt);
        
            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message} stacktrace: {ex.Data}");

            }
        }

    }
}
