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

namespace MyMail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try//spróbuj
            {
                MailMessage wiadomosc = new MailMessage(); //klasa o nazwie "wiadomość" typu wiadomosci mail
                wiadomosc.From = new MailAddress("Wpisz_swoj_mail");//od kogo wiadomość
                wiadomosc.Subject = textBox1.Text;//tytuł wiadomości, który jest pobierany jest z textbox1
                wiadomosc.Body = richTextBox2.Text;//treść wiadomości, pobierana z richboxa2
                foreach (string email in richTextBox1.Text.Split(';'))//pętla "dla każdej wartości" w tej liście nadaj nazwę email w textbox rozdzielą ;
                {
                    wiadomosc.To.Add(email);//dodaj kolekcję do email
                }
                SmtpClient klient = new SmtpClient(); //tworzenie zmiennej o nazwie "klient" typu smtpClient
                klient.Credentials = new NetworkCredential("wpisz_swoj_mail", "haslo");//detale, czyli adres i hasło zapisane w zmiennej klient
                klient.Host = "student.pwr.wroc.pl";//podanie hosta poczty
                klient.Port = 587;//podanie portu wysyłania
                klient.EnableSsl = true;//podanie zabezpieczenia poczty
                klient.Send(wiadomosc);//wysłanie wiadomości
                MessageBox.Show(this, "Wysłano wiadomość e-mail!","Sukces!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch//złap, jeśli się nie uda
            {
                MessageBox.Show(this, "Wystąpił problem podczas wysyłania wiadomości e-mail.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally//ostatecznie 
            {
                button1.Enabled = true;//aktywowanie przycisku po wysłaniu
            }
        }




    }
}
