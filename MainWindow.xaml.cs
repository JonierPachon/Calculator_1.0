using System;
using System.Collections.Generic;
using System.Windows;
//using System.Windows.

namespace Interactuando
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double numeroAuxiliar;
        double resultado;
        string operador = "";
        bool presionarIgual = false;//hace referencia ha si se ha dado click en igual 

        public MainWindow()
        {
            InitializeComponent();
        }

        #region BotonesDelCeroAlNueve

        //cuando se presiona el nuemero por primera vez y
        //y cuando realizo operaciones
        private void FiltarBotonesNumericos()
        {
            // Verificamos si se realizó operacion matemática en la calculadora
            if (presionarIgual == true & resultado != 0 & numeroAuxiliar != 0)
            {
                lblPantallaSecundaria.Content = '"' + txtPantallaPrincipal.Text + '"';
                txtPantallaPrincipal.Text = "";
                resultado = 0;
                numeroAuxiliar = 0;
            }

            else if (txtPantallaPrincipal.Text == "0")
            {
                txtPantallaPrincipal.Text = "";
            }
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            if (txtPantallaPrincipal.Text != "0")
            {
                txtPantallaPrincipal.Text += 0;
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            FiltarBotonesNumericos();
            txtPantallaPrincipal.Text += 1;


        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            FiltarBotonesNumericos();
            txtPantallaPrincipal.Text += 2;

        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            FiltarBotonesNumericos();
            txtPantallaPrincipal.Text += 3;

        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            FiltarBotonesNumericos();
            txtPantallaPrincipal.Text += 4;

        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            FiltarBotonesNumericos();
            txtPantallaPrincipal.Text += 5;

        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            FiltarBotonesNumericos();
            txtPantallaPrincipal.Text += 6;

        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            FiltarBotonesNumericos();
            txtPantallaPrincipal.Text += 7;
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            FiltarBotonesNumericos();
            txtPantallaPrincipal.Text += 8;
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            FiltarBotonesNumericos();
            txtPantallaPrincipal.Text += 9;
        }


        #endregion


        private void btnLimpiarcalculadora_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCalculadora();
        }


        private void LimpiarCalculadora()
        {
            //reiniciamos valores
            numeroAuxiliar = 0;
            resultado = 0;
            txtPantallaPrincipal.Text = "0";
            lblPantallaSecundaria.Content = "0";
        }

        private void btnBorrarUltimoNumeroDigitado_Click(object sender, RoutedEventArgs e)
        {
            BorrarUltimoNumeroDigitado();
        }

        private void BorrarUltimoNumeroDigitado()
        {
            if ((txtPantallaPrincipal.Text).ToLower() == "nan")
            {
                txtPantallaPrincipal.Text = "0";
            }
            else if (txtPantallaPrincipal.Text != "" & txtPantallaPrincipal.Text != "0")
            {
                List<char> NumBorrar = new List<char>();

                NumBorrar.AddRange(txtPantallaPrincipal.Text);

                NumBorrar.RemoveAt(NumBorrar.Count - 1);

                txtPantallaPrincipal.Text = "";

                if (NumBorrar.Count > 0)
                {
                    foreach (char x in NumBorrar)
                    {

                        txtPantallaPrincipal.Text += x;

                    }
                }

                else txtPantallaPrincipal.Text = "0";//cuando se elimina un unico elemento 
                //txtPantallaPrincipal queda vacio, por esto coloco el "else"

                NumBorrar.Clear();

            }
        }



        #region OperacionesMatemáticas

        

        private void btnSumar_Click(object sender, RoutedEventArgs e)
        {
            operacion("+");
        }

        private void btnRestar_Click(object sender, RoutedEventArgs e)
        {
            operacion("-");
        }

        private void btnMultiplicar_Click(object sender, RoutedEventArgs e)
        {
            operacion("*");

        }

        private void btnDividir_Click(object sender, RoutedEventArgs e)
        {
            operacion("/");
        }

        private void btnResiduo_Click_1(object sender, RoutedEventArgs e)
        {
            operacion("%");
        }

        #endregion

        private void operacion(string pSigno)
        {
            // aquí el, mas (+), también funciona como el botón igual
            // ya que también nos puede dar el resultado

            string pValor = (string)lblPantallaSecundaria.Content;
 
            // agregamos el signo de operación y preparamos para que el usario
            // pueda digitar el siguiente valor
            if (!pValor.EndsWith("-") & !pValor.EndsWith("+") & !pValor.EndsWith("*")
                & !pValor.EndsWith("/") & !pValor.EndsWith("%"))
            {
                numeroAuxiliar = double.Parse(txtPantallaPrincipal.Text);
                lblPantallaSecundaria.Content = txtPantallaPrincipal.Text + pSigno;
                txtPantallaPrincipal.Text = "0";
                presionarIgual = false;
            }

            // Aquí como txtPantallaPrincipal es "0" y lblPantallaSecundaria tiene
            // signo al final, lo que hacemos simplemente, es cambiar el signo al
            // final por el que indicó el usuario
            else if ((pValor.EndsWith("-") | pValor.EndsWith("+") |
               pValor.EndsWith("*") | pValor.EndsWith("/") |
               pValor.EndsWith("%")) & txtPantallaPrincipal.Text == "0")
            {
                List<char> Lista = new List<char>();
                Lista.AddRange(pValor);
                Lista.RemoveAt(Lista.Count - 1);
                pValor = "";
                foreach (char i in Lista)
                {
                    pValor += i;
                }

                lblPantallaSecundaria.Content = pValor + pSigno;
                Lista.Clear();
                presionarIgual = false;
            }


            // aquí como lblPantallaSecundaria tiene signo aritmético al final y txtPantallaPrincipal
            // es diferente de "0"y además la variable operador tiene guardado un signo aritmético, realizamos calculo para obtener un resultado
            else
            {
                EscogerOperacion();
                lblPantallaSecundaria.Content = resultado.ToString() + pSigno;
                numeroAuxiliar = resultado;
                resultado = 0; // para que esta variable no se cumpla en el if de 'FiltarBotonesNumericos()' 
                txtPantallaPrincipal.Text = "0";
                presionarIgual = true;
            }

            operador = pSigno;

        }



        //simbolos matematicos
        private void btnIgual_Click(object sender, RoutedEventArgs e)
        {
            if (presionarIgual == false)
                CalcularOperacionAritmetica();

        }

        private void EscogerOperacion()
        {
            if (operador == "+")
            {
                resultado = numeroAuxiliar + double.Parse(txtPantallaPrincipal.Text);

            }
            else if (operador == "-")
            {
                resultado = numeroAuxiliar - double.Parse(txtPantallaPrincipal.Text);
            }
            else if (operador == "*")
            {
                resultado = numeroAuxiliar * double.Parse(txtPantallaPrincipal.Text);
            }
            else if (operador == "/")
            {
                resultado = numeroAuxiliar / double.Parse(txtPantallaPrincipal.Text);
            }
            else if (operador == "%")
            {
                resultado = numeroAuxiliar % double.Parse(txtPantallaPrincipal.Text);
            }
        }

        private void CalcularOperacionAritmetica()
        {
            EscogerOperacion();

            presionarIgual = true;
            lblPantallaSecundaria.Content += txtPantallaPrincipal.Text;
            txtPantallaPrincipal.Text = resultado.ToString();

        }

        private void btnConvertidor_Click(object sender, RoutedEventArgs e)
        {
            double numDouble;

            if (txtPantallaPrincipal.Text != "0")
            {
                numDouble = double.Parse(txtPantallaPrincipal.Text) * -1;
                txtPantallaPrincipal.Text = numDouble.ToString();

            }
        }

        private void btnDecimal_Click(object sender, RoutedEventArgs e)
        {
            PuntoDecimal();
        }

        private void PuntoDecimal()
        {
            try
            {
                //de esta manera se evita que se pueda colocar mas de 2 puntos decimales
                string ayuda = txtPantallaPrincipal.Text + ".";
                double x = double.Parse(ayuda);

                if (x % 1 == 0)
                {
                    txtPantallaPrincipal.Text += ".";
                }
            }
            catch (FormatException)
            {

            }
        }

        #region "Cuando presionamos las teclas del teclado"


        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

            if (e.Key == System.Windows.Input.Key.Back)
            {
                BorrarUltimoNumeroDigitado();
            }

            else if (e.Key == System.Windows.Input.Key.Delete)
            {
                LimpiarCalculadora();
            }




            //operaciones matematicas

            else if (e.Key == System.Windows.Input.Key.Add)
            {
                operacion("+");
            }

            else if (e.Key == System.Windows.Input.Key.Subtract)
            {
                operacion("-");
            }

            else if (e.Key == System.Windows.Input.Key.Multiply)
            {
                operacion("*");
            }

            else if (e.Key == System.Windows.Input.Key.Divide)
            {
                operacion("/");
            }

            else if (e.Key == System.Windows.Input.Key.D5)
            {
                operacion("%");
            }



            //numeros del 0 al 1

            else if (e.Key == System.Windows.Input.Key.NumPad0)
            {
                if (txtPantallaPrincipal.Text != "0")
                {
                    txtPantallaPrincipal.Text += 0;
                }
                else
                {
                }
            }

            else if (e.Key == System.Windows.Input.Key.NumPad1)
            {
                FiltarBotonesNumericos();
                txtPantallaPrincipal.Text += 1;
            }

            else if (e.Key == System.Windows.Input.Key.NumPad2)
            {
                FiltarBotonesNumericos();
                txtPantallaPrincipal.Text += 2;
            }
            else if (e.Key == System.Windows.Input.Key.NumPad3)
            {
                FiltarBotonesNumericos();
                txtPantallaPrincipal.Text += 3;
            }

            else if (e.Key == System.Windows.Input.Key.NumPad4)
            {
                FiltarBotonesNumericos();
                txtPantallaPrincipal.Text += 4;
            }

            else if (e.Key == System.Windows.Input.Key.NumPad5)
            {
                FiltarBotonesNumericos();
                txtPantallaPrincipal.Text += 5;
            }

            else if (e.Key == System.Windows.Input.Key.NumPad6)
            {
                FiltarBotonesNumericos();
                txtPantallaPrincipal.Text += 6;
            }
            else if (e.Key == System.Windows.Input.Key.NumPad7)
            {
                FiltarBotonesNumericos();
                txtPantallaPrincipal.Text += 7;
            }

            else if (e.Key == System.Windows.Input.Key.NumPad8)
            {
                FiltarBotonesNumericos();
                txtPantallaPrincipal.Text += 8;
            }

            else if (e.Key == System.Windows.Input.Key.NumPad9)
            {
                FiltarBotonesNumericos();
                txtPantallaPrincipal.Text += 9;
            }

            else if (e.Key == System.Windows.Input.Key.Decimal)
            {
                PuntoDecimal();
            }

        }

        private void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                e.Handled = true;
            }

            if (e.Key == System.Windows.Input.Key.Space)
            {
                e.Handled = true;
            }
        }

        private void Window_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                CalcularOperacionAritmetica();
            }
        }

        #endregion 
    }
}