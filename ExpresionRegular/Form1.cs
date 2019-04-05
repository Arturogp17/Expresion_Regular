
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpresionRegular
{
    public partial class Form1 : Form
    {
        Arbol arbol = new Arbol();
        bool Regular = true;
        List<string> res = new List<string>();

        public Form1()
        {
            InitializeComponent();
            Generar_Posfija.Enabled = false;
            Generar_Arbol.Enabled = false;
        }

        private void gramatica_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                VerificaRegular();
            }
        }

        private void VerificaRegular()
        {
            Regular = true;
            List<string> T = new List<string>();
            List<string> NT = new List<string>();
            string[] aux = new string[2];

            foreach (string s in gramatica.Lines)
            {
                if (s != "")
                {
                    aux = s.Split('-');
                    aux[1] = aux[1].Substring(1);
                    T.Add(aux[0]);
                    NT.Add(aux[1]);
                }
            }

            for (int i = 0; i < T.Count(); i++)
            {
                if (T[i].Length == 1 && char.IsUpper(T[i][0]) && ((NT[i].Length == 2 && char.IsLower(NT[i][0]) && char.IsUpper(NT[i][1])) | (NT[i].Length == 1 && char.IsLower(NT[i][0])))) { }
                else
                {
                    Regular = false;
                    break;
                }
            }

            if (Regular)
            {
                reg.Text = "OK";
                reg.BackColor = Color.Green;
            }
            else
            {
                reg.Text = "Error";
                reg.BackColor = Color.Red;
            }
        }

        private void Generar_Click(object sender, EventArgs e)
        {
            paso1.Clear();
            paso2.Clear();
            paso3.Clear();
            paso4.Clear();
            ER_Postfija.Text = "";

            VerificaRegular();

            if (Regular && gramatica.Lines.Count() > 0)
            {
                Ordenar();
                paso1.Lines = Paso1().ToArray();
                Paso2();
                Paso3();
                Paso4();
                Regular = false;
            }
            else
            {
                if(gramatica.Lines.Count() != 0)
                {
                    SLR0 slr = new SLR0(gramatica.Lines.ToList());
                    slr.ShowDialog();
                }
            }
            Generar_Posfija.Enabled = true;
        }

        private void Ordenar()
        {
            List<string> g = new List<string>();
            List<string> r = new List<string>();
            List<int> index = new List<int>();

            g = gramatica.Lines.ToList();
            for (int i = 0; i < g.Count() && g[i] != ""; i++)
            {
                if (g[i][0] == 'S')
                {
                    r.Add(g[i]);
                    index.Add(i);
                }
            }

            for (int i = index.Count() - 1; i >= 0; i--)
            {
                g.RemoveAt(index[i]);
            }
            g.Sort();
            r.AddRange(g);
            gramatica.Lines = r.ToArray();
        }

        private List<string> Paso1()
        {
            res.Clear();
            List<string> T = new List<string>();
            List<string> NT = new List<string>();
            string[] aux = new string[2];

            foreach (string s in gramatica.Lines)
            {
                if (s != "")
                {
                    aux = s.Split('-');
                    aux[1] = aux[1].Substring(1);
                    T.Add(aux[0]);
                    NT.Add(aux[1]);
                }
            }

            int j;
            string usados = "";
            string p1 = "";
            for (int i = 0; i < T.Count(); i++)
            {
                for (j = i; j < T.Count() && T[j] == T[i] && !usados.Contains(T[i]); ++j) ;
                p1 = T[i] + "->";
                for (int k = i; k < j && !usados.Contains(T[i]); k++)
                {
                    p1 += NT[k] + "|";
                }
                p1 = p1.Remove(p1.Length - 1);
                if (!usados.Contains(T[i]))
                    res.Add(p1);
                usados += T[i];
            }
            return res;
        }

        private void Paso2()
        {
            string line = "";
            string xi = "", alfa = "{", psi = "";
            List<string> lines = new List<string>();
            string[] spl = new string[2];
            List<string> aux = new List<string>();
            string expresion = "";

            if (res.Count() == 1)
            {
                expresion = "";
                xi = ""; alfa = "{"; psi = "";
                spl = res[0].Split('-');
                spl[1] = spl[1].Substring(1);
                xi = spl[0];
                if (spl[1].Contains(xi[0]))
                {
                    if (spl[1].Contains('|'))
                    {
                        aux = Separa(spl[1], '|');
                        foreach (string s in aux)
                        {
                            if (s.Contains(xi[0]))
                            {
                                for (int j = 0; j < s.Length; j++)
                                {
                                    if (s[j] != xi[0])
                                    {
                                        alfa += s[j];
                                    }
                                }
                                alfa += "|";
                            }
                            else
                            {
                                psi += s + "|";
                            }
                        }
                        alfa = alfa.Remove(alfa.Length - 1) + "}";
                        if (psi.Length > 0)
                        {
                            psi = psi.Remove(psi.Length - 1);
                            line = "ɩ = " + (1).ToString() + "\tReduce" + "\t\t" + res[0] + "\n\tXi = " + xi + "\t αi = " + alfa + "\t Ψi = (" + psi + ")";
                            expresion = Multiplica(alfa, psi);
                        }
                    }
                    else
                    {
                        alfa = "{" + spl[1][0].ToString() + "}";
                        psi = "";
                        line = "ɩ = " + (1).ToString() + "\tReduce" + "\t\t" + res[0] + "\n\tXi = " + xi + "\t αi = " + alfa + "\t Ψi = " + psi;
                        expresion = alfa;
                    }
                    lines.Add(line);
                    res[0] = xi + "->" + expresion;
                    lines.Add(res[0]);
                    AgregaGramaticaActual(lines);
                }
                else
                {
                    spl = res[0].Split('-');
                    expresion = spl[1].Substring(1);
                    line = "ɩ = " + (1).ToString() + "\tNo reduce" + "\t" + res[0];
                    lines.Add(line);
                }
            }
            else
            {
                for (int i = 0; i < res.Count() - 1; i++)
                {
                    expresion = "";
                    xi = ""; alfa = "{"; psi = "";
                    spl = res[i].Split('-');
                    spl[1] = spl[1].Substring(1);
                    xi = spl[0];
                    if (spl[1].Contains(xi[0]))
                    {
                        if (spl[1].Contains('|'))
                        {
                            aux = Separa(spl[1], '|');
                            foreach (string s in aux)
                            {
                                if (s.Contains(xi[0]))
                                {
                                    for (int j = 0; j < s.Length; j++)
                                    {
                                        if (s[j] != xi[0])
                                        {
                                            alfa += s[j];
                                        }
                                    }
                                    alfa += "|";
                                }
                                else
                                {
                                    psi += s + "|";
                                }
                            }
                        }
                        alfa = alfa.Remove(alfa.Length - 1) + "}";
                        if (psi.Length > 0)
                            psi = psi.Remove(psi.Length - 1);
                        line = "ɩ = " + (i + 1).ToString() + "\tReduce" + "\t\t" + res[i] + "\n\tXi = " + xi + "\t αi = " + alfa + "\t Ψi = (" + psi + ")";
                        lines.Add(line);
                        expresion = alfa + "(" + psi + ")"; ;
                        res[i] = xi + "->" + expresion;
                        lines.Add("\t" + res[i]);
                        expresion = Multiplica(alfa, psi);
                        res[i] = xi + "->" + expresion;
                        lines.Add("\t" + res[i] + "\n");
                        AgregaGramaticaActual(lines);
                    }
                    else
                    {
                        spl = res[i].Split('-');
                        expresion = spl[1].Substring(1);
                        line = "ɩ = " + (i + 1).ToString() + "\tNo reduce" + "\t" + res[i];
                        lines.Add(line);
                    }

                    string r = "";

                    for (int j = i + 1; j < res.Count(); j++)
                    {
                        line = "      j" + (j + 1).ToString() + " =\t" + res[j];
                        if (res[j].Contains(xi[0]))
                        {
                            line += "\t\tSustituye ";
                            lines.Add(line);
                            spl = res[j].Split('-');
                            spl[1] = spl[1].Substring(1);
                            line = "\t" + res[j];
                            lines.Add(line);
                            r = Sustituye(expresion, xi[0], spl[1]);
                            line = "\t" + spl[0] + "->" + r;
                            res[j] = spl[0] + "->" + r;
                            lines.Add(line + "\n");
                            AgregaGramaticaActual(lines);
                        }
                        else
                        {
                            line += "\t\tNo sustituye ";
                            lines.Add(line);
                        }
                    }
                }
            }

            paso2.Lines = lines.ToArray();
        }

        private void Paso3()
        {
            string line = "";
            string xi = "", alfa = "{", psi = "";
            List<string> lines = new List<string>();
            string[] spl = new string[2];
            List<string> aux = new List<string>();
            string expresion = "";

            for (int i = res.Count() - 1; i > 0; i--)
            {
                expresion = "";
                xi = ""; alfa = "{"; psi = "";
                spl = res[i].Split('-');
                spl[1] = spl[1].Substring(1);
                xi = spl[0];
                if (spl[1].Contains(xi[0]))
                {
                    if (spl[1].Contains('|'))
                    {
                        aux = Separa(spl[1], '|');
                        foreach (string s in aux)
                        {
                            if (s.Contains(xi[0]))
                            {
                                for (int j = 0; j < s.Length; j++)
                                {
                                    if (s[j] != xi[0])
                                    {
                                        alfa += s[j];
                                    }
                                }
                                alfa += "|";
                            }
                            else
                            {
                                psi += s + "|";
                            }
                        }
                    }
                    alfa = alfa.Remove(alfa.Length - 1) + "}";
                    if (psi.Length > 0)
                        psi = psi.Remove(psi.Length - 1);
                    line = "ɩ = " + (i + 1).ToString() + "\tReduce" + "\t\t" + res[i] + "\n\tXi = " + xi + "\t αi = " + alfa + "\t Ψi = " + psi;
                    lines.Add(line);
                    expresion = alfa + "(" + psi + ")"; ;
                    res[i] = xi + "->" + expresion;
                    lines.Add("\t" + res[i]);
                    expresion = Multiplica(alfa, psi);
                    res[i] = xi + "->" + expresion;
                    lines.Add("\t" + res[i] + "\n");
                    AgregaGramaticaActual(lines);
                }
                else
                {
                    spl = res[i].Split('-');
                    expresion = spl[1].Substring(1);
                    line = "ɩ = " + (i + 1).ToString() + "\tNo reduce" + "\t" + res[i];
                    lines.Add(line);
                }

                string r = "";

                for (int j = i - 1; j >= 0; j--)
                {
                    line = "      j" + (j + 1).ToString() + " =\t" + res[j];
                    if (res[j].Contains(xi[0]))
                    {
                        line += "\t\tSustituye ";
                        lines.Add(line);
                        spl = res[j].Split('-');
                        spl[1] = spl[1].Substring(1);
                        line = "\t" + res[j];
                        lines.Add(line);
                        r = Sustituye(expresion, xi[0], spl[1]);
                        line = "\t" + spl[0] + "->" + r;
                        res[j] = spl[0] + "->" + r;
                        lines.Add(line + "\n");
                        AgregaGramaticaActual(lines);
                    }
                    else
                    {
                        line += "\t\tNo sustituye ";
                        lines.Add(line);
                    }
                }
            }
            paso3.Lines = lines.ToArray();
        }

        private void Paso4()
        {
            List<string> lines = new List<string>();
            List<string> er = new List<string>();
            string line = "";

            string r = res[0].Substring(3);
            line = "ER = " + r + "\n";
            lines.Add(line);
            line = "";

            foreach (char c in r)
            {
                if (c == '{')
                {
                    line += "(";
                }
                else
                {
                    if (c == '}')
                    {
                        line += ")*";
                    }
                    else
                        line += c;
                }
            }
            lines.Add("ER = " + line + "\n");

            r = line;

            line = "";
            for (int i = r.Length - 1; i >= 0; i--)
            {
                if (i - 2 >= 0 && r[i] == ')' && r[i - 2] == '(')
                {
                    line = r[i - 1] + line;
                    i -= 2;
                }
                else
                {
                    line = r[i] + line;
                }
            }

            lines.Add("ER= " + line + "\n");
            er = Separa(line, '|');
            for (int i = 0; i < er.Count(); i++)
            {
                er[i] = Simplifica(er[i]);
            }

            line = "";
            foreach (string s in er)
            {
                line += s + "|";
            }
            line = line.Remove(line.Length - 1);
            lines.Add("ER = " + line + "\n");

            line = Puntos(line);
            lines.Add("ER = " + line + "\n");
            paso4.Lines = lines.ToArray();
            ExpresionR.Text = line;
        }

        private string Sustituye(string ex, char xi, string gr)
        {
            string cad = "";
            string result = "";
            List<string> lgr = new List<string>();
            lgr = Separa(gr, '|');

            for (int i = 0; i < lgr.Count(); i++)
            {
                for (int j = 0; j < lgr[i].Length; j++)
                {
                    if (lgr[i][j] != xi)
                        cad += lgr[i][j];
                    else
                        cad = Multiplica(cad, ex);
                }
                result += cad + "|";
                cad = "";
            }
            return result.Remove(result.Length - 1);
        }

        private List<string> Separa(string ex, char separador)
        {
            string cad = "";
            List<string> ls = new List<string>();
            int bLlave = 0;

            foreach (char c in ex)
            {
                if (c == '{' || c == '(')
                    bLlave++;

                if (bLlave == 0)
                {
                    if (c == separador)
                    {
                        ls.Add(cad);
                        cad = "";
                    }
                    else
                        cad += c;
                }
                else
                {
                    cad += c;
                }
                if (c == '}' || c == ')')
                    bLlave--;
            }
            if (cad.Length > 0)
                ls.Add(cad);
            return ls;
        }

        private string QuitaParentesis(string cad)
        {
            string aux = "";
            for (int i = cad.Length - 1; i >= 0; i--)
            {
                if (cad[i] == ')' && cad[i - 2] == '(')
                {
                    aux = cad[i - 1] + aux;
                    i -= 2;
                }
                else
                {
                    aux = cad[i] + aux;
                }
            }
            return aux;
        }

        private string Simplifica(string cad)
        {
            string aux = "";

            for (int i = 0; i < cad.Length; i++)
            {
                if (cad[i] == '*')
                {
                    if (aux.Length - 2 >= 0 && aux.Last() == aux[aux.Length - 2])
                    {
                        aux = aux.Remove(aux.Length - 1);
                        aux += '+';
                    }
                    else
                    {
                        if (i + 1 < cad.Length && aux.Last() == cad[i + 1])
                        {
                            if (i + 2 < cad.Length && cad[i + 2] == '+')
                                i += 2;
                            else
                                i++;
                            aux += '+';
                        }
                        else
                            aux += cad[i];
                    }
                }
                else
                    aux += cad[i];
            }
            return aux;
        }

        private void AgregaGramaticaActual(List<string> lines)
        {
            lines.Add("\tGramatica Actual:");
            foreach (string s in res)
            {
                lines.Add("\t" + s);
            }
            lines.Add("");
        }

        private string Multiplica(string alfa, string psi)
        {
            List<string> aux = new List<string>();
            string result = "";
            aux = Separa(psi, '|');
            foreach (string s in aux)
            {
                result += alfa + s + "|";
            }
            result = result.Remove(result.Length - 1);
            return result;
        }

        private string Puntos(string expresion)
        {
            string resultado = "";
            for (int i = 0; i < expresion.Length && (i + 1) < expresion.Length; i++)
            {
                resultado += expresion[i];
                if (expresion[i + 1] != '|' && expresion[i + 1] != ')' && expresion[i + 1] != '+' && expresion[i + 1] != '*' && expresion[i + 1] != '?' && expresion[i] != '(' && expresion[i] != '|')
                    resultado += '·';
            }
            resultado += expresion.Last();
            return resultado;
        }

        private void Archivo_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            toolStrip1_ItemClicked(sender, e);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string line;
            string directorio = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\Gramaticas"));
            List<string> lineas = new List<string>();
            switch (e.ClickedItem.AccessibleName)
            {
                case "Abrir":
                    openFileDialog1.InitialDirectory = directorio;
                    openFileDialog1.FileName = "";
                    openFileDialog1.Filter = "(*.txt)|*.txt";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        gramatica.Clear();
                        StreamReader sr = new StreamReader(openFileDialog1.FileName);
                        line = sr.ReadLine();
                        while (line != null)
                        {
                            lineas.Add(line);
                            line = sr.ReadLine();
                        }
                        gramatica.Lines = lineas.ToArray();
                    }
                    VerificaRegular();
                    paso1.Clear();
                    paso2.Clear();
                    paso3.Clear();
                    paso4.Clear();
                    ExpresionR.Text = "";
                    ER_Postfija.Text = "";
                    Generar_Arbol.Enabled = false;
                    Generar_Posfija.Enabled = false;
                    break;

                case "Save":
                    saveFileDialog1.InitialDirectory = directorio;
                    saveFileDialog1.FileName = "";
                    saveFileDialog1.Filter = "(*.txt)|*.txt";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                        foreach (string s in gramatica.Lines)
                        {
                            sw.WriteLine(s);
                        }
                        sw.Close();
                    }
                    break;
            }
        }

        private string Postfija(string er)
        {
            List<string> pilaCar = new List<string>();
            List<char> pilaOp = new List<char>();
            string aux = "";
            int topeCar = -1;
            int topeOp = -1;

            for (int i = 0; i < er.Length; i++)
            {
                if (char.IsLetter(er[i]))
                {
                    pilaCar.Add(er[i].ToString());
                    topeCar++;
                }
                else
                {
                    if (er[i] == '*' || er[i] == '+' || er[i] == '?')
                    {
                        aux = pilaCar[topeCar] + er[i];
                        pilaCar.RemoveAt(topeCar);
                        pilaCar.Add(aux);
                    }
                    else
                    {
                        if (er[i] == ')')
                        {
                            while (pilaOp[topeOp] != '(')
                            {
                                aux = pilaCar[topeCar - 1] + pilaCar[topeCar] + pilaOp[topeOp];
                                pilaCar.RemoveAt(topeCar);
                                pilaCar.RemoveAt(topeCar - 1);
                                pilaCar.Add(aux);
                                pilaOp.RemoveAt(topeOp);
                                topeCar--;
                                topeOp--;
                            }
                            pilaOp.RemoveAt(topeOp);
                            topeOp--;
                        }
                        else
                        {
                            if (topeOp > -1 && pilaOp[topeOp] == er[i])
                            {
                                aux = pilaCar[topeCar - 1] + pilaCar[topeCar] + pilaOp[topeOp];
                                pilaCar.RemoveAt(topeCar);
                                pilaCar.RemoveAt(topeCar - 1);
                                pilaCar.Add(aux);
                                topeCar--;
                            }
                            else
                            {
                                if (topeOp > -1 && er[i] == '|' && pilaOp[topeOp] == '·')
                                {
                                    aux = pilaCar[topeCar - 1] + pilaCar[topeCar] + pilaOp[topeOp];
                                    pilaOp.RemoveAt(topeOp);
                                    pilaCar.RemoveAt(topeCar);
                                    pilaCar.RemoveAt(topeCar - 1);
                                    pilaCar.Add(aux);
                                    pilaOp.Add(er[i]);
                                    topeCar--;
                                    while (topeOp - 1 >= 0 && pilaOp[topeOp] == pilaOp[topeOp - 1])
                                    {
                                        aux = pilaCar[topeCar - 1] + pilaCar[topeCar] + pilaOp[topeOp];
                                        pilaOp.RemoveAt(topeOp);
                                        pilaCar.RemoveAt(topeCar);
                                        pilaCar.RemoveAt(topeCar - 1);
                                        pilaCar.Add(aux);
                                        pilaOp.Add(er[i]);
                                        topeCar--;
                                        pilaOp.RemoveAt(topeOp);
                                        topeOp--;
                                    }
                                }
                                else
                                {
                                    pilaOp.Add(er[i]);
                                    topeOp++;
                                }
                            }
                        }
                    }
                }
            }
            while (topeOp > -1)
            {
                aux = pilaCar[topeCar - 1] + pilaCar[topeCar] + pilaOp[topeOp];
                pilaCar.RemoveAt(topeCar);
                pilaCar.RemoveAt(topeCar - 1);
                topeCar--;
                pilaCar.Add(aux);
                pilaOp.RemoveAt(topeOp);
                topeOp--;
            }
            return pilaCar[0];
        }

        private void Generar_Posfija_Click(object sender, EventArgs e)
        {
            string pf = "";

            foreach (char c in ExpresionR.Text)
            {
                if (c == '.')
                    pf += '·';
                else
                    pf += c;
            }
            ExpresionR.Text = pf;
            ER_Postfija.Text = Postfija(ExpresionR.Text);
            Generar_Arbol.Enabled = true;
        }

        private void Generar_Arbol_Click(object sender, EventArgs e)
        {
            arbol.GenerarArbol(ER_Postfija.Text + "#·");
            Arbol_F ArbolFD = new Arbol_F(arbol, ExpresionR.Text, ER_Postfija.Text + "#·");
            ArbolFD.ShowDialog();
            ArbolFD.Dispose();
        }
        
        private void ExpresionR_TextChanged(object sender, EventArgs e)
        {
            if (ExpresionR.Text != "")
                Generar_Posfija.Enabled = true;
        }
    }
}