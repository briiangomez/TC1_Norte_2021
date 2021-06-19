using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Clase que sirve para gestionar una Dirección
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Esta propiedad se utiliza para persistir el id de la dirección...
        /// </summary>
        //IL -> genera el atributo privado + métodos get and set
        public Guid IdAddress { get; set; }        

        public string Street { get; set; }

        public int Number { get; set; }

        public string City { get; set; }

        public Address()
        {

        }

        public Address(string street, int number, string city)
        {
            Street = street;
            Number = number;
            City = city;
        }

        public override string ToString()
        {
            return $"Calle: {Street}, nro: {Number}, ciudad: {City}";
        }

    }
}
