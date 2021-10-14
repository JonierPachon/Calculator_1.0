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
        double auxiliar;
        double resultado;
        string operador = "";
        bool presionarIgual = false;//hace referencia ha si se ha dado click en igual 

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Botones del cero al 9

        //cuando se presiona el nuemro por primera vez y
        //y cuando realizo operaciones
        private void PrimeraVezPresionandoBoton()
        {
            if (presionarIgual == true & resultado != 0 & auxiliar != 0)
            {
                txtPantSecundaria.Content = '"' + txtPantalla.Text + '"';
                txtPantalla.Text = "";
                resultado = 0;
                auxiliar = 0;
            }

            else if (txtPantalla.Text == "0")
            {
                txtPantalla.Text = "";
            }
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            if (txtPantalla.Text != "0")
            {
                txtPantalla.Text += 0;
            }
            else
            {

            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            PrimeraVezPresionandoBoton();
            txtPantalla.Text += 1;
            

        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            PrimeraVezPresionandoBoton();

            txtPantalla.Text += 2;
            
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            PrimeraVezPresionandoBoton();
            txtPantalla.Text += 3;
            
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            PrimeraVezPresionandoBoton();
            txtPantalla.Text += 4;
            
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            PrimeraVezPresionandoBoton();
            txtPantalla.Text += 5;
            
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            PrimeraVezPresionandoBoton();
            txtPantalla.Text += 6;
            
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            PrimeraVezPresionandoBoton();
            txtPantalla.Text += 7;
            
        }

        // el condicional para que todo en pantalla principal aparezca vacio despues
        // de haber oprimido igual
        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            // el condicional para que todo en pantalla principal aparezca vacio despues
            // de haber oprimido igual

            PrimeraVezPresionandoBoton();
            txtPantalla.Text += 8;
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            PrimeraVezPresionandoBoton();
            txtPantalla.Text += 9;
        }


        #endregion


        private void btnBorrarTodo_Click(object sender, RoutedEventArgs e)
        {
            MetodoBorrarTodo();
        }


        private void MetodoBorrarTodo()
        {
            auxiliar = 0;
            resultado = 0;
            txtPantalla.Text = "0";
            txtPantSecundaria.Content = "0";
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            MetodoBorrar();
        }

        private void MetodoBorrar()
        {
            if ((txtPantalla.Text).ToLower() == "nan")
            {
                txtPantalla.Text = "0";
            }
            else if (txtPantalla.Text != "" & txtPantalla.Text != "0")
            {
                List<char> NumBorrar = new List<char>();

                NumBorrar.AddRange(txtPantalla.Text);

                NumBorrar.RemoveAt(NumBorrar.Count - 1);

                txtPantalla.Text = "";

                if (NumBorrar.Count > 0)
                {
                    foreach (char x in NumBorrar)
                    {

                        txtPantalla.Text += x;

                    }
                }

                else txtPantalla.Text = "0";//cuando se elimina un unico elemento 
                //txtPantalla queda vacio, por esto coloco el "else"

                NumBorrar.Clear();

            }
        }



        //operaciones matemáticas

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

        private void operacion(string pSigno)
        {
            string pValor = (string)txtPantSecundaria.Content;

            //se agrega el signo de operacion
            if (!pValor.EndsWith("-") & !pValor.EndsWith("+") & !pValor.EndsWith("*") 
                & !pValor.EndsWith("/") & !pValor.EndsWith("%"))
            {
                auxiliar = double.Parse(txtPantalla.Text);
                txtPantSecundaria.Content = txtPantalla.Text + pSigno;
                txtPantalla.Text = "0";
                presionarIgual = false;

            }


            //se tiene en cuenta que txtPantalla sea "0" y que txtPantSecundaria
            //ya tenga signo al final para cambiarlo por el del parametro
            else if ((pValor.EndsWith("-") & txtPantalla.Text == "0") |
               (pValor.EndsWith("+") & txtPantalla.Text == "0") |
               (pValor.EndsWith("*") & txtPantalla.Text == "0") |
               (pValor.EndsWith("/") & txtPantalla.Text == "0") |
               (pValor.EndsWith("%") & txtPantalla.Text == "0"))
            {
                List<char> buscandosigno = new List<char>();
                buscandosigno.AddRange(pValor);
                buscandosigno.RemoveAt(buscandosigno.Count - 1);
                pValor = "";
                foreach (char i in buscandosigno)
                {
                    pValor += i;
                }

                txtPantSecundaria.Content = pValor + pSigno;
                buscandosigno.Clear();
                presionarIgual = false;
            }


            //presionar operadores funciona tambien como igual
            else
            {
                EscogerOperacion();
                txtPantSecundaria.Content = resultado.ToString() + pSigno;
                auxiliar = resultado;
                resultado = 0; // para que esta variable no se cumpla en el if de 'PrimeraVezPresionandoBoton()' 
                txtPantalla.Text = "0";
                presionarIgual = true;
            }

            operador = pSigno;

        }



        //simbolos matematicos
        private void btnIgual_Click(object sender, RoutedEventArgs e)
        {
            if(presionarIgual==false)
                MetodoDelIgual();
            
        }

        private void EscogerOperacion()
        {
            if (operador == "+")
            {
                resultado = auxiliar + double.Parse(txtPantalla.Text);

            }
            else if (operador == "-")
            {
                resultado = auxiliar - double.Parse(txtPantalla.Text);
            }
            else if (operador == "*")
            {
                resultado = auxiliar * double.Parse(txtPantalla.Text);
            }
            else if (operador == "/")
            {
                resultado = auxiliar / double.Parse(txtPantalla.Text);
            }
            else if (operador == "%")
            {
                resultado = auxiliar % double.Parse(txtPantalla.Text);
            }
        }

        private void MetodoDelIgual()
        {
            EscogerOperacion();

            presionarIgual = true;
            txtPantSecundaria.Content += txtPantalla.Text;
            txtPantalla.Text = resultado.ToString();

        }

        private void btnConvertidor_Click(object sender, RoutedEventArgs e)
        {
            double numDouble;

            if (txtPantalla.Text != "0")
            {
                numDouble = double.Parse(txtPantalla.Text) * -1;
                txtPantalla.Text = numDouble.ToString();
                
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
                //de esta manera evito que se coloque mas de 2 puntos decimales
                string ayuda = txtPantalla.Text + ",";
                double x = double.Parse(ayuda);

                if (x % 1 == 0)
                {
                    txtPantalla.Text += ",";
                }
            }
            catch (FormatException)
            {

            }
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

            if (e.Key == System.Windows.Input.Key.Back)
            {
                MetodoBorrar();
            }

            else if (e.Key == System.Windows.Input.Key.Delete)
            {
                MetodoBorrarTodo();
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
                if (txtPantalla.Text != "0")
                {
                    txtPantalla.Text += 0;
                }
                else
                {
                }
            }

            else if (e.Key == System.Windows.Input.Key.NumPad1)
            {
                PrimeraVezPresionandoBoton();
                txtPantalla.Text += 1;
            }

            else if (e.Key == System.Windows.Input.Key.NumPad2)
            {
                PrimeraVezPresionandoBoton();
                txtPantalla.Text += 2;
            }
            else if (e.Key == System.Windows.Input.Key.NumPad3)
            {
                PrimeraVezPresionandoBoton();
                txtPantalla.Text += 3;
            }

            else if (e.Key == System.Windows.Input.Key.NumPad4)
            {
                PrimeraVezPresionandoBoton();
                txtPantalla.Text += 4;
            }

            else if (e.Key == System.Windows.Input.Key.NumPad5)
            {
                PrimeraVezPresionandoBoton();
                txtPantalla.Text += 5;
            }

            else if (e.Key == System.Windows.Input.Key.NumPad6)
            {
                PrimeraVezPresionandoBoton();
                txtPantalla.Text += 6;
            }
            else if (e.Key == System.Windows.Input.Key.NumPad7)
            {
                PrimeraVezPresionandoBoton();
                txtPantalla.Text += 7;
            }

            else if (e.Key == System.Windows.Input.Key.NumPad8)
            {
                PrimeraVezPresionandoBoton();
                txtPantalla.Text += 8;
            }

            else if (e.Key == System.Windows.Input.Key.NumPad9)
            {
                PrimeraVezPresionandoBoton();
                txtPantalla.Text += 9;
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
               MetodoDelIgual();
            }
        }
    }
}