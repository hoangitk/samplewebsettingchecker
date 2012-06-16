using System;
using System.Collections.Generic;
using System.Web;

namespace ECadena.Install
{
    public class CheckDotNet : ITask
    {
        public string Id
        {
            get { return "task3"; }
        }

        public TaskResult Run()
        {
            TaskResult result = new TaskResult();

            result.Message = string.Format("<ul><li>{0}</li></ul>", Environment.Version);

            if (Environment.Version.Major >= 2)
            {
                result.IsSuccess = true;                
            }
            else
            {
                result.IsSuccess = false;
            }

            return result;
        }
    }
}