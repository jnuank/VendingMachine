using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VendingMachine.Domain;
using VendingMachine.Domain.Moneys;
using VendingMachine.Utility;

namespace VendingMachine
{
    /// <summary>
    /// 自動販売機フォーム
    /// </summary>
    public partial class VendingForm : Form
    {
        public VendingForm()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            
            // Todo:ここでインスタンス化意味ないなー。
            // Enumクラスに対して、拡張するか？
            MoneyKind kind = new MoneyKind();
            string[] moneyKinds = new string[kind.Count()];
            for(int i = 0; i < kind.Count(); i++)
            {
                kind = (MoneyKind)i;
                moneyKinds[i] = kind.GetEnumDescription();             
            }

            cmbMoney.DataSource = moneyKinds;

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
