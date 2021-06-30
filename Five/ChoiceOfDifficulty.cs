using System.Windows.Forms;

namespace Five
{
    public partial class ChoiceOfDifficulty : Form
    {
        public ChoiceOfDifficulty()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Передает значение сложности.
        /// </summary>
        private void ChoiceDiff(object sender, System.EventArgs e)
        {
            string choiceDiff = checkedListBox1.SelectedIndex.ToString();
            Form1 form = new Form1(int.Parse(choiceDiff) + 3);
            Hide();
            form.ShowDialog();
            Show();
        }

        /// <summary>
        /// Убирает значение, если было выделено больше двух режимов
        /// </summary>
        private void checkedListBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count >= 1)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    checkedListBox1.SetItemChecked(i, false);
                checkedListBox1.SetItemChecked(checkedListBox1.SelectedIndex, true);
            }
        }
    }
}
