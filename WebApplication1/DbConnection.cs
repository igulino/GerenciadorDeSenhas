﻿using Newtonsoft.Json;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
namespace FirebaseMedium
{
    
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

        static HttpClient httpclient = new HttpClient();
        public async Task Insert(string PasswordName, string CaracsGenerateds){
            Data Dt = new Data(){
                PasswordName = PasswordName,
                CaracsGenerateds = CaracsGenerateds
            };
            try {
                PushResponse response = await new Connection().client.PushAsync("v1/", Dt);
            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message} stacktrace: {ex.StackTrace}");

            }
        }

        static public async Task<List<Data>> Consult(){
            try
            {
                List<Data> l1 = new List<Data>{};

                var a = await new Connection().client.GetAsync("/v1");
                string TakeA = a.Body;

                Dictionary<string, Data> dataDictionary = JsonConvert.DeserializeObject<Dictionary<string, Data>>(TakeA);

                foreach (var param in dataDictionary) {
                    Console.WriteLine($"ID: {param.Key}, PasswordName: {param.Value.PasswordName}, CaracsGenerateds: {param.Value.CaracsGenerateds}");
                    Data D1 = new Data{
                        CaracsGenerateds = param.Value.CaracsGenerateds,
                        PasswordName = param.Value.PasswordName
                    };

                    l1.Add(D1);
                }
                System.Console.WriteLine("aaaaaa: " + l1[0].PasswordName);
                return l1;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

    }
}
