using System;
using System.Collections.Generic;
using System.Web;

namespace ECadena.Install
{
    public class CheckIISConfiguration : ITask
    {
        public string Id
        {
            get { return "task4"; }
        }

        public TaskResult Run()
        {
            TaskResult result = new TaskResult();

            var currentLevel = GetCurrentTrustLevel();

            result.Message = string.Format("<ul><li>.Net Trust Level: {0}</li><li>Identity: {1}</li></ul>",
                currentLevel,
                System.Security.Principal.WindowsIdentity.GetCurrent().Name); 

            if (currentLevel == AspNetHostingPermissionLevel.Unrestricted ||
                currentLevel == AspNetHostingPermissionLevel.High)
            {
                result.IsSuccess = true;
            }
            else
            {
                result.IsSuccess = false;
            }

            return result;
        }

        /// <summary>
        /// Get current web application's Trust Level
        /// </summary>
        /// <returns>AspNetHostingPermissionLevel</returns>
        private AspNetHostingPermissionLevel GetCurrentTrustLevel()
        {
            AspNetHostingPermissionLevel[] levels = new []
            {
                AspNetHostingPermissionLevel.Unrestricted,
                AspNetHostingPermissionLevel.High,
                AspNetHostingPermissionLevel.Medium,
                AspNetHostingPermissionLevel.Low,
                AspNetHostingPermissionLevel.Minimal 
            };

            foreach (var trustLevel in levels)
            {
                try
                {
                    new AspNetHostingPermission(trustLevel).Demand();
                }
                catch (System.Security.SecurityException)
                {
                    continue;
                }

                return trustLevel;
            }

            return AspNetHostingPermissionLevel.None;
        }
    }
}