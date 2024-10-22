using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace JNotes
{
	public partial class Form1 : Form
	{
		public string Subject { get; set; }
		public int NoteID { get; set; }
		public string Task { get; set; }
		public int Day { get; set; }
		public int Month { get; set; }
		public int Year { get; set; }
		int count = 0;
		public string storedText { get; set; }
		List<string> lobe = new List<string>();
		Label labe = new Label();
		static string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "JNotes.txt");

		public Form1()
		{
			InitializeComponent();
		}
		
		private void button1_Click(object sender, EventArgs e)
		{
			Label labe = new Label();
			int num = count + 1;
			labe.Text = num+": "+textBox1.Text;
			labe.Location = new Point(50, 50 + (count * 30));
			this.Controls.Add(labe);
			lobe.Add(labe.Text);
			count++;
			textBox1.Text = "";
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{

		}

		private void button4_Click(object sender, EventArgs e)
		{
			try
			{
				// Write each note to the text file as a new line
				File.WriteAllLines(filePath, lobe);

				MessageBox.Show("Notes exported to TXT file successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred while exporting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
