namespace Calculator
{
    public partial class Calculator : Form
    {
        #region Private Variables

        private Double Result_Value = 0;
        private String Operator_Performed = " ";
        private bool PerformedOp = false;

        #endregion Private Variables

        public Calculator()
        {
            InitializeComponent();
        }

        #region Form Events

        private void Calculator_Resize(object sender, EventArgs e)
        {
            // Prevent the form from being resized
            this.CancelResize();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == "0" || PerformedOp)
                txtDisplay.Clear();

            PerformedOp = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!txtDisplay.Text.Contains("."))
                    txtDisplay.Text += button.Text;
            }

            else
                txtDisplay.Text += button.Text;
        }

        private void btnOperation_Click(object sender, EventArgs e)
        {
            // +, -, *, / operators
            Button button = (Button)sender;

            if (Result_Value != 0)
            {
                btnEqual.PerformClick();
                Operator_Performed = button.Text;
                txtDisplay.Text = Result_Value + " " + Operator_Performed;
                PerformedOp = true;
            }
            else
            {

                Operator_Performed = button.Text;
                Result_Value = Double.Parse(txtDisplay.Text);
                txtDisplay.Text = Result_Value + " " + Operator_Performed;
                PerformedOp = true;
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            // EQUALS BUTTON
            switch (Operator_Performed)
            {
                case "+":
                    txtDisplay.Text = (Result_Value + Double.Parse(txtDisplay.Text)).ToString();
                    break;

                case "-":
                    txtDisplay.Text = (Result_Value - Double.Parse(txtDisplay.Text)).ToString();
                    break;

                case "*":
                    txtDisplay.Text = (Result_Value * Double.Parse(txtDisplay.Text)).ToString();
                    break;

                case "/":
                    txtDisplay.Text = (Result_Value / Double.Parse(txtDisplay.Text)).ToString();
                    break;

                default:
                    break;

            }
            Result_Value = Double.Parse(txtDisplay.Text);
            txtDisplay.Text = Result_Value.ToString();
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            //CLEAR ENTRY BUTTON
            txtDisplay.Text = "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            //CLEAR BUTTON
            txtDisplay.Text = "0";
            Result_Value = 0;
            txtDisplay.Text = " ";
        }

        #endregion Form Events

        #region Private Methods

        private void CancelResize()
        {
            // Set the Cancel property of the Resize event arguments to true
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(300, 200); // Set your preferred size
            this.ResumeLayout();
        }

        #endregion Private Methods
    }
}
