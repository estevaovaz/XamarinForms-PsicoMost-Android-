using Plugin.Settings;
using Plugin.Settings.Abstractions;
using PsicoMost.Models;
using System;

namespace PsicoMost.Utils
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        static Usuario usuario = new Usuario();

        //CRP      
        private const string CrpKey = "crp_key";
        //Senha
        private const string SenhaKey = "senha_key";
        //Email
        private const string EmailKey = "email_key";
        //Nome
        private const string NomeKey = "nome_key";
        //Registro
        private const string RegistroKey = "registro_key";
        //RegistroSessao
        private const string RegistroSKey = "registroS_key";
        //RegistroAnamnese
        private const string RegistroAKey = "registroA_key";
        
        private static readonly string SettingsDefault = string.Empty;

       
        #endregion

        public static string CRP
        {
            get
            {
                return AppSettings.GetValueOrDefault(CrpKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(CrpKey, value);
            }
        }

        public static string Senha
        {
            get
            {
                return AppSettings.GetValueOrDefault(SenhaKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SenhaKey, value);
            }
        }

        public static string Nome
        {
            get
            {
                return AppSettings.GetValueOrDefault(NomeKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(NomeKey, value);
            }
        }


        public static string Email
        {
            get
            {
                return AppSettings.GetValueOrDefault(EmailKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(EmailKey, value);
            }
        }

        public static string Registro
        {
            get
            {
                return AppSettings.GetValueOrDefault(RegistroKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(RegistroKey, value);
            }
        }


        public static string RegistroS
        {
            get
            {
                return AppSettings.GetValueOrDefault(RegistroSKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(RegistroSKey, value);
            }
        }

        public static string RegistroA
        {
            get
            {
                return AppSettings.GetValueOrDefault(RegistroAKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(RegistroAKey, value);
            }
        }


    }
}
