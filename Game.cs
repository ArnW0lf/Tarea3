using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Collections.Generic;

namespace Tarea3Grafica
{
    public class Game : GameWindow
    {
        private Escenario escenario;
        private float angleX = 0.0f;
        private float angleY = 0.0f;

        // Tamaño de la ventana
        private const int WindowWidth = 800;
        private const int WindowHeight = 800;

        public Game() : base(WindowWidth, WindowHeight, GraphicsMode.Default, "T en 3D")
        {
            escenario = new Escenario();
            InicializarEscenario();
        }

        private void InicializarEscenario()
        {
            var objetoT = new Objeto();

            var parteVertical = CrearParteVertical();
            var parteHorizontal = CrearParteHorizontal();

            objetoT.Add(1, parteVertical);
            objetoT.Add(2, parteHorizontal);

            escenario.Add(1, objetoT);
        }

        private Parte CrearParteVertical()
        {
            var parteVertical = new Parte();
            var poligonos = Vertice.CrearPoligonos();
            parteVertical.Add(1, poligonos["caraFrontalV"]);
            parteVertical.Add(2, poligonos["caraTraseraV"]);
            parteVertical.Add(3, poligonos["caraDerechaV"]);
            parteVertical.Add(4, poligonos["caraIzquierdaV"]);
            parteVertical.Add(5, poligonos["caraSuperiorV"]);
            parteVertical.Add(6, poligonos["caraInferiorV"]);

            return parteVertical;
        }

        private Parte CrearParteHorizontal()
        {
            var parteHorizontal = new Parte();
            var poligonos = Vertice.CrearPoligonos();
            parteHorizontal.Add(1, poligonos["caraTraseraH"]);
            parteHorizontal.Add(2, poligonos["caraFrontalH"]);
            parteHorizontal.Add(3, poligonos["caraDerechaH"]);
            parteHorizontal.Add(4, poligonos["caraIzquierdaH"]);
            parteHorizontal.Add(5, poligonos["caraSuperiorH"]);
            parteHorizontal.Add(6, poligonos["caraInferiorH"]);

            return parteHorizontal;
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(0.1f, 0.1f, 0.1f, 1.0f);
            GL.Enable(EnableCap.DepthTest);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-2, 2, -2, 2, -2, 2);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();


            GL.Rotate(angleX, 1.0, 0.0, 0.0);
            GL.Rotate(angleY, 0.0, 1.0, 0.0);

            escenario.Draw();

            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            float rotationSpeed = 10.0f; // Factor de velocidad de rotación

            // Incrementa los ángulos para una rotación automática más rápida
            angleX += rotationSpeed * (float)e.Time; // Rotación en el eje X
            angleY += rotationSpeed * (float)e.Time; // Rotación en el eje Y
        }

    }
}
