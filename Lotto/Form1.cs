using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotto
{
    public partial class Form1 : Form
    {
        private const int numberOfRows = 7;
        int[] lottoTicket = new int[numberOfRows] {4,7,10,13,20,27,34};
        int[] draws = new int[numberOfRows] { 0, 0, 0, 0, 0, 0, 0};
        Random random = new Random();
        int winner = 0;
        int[] winners = new int[3] { 0, 0, 0 };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void setDisabled()
        {

        }
        private void play(int n)
        {
            Console.WriteLine("Antal dragningar: " + n);
            for(int i = 0; i < n; i++)
            {
                setDraws();
                compareTicketToDraws();
                if (winner == 5) winners[0] += 1;
                if (winner == 6) winners[1] += 1;
                if (winner == 7) winners[2] += 1;
                winner = 0;
            }
            textBox1.Text = winners[0].ToString();
            textBox2.Text = winners[1].ToString();
            textBox3.Text = winners[2].ToString();
            button1.Enabled = true;
            Console.WriteLine("Done");
        }
        private bool numberUnique(int number)
        {
            int exists = 0;
            for(int i=0; i < numberOfRows; i++)
            {
                if (draws[i] == number)
                    exists++;
            }
            if (exists <= 1) return true;
            else return false;
        }
        private void setLottoTicketRow(int position, int value)
        {
            lottoTicket[position] = value;
        }
        private void setDraws()
        {
            int number;
            for(int i = 0; i < numberOfRows; i++)
            {
                do {
                    number = random.Next(1, 35);
                    if (numberUnique(number)) draws[i] = number;
                } while (numberUnique(number) == false);
            }
        }

        private void checkForDoublets()
        {
            int found = 0;
            for(int i = 0; i < numberOfRows; i++)
            {
                for(int k = 0; k < numberOfRows; k++)
                {
                    if (k != i && lottoTicket[i] == lottoTicket[k])
                    {
                        found += 1;
                    }
                }
            }
            if (found != 0)
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

        private void commonNumericUpDownEvent(object sender, EventArgs e)
        {
            var source = (NumericUpDown)sender;
            Console.WriteLine(source.Name);
            switch (source.Name)
            {
                case "numericUpDown1":
                    setLottoTicketRow(0, Convert.ToInt32(Math.Round(source.Value, 0)));
                    break;
                case "numericUpDown2":
                    setLottoTicketRow(1, Convert.ToInt32(Math.Round(source.Value, 0)));
                    break;
                case "numericUpDown3":
                    setLottoTicketRow(2, Convert.ToInt32(Math.Round(source.Value, 0)));
                    break;
                case "numericUpDown4":
                    setLottoTicketRow(3, Convert.ToInt32(Math.Round(source.Value, 0)));
                    break;
                case "numericUpDown5":
                    setLottoTicketRow(4, Convert.ToInt32(Math.Round(source.Value, 0)));
                    break;
                case "numericUpDown6":
                    setLottoTicketRow(5, Convert.ToInt32(Math.Round(source.Value, 0)));
                    break;
                case "numericUpDown7":
                    setLottoTicketRow(6, Convert.ToInt32(Math.Round(source.Value, 0)));
                    break;
                default:
                    Console.WriteLine("Fan");
                    break;
            }
            checkForDoublets();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            play(Convert.ToInt32(Math.Round(numericUpDown8.Value, 0)));
        }
        private void compareTicketToDraws()
        {
            for(int i=0; i < numberOfRows; i++)
            {
                for(int k = 0; k < numberOfRows; k++)
                {
                    if (lottoTicket[i] == draws[k])
                        winner++;
                }
            }
        }
    }
}
