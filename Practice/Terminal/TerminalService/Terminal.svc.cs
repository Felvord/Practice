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
                       return Help(str);
                    }
                    break;
                case "showstatus":
                    {
                       Showstatus(str);
                    }
                    break;
                case "store <N>":
                    {
                        Store(str);
                    }
                    break;
                case "free <N> <H_ID>":
                    {
                        Free(str);
                    }
                    break;
                case "exit":
                    {
                       Environment.Exit(0);
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

        public string Help(string help)
        {
            help = @"1. help – отображение отформатированной справки по всем поддерживаемым командам
2. showstatus  – отображение отформатированной таблицы загруженности всех ангаров на всех площадках склада
3. store <N> – разместить N контейнеров на складе, N – натуральное число
4. free <N> <H_ID> – выгрузить N контейнеров из ангара H_ID на складе, N – натуральное число
5. exit  – завершение работы";
            return help;
        }
        public void Exit()
        {
           Environment.Exit(0);
        }
        public void Showstatus(string show)
        {
            storageEntities storage = new storageEntities();
            List<hangar> list = storage.hangar.ToList();
            show = "Номер платформы-------Имя ангара-------Вмещаемость ангара------Сколько мест занято\n";
            
            foreach (hangar item in list)
            {
                Console.WriteLine("TEST {0}",item.hangarName);
            }
            
               // return show;
        }
        public string Store(string store)
        {
            storageEntities storage = new storageEntities();
            storage.SaveChanges();
            return store;
        }
        public string Free(string free)
        {
            storageEntities storage = new storageEntities();
            storage.SaveChanges();
            return free;
        }
    }
}