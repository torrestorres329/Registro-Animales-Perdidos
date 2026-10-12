using System;
using System.Data;
using DAL;
using Entidades;

namespace BLL
{
    public class AnimalBLL
    {
        private AnimalDAL animalDAL = new AnimalDAL();

        public void Registrar(AnimalPerdido animal)
        {
            Validar(animal);
            animalDAL.Insertar(animal);
        }

        public DataTable Consultar()
        {
            return animalDAL.Listar();
        }

        public void Actualizar(AnimalPerdido animal)
        {
            Validar(animal);
            animalDAL.Actualizar(animal);
        }

        public void Eliminar(int idAnimal)
        {
            if (idAnimal <= 0)
            {
                throw new Exception("El ID del animal no es válido.");
            }

            animalDAL.Eliminar(idAnimal);
        }
// CONSULTAR ANIMALES DE UNA PERSONA
public DataTable ConsultarPorPersona(int idPersona)
{
    if (idPersona <= 0)
    {
        throw new Exception("El ID de la persona no es válido.");
    }

    return animalDAL.ListarPorPersona(idPersona);
}


// OBTENER RESUMEN DE ANIMALES DE UNA PERSONA
public DataTable ObtenerResumenPorPersona(int idPersona)
{
    if (idPersona <= 0)
    {
        throw new Exception("El ID de la persona no es válido.");
    }

    return animalDAL.ResumenPorPersona(idPersona);
}
// OBTENER ANIMALES POR CATEGORIA
public DataTable ObtenerPorCategoria()
{
    return animalDAL.ListarPorCategoria();
}
        private void Validar(AnimalPerdido animal)
        {
            if (animal == null)
            {
                throw new Exception("Los datos del animal son obligatorios.");
            }

            if (string.IsNullOrWhiteSpace(animal.Nombre))
            {
                throw new Exception("El nombre del animal es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(animal.Especie))
            {
                throw new Exception("La especie es obligatoria.");
            }

            if (string.IsNullOrWhiteSpace(animal.LugarPerdida))
            {
                throw new Exception("El lugar de pérdida es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(animal.Estado))
            {
                throw new Exception("El estado es obligatorio.");
            }

            if (animal.IdPersona <= 0)
            {
                throw new Exception("Debe seleccionar una persona responsable.");
            }
        }
    }
}