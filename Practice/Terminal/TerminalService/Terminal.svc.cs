using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TerminalService
{
    public class Terminal : ITerminal
    {
        public string TestConnection()
        {
            return "OK";
        }

        public string GetCommand(string str)
        {
            switch (str)
            {
                case "help":
                    {
                        return ComHelp(str);
                    }
                    break;
                case "showstatus":
                    {
                        return str;
                    }
                    break;
                case "store":
                    {
                        return str;
                    }
                    break;
                case "free":
                    {
                        return str;
                    }
                    break;
                case "exit":
                    {
                        return str;
                    }
                    break;
                default:
                    {
                        Console.Write("Введите команду             ");

                    }
                    break;
            }

            return "ERROR COMMAND";
        }

        public string ComHelp (string help)
        {
            help = "";
            string[] commands = new string[]
             {
                        "1. help – отображение отформатированной справки по всем поддерживаемым командам\n",
                        "2. showstatus  – отображение отформатированной таблицы загруженности всех ангаров на всех площадках склада\n",
                        "3. store <N> – разместить N контейнеров на складе, N – натуральное число\n",
                        "4. free <N> <H_ID> – выгрузить N контейнеров из ангара H_ID на складе, N – натуральное число\n",
                        "5. exit  – завершение работы\n",
              };
            foreach (var line in commands)
                help += line;
            return help;
        }
    }
}