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
        /// <summary>
        /// 自販機ロジック
        /// </summary>
        IVending machine = new VendingMachine();

        public VendingForm()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            string[] moneyKinds = Enum.GetNames(typeof(MoneyKind));

            cmbMoney.DataSource = moneyKinds;
        }

        private void Coke_Click(object sender, EventArgs e)
        {
            BuyDrink(DrinkKind.COKE);
        }

        private void Tea_Click(object sender, EventArgs e)
        {
            BuyDrink(DrinkKind.TEA);
        }

        private void Cider_Click(object sender, EventArgs e)
        {
            BuyDrink(DrinkKind.CIDER);
        }

        private void BuyDrink(DrinkKind kind)
        {
            Drink drink = machine.BuyDrink(kind);

            if (drink == null)
            {
                MessageBox.Show($"買えませんでした\n入金金額：{machine.DisplayCache()}");
                return;
            }

            MessageBox.Show($"{drink.Kind.GetEnumDescription()}を買いました");

            lblMoney.Text = machine.DisplayCache().ToString();
        }

        private void btnPut_Click(object sender, EventArgs e)
        {
            string moneyName = cmbMoney.SelectedItem.ToString();

            if (moneyName == "FIVE_HUNDRED")
                machine.PutMoney(MoneyKind.FIVE_HUNDRED);

            lblMoney.Text = machine.DisplayCache().ToString();

        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Change moneys = machine.ReturnChange();

            MessageBox.Show($"{moneys.Amount()}を返しました");

            lblMoney.Text = machine.DisplayCache().ToString();

        }
    }
}
