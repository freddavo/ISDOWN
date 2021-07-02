using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Daemon
{
    //Maintenance
    public static class Daemon3
    {
        [FunctionName("Daemon3")]
        public static void Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
        {
            GetRequest("https://localhost:7001/api/service");
            

            List<Servico1> servicos = new List<Servico1>();

            var url1 = "https://localhost:7001/api/service";
            var httpRequest1 = (HttpWebRequest)WebRequest.Create(url1);
            var httpResponse1 = (HttpWebResponse)httpRequest1.GetResponse();

            using (var streamReader = new StreamReader(httpResponse1.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                var dadosAPI = result.Split('{');
                
                List<string> namesUnique = new List<string>();


                foreach (var x in dadosAPI)
                {
                    var cut = x.Remove(x.Length - 1, 1);
                    var servico = cut.Split(',');
                    if (servico.Length > 1)
                    {
                        var tuploName = servico[1].Replace("\"", "").Replace("}", "").Replace("]", "");
                        var tuploMaintenance = servico[2].Replace("\"", "").Replace("}", "").Replace("]", "");

                        if (tuploName.Contains("name:") & tuploMaintenance.Contains("maintenance:"))
                        {
                            if (!namesUnique.Contains(tuploName.Split("name:")[1].ToUpper()))
                            {
                                namesUnique.Add(tuploName.Split("name:")[1].ToUpper());
                                
                            }
                            Servico1 s = new Servico1(tuploName.Split("name:")[1], tuploMaintenance.Split("maintenance:")[1], "");
                            servicos.Add(s);
                        }
                    }
                }
            }

            // Adding custom code to log messages to the Azure SQL Database  
            string connectionString = "Server=tcp:isdown1.database.windows.net,1433;Initial Catalog=isdown;Persist Security Info=False;User ID=isdown1;Password=projeto.1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            // Using the connection string to open a connection
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Opening a connection
                    connection.Open();

                    var query1 = $"SELECT [ServiceName], [DataManutencao] FROM [dbo].[Manutencao]";
                    SqlCommand command1 = new SqlCommand(query1, connection);
                    var reader = command1.ExecuteReader();
                    var namesUnique = new ArrayList();
                    

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            
                            var nome = reader["ServiceName"].ToString().ToUpper();
                            var data = reader["DataManutencao"].ToString().ToUpper();
                            Servico1 s = new Servico1(nome, data, "");
                            namesUnique.Add(s);

                        }
                    }
                    reader.Close();


                    //Se estiver vazio, insere! Se não, continua!
                    for (int i = 0; i < servicos.Count(); i++)
                    {
                         
                        Servico1 servico = servicos[i];

                        bool add = true;

                        //Console.WriteLine(servico.Name + " " + servico.Maintenance);
                        foreach (Servico1 s1 in namesUnique) {
                            
                            if (s1.Name.ToLower().Equals(servico.Name.ToLower()) && s1.Maintenance.Equals(servico.Maintenance))
                            {
                                add = false;
                            }

                        }

                        if (add)
                        {
                            namesUnique.Add(servico);
                            var query = $"INSERT INTO [dbo].[Manutencao] ([ServiceName],[DataManutencao]) VALUES('{servico.Name}', '{servico.Maintenance}')";
                            SqlCommand command2 = new SqlCommand(query, connection);
                            if (command2.Connection.State == System.Data.ConnectionState.Open)
                            {
                                command2.Connection.Close();
                            }
                            command2.Connection.Open();
                            command2.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.LogError(e.ToString());
            }

            async static void GetRequest(string url)
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync(url))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string mycontent = await content.ReadAsStringAsync();
                            //Console.WriteLine(mycontent);
                        }
                    }
                }
            }
        }
    }
}
