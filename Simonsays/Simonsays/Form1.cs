using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Media;
namespace Simonsays
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int onInList = 0;
        List<int> pattern = new List<int>(); //
        Random rand = new Random(); //de random knop die er wordt opgelicht wordt
        bool playingBack = false; 

        private void Red_Click(object sender, EventArgs e)
        {
            testCorrect(0);
            //als deze knop ingedrukt word geeft hij een een 0 door aan de functie testCorrect
        }

        private void Blue_Click(object sender, EventArgs e)
        {
            testCorrect(1);
            //als deze knop ingedrukt word geeft hij een een 1 door aan de functie testCorrect
        }

        private void Yellow_Click(object sender, EventArgs e)
        {
            testCorrect(2);
            //als deze knop ingedrukt word geeft hij een een 2 door aan de functie testCorrect
        }

        private void Green_Click(object sender, EventArgs e)
        {
            testCorrect(3);
            //als deze knop ingedrukt word geeft hij een een 3 door aan de functie testCorrect
        }

        void testCorrect(int color)
        {
            //voer de functie playingBack uit als deze aangeroept kan worden
            if (playingBack)
                return;
            //als de kleur(en) overeenkomt met de kleur(en) uit het array voeg er een aan toe.
            if (pattern[onInList] == color)
            {
                onInList++;
            }
            else //als de kleur(en) niet overeenkomt
            {
                MessageBox.Show("Final Score: " + pattern.Count.ToString()); //geeft een messagebox weer die je final score zegt
                onInList = 0; //reset de lijst
                pattern = new List<int>();
                new Thread(playback).Start();
            }
            if (onInList >= pattern.Count) //als de lijst groter is dan het huidige patroon doe dit
            {
                pattern.Add(rand.Next(0, 6)); //voeg een random nummer tussen 0 en 6 toe aan de lijst
                onInList = 0; 
                new Thread(playback).Start();
            }
            scorelabel.Text = ("Score: " + pattern.Count.ToString()); //laat de huidige score zien
            patternlabel.Text = ("Item within pattern: " + onInList.ToString()); //laat de huidige items in de reeks zien
        }

        void playback() //deze functie gebeurt als de computer de reeks laat zien die nagespeeld moet worden
        {
            playingBack = true;
            foreach(int color in pattern){ //voor elke kleur in de lijst doe een van de volgende cases
                switch (color)
                {
                    case 0: //knop 1
                        Red.BackColor = Color.Red;
                        Thread.Sleep(500);
                        Red.BackColor = Color.Transparent;
                        break;

                    case 1: //knop 2
                        Blue.BackColor = Color.Blue;
                        Thread.Sleep(500);
                        Blue.BackColor = Color.Transparent;
                        break;

                    case 2: //knop 3
                        Yellow.BackColor = Color.Yellow;
                        Thread.Sleep(500);
                        Yellow.BackColor = Color.Transparent;
                        break;

                    case 3: //knop 4
                        Green.BackColor = Color.Green;
                        Thread.Sleep(500);
                        Green.BackColor = Color.Transparent;
                        break;

                    case 4: //knop 5
                        Purple.BackColor = Color.Purple;
                        Thread.Sleep(500);
                        Purple.BackColor = Color.Transparent;
                        break;

                    case 5: //knop 6
                        Pink.BackColor = Color.Pink;
                        Thread.Sleep(500);
                        Pink.BackColor = Color.Transparent;
                        break;
                }
                Thread.Sleep(200); //wacht even voordat de volgende reeks wordt laten zien
            }
            playingBack = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pattern.Add(rand.Next(0, 6)); //voeg een random nummer tussen 1 en 6 toe
            new Thread(playback).Start();
        }

        private void Purple_Click(object sender, EventArgs e)
        {
            testCorrect(4);
            //als deze knop ingedrukt word geeft hij een een 4 door aan de functie testCorrect
        }

        private void Pink_Click(object sender, EventArgs e)
        {
            testCorrect(5);
            //als deze knop ingedrukt word geeft hij een een 5 door aan de functie testCorrect
        }

        private void patternlabel_Click(object sender, EventArgs e)
        {

        }
    }
}
