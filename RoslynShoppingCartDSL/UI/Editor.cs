
namespace RoslynShoppingCartDSL.UI {
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using FastColoredTextBoxNS;

    public partial class Editor : Form {
        private readonly FastColoredTextBox _txtSrcCode;
        private readonly TextStyle _blueStyle;
        private readonly AutocompleteMenu _popupMenu;

        public Editor() {
            InitializeComponent();

            _blueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);

            _txtSrcCode = new FastColoredTextBox {
                Font = new Font("Consolas", 11),
                Dock = DockStyle.Fill
            };
            _txtSrcCode.TextChanged += (s, e) => PPLSyntaxHighlight(e);
            _txtSrcCode.SelectionChangedDelayed += (s, e) => SelectionDelayed();
            _txtSrcCode.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Space)
                    if (e.Control) {
                        _popupMenu.Show(true);
                        e.Handled = true;
                    }
            };

            _popupMenu = new AutocompleteMenu(_txtSrcCode) {
                MinFragmentLength = 100,
                AllowTabKey = true
            };

            _popupMenu.Items.ImageList = iconsList;

            _popupMenu.Items.SetAutocompleteItems(
                new List<AutocompleteItem> {
                    //operators
                    new AutocompleteItem("when"),
                    new AutocompleteItem("and"),
                    new AutocompleteItem("or"),
                    //conditions
                    new AutocompleteItem("is_a_bad_credit_customer",1),
                    new AutocompleteItem("order_ammount_is",1),
                    new AutocompleteItem("is_a_good_credit_customer",1),
                    new AutocompleteItem("is_international_order",1),
                    //actions                   
                    new AutocompleteItem("add_shipping_fee",0),                    
                    new AutocompleteItem("apply_discount",0), 
                    new AutocompleteItem("block_the_order",0),
                });

            Controls.Add(_txtSrcCode);
        }

        static RegexOptions RegexCompiledOption {
            get {
                return PlatformType.GetOperationSystemPlatform() == Platform.X86
                    ? RegexOptions.Compiled : RegexOptions.None;
            }
        }

        private void SelectionDelayed() {
        }

        private void PPLSyntaxHighlight(TextChangedEventArgs e) {
            e.ChangedRange.SetStyle(_blueStyle,
                //available actions
                @"\b(when|and|or)\b",
                RegexOptions.IgnoreCase | RegexCompiledOption);
        }
    }
}
