using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Data.Exceptions {
    public class ValidationException : FaultException {

        public ValidationException( string message ): base(message){

        }

    }
}
