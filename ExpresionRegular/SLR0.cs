using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpresionRegular
{
    public partial class SLR0 : Form
    {
        List<string> gramatica = new List<string>();
        List<string> lines = new List<string>();
        List<NodoSLR> g = new List<NodoSLR>();


        public SLR0(List<string> g)
        {
            InitializeComponent();
            gram.Lines = g.ToArray();
            gramatica = g;
        }

        private void SLR0_Load(object sender, EventArgs e)
        {
            GramaticaExpandida();
            CalculaPrimero();
            CalculaSiguiente();
        }

        private void GramaticaExpandida()
        {
            bool existe = true;
            NodoSLR nodo = new NodoSLR();
            List<string> exp = new List<string>();
            for (int i = 0; i < gramatica.Count(); i++)
            {
                List<string> cad = new List<string>();
                cad = gramatica[i].Split('-').ToList();
                cad[1] = cad[1].Substring(1);
                nodo = BuscaNodo(cad[0]);
                if (nodo == null)
                {
                    existe = false;
                    nodo = new NodoSLR(cad[0]);
                }
                string element = "";
                List<string> elements = new List<string>();
                foreach (char c in cad[1])
                {
                    if (char.IsLower(c))
                    {
                        element += c;
                    }
                    else
                    {
                        if (element.Length > 0)
                            elements.Add(element);
                        elements.Add(c.ToString());
                        element = "";
                    }
                }
                if(element != "")
                    elements.Add(element);
                nodo.producciones.Add(elements);

                if (g.Count == 0)
                {
                    NodoSLR n = new NodoSLR(cad[0] + "'");
                    List<string> l = new List<string>();
                    l.Add(cad[0]);
                    n.producciones.Add(l);
                    g.Add(n);
                    lines.Add(cad[0] + "'->" + cad[0]);
                }
                lines.Add(gramatica[i]);
                if (!existe)
                {
                    existe = true;
                    g.Add(nodo);
                }
            }

            expandida.Lines = lines.ToArray();
        }

        private void CalculaPrimero()
        {
            foreach(NodoSLR n in g)
            {
                foreach(List<string> ls in n.producciones)
                {
                    if(!char.IsUpper(ls[0][0]))
                    {
                        n.primero.Add(ls[0]);
                    }
                }
            }

            bool cambio = true;
            NodoSLR nAux;
            while(cambio)
            {
                cambio = false;
                foreach(NodoSLR n in g)
                {
                    foreach (List<string> ls in n.producciones)
                    {
                        if(char.IsUpper(ls[0][0]) && ls[0]!= n.name)
                        {
                            nAux = BuscaNodo(ls[0]);
                            if(CambioGenerado(n.primero, nAux.primero))
                            {
                                cambio = true;
                                n.primero = n.primero.Union(nAux.primero).ToList();
                            }
                        }
                    }
                }
            }

            treePrimero.BeginUpdate();
            for(int i = 0; i < g.Count; i++)
            {
                treePrimero.Nodes.Add("PRI(" + g[i].name + ")");
                foreach(string s in g[i].primero)
                {
                    treePrimero.Nodes[i].Nodes.Add(s);
                }
            }
            treePrimero.EndUpdate();
        }

        private void CalculaSiguiente()
        {
            NodoSLR nAux = new NodoSLR();
            bool cambio = true;
            g[0].siguiente.Add("$");
            while (cambio)
            {
                cambio = false;
                foreach (NodoSLR n in g)
                {
                    foreach(List<string> p in n.producciones)
                    {
                        if(char.IsUpper(p.Last()[0]))
                        {
                            nAux = BuscaNodo(p.Last());
                            if (CambioGenerado(nAux.siguiente, n.siguiente))
                            {
                                nAux.siguiente = nAux.siguiente.Union(n.siguiente).ToList();
                                cambio = true;
                            }
                        }
                    }
                    foreach (NodoSLR nc in g)
                    {
                        foreach (List<string> ls in nc.producciones)
                        {
                            for (int i = 0; i < ls.Count; i++)
                            {
                                if (ls[i].Equals(n.name))
                                {
                                    if (i + 1 < ls.Count)
                                    {
                                        if (char.IsUpper(ls[i + 1][0]))
                                        {
                                            nAux = BuscaNodo(ls[i + 1]);
                                            if (CambioGenerado(n.siguiente, nAux.primero))
                                            {
                                                n.siguiente = n.siguiente.Union(nAux.primero).ToList();
                                                cambio = true;
                                            }
                                        }
                                        else
                                        {
                                            if (!n.siguiente.Contains(ls[i + 1]))
                                            {
                                                n.siguiente.Add(ls[i + 1]);
                                                cambio = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            treeSiguiente.BeginUpdate();
            for(int i = 0; i < g.Count; i++)
            {
                treeSiguiente.Nodes.Add(g[i].name);
                foreach(string s in g[i].siguiente)
                {
                    treeSiguiente.Nodes[i].Nodes.Add(s);
                }
            }
            treeSiguiente.EndUpdate();
        }

        private NodoSLR BuscaNodo(string cad)
        {
            foreach(NodoSLR n in g)
            {
                if (cad == n.name)
                    return n;
            }
            return null;
        }

        private bool CambioGenerado(List<string> d, List<string> p)
        {
            if (p.Count == 0)
                return false;
            else
            {
                foreach(string s in p)
                {
                    if (!d.Contains(s))
                        return true;
                }
            }
            return false;
        }
    }
}
