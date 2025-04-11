using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UC11_Jogo_Forca
{
    public partial class Form1 : Form
    {
        string palavraSECRETA = string.Empty;

        // Criando um VETOR do tipo String (texto) com 10 posições. 
        string[] vetorpalavraSECRETA = new string[10];

        string palavraJOGO = "";
        string letraTESTAR = "";
        int erro = 1;
        int acerto = 0;
        int contador = 0;
        double pontos = 0;

        public Form1()
        {
            InitializeComponent();

            panelCONFIG.Visible = false;
            labelNOMEJOGADOR.Text = string.Empty;
            labelpalavraSECRETA.Text = string.Empty;
            labelPONTOS.Text = string.Empty;

            // Preenchendo o "vetorpalavraSECRETA" com o caracter
            // "_" em todas as suas posições.
            for (int i = 0; i < 10; i++)
            {
                vetorpalavraSECRETA[i] = "_";
            }
        }

        private void buttonINICIA_Click(object sender, EventArgs e)
        {
            labelNOMEJOGADOR.Text = textBoxNOMEJOGADOR.Text;
            textBoxNOMEJOGADOR.Text = string.Empty;

            palavraSECRETA = textBoxPALAVRASECRETA.Text.ToUpper();
            textBoxPALAVRASECRETA.Text = string.Empty;

            labelPONTOS.Text = "0";
            pictureBoxFORCA.Image = Properties.Resources.vazia;

            panelCONFIG.Visible = false;

            labelpalavraSECRETA.Text = string.Empty;


            for (int i = 0; i < palavraSECRETA.Length; i++)
            {
                labelpalavraSECRETA.Text = labelpalavraSECRETA.Text + vetorpalavraSECRETA[i] + " ";
            }
        }

        private void labelCONFIG_Click(object sender, EventArgs e)
        {
            panelCONFIG.Visible = true;
        }

        private void buttonTESTAR_Click(object sender, EventArgs e)
        {
            if (textBoxLETRA.Text != string.Empty)
            {
                letraTESTAR = textBoxLETRA.Text.ToUpper();

                for (int i = 0; i < palavraSECRETA.Length; i++)
                {
                    if (letraTESTAR == palavraSECRETA.Substring(i, 1))
                    {
                        vetorpalavraSECRETA[i] = letraTESTAR;
                        erro = 0;
                        pontos = pontos + 50;
                        labelPONTOS.Text = pontos.ToString();
                    }
                    else
                    {
                        // ...
                    }
                }

                if (erro == 1)
                {
                    MessageBox.Show("Letra Incorreta!");
                    contador++;

                    if (contador == 1)
                    {
                        pictureBoxFORCA.Image = Properties.Resources.cabeca;
                        pontos = pontos - 25;
                        labelPONTOS.Text = pontos.ToString();
                    }
                    if (contador == 2)
                    {

                        pictureBoxFORCA.Image = Properties.Resources.corpo;
                        pontos = pontos - 25;
                        labelPONTOS.Text = pontos.ToString();
                    }
                    if (contador == 3)
                    {
                        pictureBoxFORCA.Image = Properties.Resources.braco1;
                        pontos = pontos - 25;
                        labelPONTOS.Text = pontos.ToString();
                    }

                    if (contador == 4)
                    {
                        pictureBoxFORCA.Image = Properties.Resources.braco2;
                        pontos = pontos - 25;
                        labelPONTOS.Text = pontos.ToString();
                    }
                    if (contador == 5)
                    {
                        pictureBoxFORCA.Image = Properties.Resources.perna1;
                        pontos = pontos - 25;
                        labelPONTOS.Text = pontos.ToString();

                    }
                    if (contador == 6)
                    {
                        pictureBoxFORCA.Image = Properties.Resources.perna2;
                        pontos = pontos - 25;

                        MessageBox.Show("VOCÊ PERDEU!");
                        labelpalavraSECRETA.Visible = false;
                        labelpalavraSECRETA.Text = string.Empty;
                        pictureBoxFORCA.Image = Properties.Resources.vazia;

                    }


                }

                erro = 1;
                textBoxLETRA.Text = string.Empty;
                labelpalavraSECRETA.Text = string.Empty;

                for (int i = 0; i < palavraSECRETA.Length; i++)
                {
                    labelpalavraSECRETA.Text = labelpalavraSECRETA.Text + vetorpalavraSECRETA[i] + " ";
                    if (vetorpalavraSECRETA[i] == palavraSECRETA.Substring(i, 1))
                    {
                        acerto++;
                    }
                }
                if (acerto == palavraSECRETA.Length)
                {
                    MessageBox.Show("VOCÊ VENCEU!", labelPONTOS.Text);
                    labelpalavraSECRETA.Text = string.Empty;
                    pictureBoxFORCA.Image = Properties.Resources.vazia;
                    
                }
                acerto = 0;
                textBoxLETRA.Focus();



                // Variável de texto com o valor: "Mateus"
                //string texto = "Mateus";

                // Variável INT que armazena o Tamanho do texto da variável 'texto' (.Length)
                //int texto_tamanho = texto.Length;

                // Função para 'pegar' um caracter específico de um texto (.Substring)
                //string letra = texto.Substring(3, 2);

                // Mostra o "Tamanho do Texto" e a "Primeira Letra do Teto"
                //MessageBox.Show("Tamanho: " + texto_tamanho + " - 1ª Letra: " + letra);
            }
            else
            {
                MessageBox.Show("Informe UMA LETRA!");
            }
        }

        private void labelPONTOS_Click(object sender, EventArgs e)
        {

        }
    }
}
