using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Daemon
{
    //Time
    public static class Daemon4
    {
        [FunctionName("Daemon4")]
        public static void Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
        {
            
            GetRequest1("https://localhost:6001/api/time/v1");

            List<Servico2> servicos = new List<Servico2>();

            var url1 = "https://localhost:6001/api/time/v1";
            var httpRequest1 = (HttpWebRequest)WebRequest.Create(url1);
            var httpResponse1 = (HttpWebResponse)httpRequest1.GetResponse();

            using (var streamReader = new StreamReader(httpResponse1.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                var dadosAPI = result.Split('{');

                List<string> namesUnique = new List<string>();

                foreach (var x in dadosAPI)
                {
                    //Console.WriteLine(x);
                    var cut = x.Remove(x.Length - 1, 1);
                    var servico = cut.Split(',');
                    if (servico.Length > 1)
                    {
                        var tuploName = servico[1].Replace("\"", "").Replace("}", "").Replace("]", "");
                        var tuploTempo = servico[2].Replace("\"", "").Replace("}", "").Replace("]", "");

                        var time = tuploTempo.Split("tempo:")[1]; //01:40

                        
                        var dataAPIToTime = TimeSpan.Parse(time); //01:40:00
                        Console.WriteLine(dataAPIToTime);
                        
                        var timeDecrement = dataAPIToTime - TimeSpan.FromMinutes(30); //01:39:00
                        Console.WriteLine(timeDecrement);

                       
                        Console.WriteLine();
                        Console.WriteLine();

                        if (tuploName.Contains("name:") & tuploTempo.Contains("tempo:"))
                        {
                            if (!namesUnique.Contains(tuploName.Split("name:")[1].ToUpper()))
                            {
                                namesUnique.Add(tuploName.Split("name:")[1].ToUpper());

                                Servico2 s = new Servico2(tuploName.Split("name:")[1], tuploTempo.Split("tempo:")[1]);
                                servicos.Add(s); 
                            }
                        }
                    }
                }
            }

            //-----------------------------------------------------------------------------------------------------//
            // Adding custom code to log messages to the Azure SQL Database  
            string connectionString = "Server=tcp:isdown.database.windows.net,1433;Initial Catalog=isdown;Persist Security Info=False;User ID=isdown;Password=projeto.1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            // Using the connection string to open a connection
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Opening a connection
                    connection.Open();

                    var query1 = $"SELECT [Name], [Tempo] FROM [id].[Servico]";
                    SqlCommand command1 = new SqlCommand(query1, connection);
                    var reader = command1.ExecuteReader();
                    var namesUnique = new ArrayList();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            namesUnique.Add(reader["Name"].ToString().ToUpper());
                        }
                    }
                    reader.Close();


                    //Se estiver vazio, insere! Se não, continua!
                    for (int i = 0; i < servicos.Count(); i++)
                    {
                        Servico2 servico = servicos[i];

                        if (!namesUnique.Contains(servico.Name.ToUpper()))
                        {
                            namesUnique.Add(servico.Name.ToUpper());
                            var query = $"INSERT INTO [id].[Servico] ([Name],[Tempo]) VALUES('{servico.Name}', '{servico.Tempo}')";
                            SqlCommand command2 = new SqlCommand(query, connection);
                            if (command2.Connection.State == System.Data.ConnectionState.Open)
                            {
                                command2.Connection.Close();
                            }
                            command2.Connection.Open();
                            command2.ExecuteNonQuery();
                        }
                        else
                        {
                            var query3 = $"UPDATE [id].[Servico] SET [Tempo] = '{servico.Tempo}' WHERE Name = '{servico.Name}' ";
                            SqlCommand command3 = new SqlCommand(query3, connection);
                            if (command3.Connection.State == System.Data.ConnectionState.Open)
                            {
                                command3.Connection.Close();
                            }
                            command3.Connection.Open();
                            command3.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.LogError(e.ToString());
            }

            async static void GetRequest1(string url)
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync(url))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string mycontent = await content.ReadAsStringAsync();
                            //Console.WriteLine(mycontent);
                            //Console.WriteLine();
                            //Console.WriteLine();
                            //Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
