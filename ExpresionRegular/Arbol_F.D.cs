using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpresionRegular
{
    public partial class Arbol_F : Form
    {
        Graphics g, gA;
        int opcion;
        Pen Pen, PenA;
        SolidBrush brush, brushFont, brushPrimera, brushUltima, brushAnulable, brushArista;
        SolidBrush brushVer, brushVerFinal;
        Pen penV, penVF;
        Arbol arbol, autVerif;
        Bitmap bmp, bmpA;
        bool VerificaTick;
        Font font, fontpos, fontA;
        bool band, wVerificada;
        int contV = 0;
        Nodo nodoAux;
        Bezier bz;
        Point p1;
        double z;
        int contZoomAut= 10, contZoom = 10;
        int w, h;
        List<Point> respaldo, respaldoAut;
        Arbol automata;
        List<Nodo> nodosV = new List<Nodo>();
        List<Arista> AristasV = new List<Arista>();
        int autYpos = 150;
        List<int> estado = new List<int>();
        AdjustableArrowCap arrow;
        DateTime inicio;

        public Arbol_F(Arbol a, string ER, string ERP)
        {
            InitializeComponent();
            arbol = a;
            ExpReg.Text = ER;
            ER_Post.Text = ERP;
        }

        private void Arbol_F_Load(object sender, EventArgs e)
        {
            VerificaTick = false;
            brushArista = new SolidBrush(Color.Blue);
            autVerif = new Arbol();
            fontA = new Font("Arial", 10, FontStyle.Bold);
            g = pictureArbol.CreateGraphics();
            gA = pictureAutomata.CreateGraphics();
            automata = new Arbol();
            font = new Font("Arial", 12, FontStyle.Bold);
            fontpos = new Font("Arial", 10, FontStyle.Bold);
            Pen = new Pen(Color.Black, 2);
            penV = new Pen(Color.Purple, 3);
            penVF = new Pen(Color.DeepSkyBlue, 3);
            PenA = new Pen(Color.Black, 2);
            arrow = new AdjustableArrowCap(5, 5);
            PenA.CustomEndCap = arrow;
            penV.CustomEndCap = arrow;
            penVF.CustomEndCap = arrow;
            brush = new SolidBrush(Color.White);
            brushFont = new SolidBrush(Color.Black);
            brushAnulable = new SolidBrush(Color.Red);
            brushPrimera = new SolidBrush(Color.Green);
            brushUltima = new SolidBrush(Color.Blue);
            brushVer = new SolidBrush(Color.Purple);
            brushVerFinal = new SolidBrush(Color.Red);
            nodoAux = new Nodo();
            p1 = new Point();
            w = 0;
            h = 0;
            respaldo = new List<Point>();
            respaldoAut = new List<Point>();
            z = 1.0;
            band = false;
            opcion = 0;
            SizeBmp(ref w, ref h, arbol);
            bmp = new Bitmap(w, h);
            tabArbol.BackColor = Color.White;
            Pinta();
            LlenaTablaPosiciones();
            GeneraSiguientePos();
            respalda(arbol, respaldo);
            GeneraAutomata();
            SetNiveles(automata[0], 0);
            foreach (Nodo n in automata)
            {
                n.visitado = false;
                n.centro = new Point(0, 0);
            }
            GeneraPosicionesAutomata(automata[0]);
            respalda(automata, respaldoAut);
            SizeBmp(ref w, ref h, automata);
            bmpA = new Bitmap(w, h);
            PintaAutomata();
        }

        private void pictureArbol_Paint(object sender, PaintEventArgs e)
        {
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            foreach (Nodo n in arbol)
            {
                foreach (Arista a in n.aristas)
                {
                    g.DrawLine(Pen, n.centro, a.destino.centro);
                }
            }

            foreach (Nodo n in arbol)
            {
                int cont = 0;
                g.FillEllipse(brush, n.centro.X - n.radio, n.centro.Y - n.radio, n.radio * 2, n.radio * 2);
                g.DrawEllipse(Pen, n.centro.X - n.radio, n.centro.Y - n.radio, n.radio * 2, n.radio * 2);

                g.DrawString(n.name, font, brushFont, n.centro.X - (n.radio / 2), n.centro.Y - (n.radio / 2));
                string s = "{";
                cont = 0;
                foreach (int i in n.PrimeraPos)
                {
                    if (cont == 1)
                    {
                        s += i.ToString() + ",\n";
                        cont = 0;
                    }
                    else
                    {
                        cont++;
                        s += i.ToString() + ",";
                    }
                }
                s = s.Remove(s.Length - 1);
                s += "}";
                g.DrawString(s, fontpos, brushPrimera, n.centro.X - (n.radio * 3), n.centro.Y - (n.radio / 2));
                s = "{";
                cont = 0;
                foreach (int i in n.UltimaPos)
                {
                    if (cont == 2)
                    {
                        s += i.ToString() + ",\n";
                        cont = 0;
                    }
                    else
                    {
                        cont++;
                        s += i.ToString() + ",";
                    }
                }

                s = s.Remove(s.Length - 1);
                s += "}";
                g.DrawString(s, fontpos, brushUltima, n.centro.X + n.radio , n.centro.Y - (n.radio / 2));
                if (n.anulable)
                    g.DrawString("T", fontpos, brushAnulable, n.centro.X, n.centro.Y + n.radio);
                else
                    g.DrawString("F", fontpos, brushAnulable, n.centro.X, n.centro.Y + n.radio);

            }
            
            g.DrawImage(bmp, 0, 0);
            pictureArbol.Image = bmp;
        }


        private void pictureArbol_MouseDown(object sender, MouseEventArgs e)
        {
            p1 = e.Location;
            if(opcion != 0)
            {
                nodoAux = BuscaNodo(e.Location, arbol);
                if (nodoAux != null)
                {
                    band = true;
                }
            }
        }

        private void pictureArbol_MouseMove(object sender, MouseEventArgs e)
        {
            if(band && e.Button.Equals(MouseButtons.Left))
            {
                SizeBmp(ref w, ref h, arbol);
                bmp = new Bitmap(w, h);
                if (opcion == 1)
                    nodoAux.centro = e.Location;
                else
                {
                    int distx, disty;

                    distx = e.Location.X - p1.X;
                    disty = e.Location.Y - p1.Y;
                    Point p = new Point();
                    foreach (Nodo n in arbol)
                    {
                        p.X = n.centro.X + distx;
                        p.Y = n.centro.Y + disty;
                        n.centro = p;
                    }
                    p1 = e.Location;
                }
                pictureArbol_Paint(this, null);
            }
        }

        private void pictureArbol_MouseUp(object sender, MouseEventArgs e)
        {
            band = false;
        }

        private void LlenaTablaPosiciones()
        {
            dataPosiciones.Columns.Add("Nodo", "Nodo");
            dataPosiciones.Columns.Add("Anulable", "Anulable");
            dataPosiciones.Columns.Add("Primera Pos", "Primera Pos");
            dataPosiciones.Columns.Add("Ultima Pos", "Ultima Pos");
            foreach (Nodo n in arbol)
            {
                string p = "", u = "";
                foreach (int i in n.PrimeraPos)
                    p += i.ToString() + ",";

                p = p.Remove(p.Length - 1);

                foreach (int i in n.UltimaPos)
                    u += i.ToString() + ",";
                u = u.Remove(u.Length - 1);

                dataPosiciones.Rows.Add(n.name, n.anulable.ToString(), "{" + p + "}", "{" + u + "}");
            }
        }

        private void GeneraSiguientePos()
        {
            string s = "";
            dataSigPos.Columns.Add("Hoja", "Hoja");
            dataSigPos.Columns.Add("Operador", "Operador");
            dataSigPos.Columns.Add("Conjunto", "Conjunto");
            List<Nodo> hojas = new List<Nodo>();
            List<Nodo> operandos = new List<Nodo>();
            List<int> siguientes = new List<int>();
            List<int> sig = new List<int>();

            foreach (Nodo n in arbol)
            {
                if (char.IsLetter(n.name[0]) || n.name == "#")
                    hojas.Add(n);
                else
                    operandos.Add(n);
            }

            foreach (Nodo n in hojas)
            {
                siguientes.Clear();
                int count = 0;
                foreach (Nodo o in operandos)
                {
                    if (o.aristas.Count == 2)
                    {
                        if (o.aristas[0].destino.UltimaPos.Contains(n.PrimeraPos[0]))
                        {
                            foreach (int i in o.aristas[1].destino.PrimeraPos)
                                sig.Add(i);
                        }
                    }
                    else
                    {
                        if (o.aristas[0].destino.UltimaPos.Contains(n.PrimeraPos[0]))
                        {
                            foreach (int i in o.aristas[0].destino.PrimeraPos)
                                sig.Add(i);
                        }
                    }
                    s = "";
                    sig.Sort();
                    foreach (int i in sig)
                        s += i.ToString() + ",";
                    if (s.Length > 0)
                        s = s.Remove(s.Length - 1);
                    else
                        s = "---";
                    if (count == 0)
                    {
                        count++;
                        dataSigPos.Rows.Add(n.name, o.name, "{" + s + "}");
                    }
                    else
                        dataSigPos.Rows.Add("", o.name, "{" + s + "}");
                    siguientes = siguientes.Union(sig).ToList();
                    sig.Clear();
                }
                s = "";
                siguientes.Sort();
                foreach (int i in siguientes)
                {
                    s += i.ToString() + ",";
                    n.SiguientePos.Add(i);
                }
                if (s.Length > 0)
                    s = s.Remove(s.Length - 1);
                else
                    s = "---";
                dataSigPos.Rows.Add("", "Siguiente Pos", "{" + s + "}");
            }
        }

        private Nodo BuscaNodo(Point p, Arbol arbol)
        {
            foreach (Nodo n in arbol)
            {
                if (Math.Sqrt(Math.Pow(p.X - n.centro.X, 2) + Math.Pow(p.Y - n.centro.Y, 2)) <= n.radio)
                    return n;
            }
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (contZoom > 1)
            {
                contZoom--;
                z = 0.9;
                Zoom(arbol);
                pictureArbol_Paint(this, null);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            obten(arbol, respaldo);
            contZoom = 10;
            z = 1.0;
            Zoom(arbol);
            pictureArbol_Paint(this, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (contZoom < 19)
            {
                contZoom++;
                z = 1.1;
                Zoom(arbol);
                pictureArbol_Paint(this, null);
            }
        }

        private void Zoom(Arbol a)
        {
            if (z == 1.1)
            {
                font = new Font("Arial", font.Size + 1, FontStyle.Bold);
                fontpos = new Font("Arial", fontpos.Size + 1, FontStyle.Bold);
            }
            else
            {
                if (font.Size - 1 > 0 && fontpos.Size - 1 > 0)
                {
                    font = new Font("Arial", font.Size - 1, FontStyle.Bold);
                    fontpos = new Font("Arial", fontpos.Size - 1, FontStyle.Bold);
                }
            }
            foreach (Nodo n in a)
            {
                Point p = new Point();
                p.X = (int)Math.Round(n.centro.X * z);
                p.Y = (int)Math.Round(n.centro.Y * z);
                n.radio = (int)Math.Round(n.radio * z);
                n.centro = p;
            }
            SizeBmp(ref w, ref h, arbol);
            bmp = new Bitmap(w, h);
            Pinta();
            SizeBmp(ref w, ref h, automata);
            bmpA = new Bitmap(w, h);
            PintaAutomata();
        }

        private void Pinta()
        {
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            foreach (Nodo n in arbol)
            {
                foreach (Arista a in n.aristas)
                {
                    g.DrawLine(Pen, n.centro, a.destino.centro);
                }
            }

            foreach (Nodo n in arbol)
            {
                int cont = 0;
                g.FillEllipse(brush, n.centro.X - n.radio, n.centro.Y - n.radio, n.radio * 2, n.radio * 2);
                g.DrawEllipse(Pen, n.centro.X - n.radio, n.centro.Y - n.radio, n.radio * 2, n.radio * 2);

                g.DrawString(n.name, font, brushFont, n.centro.X - (n.radio / 2), n.centro.Y - (n.radio / 2 + 1));
                string s = "{";
                cont = 0;
                foreach (int i in n.PrimeraPos)
                {
                    if (cont == 1)
                    {
                        s += i.ToString() + ",\n";
                        cont = 0;
                    }
                    else
                    {
                        cont++;
                        s += i.ToString() + ",";
                    }
                }
                s = s.Remove(s.Length - 1);
                s += "}";
                g.DrawString(s, fontpos, brushPrimera, n.centro.X - (n.radio * 3), n.centro.Y - (n.radio / 2 + 1));
                s = "{";
                cont = 0;
                foreach (int i in n.UltimaPos)
                {
                    if (cont == 2)
                    {
                        s += i.ToString() + ",\n";
                        cont = 0;
                    }
                    else
                    {
                        cont++;
                        s += i.ToString() + ",";
                    }
                }

                s = s.Remove(s.Length - 1);
                s += "}";
                g.DrawString(s, fontpos, brushUltima, n.centro.X + n.radio, n.centro.Y - n.radio);
                if (n.anulable)
                    g.DrawString("T", fontpos, brushAnulable, n.centro.X, n.centro.Y + n.radio);
                else
                    g.DrawString("F", fontpos, brushAnulable, n.centro.X, n.centro.Y + n.radio);

            }

            g.DrawImage(bmp, 0, 0);
            pictureArbol.Image = bmp;
        }
               
        private void Simulacion_Tick(object sender, EventArgs e)
        {
            Nodo nd = new Nodo();
            Arista a = new Arista();
            if (contV < nodosV.Count)
            {
                if (autVerif.Count == contV)
                {
                    /*nd = new Nodo(nodosV[contV].name);
                    nd.nivel = nodosV[contV].nivel;
                    nd.centro = nodosV[contV].centro;
                    nd.terminal = nodosV[contV].terminal;*/
                    autVerif.Add(nodosV[contV]);
                }
                else
                {
                    if (contV < AristasV.Count)
                        autVerif.Last().aristas.Add(AristasV[contV]);
                    contV++;
                }
            }
            else
            {
                foreach(Nodo n in nodosV)
                {
                    n.aristas.Clear();
                }
                foreach (Nodo n in autVerif)
                {
                    n.aristas.Clear();
                }
                autVerif.Clear();
                contV = 0;
            }
        }

        private int nivelMayor()
        {
            int mayor = 0;
            foreach (Nodo n in automata)
                if (n.nivel > mayor)
                    mayor = n.nivel;
            return mayor;
        }

        private void GeneraPosicionesAutomata(Nodo n)
        {
            n.visitado = true;
            if (n.aristas.Count > 0)
            {
                if (AristaNoVisitadas(n))
                {
                    foreach (Arista a in n.aristas)
                    {
                        if (!a.destino.visitado)
                            GeneraPosicionesAutomata(a.destino);
                    }
                    n.centro = PosicionPadre(n);
                }
                else
                {
                    if(n.aristas[0].destino.centro.X != 0)
                    {
                        n.centro = PosicionPadre(n);
                    }
                    else
                    {
                        n.centro.X = n.nivel * 130 + 50;
                        n.centro.Y = autYpos;
                        autYpos += 80;
                    }
                }
            }
            else
            {
                n.centro.X = n.nivel * 130 + 50;
                n.centro.Y = autYpos;
                autYpos += 80;
            }
        }

        private Point PosicionPadre(Nodo n)
        {
            Point p = new Point();
            int y = 0, cont = 0;
            foreach(Arista a in n.aristas)
            {
                if (a.destino.name != n.name && n.nivel + 1 == a.destino.nivel)
                {
                    y += a.destino.centro.Y;
                    cont++;
                }
            }
            if(cont == 0)
            {
                p = new Point(n.nivel * 130 + 50, autYpos);
                autYpos += 80;
            }
            else
                p = new Point(n.nivel * 130 + 50, y / cont);
            return p;
        }

        private bool AristaNoVisitadas(Nodo n)
        {
            foreach(Arista a in n.aristas)
            {
                if (!a.destino.visitado)
                    return true;
            }
            return false;
        }

        private void SetNiveles(Nodo n, int nivel)
        {
            n.nivel = nivel;
            n.visitado = true;
            foreach(Arista a in n.aristas)
            {
                if(!a.destino.visitado && n.name[0] < a.destino.name[0])
                    SetNiveles(a.destino, nivel + 1);
            }
        }

        private void PintaAutomata()
        {
            gA = Graphics.FromImage(bmpA);
            gA.Clear(Color.White);

            foreach(Nodo n in automata)
            {
                gA.FillEllipse(brush, n.centro.X - n.radio, n.centro.Y - n.radio, n.radio * 2, n.radio * 2);
                gA.DrawEllipse(Pen, n.centro.X - n.radio, n.centro.Y - n.radio, n.radio * 2, n.radio * 2);
                gA.DrawString(n.name, font, brushFont, n.centro.X - (n.radio / 2), n.centro.Y - (n.radio / 2 + 1));
                foreach(Arista a in n.aristas)
                {
                    if(a.destino.Equals(n))
                        gA.DrawBezier(PenA, n.centro.X - (n.radio / 3 * 2), n.centro.Y - (n.radio / 3 * 2), n.centro.X - (n.radio), n.centro.Y - (n.radio * 2), n.centro.X + n.radio, n.centro.Y - (n.radio*2), n.centro.X + (n.radio / 3 * 2), n.centro.Y - (n.radio / 3 * 2));
                    else
                        gA.DrawLine(PenA, BuscaInterseccion(n.centro, a.destino.centro, n.radio), BuscaInterseccion(a.destino.centro, n.centro, n.radio));
                }
            }
            gA.DrawImage(bmpA, 0, 0);
            pictureAutomata.Image = bmpA;
        }

        private void Simular_Click(object sender, EventArgs e)
        {
            if(!VerificaTick)
            {
                VerificaTick = true;
                inicio = DateTime.Now;
            }
            else
            {
                VerificaTick = false;
                contV = 0;
                foreach(Nodo n in autVerif)
                {
                    n.aristas.Clear();
                }
                autVerif.Clear();

                foreach(Nodo n in nodosV)
                {
                    n.aristas.Clear();
                }
                nodosV.Clear();
                AristasV.Clear();
            }
        }

        private void TextVer_TextChanged(object sender, EventArgs e)
        {
            Simular.Enabled = false;
            Simular.Visible = false;
            VerRes.Visible = false;
            VerificaTick = false;
            contV = 0;
            foreach (Nodo n in autVerif)
            {
                n.aristas.Clear();
            }
            autVerif.Clear();
            foreach (Nodo n in nodosV)
            {
                n.aristas.Clear();
            }
            nodosV.Clear();
            AristasV.Clear();
        }

        private void pictureAutomata_Paint(object sender, PaintEventArgs e)
        {
            gA = Graphics.FromImage(bmpA);
            gA.Clear(Color.White);

            foreach (Nodo n in automata)
            {
                gA.FillEllipse(brush, n.centro.X - n.radio, n.centro.Y - n.radio, n.radio * 2, n.radio * 2);
                gA.DrawEllipse(Pen, n.centro.X - n.radio, n.centro.Y - n.radio, n.radio * 2, n.radio * 2);
                if (n.terminal)
                    gA.DrawEllipse(Pen, n.centro.X - n.radio + 3, n.centro.Y - n.radio + 3, n.radio * 2 - 6, n.radio * 2 - 6);
                gA.DrawString(n.name, font, brushFont, n.centro.X - (n.radio / 2), n.centro.Y - (n.radio / 2 + 1));


                foreach (Arista a in n.aristas)
                {
                    if (a.destino.Equals(n))
                    {
                        gA.DrawBezier(PenA, n.centro.X - (n.radio / 3 * 2), n.centro.Y - (n.radio / 3 * 2), n.centro.X - (n.radio), n.centro.Y - (n.radio * 2 + 5), n.centro.X + n.radio, n.centro.Y - (n.radio * 2 + 2), n.centro.X + (n.radio / 3 * 2), n.centro.Y - (n.radio / 3 * 2));
                        gA.DrawString(a.nombre, fontA, brushArista, n.centro.X, n.centro.Y - (n.radio * 3));
                    }
                    else
                    {
                        if (n.nivel + 1 == a.destino.nivel)
                        {
                            gA.DrawLine(PenA, BuscaInterseccion(n.centro, a.destino.centro, n.radio), BuscaInterseccion(a.destino.centro, n.centro, n.radio));
                            gA.DrawString(a.nombre, fontA, brushArista, (n.centro.X + a.destino.centro.X) / 2 - 8, (n.centro.Y + a.destino.centro.Y) / 2 - 15);
                        }
                        else
                        {
                            bz = new Bezier(BuscaInterseccion(a.destino.centro, n.centro, n.radio), BuscaInterseccion(n.centro, a.destino.centro, n.radio), gA, PenA, false, a.nombre, false, true);
                        }

                    }
                }
            }
            

            if (VerificaTick)
            {
                DateTime entrada = DateTime.Now;
                if (entrada - inicio >= new TimeSpan(8000000))
                {
                    inicio = entrada;
                    Simulacion_Tick(this, null);
                }
                foreach (Nodo n in autVerif)
                {
                    if (n.terminal && nodosV.Last().Equals(n))
                        gA.FillEllipse(brushVerFinal, n.centro.X - n.radio, n.centro.Y - n.radio, n.radio * 2, n.radio * 2);
                    else
                    {
                        if(n.aristas.Count == 0)
                            gA.FillEllipse(new SolidBrush(Color.DeepSkyBlue), n.centro.X - n.radio, n.centro.Y - n.radio, n.radio * 2, n.radio * 2);
                        else
                            gA.FillEllipse(brushVer, n.centro.X - n.radio, n.centro.Y - n.radio, n.radio * 2, n.radio * 2);
                    }
                    gA.DrawEllipse(Pen, n.centro.X - n.radio, n.centro.Y - n.radio, n.radio * 2, n.radio * 2);
                    if (n.terminal)
                        gA.DrawEllipse(Pen, n.centro.X - n.radio + 3, n.centro.Y - n.radio + 3, n.radio * 2 - 6, n.radio * 2 - 6);
                    gA.DrawString(n.name, font, brushFont, n.centro.X - (n.radio / 2), n.centro.Y - (n.radio / 2 + 1));


                    foreach (Arista a in n.aristas)
                    {
                        if (a.destino.name == n.name)
                        {
                            if(autVerif.Last().Equals(n))
                                gA.DrawBezier(penVF, n.centro.X - (n.radio / 3 * 2), n.centro.Y - (n.radio / 3 * 2), n.centro.X - (n.radio), n.centro.Y - (n.radio * 2 + 5), n.centro.X + n.radio, n.centro.Y - (n.radio * 2 + 2), n.centro.X + (n.radio / 3 * 2), n.centro.Y - (n.radio / 3 * 2));
                            else
                                gA.DrawBezier(penV, n.centro.X - (n.radio / 3 * 2), n.centro.Y - (n.radio / 3 * 2), n.centro.X - (n.radio), n.centro.Y - (n.radio * 2 + 5), n.centro.X + n.radio, n.centro.Y - (n.radio * 2 + 2), n.centro.X + (n.radio / 3 * 2), n.centro.Y - (n.radio / 3 * 2));
                            gA.DrawString(a.nombre, fontA, brushVer, n.centro.X, n.centro.Y - (n.radio * 3));
                        }
                        else
                        {
                            if (n.nivel + 1 == a.destino.nivel)
                            {
                                if (autVerif.Last().Equals(n))
                                    gA.DrawLine(penVF, BuscaInterseccion(n.centro, a.destino.centro, n.radio), BuscaInterseccion(a.destino.centro, n.centro, n.radio));
                                else
                                    gA.DrawLine(penV, BuscaInterseccion(n.centro, a.destino.centro, n.radio), BuscaInterseccion(a.destino.centro, n.centro, n.radio));
                                gA.DrawString(a.nombre, fontA, brushVer, (n.centro.X + a.destino.centro.X) / 2 - 8, (n.centro.Y + a.destino.centro.Y) / 2 - 15);
                            }
                            else
                            {
                                if (autVerif.Last().Equals(n))
                                    bz = new Bezier(BuscaInterseccion(a.destino.centro, n.centro, n.radio), BuscaInterseccion(n.centro, a.destino.centro, n.radio), gA, penVF, false, a.nombre, false, true);
                                else
                                    bz = new Bezier(BuscaInterseccion(a.destino.centro, n.centro, n.radio), BuscaInterseccion(n.centro, a.destino.centro, n.radio), gA, penV, false, a.nombre, false, true);
                            }
                        }
                    }
                }
            }
            gA.DrawImage(bmpA, 0, 0);
            pictureAutomata.Image = bmpA;
        }

        private void SizeBmp(ref int w, ref int h, Arbol a)
        {
            int mayor = 0;
            int mayorY = 0;
            foreach (Nodo n in a)
            {
                if (n.centro.X > mayor)
                    mayor = n.centro.X;
                if (n.centro.Y > mayorY)
                    mayorY = n.centro.Y;
            }
            w = (mayor + 100);
            h = (mayorY + 100);
        }

        private void PictureAutomata_MouseDown(object sender, MouseEventArgs e)
        {
            p1 = e.Location;
            if (opcion != 0)
            {
                nodoAux = BuscaNodo(e.Location, automata);
                if (nodoAux != null)
                {
                    band = true;
                }
            }
        }

        private void Validar_Click(object sender, EventArgs e)
        {
            VerificaTick = false;
            foreach (Nodo n in nodosV)
                n.aristas.Clear();
            nodosV.Clear();
            AristasV.Clear();
            autVerif.Clear();
            contV = 0;
            Arista ar = new Arista();
            Nodo EdoActual = new Nodo();
            Nodo nod = new Nodo();
            bool bandV = true;
            EdoActual = automata[0];
            nod = new Nodo(EdoActual.name);
            nod.centro = EdoActual.centro;
            nod.radio = EdoActual.radio;
            nod.nivel = EdoActual.nivel;
            nod.terminal = EdoActual.terminal;
            nodosV.Add(nod);
            string w = "";
            w = TextVer.Text;
            int contW = 0;
            if(w.Length > 0)
            {
                while(contW < w.Length && bandV)
                {
                    bandV = false;
                    foreach(Arista a in EdoActual.aristas)
                    {
                        if (a.nombre[0] == w[contW])
                        { 
                            EdoActual = a.destino;
                            nod = new Nodo(EdoActual.name);
                            nod.centro = EdoActual.centro;
                            nod.nivel = EdoActual.nivel;
                            nod.terminal = EdoActual.terminal;
                            nod.radio = EdoActual.radio;
                            ar = new Arista();
                            ar.nombre = a.nombre;
                            ar.destino = nod;
                            AristasV.Add(ar);
                            nodosV.Add(nod);
                            contW++;
                            bandV = true;
                            break;
                        }
                    }
                }
                if(contW == w.Length && EdoActual.terminal)
                {
                    VerRes.Visible = true;
                    VerRes.Text = "Aceptada";
                    VerRes.BackColor = Color.Green;
                    wVerificada = true;
                    Simular.Visible = true;
                    Simular.Enabled = true;
                }
                else
                {
                    VerRes.Visible = true;
                    VerRes.Text = "Error";
                    VerRes.BackColor = Color.Red;
                    wVerificada = false;
                    Simular.Visible = false;
                    Simular.Enabled = false;
                }
            }
        }

        private void PictureAutomata_MouseMove(object sender, MouseEventArgs e)
        {
            if (band && e.Button.Equals(MouseButtons.Left))
            {
                SizeBmp(ref w, ref h, automata);
                bmpA = new Bitmap(w, h);
                pictureAutomata.Image = bmpA;
                if (opcion == 1)
                    nodoAux.centro = e.Location;
                else
                {
                    int distx, disty;

                    distx = e.Location.X - p1.X;
                    disty = e.Location.Y - p1.Y;
                    Point p = new Point();
                    foreach (Nodo n in automata)
                    {
                        p.X = n.centro.X + distx;
                        p.Y = n.centro.Y + disty;
                        n.centro = p;
                    }
                    p1 = e.Location;
                }
                pictureAutomata_Paint(this, null);
            }
        }

        private void PictureAutomata_MouseUp(object sender, MouseEventArgs e)
        {
            band = false;
        }

        private void ToolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "mueveNodoAut":
                    opcion = 1;
                    break;

                case "mueveAut":
                    opcion = 2;
                    break;
            }
        }

        private void ToolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "mueveNodo":
                    opcion = 1;
                    break;

                case "mueveArbol":
                    opcion = 2;
                    break;
            }
        }

        private void ZoomMenosAut_Click(object sender, EventArgs e)
        {
            if (contZoomAut > 1)
            {
                contZoomAut--;
                z = 0.9;
                Zoom(automata);
                pictureAutomata_Paint(this, null);
            }
        }

        private void OriginalAut_Click(object sender, EventArgs e)
        {
            obten(automata, respaldoAut);
            contZoom = 10;
            z = 1.0;
            Zoom(arbol);
            pictureArbol_Paint(this, null);
        }

        private void ZoomMasAut_Click(object sender, EventArgs e)
        {
            if (contZoomAut < 19)
            {
                contZoomAut++;
                z = 1.1;
                Zoom(automata);
                pictureAutomata_Paint(this, null);
            }
        }

        private void respalda(Arbol a, List<Point> respaldo)
        {
            foreach(Nodo n in a)
            {
                Point p = new Point(n.centro.X, n.centro.Y);
                respaldo.Add(p);
            }
        }

        private void obten(Arbol a, List<Point> respaldo)
        {
            for (int i = 0; i < a.Count(); i++)
            {
                a[i].centro = respaldo[i];
                a[i].radio = 15;
            }
            font = new Font("Arial", 12, FontStyle.Bold);
            fontpos = new Font("Arial", 10, FontStyle.Bold);
        }

        private void GeneraAutomata()
        {
            int term = 0;
            
            List<List<int>> posTerminales = new List<List<int>>();
            
            List<string> terminales = new List<string>();

            foreach (Nodo n in arbol)
            {
                if (n.name == "#")
                    term = n.PrimeraPos[0];
                if (char.IsLetter(n.name[0]))
                {
                    if (!terminales.Contains(n.name))
                        terminales.Add(n.name);
                }
            }

            Nodo dest = new Nodo();
            char nombre = 'A';
            bool rep = false;
            
            Nodo nodo = new Nodo(nombre.ToString());
            automata.Add(nodo);
            nombre++;
            foreach (int i in arbol.Last().PrimeraPos)
                nodo.conjunto.Add(i);
            if (nodo.conjunto.Contains(term))
                nodo.terminal = true;

            for (int i = 0; i < automata.Count; i++)
            {
                foreach (string s in terminales)
                {
                    rep = false;
                    estado.Clear();
                    foreach (int x in automata[i].conjunto)
                    {
                        PuedeLlegar(x, s);
                    }
                    if (estado.Count > 0)
                    {
                        foreach (Nodo nd in automata)
                        {
                            if (EstadoExistente(estado, nd.conjunto))
                            {
                                rep = true;
                                dest = nd;
                                break;
                            }
                        }
                        if (rep)
                        {
                            Arista a = new Arista();
                            a.destino = dest;
                            a.nombre = s;
                            automata[i].aristas.Add(a);
                        }
                        else
                        {
                            nodo = new Nodo(nombre.ToString());
                            nombre++;
                            foreach (int j in estado)
                                nodo.conjunto.Add(j);
                            if (nodo.conjunto.Contains(term))
                                nodo.terminal = true;
                            automata.Add(nodo);

                            Arista a = new Arista();
                            a.nombre = s;
                            a.destino = nodo;
                            automata[i].aristas.Add(a);
                        }
                    }
                }
            }
        }

        private void PuedeLlegar(int x, string s)
        {
            foreach(Nodo n in arbol)
            {
                if(n.name == s && n.PrimeraPos[0] == x)
                {
                    foreach (int i in n.SiguientePos)
                    {
                        if(!estado.Contains(i))
                            estado.Add(i);
                    }
                    
                }
            }
        }

        public Point BuscaInterseccion(Point po, Point pd, int radio)
        {
            Point p = new Point();
            double m;
            double cordX = 0, cordY = 0;
            double pox, poy, pdx, pdy;

            pox = (double)po.X;
            poy = (double)po.Y;
            pdx = (double)pd.X;
            pdy = (double)pd.Y;

            if ((pdx - pox) != 0)
            {
                m = ((pdy - poy) / (pdx - pox));
                m = (double)Math.Atan(m);
                cordY = (double)Math.Sin(m) * radio;
                cordX = (double)Math.Cos(m) * radio;

                cordY = (double)Math.Round(cordY);
                cordX = (double)Math.Round(cordX);
            }

            if (pox == pdx)
            {
                p.X = (int)(pox + 0);
                if (pdy > poy)
                    p.Y = (int)(poy + radio);
                else
                    p.Y = (int)(poy - radio);
            }

            if (pox < pdx)
            {
                p.X = (int)(pox + cordX);
                p.Y = (int)(poy + cordY);
            }

            if (po.X > pd.X)
            {
                p.X = (int)(pox - cordX);
                p.Y = (int)(poy - cordY);
            }

            return p;
        }

        private bool EstadoExistente(List<int> A, List<int> B)
        {
            bool r = true;

            if (A.Count() == B.Count())
            {
                for (int i = 0; i < A.Count(); i++)
                {
                    if (A[i] != B[i])
                        return false;
                }
            }
            else
                return false;

            return r;
        }
    }
}
