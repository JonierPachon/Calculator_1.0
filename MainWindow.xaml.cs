using System;
using System.Collections.Generic;
using System.Windows;
using Interactuando.Models;
//using System.Windows.

namespace Interactuando
{
    public partial class MainWindow : Window
    {
        OperacionesBasicas calculadora = new OperacionesBasicas();
        public MainWindow()
        {
            InitializeComponent();
        }

        #region BotonesDelCeroAlNueve

        //cuando se presiona el numero por primera vez y
        //y cuando realizo operaciones
        private void FiltarBotonesNumericos()
        {
            // Verificamos si se realizó operacion matemática en la calculadora
            if (calculadora.PresionarIgual == true & calculadora.Resultado != 0 & calculadora.NumeroAuxiliar != 0)
            {
                lblPantallaSecundaria.Content = '"' + txtPantallaPrincipal.Text + '"';
                txtPantallaPrincipal.Text = "";
                calculadora.Resultado = 0;
                calculadora.NumeroAuxiliar = 0;
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

        private void LimpiarCalculadora()
        {
            calculadora.LimpiarCalculadora();
            txtPantallaPrincipal.Text = "0";
            lblPantallaSecundaria.Content = "0";
        }
        private void btnLimpiarcalculadora_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCalculadora();
        }


        private void BorrarUltimoNumeroDigitado()
        {
            txtPantallaPrincipal.Text = calculadora.BorrarUltimoNumeroDigitado(txtPantallaPrincipal.Text);
        }
        private void btnBorrarUltimoNumeroDigitado_Click(object sender, RoutedEventArgs e)
        {
            BorrarUltimoNumeroDigitado();
        }


        #region OperacionesMatemáticas

        private void Operacion(string pSigno)
        {
            calculadora.RealizarOperacion(pSigno, txtPantallaPrincipal.Text, lblPantallaSecundaria.Content.ToString());

            txtPantallaPrincipal.Text = calculadora.NumeroPantallaPrincipal;
            lblPantallaSecundaria.Content = calculadora.NumeroPantallaSecundaria;
        }

        private void btnSumar_Click(object sender, RoutedEventArgs e)
        {
            Operacion("+");
        }

        private void btnRestar_Click(object sender, RoutedEventArgs e)
        {
            Operacion("-");
        }

        private void btnMultiplicar_Click(object sender, RoutedEventArgs e)
        {
            Operacion("*");
        }

        private void btnDividir_Click(object sender, RoutedEventArgs e)
        {
            Operacion("/");
        }


        #endregion


        //simbolos matematicos
        private void btnIgual_Click(object sender, RoutedEventArgs e)
        {
            CalcularOperacionAritmetica();

        }

        private void CalcularOperacionAritmetica()
        {
            if (calculadora.PresionarIgual == false)
                calculadora.CalcularOperacionAritmetica(txtPantallaPrincipal.Text,lblPantallaSecundaria.Content.ToString());

            lblPantallaSecundaria.Content = calculadora.NumeroPantallaSecundaria;
            txtPantallaPrincipal.Text = calculadora.Resultado.ToString();
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
                txtPantallaPrincipal.Text = calculadora.BorrarUltimoNumeroDigitado(txtPantallaPrincipal.Text);
            }

            else if (e.Key == System.Windows.Input.Key.Delete)
            {
                calculadora.LimpiarCalculadora();
                txtPantallaPrincipal.Text = "0";
                lblPantallaSecundaria.Content = "0";
            }




            //operaciones matematicas

            else if (e.Key == System.Windows.Input.Key.Add)
            {
                Operacion("+");
            }

            else if (e.Key == System.Windows.Input.Key.Subtract)
            {
                Operacion("-");
            }

            else if (e.Key == System.Windows.Input.Key.Multiply)
            {
                Operacion("*");
            }

            else if (e.Key == System.Windows.Input.Key.Divide)
            {
                Operacion("/");
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