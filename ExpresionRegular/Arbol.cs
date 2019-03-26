using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpresionRegular
{
    public class Arbol : List<Nodo>
    {
        public void GenerarArbol(string ER)
        {
            int contHojas = 1;
            this.Clear();
            Point pos = new Point(0, 0);
            Nodo nodo;
            Arista a;
            List<Nodo> pila = new List<Nodo>();
            foreach (char c in ER)
            {
                if (char.IsLetter(c) || c == '#')
                {
                    nodo = new Nodo(c.ToString());
                    pos.X += 100;
                    nodo.centro = pos;
                    nodo.anulable = false;
                    nodo.PrimeraPos.Add(contHojas);
                    nodo.UltimaPos.Add(contHojas);
                    contHojas++;
                    this.Add(nodo);
                    pila.Add(nodo);
                }
                else
                {
                    pos.Y -= 50;
                    if (c == '|' || c == '·')
                    {
                        nodo = new Nodo(c.ToString());

                        a = new Arista();
                        a.destino = pila[pila.Count - 2];
                        nodo.aristas.Add(a);
                        pila.RemoveAt(pila.Count - 2);

                        a = new Arista();
                        a.destino = pila[pila.Count - 1];
                        nodo.aristas.Add(a);
                        pila.RemoveAt(pila.Count - 1);
                        nodo.centro.X = (nodo.aristas[0].destino.centro.X + nodo.aristas[1].destino.centro.X) / 2;
                        nodo.centro.Y = pos.Y;
                        if (nodo.name == "|")
                        {
                            nodo.anulable = (nodo.aristas[0].destino.anulable || nodo.aristas[1].destino.anulable);
                            //Calculo de la primera y siguiente Posicion
                            nodo.PrimeraPos = nodo.aristas[0].destino.PrimeraPos.Union(nodo.aristas[1].destino.PrimeraPos).ToList();
                            nodo.UltimaPos = nodo.aristas[0].destino.UltimaPos.Union(nodo.aristas[1].destino.UltimaPos).ToList();
                        }
                        else
                        {
                            nodo.anulable = (nodo.aristas[0].destino.anulable && nodo.aristas[1].destino.anulable);
                            //Calculo de la primera y siguiente Posicion
                            if (nodo.aristas[0].destino.anulable)
                                nodo.PrimeraPos = nodo.aristas[0].destino.PrimeraPos.Union(nodo.aristas[1].destino.PrimeraPos).ToList();
                            else
                            {
                                foreach (int i in nodo.aristas[0].destino.PrimeraPos)
                                    nodo.PrimeraPos.Add(i);
                            }

                            if (nodo.aristas[1].destino.anulable)
                                nodo.UltimaPos = nodo.aristas[0].destino.UltimaPos.Union(nodo.aristas[1].destino.UltimaPos).ToList();
                            else
                            {
                                foreach (int i in nodo.aristas[1].destino.UltimaPos)
                                    nodo.UltimaPos.Add(i);
                            }
                        }
                        pila.Add(nodo);
                        this.Add(nodo);
                    }
                    else
                    {
                        nodo = new Nodo(c.ToString());
                        a = new Arista();
                        a.destino = pila[pila.Count - 1];
                        nodo.aristas.Add(a);
                        pila.RemoveAt(pila.Count - 1);
                        nodo.centro.X = nodo.aristas[0].destino.centro.X;
                        nodo.centro.Y = pos.Y;

                        if (nodo.name == "+")
                            nodo.anulable = nodo.aristas[0].destino.anulable;
                        else
                            nodo.anulable = true;

                        //Calculo de la primera y siguiente Posicion
                        foreach (int i in nodo.aristas[0].destino.PrimeraPos)
                            nodo.PrimeraPos.Add(i);
                        foreach (int i in nodo.aristas[0].destino.UltimaPos)
                            nodo.UltimaPos.Add(i);
                        
                        pila.Add(nodo);
                        this.Add(nodo);
                    }
                }
            }
            foreach(Nodo n in this)
            {
                n.centro.Y += Math.Abs(pos.Y - 40);
            }
        }
    }
}
