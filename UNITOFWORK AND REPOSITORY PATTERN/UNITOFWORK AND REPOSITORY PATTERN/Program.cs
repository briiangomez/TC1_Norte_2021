using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNITOFWORK_AND_REPOSITORY_PATTERN.Entities;
using System.Data.Linq;
using System.Data.Entity;

namespace UNITOFWORK_AND_REPOSITORY_PATTERN
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new MyDbContext("DefaultDB");
            var unitOfWork = new UnitOfWork(dbContext);

            dbContext.Books.Add(new Book());
            dbContext.Books.Add(new Book());
            dbContext.SaveChanges();
                    
            //Crear
            var author1 = new Author() { Name = "Leonardo" };
            unitOfWork.AuthorRepository.Add(author1);

            var author2 = new Author() { Name = "Agustín" };
            unitOfWork.AuthorRepository.Add(author2);

            unitOfWork.Commit(); //Guardar cambios

            //Actualizar
            var author3 = unitOfWork.AuthorRepository.Entities
                .First(n => n.Name == "Gastón");
            author3.Name = "Martín";

            author2 = unitOfWork.AuthorRepository.Entities
                .First(n => n.Name == "Daniel");
            author2.Name = "Daniel";

            unitOfWork.Commit(); //Guardar cambios

            // Eliminar
            //author1 = unitOfWork.AuthorRepository.Entities
            //    .First(n => n.Name == "Dan");
            //unitOfWork.AuthorRepository.Remove(author1);
            //unitOfWork.Commit(); //Guardar cambios

            // Eliminar
            var author4 = unitOfWork.AuthorRepository.Entities
                .First(n => n.Name == "Dan");

            unitOfWork.AuthorRepository.Remove(author4);
                        
            unitOfWork.RejectChanges(); //Quitar los cambios en memoria...

            Console.ReadKey();
        }
    }
}
