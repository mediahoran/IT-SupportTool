using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Management.Automation;
using DockPanel.PowershellFunctions;

namespace DockPanel
{
    /// <summary>
    /// Interaction logic for ComputerInformation.xaml
    /// </summary>
    public partial class ComputerInformation : Page
    {
        public ComputerInformation()
        {
            InitializeComponent();
        }

        private void TextComputerInfo_MouseDown(object sender, RoutedEventArgs e)
        {
            TextComputerInfo.Clear();
        }

        private void BtnOkComputerInfo_Click(object sender, RoutedEventArgs e)
        {
            /*PowerShell ps = PowerShell.Create().AddCommand("Get-CimInstance").AddParameter("ClassName", "CIM_ComputerSystem");
            IAsyncResult async = ps.BeginInvoke();
            foreach (PSObject result in ps.EndInvoke(async))
            {
                TextComputerName.Text = result.Members["Name"].Value.ToString();
            }*/


            //PowershellComputerInformation ps1 = new PowershellComputerInformation();

            // The computers hostname
            //TextComputerName.Text = ps1.GetComputerName(TextComputerInfo.Text);

            // All the information about the whole computer object
            //TextComputerName.Text = ps1.GetComputerObject(TextComputerInfo.Text);

            TextComputerName.Text = PowershellComputerInformation.GetComputerObject(TextComputerInfo.Text, "Name");
            TextModel.Text = PowershellComputerInformation.GetComputerObject(TextComputerInfo.Text, "Model");
            TextManufacturer.Text = PowershellComputerInformation.GetComputerObject(TextComputerInfo.Text, "Manufacturer");
            TextComputerType.Text = PowershellComputerInformation.GetComputerObject(TextComputerInfo.Text, "ChassisSKUNumber");
            TextUser.Text = PowershellComputerInformation.GetComputerObject(TextComputerInfo.Text, "UserName");
            //TextInstalldate.Text = ps1.GetComputerObject(TextComputerInfo.Text, "InstallDate");





        }
    }
}
