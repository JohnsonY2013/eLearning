using System.Runtime.Serialization;

namespace WCF.Exception.Services
{
    [DataContract]
    public class MathError
    {
        private string _operation;
        private string _errorMessage;

        public MathError(string operation, string errorMessage)
        {
            this._operation = operation;
            this._errorMessage = errorMessage;
        }

        [DataMember]
        public string Operation
        {
            get { return _operation; }
            set { _operation = value; }
        }

        [DataMember]
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }
    }
}
