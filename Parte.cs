using System.Collections.Generic;

namespace Tarea3Grafica
{
    public class Parte
    {
        private Dictionary<int, Poligono> poligonos = new Dictionary<int, Poligono>();

        public void Add(int id, Poligono poligono)
        {
            poligonos[id] = poligono;
        }

        public Poligono Get(int id)
        {
            poligonos.TryGetValue(id, out var poligono);
            return poligono;
        }

        public void Delete(int id)
        {
            poligonos.Remove(id);
        }

        public void Draw()
        {
            foreach (var poligono in poligonos.Values)
            {
                poligono.Draw();
            }
        }
    }
}
