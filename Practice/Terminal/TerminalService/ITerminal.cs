using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TerminalService
{
    [ServiceContract]
    public interface ITerminal
    {

        [OperationContract]
        string TestConnection();

        [OperationContract]
        string GetCommand(string str);

        [OperationContract]
        string ComHelp(string help);

    }
}