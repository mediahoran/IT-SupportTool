using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Collections;

namespace DockPanel.PowershellFunctions
{
    static class PowershellComputerInformation
    {

        public static string GetComputerObject(string computer, string computerProperty)
        {

            IDictionary parameters = new Dictionary<string, string>();
            parameters.Add("ClassName", "CIM_ComputerSystem");
            parameters.Add("ComputerName", computer);
            parameters.Add("Property", "*");


            PowerShell CIM_ComputerSystem = PowerShell.Create()
                .AddCommand("Get-CimInstance")
                .AddParameters(parameters);
            /*PowerShell Win32_LogicalDisk = PowerShell.Create()
                .AddCommand("Get-CimInstance")
                .AddParameter("ComputerName", computer)
                .AddParameter("ClassName", "Win32_LogicalDisk");*/
                

            // GIT TEST

            IAsyncResult asyncCIM_ComputerSystem = CIM_ComputerSystem.BeginInvoke();
            //IAsyncResult asyncWin32_LogicalDisk = Win32_LogicalDisk.BeginInvoke();


            foreach (PSObject item in CIM_ComputerSystem.EndInvoke(asyncCIM_ComputerSystem))
            {
                computer = item.Members[computerProperty].Value.ToString();
            }


            return computer; 
        }

    }
}
