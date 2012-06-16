using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace ECadena.Install
{    
    public class TaskResult
    {
        private bool _isSuccess;

        public bool IsSuccess
        {
            get { return _isSuccess; }
            set { _isSuccess = value; }
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public TaskResult()
        {
            _isSuccess = false;
            _message = string.Empty;
        }

        public TaskResult(bool isSuccess, string message)
        {
            _isSuccess = isSuccess;
            _message = message;
        }
    }
}
