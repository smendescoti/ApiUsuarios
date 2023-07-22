using ApiUsuarios.Domain.Interfaces;
using ApiUsuarios.Domain.Models;
using ApiUsuarios.Infra.Data.Contexts;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Add(Usuario usuario)
        {
            using (var context = new DataContext())
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            }
        }

        public void Update(Usuario usuario)
        {
            using (var context = new DataContext())
            {
                context.Usuarios.Update(usuario);
                context.SaveChanges();
            }
        }

        public Usuario Get(string email)
        {
            using (var context = new DataContext())
            {
                //LINQ
                /*
                var query = from u in context.Usuarios
                            where u.Email.Equals(email)
                            select u;
                return query.FirstOrDefault();
                */

                //LAMBDA
                /*
                return context.Usuarios
                    .FirstOrDefault(u => u.Email.Equals(email)); 
                */

                //SQL (DAPPER)                
                return context.Database.GetDbConnection()
                    .Query<Usuario>
                    ("SELECT * FROM USUARIOS WHERE EMAIL = @email",
                        new { email })
                    .FirstOrDefault();
            }
        }

        public Usuario Get(string email, string senha)
        {
            using (var context = new DataContext())
            {
                //LINQ
                /*
                var query = from u in context.Usuarios
                            where u.Email.Equals(email) && u.Senha.Equals(senha)
                            select u;
                return query.FirstOrDefault();
                */

                //LAMBDA
                /*
                return context.Usuarios
                    .FirstOrDefault(u => u.Email.Equals(email)
                                      && u.Senha.Equals(senha));
                */
                //SQL (DAPPER)                
                return context.Database.GetDbConnection()
                    .Query<Usuario>
                    ("SELECT * FROM USUARIOS WHERE EMAIL = @email AND SENHA = @senha",
                        new { email, senha })
                    .FirstOrDefault();

            }
        }
    }
}
