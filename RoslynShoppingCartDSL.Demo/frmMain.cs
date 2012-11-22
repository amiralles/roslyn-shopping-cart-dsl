
namespace RoslynShoppingCartDSL.Demo {
    using System.Windows.Forms;
    using UI;

    public partial class frmMain : Form {
        public frmMain() {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            menuScriptsNew.Click += delegate {
                using (var editor = new Editor()) {
                    editor.ShowDialog();
                }
            };
        }
    }
}
