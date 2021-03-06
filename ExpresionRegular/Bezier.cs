﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpresionRegular
{
    class Bezier
    {
        private Point p1, p2, p3, p4;
        private int numPtos;
        private Point[] arrptos;
        private Pen pn;
        AdjustableArrowCap arrow;
        bool ida, abajo;
        string nom;
        int curva = 15;

        /// <summary>
        /// Constructor del SpLine que recibe los puntos iniciales y finales del mismo
        /// </summary>
        /// <param name="pt1">Punto inicial del SpLine</param>
        /// <param name="pt2">Punto final del SpLine</param>
        public Bezier(Point pt1, Point pt2, Graphics g, Pen p, bool bandDireccion, string nombreArista, bool ab, bool dibuja)
        {
            abajo = ab;
            arrow = new AdjustableArrowCap(5, 5);
            ida = bandDireccion;
            nom = nombreArista;
            pn = new Pen(new SolidBrush(p.Color), p.Width);
            p1 = new Point(pt1.X, pt1.Y);
            p4 = new Point(pt2.X, pt2.Y);
            p2 = new Point();
            p3 = new Point();
            
            numPtos = 35;
            arrptos = new Point[numPtos];
            for (int i = 0; i < numPtos; i++)
                arrptos[i] = new Point();
            Crea_Puntos();
            if(dibuja)
                PintaCurva(g);
        }
        /// <summary>
        /// Crea los puntos de control en los que se basara para crear el SpLine, dandoles 
        /// una distancia apropiada para formar bien la curva
        /// </summary>
        public void Crea_Puntos()
        {
            double distancia, grados;
            float x1 = p1.X, y1 = p1.Y, x2, y2, x3, y3, x4 = p4.X, y4 = p4.Y;
            Point paux1 = new Point();
            Point paux2 = new Point();
            Point paux3 = new Point();
            Point paux4 = new Point();

            grados = Math.Atan2((p4.Y - p1.Y), p4.X - (p1.X + .0001));
            grados += Math.PI / 2;
            distancia = Math.Sqrt(Math.Pow(((p4.X - p1.X) / 5), 2) + Math.Pow(((p4.Y - p1.Y) / 5), 2));
            //Punto 2
            p2.X = p1.X + ((p4.X - p1.X) / 3);
            if(!abajo)
                p2.Y = p1.Y + ((p4.Y - p1.Y) / 3) - curva;
            else
                p2.Y = p1.Y + ((p4.Y - p1.Y) / 3) + curva;

            x2 = (float)(p2.X - (distancia * Math.Cos(grados)));
            y2 = (float)(p2.Y - (distancia * Math.Sin(grados)));
            //Punto 3
            p3.X = p4.X - ((p4.X - p1.X) / 3);
            if(!abajo)
                p3.Y = p4.Y - ((p4.Y - p1.Y) / 3) - curva;
            else
                p3.Y = p4.Y - ((p4.Y - p1.Y) / 3) + curva;

            x3 = (float)(p3.X - (distancia * Math.Cos(grados)));
            y3 = (float)(p3.Y - (distancia * Math.Sin(grados)));

            paux2.X = (int)x2;
            paux2.Y = (int)y2;
            paux3.X = (int)x3;
            paux3.Y = (int)y3;
            //Aqui se podria calcular de nuevo paux1 y paux4 para ponerlos afuera de un nodo
            paux1.X = (int)x1;
            paux1.Y = (int)y1;
            paux4.X = (int)x4;
            paux4.Y = (int)y4;
            calcPuntos(paux1, paux2, paux3, paux4, numPtos);
        }
        /// <summary>
        /// Calcula los puntos de control según los puntos inicial y final del SpLine
        /// </summary>
        /// <param name="pt0">Punto inicial del SpLine</param>
        /// <param name="pt1">Punto 2 de contrl del SpLine</param>
        /// <param name="pt2">Punto 3 de contrl del SpLine</param>
        /// <param name="pt3">Punto final del SpLine</param>
        /// <param name="nptos">Numero total de puntos que forman el SpLine</param>
        private void calcPuntos(Point pt0, Point pt1, Point pt2, Point pt3, int nptos)
        {
            double dt;

            dt = 1.0 / (nptos - 1);
            for (int i = 0; i < nptos; i++)
                arrptos[i] = PointCubicBzier(pt0, pt1, pt2, pt3, i * dt);
        }
        private Point PointCubicBzier(Point pt0, Point pt1, Point pt2, Point pt3, double t)
        {
            double ax, bx, cx;
            double ay, by, cy;
            double tsquared, tcubed, xr, yr;
            Point result;

            cx = 3.0 * (pt1.X - pt0.X);
            bx = 3.0 * (pt2.X - pt1.X) - cx;
            ax = pt3.X - pt0.X - cx - bx;
            cy = 3.0 * (pt1.Y - pt0.Y);
            by = 3.0 * (pt2.Y - pt1.Y) - cy;
            ay = pt3.Y - pt0.Y - cy - by;

            tsquared = t * t;
            tcubed = tsquared * t;
            xr = (ax * tcubed) + (bx * tsquared) + (cx * t) + pt0.X;
            yr = (ay * tcubed) + (by * tsquared) + (cy * t) + pt0.Y;
            result = new Point((int)Math.Round(xr), (int)Math.Round(yr));

            return result;
        }
        /// <summary>
        /// Pinta el SpLine
        /// </summary>
        /// <param name="grp">Parametro tipo Grahics utilizado para pintar las lineas</param>
        public void PintaCurva(Graphics grp)
        {
            float x, y, x2, y2;

            for (int i = 0; i < arrptos.Length - 1; i++)
            {
                if (i == arrptos.Length - 2 && ida)
                    pn.CustomEndCap = arrow;
                else
                {
                    if (!ida && i == 0)
                        pn.CustomStartCap = arrow;
                }
                if (!ida && i == 1)
                    pn = new Pen(pn.Color, pn.Width);
                if(i == arrptos.Length / 2)
                    grp.DrawString(nom, new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.Blue), arrptos[i].X, arrptos[i].Y - 15);
                
                x = (float)arrptos[i].X;
                y = (float)arrptos[i].Y;
                x2 = (float)arrptos[i + 1].X;
                y2 = (float)arrptos[i + 1].Y;
                grp.DrawLine(pn, x, y, x2, y2);
            }
        }
        /// <summary>
        /// Asigna un nuevo valor al punto final del SpLine (p4)
        /// </summary>
        /// <param name="pf">Punto nuevo al que se asignara p4</param>
        public void SetPtFinal(Point pf)
        {
            p4.X = pf.X;
            p4.Y = pf.Y;
        }
    }
}
