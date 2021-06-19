using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace SL.DAL
{
    internal sealed class DALLanguage
    {
        #region Singleton
        private readonly static DALLanguage _instance = new DALLanguage();

        private string filePath;

        public static DALLanguage Current
        {
            get
            {
                return _instance;
            }
        }

        private DALLanguage()
        {
            //Implement here the initialization code
            filePath = @"I18n\idioma.";
        }
        #endregion

        public string Traducir(string clave)
        {
            string codigoCultura = Thread.CurrentThread.CurrentUICulture.Name;

            string palabraTraducida = clave;

            using (StreamReader streamReader = new StreamReader(filePath + codigoCultura))
            {
                while(!streamReader.EndOfStream)
                {
                    string linea = streamReader.ReadLine();
                    string[] keyValuePair = linea.Split(':');

                    if(keyValuePair[0].ToLower() == clave.ToLower())
                    {
                        palabraTraducida = keyValuePair[1];
                        break;
                    }
                }
            }

            return palabraTraducida;
        }
    }

}
