using System;
using System.Collections.Generic;
using System.Linq;

namespace Tarea3Grafica
{
    public class Objeto
    {
        private Dictionary<int, Parte> partes = new Dictionary<int, Parte>();

        public void Add(int id, Parte parte)
        {
            partes[id] = parte;
        }

        public Parte Get(int id)
        {
            return partes.ContainsKey(id) ? partes[id] : null;
        }

        public void Delete(int id)
        {
            partes.Remove(id);
        }

        public void Draw()
        {
            foreach (var parte in partes.Values)
            {
                parte.Draw();
            }
        }

     
    }
    

}

