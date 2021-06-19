using SL.Domain.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.Domain
{
    public class Usuario
    {
        public string IdiomaSeleccionado { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public List<FamiliaPatente> Permisos { get; set; } = new List<FamiliaPatente>();

        public List<Familia> GetFamilias()
        {
            return null;
        }
        public List<Patente> GetPatentes()
        {
            List<Patente> patentes = new List<Patente>();

            RecorrerPatentes(Permisos, patentes);

            return patentes;
        }

        //Segunda opción de recorrido recursivo...
        //private List<Patente> RecorrerPatentes(List<FamiliaPatente> familiasPatentes)

        private void RecorrerPatentes(List<FamiliaPatente> permisos, List<Patente> patentesSalida)
        {
            foreach (var item in permisos)
            {
                if (item.ChildrenCount() == 0)
                {
                    //Validamos que no exista el elemento en la lista...
                    if (!patentesSalida.Any(o => o.Nombre == item.Nombre))
                        patentesSalida.Add(item as Patente);
                }
                else
                {
                    Familia familia = item as Familia;
                    RecorrerPatentes(familia.Permisos, patentesSalida);
                }
            }
        }
    }
}
