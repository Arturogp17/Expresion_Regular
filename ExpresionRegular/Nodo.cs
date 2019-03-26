using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpresionRegular
{
    public class Nodo
    {
        public List<int> PrimeraPos;
        public List<int> UltimaPos;
        public List<int> SiguientePos;
        public bool anulable;
        public Point centro;
        public int radio;
        public bool visitado;
        public List<int> conjunto;
        public List<Arista> aristas;
        public string name;
        public int nivel;
        public bool terminal;

        public Nodo(){ }

        public Nodo(string nombre)
        {
            terminal = false;
            name = nombre;
            aristas = new List<Arista>();
            conjunto = new List<int>();
            PrimeraPos = new List<int>();
            UltimaPos = new List<int>();
            SiguientePos = new List<int>();
            aristas = new List<Arista>();
            radio = 15;
            visitado = false;
        }
    }
}
