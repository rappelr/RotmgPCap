using System.Windows.Forms;

namespace RotmgPCap.Forms.Components
{
    public class NumericTextbox : TextBox
    {

        public NumericTextbox() : base() => KeyPress += new KeyPressEventHandler(HandleKeyPress);

        private void HandleKeyPress(object s, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
