using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RegisztracioAlkalmazas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            SaveButton.Click += (sender, e) =>
            {
                Mentes();

                //MessageBox.Show(FavListBox.Text);
                //FavListBox.Items.Count;
                
                //MessageBox.Show(tmp);
                
            };
            OpenButton.Click += (sender, e) =>
            {
                Megnyitas();
            };
            NewHobbyButton.Click += (sender, e) =>
            {
                Hozzaad();
            };
        }
        private string adatok()
        {
            string nev = NameBox.Text;
            string ev = AgeBox.Text;
            string nem = null;
            if (FemaleRadioButton.Checked)
            {
                nem = "Nő";    
            }
            else
            {
                nem = "férfi";
            }
            string kedvenclista = FavHobbyListBox.Text;
            string osszeslista = "";
            for (int i = 0; i < FavHobbyListBox.Items.Count; i++)
            {
                osszeslista += FavHobbyListBox.Items[i]+",";
            }



            string tmp = String.Format("Név: {0};Szül.dátum: {1};Nem: {2};Kedvenc Hobbi: {3}, Összes Hobbi: {4}", nev, ev, nem, kedvenclista,osszeslista);
            return tmp;
        }
        private void Mentes()
        {
            var eredmeny = saveFileDialog1.ShowDialog(this);
            if (eredmeny == DialogResult.OK)
            {
                string fileNev = saveFileDialog1.FileName;
                using (var file = File.CreateText(fileNev))
                {
                    file.Write(adatok());
                }
            }
        }
        private void Megnyitas()
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                string tartalom = File.ReadAllText(openFileDialog1.FileName);
            }
        }
        private void Hozzaad()
        {
            FavHobbyListBox.Items.Add(NewHobbiBox.Text);
        }

        private void FavText_Click(object sender, EventArgs e)
        {

        }

        private void SexText_Click(object sender, EventArgs e)
        {

        }
    }
}
