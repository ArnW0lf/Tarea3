using System.Collections.Generic;

namespace Tarea3Grafica
{
    public class Parte
    {
        private List<Poligono> poligonos = new List<Poligono>();
        private List<int> ids = new List<int>();

        public void Add(int id, Poligono poligono)
        {
            int index = ids.IndexOf(id);
            if (index >= 0)
            {
                poligonos[index] = poligono;
            }
            else
            {
                ids.Add(id);
                poligonos.Add(poligono);
            }
        }

        public Poligono Get(int id)
        {
            int index = ids.IndexOf(id);
            if (index >= 0)
            {
                return poligonos[index];
            }
            return null;  // Retorna null si no se encuentra el ID
        }

        public void Delete(int id)
        {
            int index = ids.IndexOf(id);
            if (index >= 0)
            {
                ids.RemoveAt(index);
                poligonos.RemoveAt(index);
            }
        }

        public void Draw()
        {
            foreach (var poligono in poligonos)
            {
                poligono.Draw();
            }
        }
    }

}