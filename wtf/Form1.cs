using System.IO;
using static System.Windows.Forms.LinkLabel;

namespace wtf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("kysave.txt"))
                File.Create("kysave.txt");
            loadGame();
        }

        public string path = "kysave.txt";
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            loadGame();

            /*textBox1.Text = dateTimePicker1.Value.ToString();*/

        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveGame();
        }


        public void saveGame() 
        {
            string toSave = dateTimePicker1.Value.ToString() + textBox1.Text;
            bool ishome = false;
            string[] lines = new string[File.ReadAllLines(path).Length];
            for (int i = 0; i < File.ReadAllLines(path).Length; i++)
            {
                lines[i] = File.ReadAllLines(path)[i];
                if (File.ReadAllLines(path)[i].StartsWith(dateTimePicker1.Value.ToString()))
                {
                    string[] linesp1 = new string[lines.Length + 1]; linesp1 = lines;
                    string essa = "";
                    for (int j = 0; j < textBox1.Lines.Length; j++)
                    {
                        if (j == textBox1.Lines.Length - 1) essa += textBox1.Lines[j];
                        else essa += textBox1.Lines[j] + "{[/n]}";
                    }

                    lines[i] = dateTimePicker1.Value.ToString() + essa;
                    ishome = true;
                }
            }
            if (ishome) { File.WriteAllLines(path, lines); }
            else {

                string[] linesp1 = new string[lines.Length + 1]; linesp1 = lines;
                string essa="";
                for (int i = 0; i < textBox1.Lines.Length; i++) 
                {
                   if(textBox1.Lines.Length-1==i) essa += textBox1.Lines[i];
                   else essa += textBox1.Lines[i] + "{[/n]}";
                }
                //textBox1.Text = dateTimePicker1.Value.ToString() + essa + "\n";
                File.AppendAllText(path, dateTimePicker1.Value.ToString() + essa + "\n");

            }
        }
        public void loadGame() 
        {
            foreach (string line in File.ReadAllLines(path))
            {
                if (line.StartsWith(dateTimePicker1.Value.ToString()))
                {
                    string lines = line.Substring(19).Replace("{[/n]}", "\r\n");
                    textBox1.Text = lines;
                    break;
                }
                else { textBox1.Clear(); }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveGame();
            Application.Exit();
        }
    }
}