using Microsoft.EntityFrameworkCore;
using Persona2.DAL;
using Persona2.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Persona2.BLL
{
    public class PersonasBLL
    {
        public static bool Guardar(Personas personas)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Personas.Add(personas) != null)
                    paso = db.SaveChanges() > 0;
            }catch(Exception)
            {
                throw;
            }finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static bool Modificar(Personas personas)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(personas).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }catch(Exception)
            {
                throw;
            }finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Personas.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }catch(Exception)
            {
                throw;
            }finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static Personas Buscar(int id)
        {
            Contexto db = new Contexto();
            Personas persona = new Personas();
            try
            {
                persona = db.Personas.Find(id);
            }catch(Exception)
            {
                throw;
            }finally
            {
                db.Dispose();
            }
            return persona;
        }
        public static List<Personas> GetList(Expression<Func<Personas, bool>> persona)
        {
            List<Personas> lista = new List<Personas>();

            Contexto db = new Contexto();
            try
            {
                lista = db.Personas.Where(persona).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }
    }
}
