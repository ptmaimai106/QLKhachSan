using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKhachSan
{

   
    public partial class Thoat : UserControl
    {
  
        public Thoat()
        {
            InitializeComponent();
            
         }
    
    
        private void huy_Click(object sender, EventArgs e)
        {
            this.Hide();
       
        }

        private void ok_Click(object sender, EventArgs e)
        {
            Home home = (Home)this.Parent;
            home.Close();
        }
    }
}
