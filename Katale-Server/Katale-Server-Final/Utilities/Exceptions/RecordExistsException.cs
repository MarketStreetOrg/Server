using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Katale_Server_Final.Utilities.Exceptions
{
    [Serializable]
    public class RecordExistsException : Exception
    {
        private string message = "Record Already Exists in DB";

        public RecordExistsException(string record) 
            : base(String.Format("Record '{0}' already exists in the DB",record))
        {

        }

        public RecordExistsException(string message,Exception inner) : base(message, inner) { }
    }
}