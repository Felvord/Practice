using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TerminalService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Terminal : ITerminal
    {
        public string testConnection()
        {
            return "OK";
        }

        public string getCommand(string str)
        {
            switch (str)
            {
                case "!help":
                    {
                        str ="";
                        string[] commands = new string[]
                            {
                                "1. !help\n",
                                "2. !showstatus\n",
                                "3. !store\n",
                                "4. !free\n",
                                "5. !exit\n",
                            };
                        foreach (var line in commands)
                            str += line;
                            return str;
                    } 
                     break;
                case "!showstatus":
                    {
                        //
                        return str;
                    }
                    break;
                case "!store":
                    {
                        //
                        return str;
                    }
                    break;
                case "!free":
                    {
                        //
                        return str;
                    }
                    break;
                case "!exit":
                    {
                        //
                        return str;
                    }
                    break;
                default:
                    {
                       Console.Write("             ");

                    }
                    break;
            }

            return "ERROR COMMAND";
        }
    }
}
