using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace EjercicioValidaciones.ViewModel
{
    public class FormViewModel : BaseViewModel
    {
        #region Attributes
        private string name;
        private int age;

        #endregion

        #region Properties
        public string NameTxt
        {
            get { return this.name; }
            set { SetValue(ref this.name, value); }
        }
        public int AgeNum
        {
            get { return this.age; }
            set { SetValue(ref this.age, value); }
        }
        #endregion

        #region Commands
        public ICommand RegisterCommand 
        { 
            get 
            {
                return new RelayCommand(Register);
            }
            set
            {
            }
        }


        #endregion

        #region Methods
        private void Register()
        {
            
            if (NameValidation() && AgeValidation())
            {
                Application.Current.MainPage.DisplayAlert("Registo exitoso", "Sus datos de han guardado correctamente", "Ok");
            }
            else if (!NameValidation())
            {
                Application.Current.MainPage.DisplayAlert("Registo fallido", "El nombre no debe superar los 20 caracteres ni debe contener numeros", "Ok");
            }
            else if (!AgeValidation())
            {
                Application.Current.MainPage.DisplayAlert("Registo fallido", "La edad debe estar en un rango de 20 a 50 años y debe ser un número entero", "Ok");
            } else
            {
                Application.Current.MainPage.DisplayAlert("Registo fallido", "", "Ok");
            }
        }

        private bool NameValidation()
        {
            if (NameTxt != null)
            {
                if (NameTxt.Length <= 20 && Regex.IsMatch(NameTxt, @"^[a-zA-Z ]+$"))
                {
                    Console.WriteLine("Nombre Correcto");
                    return true;
                }
                else
                {
                    Console.WriteLine("Nombre Incorrecto");
                    return false;

                }
            }
            else
            {
                return false;
            }
        }

        private bool AgeValidation()
        {
            if (AgeNum >= 20 && AgeNum <=50 )
            {
                Console.WriteLine("Edad Correcta");
                return true;
            }
            else
            {
                Console.WriteLine("Edad Incorrecta");
                return false;

            }
        }
        #endregion

        #region Constructor
        #endregion
    }
}
