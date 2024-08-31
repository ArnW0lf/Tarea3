using System;
using System.Collections.Generic;
using System.Linq;



namespace Tarea3Grafica
{
     public class Escenario
     {
         private Dictionary<int, Objeto> objetos = new Dictionary<int, Objeto>();

         public void Add(int id, Objeto objeto)
         {
             objetos[id] = objeto;
         }

         public Objeto Get(int id)
         {
             return objetos.ContainsKey(id) ? objetos[id] : null;
         }

         public void Delete(int id)
         {
             objetos.Remove(id);
         }

         public void Draw()
         {
             foreach (var objeto in objetos.Values)
             {
                 objeto.Draw();
             }
         }

    }
   
}
