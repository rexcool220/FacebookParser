using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace FacebookParser
{
    public partial class CommentsForm : Form
    {
        public Form1 Mainform = null;
        public CommentsForm()
        {
            InitializeComponent();
        }

        private void Comments_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "人名";
            dataGridView1.Columns[1].Name = "回覆";
            //Regex regex = new Regex("\"from\":{\"name\":\"([^\"]+)\"},\"id\":\"\\d+\",\"message\":\"([^\"]+)\"");
            Regex regex = new Regex("\"from\":{\"name\":\"([^\"]+)\",\"id\":\"\\d+\"},\"message\":\"([^\"]+)\"");
            String result = Mainform.dataGridView1.Rows[Mainform.dataGridView1.CurrentCell.RowIndex].Cells[2].FormattedValue.ToString();
            foreach (Match match in regex.Matches(result))
            {
                dataGridView1.Rows.Add(match.Groups[1].Value, match.Groups[2].Value);
            }

        }
    }
}
