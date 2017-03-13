using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFVirus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("https://9zld4zwegj.execute-api.us-east-1.amazonaws.com/dev/challenge/start");
                request.Method = "POST";
                string postData = "{\"email\": \"i-m-juanito@hotmail.com\"}";
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/json" ;
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();

                string D = "";

                for (int i = 0; i < responseFromServer.Length; i++)
                {
                    if (responseFromServer[i] == '{')
                    {
                        i++;
                        do
                        {
                            D += responseFromServer[i];
                            i++;
                        }
                        while (responseFromServer[i] != ',');
                    }

                    if (responseFromServer[i] == '[')
                    {
                        i++;
                        do
                        {
                            textBox5.Text += responseFromServer[i];
                            i++;
                        }
                        while (responseFromServer[i] != ']');
                        break;
                    }

                }
                char[] delimiter1 = new char[] { '"', ',', '\t' };
                string[] array = textBox5.Text.Split(delimiter1, StringSplitOptions.RemoveEmptyEntries);
                int cont = array.Length;
                int pc = 0;
                int sicknessPercentage;
                double decimals;


                for (int n = 0; n < array.Length; n++)
                {
                    request = WebRequest.Create("" + array[n]);
                    response = request.GetResponse();
                    dataStream = response.GetResponseStream();
                    reader = new StreamReader(dataStream);
                    responseFromServer = reader.ReadToEnd();

                    int A = 0;
                    int C = 0;
                    int G = 0;
                    int T = 0;
                    for (int x = 0; x < responseFromServer.Length; x++)
                    {
                        if (responseFromServer[x] == 'A')
                        {
                            A++;
                        }
                        if (responseFromServer[x] == 'C')
                        {
                            C++;
                        }
                        if (responseFromServer[x] == 'G')
                        {
                            G++;
                        }
                        if (responseFromServer[x] == 'T')
                        {
                            T++;
                        }

                    }

                    if (T > A && T > C && T > G)
                    {
                        pc++;
                    }
                    reader.Close();
                    response.Close();
                }

                decimals = (pc * 100) / cont;
                sicknessPercentage = (int)decimals;
                textBox6.Text = "{" + D + ", \"sicknessPercentage\": " + sicknessPercentage.ToString() + ",}";

                request = WebRequest.Create("https://9zld4zwegj.execute-api.us-east-1.amazonaws.com/dev/challenge/submission");
                request.Method = "POST";
                postData = "" + textBox6.Text;
                byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/json";
                request.ContentLength = byteArray.Length;
                dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                response = request.GetResponse();
                dataStream = response.GetResponseStream();
                reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
                textBox7.Text = responseFromServer;
                reader.Close();
                dataStream.Close();
                response.Close();

        }
        
    }
}
