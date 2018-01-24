using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net; //biblioteka od łączenia z internetem
using System.Net.Mail; //biblioteka od wysyłania e-mail


namespace MyMail1._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void oProjekcieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MyMail by Michał Gołdyn, Programowanie aplikacyjne 2017");
        }
        private static string login;
        private static string haslo;
        private void button1_Click_1(object sender, EventArgs e)
        {
            try//spróbuj
            {
                MailMessage wiadomosc = new MailMessage(); //klasa o nazwie "wiadomość" typu wiadomosci mail
                wiadomosc.From = new MailAddress(login);//od kogo wiadomość
                wiadomosc.From.ToString();
                wiadomosc.Subject = temat.Text;//tytuł wiadomości, który jest pobierany jest z tematu
                wiadomosc.Body = wiadomosc.ToString();//treść wiadomości
                foreach (string email in Odbiorca.Text.Split(';'))//pętla "dla każdej wartości" w tej liście nadaj nazwę email w textbox rozdzielą ;
                {
                    wiadomosc.To.Add(email);//dodaj kolekcję do email
                }
                SmtpClient klient = new SmtpClient(); //tworzenie zmiennej o nazwie "klient" typu smtpClient
                klient.Credentials = new NetworkCredential(login, haslo);//detale, czyli adres i hasło zapisane w zmiennej klient
                klient.Host = "student.pwr.wroc.pl";//podanie hosta poczty
                klient.Port = 587;//podanie portu wysyłania
                klient.EnableSsl = true;//podanie zabezpieczenia poczty
                klient.Send(wiadomosc);//wysłanie wiadomości
                MessageBox.Show(this, "Wysłano wiadomość e-mail!", "Sukces!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch//złap, jeśli się nie uda
            {
                MessageBox.Show(this, "Wystąpił problem podczas wysyłania wiadomości e-mail.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void zalogujToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            login = textBox1.Text;
            twojmail.Text = login;
            haslo = maskedTextBox1.Text;
            MessageBox.Show("Zalogowano");
        }


    }
}