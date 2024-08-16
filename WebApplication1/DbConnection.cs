using FireSharp;
using RandomPos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
namespace FirebaseMedium
{
    
    static class Program {
        static async Task Main(){
            
            Crud ins = new Crud();
            await ins.Insert("Netflix", "Ks@e39Lk2f@a01");
        }
    }
    public class Connection{
        //firebase connection Settings
        public IFirebaseConfig FbConfig = new FirebaseConfig()
        {
            AuthSecret = "WTv8rerSHJvJ4J4tbGlNxziWAklYN24J3x9Q60Pa",
            BasePath = "https://gerenciadordesenhapapito-default-rtdb.firebaseio.com/"
        };

        public IFirebaseClient client;
        //Code to warn console if class cannot connect when called.
        public Connection()
        {
            try
            {
                client = new FireSharp.FirebaseClient(FbConfig);
            }
            catch (Exception)
            {
                Console.WriteLine("error");
            }
        }
    }

    public class Data{
        public string CaracsGenerateds;
        public string PasswordName;
    }
    
    public partial class Crud{
        public Connection BD = new Connection();
        public async Task Insert(string PasswordName, string CaracsGenerateds){
            Data Dt = new Data(){
                PasswordName = PasswordName,
                CaracsGenerateds = CaracsGenerateds
            };

            BD.client.Push("/Registrar", Dt);
        }

    }
}
