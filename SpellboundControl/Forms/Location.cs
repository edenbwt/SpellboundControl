using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpellboundControl;
using SpellboundControl.Forms;


namespace SpellboundControl.Forms
{
    public partial class Location : Form
    {
        public Location()
        {
            InitializeComponent();
        }


        public void SetLongLatt(String Long, String Latt)
        {
            Long_data.Text = Long;
            Lat_Data.Text = Latt;

        }
    }
}
