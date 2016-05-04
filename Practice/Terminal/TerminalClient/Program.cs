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
            // создаём клиент сервиса
            TerminalClient client = new TerminalClient();
            Console.Title = "TerminalConsole";
            

            try
            {
                // проверка соединения
                Console.Write("Проверка соединения с сервисом... ");
                if (!string.Equals(client.TestConnection(), "OK", StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new Exception("Проверка соединения не удалась");
                }
                Console.Write("OK\n");
                Console.WriteLine("Welcome Terminal.Type 'help' for help.");
                string value = Console.ReadLine();
                Console.WriteLine(client.GetCommand(value));

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
