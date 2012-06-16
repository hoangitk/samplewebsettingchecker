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
    public class CheckWindowsServerVersion : ITask
    {
        private const int OS6 = 6;  // Vista, W7, W2008
        private const int OS5 = 5;  // XP, W2003
        private const int Server2003 = 2;

        #region ITask Members

        public TaskResult Run()
        {
            TaskResult result = new TaskResult();

            System.OperatingSystem osInfo = System.Environment.OSVersion;

            result.Message = string.Format("<ul><li>{0}</li></ul>", osInfo);

            if (osInfo.Version.Major == OS6 || (osInfo.Version.Major == OS5 && osInfo.Version.Minor == Server2003))
            {
                result.IsSuccess = true;
            }
            else
            {
                result.IsSuccess = false;
            }

            return result;
        }

        public string Id
        {
            get 
            {
                return "task1";
            }
        }
        #endregion
    }
}
