using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace AutoMir2022
{
    public partial class MainMenu : Form
    {
        
        public MainMenu()
        {
       

        InitializeComponent();
           
            // TestConnection();
        
        }

        
        private void retailButton_Click(object sender, EventArgs e)
        {
            var retail = new retail();
            retail.Show();
            //this.Close();
        }
        
                
     
    }
}
