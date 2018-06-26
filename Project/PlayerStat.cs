using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
namespace Project
{
    public partial class PlayerStat : MetroFramework.Forms.MetroForm
    {
        string x;
        public PlayerStat()
        {
            InitializeComponent();
            Displaydata();
        }
        string s;
        void Displaydata()
        {
            csDBOperator obj = new csDBOperator();
            dataGridView1.DataSource = obj.mViewData(out x).DefaultView;
            obj.mcbai(out s);
            label2.Text = s;
        }
        
    }
}
