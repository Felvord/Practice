using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleClient.ServiceTerminal;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // создадим клиент сервиса
            TerminalClient client = new TerminalClient();
            Console.Title = "TerminalConsole";
            Console.WriteLine("Welcome Terminal.Type !help for help.");

            try
            {
                // проверка соединения
                Console.Write("Проверка соединения с сервисом... ");
                if (!string.Equals(client.testConnection(), "OK", StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new Exception("Проверка соединения не удалась");
                }
                Console.Write("OK\n");
                string value = Console.ReadLine();
                Console.WriteLine(client.getCommand(value));

            }
            catch (Exception ex)
            {
                client.Abort();
                Console.Write("Error: {0}", ex.Message);
            }

            client.Close();
        }
    }
}
