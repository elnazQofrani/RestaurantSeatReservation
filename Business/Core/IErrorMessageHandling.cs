using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Enums;
namespace Business.Core
{
    public interface IErrorMessageHandling
    {

        string GetMessage(StatusMessage status, StatusOperation operation);

    }
}
