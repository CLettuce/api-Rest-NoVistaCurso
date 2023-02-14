using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consumo_api_Curso
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RestClient cliente = new RestClient("https://localhost:44306/");
            var solictud = new RestRequest("api/EEstudiantes");
            var respuesta = cliente.Get(solictud);
            if(respuesta.StatusCode == System.Net.HttpStatusCode.OK )
            {
                List<DtoEstudiante> data = JsonConvert.DeserializeObject<List<DtoEstudiante>>(respuesta.Content);
                dataGridView1.DataSource = data;
                dataGridView1.Refresh();
            }
           // solictud.a
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RestClient cliente = new RestClient("https://localhost:44306/");
            var solictud = new RestRequest($"api/EEstudiantes/{Convert.ToInt32(txtIdEstudiante.Text.Trim())}");
            var respuesta = cliente.Get(solictud);
            if (respuesta.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = JsonConvert.DeserializeObject<List<DtoEstudiante>>(respuesta.Content).FirstOrDefault();
                dataGridView1.DataSource = data;
                dataGridView1.Refresh();
            }
        }
    }
}
  