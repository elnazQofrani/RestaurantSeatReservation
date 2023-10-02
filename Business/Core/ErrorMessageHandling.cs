using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Enums;
namespace Business.Core
{

    public class ErrorMessageHandling : IErrorMessageHandling
    {
        public ErrorMessageHandling() { 
        
        }

        public string GetMessage(StatusMessage status, StatusOperation operation)
        {
            if (StatusMessage.Successful == status) return string.Format("{0} has been done succesfully", operation);

            return string.Format("{0} faced a problem", operation);
        }
    }
}
