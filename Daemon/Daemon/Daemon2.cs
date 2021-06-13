using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Daemon
{
    //Historico
    public static class Daemon2
    {
        [FunctionName("Daemon2")]
        public static void Run([TimerTrigger("0 */2 * * * *")] TimerInfo myTimer, ILogger log)
        {
            List<Servico> servicos = new List<Servico>();
            List<Historico> historicos = new List<Historico>();
            //Console.WriteLine("-------");

            //ACCESS TOKEN (POST)
            var url = "https://wso2-gw.ua.pt/token?grant_type=client_credentials&state=1234567890&scope=openid";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.ContentType = "application/x-www-form-urlencoded";
            httpRequest.Headers["Authorization"] = "Basic MXRCUEZCWjJmWV8yZElHZlowaERUWWhURmZvYTpWV21rOHRwWUNmWUYzYlN4N1pfa2tUX1F3Zjhh";
            httpRequest.Headers["Content-Length"] = "0";


            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                //OBTER ACCESS TOKEN
                var result = streamReader.ReadToEnd();
                char[] chars = result.ToCharArray();

                //for (int i = 17; i < 53; i++)
                //    Console.Write(chars[i]);
                myfunc(chars);
            }


            //GET WEBSITES
            void myfunc(char[] chars)
            {
                var url1 = "https://wso2-gw.ua.pt/scom/v1.0/WebSites";

                var httpRequest1 = (HttpWebRequest)WebRequest.Create(url1);

               // Console.WriteLine();
               // Console.WriteLine();
               // Console.WriteLine();

                string resultado0 = "Bearer ";
                char resultado = chars[17];
                char resultado1 = chars[18];
                char resultado2 = chars[19];
                char resultado222 = chars[20]; char resultado3 = chars[21]; char resultado4 = chars[22]; char resultado5 = chars[23];
                char resultado6 = chars[24]; char resultado7 = chars[25]; char resultado8 = chars[26]; char resultado9 = chars[27];
                char resultado10 = chars[28]; char resultado11 = chars[29]; char resultado12 = chars[30]; char resultado13 = chars[31];
                char resultado14 = chars[32]; char resultado15 = chars[33]; char resultado16 = chars[34]; char resultado17 = chars[35];
                char resultado18 = chars[36]; char resultado19 = chars[37]; char resultado20 = chars[38]; char resultado21 = chars[39];
                char resultado22 = chars[40]; char resultado23 = chars[41]; char resultado24 = chars[42]; char resultado25 = chars[43];
                char resultado26 = chars[44]; char resultado27 = chars[45]; char resultado28 = chars[46]; char resultado29 = chars[47];
                char resultado30 = chars[48]; char resultado31 = chars[49]; char resultado32 = chars[50]; char resultado33 = chars[51];
                char resultado34 = chars[52]; char resultado35 = chars[53];


                httpRequest1.Headers["Authorization"] = resultado0 + resultado.ToString() + resultado1.ToString() + resultado2.ToString() + resultado222.ToString()
                     + resultado3.ToString() + resultado4.ToString() + resultado5.ToString() + resultado6.ToString() + resultado7.ToString()
                     + resultado8.ToString() + resultado9.ToString() + resultado10.ToString() + resultado11.ToString() + resultado12.ToString()
                     + resultado13.ToString() + resultado14.ToString() + resultado15.ToString() + resultado16.ToString() + resultado17.ToString()
                     + resultado18.ToString() + resultado19.ToString() + resultado20.ToString() + resultado21.ToString() + resultado22.ToString()
                     + resultado23.ToString() + resultado24.ToString() + resultado25.ToString() + resultado26.ToString() + resultado27.ToString()
                     + resultado28.ToString() + resultado29.ToString() + resultado30.ToString() + resultado31.ToString() + resultado32.ToString()
                     + resultado33.ToString() + resultado34.ToString();

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

                            if (tuploName.Contains("Name:") & tuploState.Contains("HealthState:")
                                & tuploPath.Contains("Path:"))
                            {
                                if (!namesUnique.Contains(tuploName.Split("Name:")[1].ToUpper()))
                                {
                                    namesUnique.Add(tuploName.Split("Name:")[1].ToUpper());
                                    Servico s = new Servico(tuploName.Split("Name:")[1], tuploState.Split("HealthState:")[1],
                                        tuploPath.Split("Path:")[1]);
                                    servicos.Add(s);
                                }

                            }

                        }
                    }
                    //Console.WriteLine("-");
                    //Console.WriteLine(servicos.Count());
                    //Console.WriteLine("-");
                    //Console.WriteLine(result);    
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

                    var query1 = $"SELECT [Name], [Health_State] FROM [id].[Admin]";
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


                    /*var query4 = $"SELECT * FROM [id].[Historico]";
                    SqlCommand command4 = new SqlCommand(query4, connection);
                    var reader4 = command4.ExecuteReader();
                    var namesUnique4 = new ArrayList();

                    if (reader4.HasRows)
                    {
                        while (reader4.Read())
                        {
                            namesUnique4.Add(reader4["NomeServico"].ToString().ToUpper());
                        }
                    }

                    reader4.Close();*/

                    for (int i = 0; i < servicos.Count(); i++)
                    {
                        Servico servico = servicos[i];
                        
                        if(servico.HealthState.Equals("Error")) {
                            if (!namesUnique.Contains(servico.Name.ToUpper()))
                            {
                                namesUnique.Add(servico.Name.ToUpper());
                                var query = $"INSERT INTO [id].[Admin] ([Name],[Health_State]) VALUES('{servico.Name}', '{servico.HealthState}')";
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
                                var query3 = $"UPDATE [id].[Admin] SET [Health_State] = '{servico.HealthState}' WHERE Name = '{servico.Name}' ";
                                SqlCommand command3 = new SqlCommand(query3, connection);
                                if (command3.Connection.State == System.Data.ConnectionState.Open)
                                {
                                    command3.Connection.Close();
                                }
                                command3.Connection.Open();
                                command3.ExecuteNonQuery();
                            }

                            /*if (servico.HealthState.Equals("Error"))
                            {
                                var query5 = $"SELECT * FROM [id].[Historico]";
                                SqlCommand command5 = new SqlCommand(query5, connection);
                                var reader5 = command5.ExecuteReader();
                                var namesError = new ArrayList();


                                if (reader5.HasRows)
                                {
                                    while (reader5.Read())
                                    {
                                        if ((reader5["Resolvido"].Equals("N") || reader5["Falha"].ToString().ToUpper().Contains("PERMANENTE")) & !namesError.Contains(reader5["NomeServico"].ToString().ToUpper()))
                                        {
                                            namesError.Add(reader5["NomeServico"].ToString().ToUpper());
                                        }
                                    }
                                }

                                reader5.Close();


                                if (!namesError.Contains(servico.Name.ToUpper()))
                                {
                                    DateTime time = DateTime.Now;
                                    string format = "yyyy-MM-dd HH:mm:ss";

                                    namesError.Add(servico.Name.ToUpper());
                                    var query = $"INSERT INTO [id].[Historico] ([NomeServico],[DataFalha], [Resolvido]) VALUES('{servico.Name}', '{time.ToString(format)}', '{'N'}')";
                                    SqlCommand command2 = new SqlCommand(query, connection);
                                    if (command2.Connection.State == System.Data.ConnectionState.Open)
                                    {
                                        command2.Connection.Close();
                                    }
                                    command2.Connection.Open();
                                    command2.ExecuteNonQuery();

                                }*/

                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.LogError(e.ToString());
            }
        }
    }
}
