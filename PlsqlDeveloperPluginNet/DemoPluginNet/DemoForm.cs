using System;
using System.Windows.Forms;

namespace DemoPluginNet
{
    public partial class DemoForm : Form
    {
        private DemoPlugin plugin;

        public DemoForm()
        {
            InitializeComponent();
        }

        public void Show(DemoPlugin plugin)
        {
            this.plugin = plugin;
            Text = plugin.Name;
            Show();
        }

        private void NewSqlWindowButton_Click(object sender, EventArgs e)
        {
            plugin.CreateSqlWindow();
        }
    }
}
