using System;
using System.Collections.Generic;
using System.Windows;
using Interactuando.Models;
//using System.Windows.

namespace Interactuando
{
    public partial class MainWindow : Window
    {
        CalculadoraBasica calculadora = new CalculadoraBasica();
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
            if ((calculadora.CalculoRealizado == true &
                calculadora.Resultado != 0 & 
                calculadora.NumeroAuxiliar != 0) | 
                txtPantallaPrincipal.Text.ToLower() == "nan")
            {
                txtPantallaSecundaria.Text = '"' + txtPantallaPrincipal.Text + '"';
                txtPantallaPrincipal.Text = "";
                calculadora.Resultado = 0;
                calculadora.NumeroAuxiliar = 0;
                calculadora.CalculoRealizado = false;
            }

            else if (txtPantallaPrincipal.Text == "0")
            {
                txtPantallaPrincipal.Text = "";
            }
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            if (txtPantallaPrincipal.Text.ToLower() == "nan")
            {
                txtPantallaSecundaria.Text = "0";
                txtPantallaPrincipal.Text = "0";
            }
            else if (txtPantallaPrincipal.Text != "0")
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
            txtPantallaSecundaria.Text = "0";
        }
        private void btnLimpiarcalculadora_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCalculadora();
        }


        private void BorrarUltimoNumeroDigitado()
        {
            if (txtPantallaPrincipal.Text.ToLower() == "nan")
            {
                txtPantallaPrincipal.Text = "0";
                txtPantallaSecundaria.Text = "0";
            }
            else
            {
                txtPantallaPrincipal.Text = calculadora.BorrarUltimoNumeroDigitado(txtPantallaPrincipal.Text);
            }
        }
        private void btnBorrarUltimoNumeroDigitado_Click(object sender, RoutedEventArgs e)
        {
            BorrarUltimoNumeroDigitado();
        }


        #region OperacionesMatemáticas

        private void Operacion(string pSigno)
        {
            if (txtPantallaPrincipal.Text.ToLower() == "nan")
            {
                txtPantallaSecundaria.Text = '"' + txtPantallaPrincipal.Text + '"';
                txtPantallaPrincipal.Text = "0";
            }
            else
            {
                calculadora.RealizarOperacion(pSigno, txtPantallaPrincipal.Text, txtPantallaSecundaria.Text.ToString());

                txtPantallaPrincipal.Text = calculadora.NumeroPantallaPrincipal;
                txtPantallaSecundaria.Text = calculadora.NumeroPantallaSecundaria;

            }
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

        private void CalcularOperacionAritmetica()
        {
            if (calculadora.CalculoRealizado == false)
                calculadora.CalcularOperacionAritmetica(txtPantallaPrincipal.Text,txtPantallaSecundaria.Text.ToString());

            txtPantallaSecundaria.Text = calculadora.NumeroPantallaSecundaria;
            txtPantallaPrincipal.Text = calculadora.Resultado.ToString();

            
        }

        private void btnIgual_Click(object sender, RoutedEventArgs e)
        {
            CalcularOperacionAritmetica();

        }


        private void btnConvertidor_Click(object sender, RoutedEventArgs e)
        {
            txtPantallaPrincipal.Text = calculadora.ConvertidorNegativoPositivo(txtPantallaPrincipal.Text);
        }

        private void btnDecimal_Click(object sender, RoutedEventArgs e)
        {
            PuntoDecimal();
        }

        //ya esta
        private void PuntoDecimal()
        {
            txtPantallaPrincipal.Text = calculadora.FiltroPuntoDecimal(txtPantallaPrincipal.Text);
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
                if (txtPantallaPrincipal.Text.ToLower() == "nan")
                {
                    txtPantallaSecundaria.Text = "0";
                    txtPantallaPrincipal.Text = "0";
                }
                else if (txtPantallaPrincipal.Text != "0")
                {
                    txtPantallaPrincipal.Text += 0;
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