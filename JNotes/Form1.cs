using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace JNotes
{
	public partial class Form1 : Form
	{
		public class Task
		{ 
			public string Objective { get; set; }
			public int NoteID { get; set; }
			public string toDo { get; set; }
			public int Day { get; set; }
			public int Month { get; set; }
			public int Year { get; set; }

			public Task(string objective, int noteid,string todo, int day, int month, int year) 
			{
				Objective = objective;
				NoteID = noteid;
				toDo = todo;
				Day = day;
				Month = month;
				Year = year;
			}
			public override string ToString()
			{
				return $"{Objective}\n	{NoteID}: {toDo} ending at :{Day}.{Month}.{Year}" ;
			}
		}
		public static void ExportListToTxt(List<Task> lobe, string filePath)
		{
			List<string> lines = new List<string>();

			foreach (Task task in lobe)
			{
				lines.Add(task.ToString());
			}

			File.WriteAllLines(filePath, lines);

			MessageBox.Show("Export complete. File saved at: " + Path.GetFullPath(filePath));
		}

		private int count = 1;
		public string storedText { get; set; }
		public List<Task> lobe = new List<Task>();
		Label labe = new Label();
		static string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "JNotes.txt");

		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int day, month, year;
			string enddate = textBox3.Text;
			string[] thedates = enddate.Split('.');
			day = int.Parse(thedates[0]);
			month = int.Parse(thedates[1]);
			year = int.Parse(thedates[2]);
			string ob = textBox1.Text;
			string ta = textBox2.Text;
			Label labe = new Label();
			Task newTask = new Task(textBox1.Text, count, textBox2.Text, day, month, year);
			labe.MaximumSize = new Size(400, 0);
			labe.AutoSize = true;
			labe.Text = String.Format("{0} {1}: {2} End Date: {3}",ob,count,ta,enddate);
			labe.Location = new Point(50, 50 + (count * 30));
			this.Controls.Add(labe);
			lobe.Add(newTask);
			count++;
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
				int noteIDToDelete;

				if (int.TryParse(textBox1.Text, out noteIDToDelete))
				{

					Task taskToRemove = lobe.FirstOrDefault(t => t.NoteID == noteIDToDelete);

					if (taskToRemove != null)
					{
						// Find the corresponding label by its text (or use another identifier if you have one)
						Label labelToRemove = this.Controls.OfType<Label>()
							.FirstOrDefault(l => l.Text.Contains(taskToRemove.NoteID.ToString()));

						if (labelToRemove != null)
						{
							// Remove the label from the form controls
							this.Controls.Remove(labelToRemove);
						}

						// Remove the task from the list
						lobe.Remove(taskToRemove);

						MessageBox.Show($"Task {noteIDToDelete} and its label have been removed.");
					}
					else
					{
						MessageBox.Show("Task not found.");
					}
				}
				else
				{
					MessageBox.Show("Invalid NoteID. Please enter a valid number.");
				}

				// Clear the input field
				textBox1.Text = "";
		}

		private void button4_Click(object sender, EventArgs e)
		{
			ExportListToTxt(lobe, filePath);
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox4_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
