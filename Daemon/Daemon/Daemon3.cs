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
    public static class Daemon3
    {
        [FunctionName("Daemon3")]
        public static void Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
        {
            GetRequest("https://localhost:6001/api/service/v1");

            List<Servico1> servicos = new List<Servico1>();

            var url1 = "https://localhost:6001/api/service/v1";

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
                    if (servico.Length > 2)
                    {
                        var tuploName = servico[0].Replace("\"", "").Replace("}", "");
                        var tuploState = servico[1].Replace("\"", "").Replace("}", "");
                        var tuploPath = servico[2].Replace("\"", "").Replace("}", "");

                        if (tuploName.Contains("name:") & tuploState.Contains("maintenance:"))
                        {
                            if (!namesUnique.Contains(tuploName.Split("name:")[1].ToUpper()))
                            {
                                namesUnique.Add(tuploName.Split("name:")[1].ToUpper());
                                Servico1 s = new Servico1(tuploName.Split("name:")[1], tuploState.Split("maintenance:")[1]);
                                servicos.Add(s);
                            }
                            else if (tuploState.Split("maintenance:")[1].Equals("30 min"))
                            {
                                Console.WriteLine(tuploName.Split("name:")[1].ToUpper());

                                foreach (var s in servicos)
                                {
                                    if (s.Name.ToUpper().Equals(tuploName.Split("name:")[1].ToUpper()))
                                    {
                                        Console.WriteLine(tuploName.Split("name:")[1].ToUpper());

                                        s.Maintenance = tuploState.Split("maintenance:")[1];
                                        //s.Path = tuploPath.Split("Path:")[1];


                                    }
                                }
                            }
                        }

                    }
                }
                //Console.WriteLine("-");
                //Console.WriteLine(servicos.Count());
                //Console.WriteLine("-");
                //Console.WriteLine(result);    
            }

            //fazer o split dos dados recebidos pela API

            //-----------------------------------------------------------------------------------------------------//
            // Adding custom code to log messages to the Azure SQL Database  
            string connectionString = "Server=tcp:isdown.database.windows.net,1433;Initial Catalog=isdown;Persist Security Info=False;User ID=isdown;Password=projeto.1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            // Using the connection string to open a connection
            /*try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Opening a connection
                    connection.Open();

                    var query1 = $"SELECT [Name], [Maintenance], [Tempo] FROM [id].[Servico]";
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
                        Servico1 servico = servicos[i];

                        if (!namesUnique.Contains(servico.Name.ToUpper()))
                        {
                            namesUnique.Add(servico.Name.ToUpper());
                            var query = $"INSERT INTO [id].[Servico] ([Name], [Maintenance], [Tempo]) VALUES('{servico.Name}', '{servico.Maintenance}', '{servico.Tempo}')";
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
                            var query3 = $"UPDATE [id].[Servico] SET [Maintenance] = '{servico.Maintenance}', [Tempo] = '{servico.Tempo}' WHERE Name = '{servico.Name}' ";
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

        }*/

            async static void GetRequest(string url)
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync(url))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string mycontent = await content.ReadAsStringAsync();
                            Console.WriteLine(mycontent);
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
