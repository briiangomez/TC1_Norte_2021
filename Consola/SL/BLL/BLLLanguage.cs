using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SL.DAL;

namespace SL.BLL
{

    internal sealed class BLLLanguage
    {
        #region Singleton
        private readonly static BLLLanguage _instance = new BLLLanguage();

        public static BLLLanguage Current
        {
            get
            {
                return _instance;
            }
        }

        private BLLLanguage()
        {
            //Implement here the initialization code
        }
        #endregion

        public string Traducir(string clave)
        {
            return DALLanguage.Current.Traducir(clave);
        }
    }

}
