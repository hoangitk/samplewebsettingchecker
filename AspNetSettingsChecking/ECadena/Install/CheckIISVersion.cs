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
    public class CheckIISVersion : ITask
    {
        private string _iisVersion;

        public string IISVersion
        {
            get { return _iisVersion; }
            set { _iisVersion = value; }
        }

        public CheckIISVersion()
        {

        }

        public CheckIISVersion(string iisVersion)
        {
            _iisVersion = iisVersion;
        }

        #region ITask Members

        public string Id
        {
            get
            {
                return "task2";
            }
        }

        public TaskResult Run()
        {
            TaskResult result = new TaskResult();
            result.IsSuccess = true;
            result.Message = string.Format("<ul><li>{0}</li></ul>", IISVersion);
            
            return result;
        }

        #endregion ITask Members
    }
}