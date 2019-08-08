using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;

namespace DockPanel.PowershellFunctions
{
    class PowershellComputerInformation
    {

        public string GetComputerObject(string computer, string computerProperty)
        {
            PowerShell CIM_ComputerSystem = PowerShell.Create()
                .AddCommand("Get-CimInstance")
                .AddParameter("ClassName", "CIM_ComputerSystem")
                .AddParameter("ComputerName",computer);
            PowerShell Win32_LogicalDisk = PowerShell.Create()
                .AddCommand("Get-CimInstance")
                .AddParameter("ComputerName", computer)
                .AddParameter("ClassName", "Win32_LogicalDisk");
                



            IAsyncResult asyncCIM_ComputerSystem = CIM_ComputerSystem.BeginInvoke();
            IAsyncResult asyncWin32_LogicalDisk = Win32_LogicalDisk.BeginInvoke();


            foreach (PSObject item in CIM_ComputerSystem.EndInvoke(asyncCIM_ComputerSystem))
            {
                computer = item.Members[computerProperty].Value.ToString();
            }


            return computer; 
        }

        public string GetComputerName(string computer)
        {
            /*PowerShell ps = PowerShell.Create()
                .AddCommand("Get-CimInstance")
                .AddParameter("ClassName", "CIM_ComputerSystem")
                .AddParameter("ComputerName",computer);

            IAsyncResult async = ps.BeginInvoke();

            
            foreach (PSObject result in ps.EndInvoke(async))
            {
                  computer = result.Members["Name"].Value.ToString();
            }

            return computer;
        */

            PowerShell ps = PowerShell.Create()
                .AddCommand("Get-CimInstance")
                .AddParameter("ClassName", "CIM_ComputerSystem")
                .AddParameter("ComputerName", computer);


            PSObject result = ps.Invoke().First();
            return result.Members["Name"].Value.ToString();
        }

    }
}
