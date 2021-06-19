using Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Tracing;
using System.Threading;
using System.Globalization;
using DAL.Repositories.SqlServer;
using SL.Services;
using DAL.Factory;
using DAL.Contracts;
using SL.Services.Extentions;
using SL.Domain.Composite;
using SL.Domain;

namespace Consola
{
    class Program
    {

        static void Main(string[] args)
        {
            #region Usuario_Patente_Familia

            Patente patenteVentas = new Patente()
            {
                Nombre = "Pantalla de ventas"
            };

            Patente patenteCompras = new Patente()
            {
                Nombre = "Pantalla de compras"
            };

            Familia familia1 = new Familia(patenteVentas);
            familia1.Add(patenteCompras);

            Patente patentePerfilUsuario = new Patente()
            {
                Nombre = "Pantalla perfil de usuario"
            };

            Familia familiaCompleta = new Familia(familia1);
            familiaCompleta.Add(patentePerfilUsuario);

            Usuario usuario = new Usuario();
            usuario.UserName = "briangomez";
            usuario.Permisos.Add(familiaCompleta);

            Patente patenteSoloParaElUsuario = new Patente()
            {
                Nombre = "Pantalla de bienvenida"
            };

            usuario.Permisos.Add(patenteSoloParaElUsuario);

            Console.WriteLine($"El usuario {usuario.UserName} tiene los siguiente permisos: ");
            foreach (var item in usuario.GetPatentes())
            {
                Console.WriteLine($"Permiso: {item.Nombre}");
            }

            Console.WriteLine($"El usuario {usuario.UserName} tiene las siguientes familias: ");
            foreach (var item in usuario.GetFamilias())
            {
                Console.WriteLine($"Familia: {item.Nombre}");
            }

            #endregion



            #region MULTI-IDIOMA

            CultureInfo[] custom = CultureInfo.GetCultures(CultureTypes.UserCustomCulture);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            string palabra = "hola".Traducir();

            Console.WriteLine($"Palabra traducida:  {palabra}");

            string bienvenido = "bienvenido".Traducir();

            #endregion


            #region SINGLETON + FACTORY

            //DAL.Contracts.IGenericRepository<Address> addressRepository2 = new AddressRepository();            
            IGenericRepository<Address> addressRepository = Factory.Current.GetAddressRepository();

            //DAL.Contracts.IGenericRepository<Customer> customerRepository2 = new CustomerRepository();
            IGenericRepository<Customer> customerRepository = Factory.Current.GetCustomerRepository();

            Console.WriteLine(addressRepository.GetType().FullName);

            Console.ReadLine();

            LoggerManager instancia1 = LoggerManager.Current;
            LoggerManager instancia2 = LoggerManager.Current;

            if (instancia1 == instancia2)
            {
                Console.WriteLine("EFECTIVAMENTE ESTOY EN UN SINGLETON");
            }

            LoggerManager.Current.Write("Bienvenidos al mundo de los patrones", EventLevel.Informational);

            Address address = addressRepository.GetOne(Guid.Parse("BFB7F9B7-198B-EA11-81A3-E8D8D142D59B"));


            Console.ReadLine();


            //LOS SERVICIOS SON CANDIDATOS A SINGLETON....
            //DAL.Contracts.IGenericRepository<Address> addressRepository2 = new AddressRepository();

            #endregion

        }
    }
}
