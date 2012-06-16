using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace ECadena.Install
{
    public partial class TestProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Collections.Generic.IList<ITask> taskes = new System.Collections.Generic.List<ITask>();

            // Padding to circumvent IE's buffer.
            Response.Write(new string('*', 256));
            Response.Flush();

            taskes.Add(new CheckWindowsServerVersion());
            taskes.Add(new CheckIISVersion(Request.ServerVariables["SERVER_SOFTWARE"]));
            taskes.Add(new CheckDotNet());
            taskes.Add(new CheckIISConfiguration());

            foreach (ITask task in taskes)
            {
                TaskResult result = task.Run();
                UpdateProgress(task.Id, result, 0);
                System.Threading.Thread.Sleep(1000);
            }
        }

        protected void UpdateProgress(string taskId, TaskResult taskResult, int percentComplete)
        {
            // Write out the parent script callback.
            Response.Write(
                String.Format("<script type=\"text/javascript\">parent.updateProgress('{0}', '{1}', '{2}', {3});</script>", 
                taskId, taskResult.IsSuccess , taskResult.Message, percentComplete));
            // To be sure the response isn't buffered on the server.    
            Response.Flush();
        }
    }

    
}
