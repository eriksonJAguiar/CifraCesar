using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace cifraCezar
{
    [Activity(Label = "CifraCezar", MainLauncher = true, Icon = "@drawable/logo")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            Button button = FindViewById<Button>(Resource.Id.btn);

            button.Click += delegate
            {

                var cifra = FindViewById<TextView>(Resource.Id.cifraText);

                var chave = FindViewById<TextView>(Resource.Id.chaveText);

                var res = FindViewById<TextView>(Resource.Id.result);

                RadioGroup radioGroup = FindViewById<RadioGroup>(Resource.Id.cifrar_decifrar);


                RadioButton check = FindViewById<RadioButton>(radioGroup.CheckedRadioButtonId);


                if (check.Text.Equals("Cifrar"))
                {
                    if (!(cifra.Text == "" || chave.Text == ""))
                    {

                        string cifrada = cifrar(Convert.ToString(cifra.Text).ToLower(), Convert.ToInt32(chave.Text));

                        res.setText(cifrada);

                        AlertDialog.Builder alert = new AlertDialog.Builder(this);

                        alert.SetTitle("Resultado");

                        alert.SetMessage("Resultado: " + cifrada);

                        alert.Show();


                    }
                    else
                    {
                        AlertDialog.Builder alert = new AlertDialog.Builder(this);

                        alert.SetTitle("Erro");

                        alert.SetMessage("Por favor digite todos os campos");

                        alert.Show();
                    }
                }
                if (check.Text.Equals("Decifrar"))
                {
                    if (!(cifra.Text == "" || chave.Text == ""))
                    {
                        string decifrada = decifrar(Convert.ToString(cifra.Text), Convert.ToInt32(chave.Text));

                        AlertDialog.Builder alert = new AlertDialog.Builder(this);

                        alert.SetTitle("Resultado");

                        alert.SetMessage("Resultado: "+ decifrada);

                        alert.Show();
                    }
                    else
                    {
                        AlertDialog.Builder alert = new AlertDialog.Builder(this);

                        alert.SetTitle("Erro");

                        alert.SetMessage("Por favor digite todos os campos");

                        alert.Show();
                    }

                }

            };
            


        }

        private string cifrar(string palavra, int chave)
        {


            string cifrada = null;

            for(int i=0;i < palavra.Length;i++)
            {
                int caracter = palavra[i];

                int caracterCifrado = caracter + chave;

                cifrada += Char.ConvertFromUtf32(caracterCifrado);
            }

            return cifrada.ToLower();

        }
        private string decifrar(string cifrada,int chave)
        {
            string palavra = null;

            for(int i = 0; i < cifrada.Length; i++)
            {
                int caracter = cifrada[i];

                int caracterDecifrado = caracter - chave;

                palavra += Char.ConvertFromUtf32(caracterDecifrado);
            }

            return palavra;
        }

       
    }
}

