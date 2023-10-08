using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNet.Modele
{
    internal static class GestionBD
    {
        public static EnitContext db = new EnitContext();
        public static void AjouterDepartement(Departement ut)
        {
            db.Departements.Add(ut);
            db.SaveChanges();
        }

        public static List<Departement> GetDepartements()
        {
            return db.Departements.ToList();
        }
        public static Departement GetDepartementById(string id)
        {
            var result = db.Departements.SingleOrDefault(u => u.IdDep == id);
            return result;
        }

        public static void AjouterClasse(Classe ut)
        {
            db.Classes.Add(ut);
            db.SaveChanges();
        }

        public static List<Classe> GetClasses()
        {
            return db.Classes.ToList();
        }
        public static List<Classe> GetClasseByDep(string cd)
        {
            return (db.Classes.Where(u => u.DepartementIdDep == cd).ToList());
        }

        public static List<Etudiant> GetEtudiants()
        {
            return db.Etudiants.ToList();
        }
        public static void AjouterEtudiant(Etudiant ut)
        {
            db.Etudiants.Add(ut);
            db.SaveChanges();
        }
    }
}
