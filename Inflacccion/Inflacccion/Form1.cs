using LinqToExcel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inflacccion
{
    public partial class Form1 : Form
    {
        List<anoIpc> ipc;
        public Form1()
        {
            InitializeComponent();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try {

                
                var book = new ExcelQueryFactory(openFileDialog1.FileName);
                var resultado = (from row in book.Worksheet("IPC")
                                 let item = new anoIpc
                                 {
                                     periodo = row[1].Cast<string>(),
                                     indice1 = row[2].Cast<string>(),
                                     indice2 = row[3].Cast<string>(),
                                     inflaccion = row[4].Cast<string>()
                                 }
                                 select item).ToList();
                book.Dispose();

                ipc = resultado.ToList();
                for (int v = 6; v <= resultado.Count; v++) {
                    if(int.Parse(resultado[v].periodo.ToString())<DateTime.Today.Year)    
                    ipc.Add(new anoIpc(resultado[v].periodo, resultado[v].indice1, resultado[v].indice2, resultado[v].inflaccion));

                    textBox1.Text += resultado[v].periodo + " " + resultado[v].indice1 + " " + resultado[v].indice2 + " " + resultado[v].inflaccion + Environment.NewLine;   
                }
                //Form2 f = new Form2(resultado);
                //f.Show();
            }catch{

            
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
