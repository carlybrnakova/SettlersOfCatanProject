using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SettlersOfCatan
{
    public partial class AcceptTradeForm : Form
    {
        TradeForm TradeForm;

        public AcceptTradeForm(TradeForm tradeForm)
        {
            this.TradeForm = tradeForm;
            InitializeComponent();
        }

        private void AcceptTradeButton_Click(object sender, EventArgs e)
        {
            this.TradeForm.makeTrade();
            this.Close();
        }

        private void DeclineTradeButton_Click(object sender, EventArgs e)
        {
            this.TradeForm.declineTrade();
            this.Close();
        }
    }
}
