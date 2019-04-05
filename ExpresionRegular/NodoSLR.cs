using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpresionRegular
{
    class NodoSLR
    {
        public List<List<string>> producciones = new List<List<string>>();
        public List<string> primero = new List<string>();
        public List<string> siguiente = new List<string>();
        public string name;
        public NodoSLR(string n) { name = n; }
        public NodoSLR() {}
    }
}
