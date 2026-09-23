namespace Entidades
{
    public class AnimalPerdido
    {
        public int IdAnimal { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }
        public string Color { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPerdida { get; set; }
        public string LugarPerdida { get; set; }
        public string Estado { get; set; }
        public int IdPersona { get; set; }
    }
}