using System;
using System.Collections.Generic;
using System.Drawing;
using ZedGraph;

namespace Monte_Carlo
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private double nVar = 14.0;
        double R = 33;
        private List<PointPairList> dots = new List<PointPairList>();
        PointPairList ppdIn = new PointPairList();
        PointPairList ppdOut = new PointPairList();

        struct Point
        {
            public double x;
            public double y;

            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }

        double f1(double x)
        {
            if(checkBox1.Checked == true)
                return 4 * x;
            else
                return 10.0 * x / nVar;
        }

        double f2(double x)
        {
            if (checkBox1.Checked == true)
                return 10.0 - x;
            else
                return 10.0 * (x - 20.0) / (nVar - 20.0) + 20.0;
        }

        double f3(double x)
        {
            if (checkBox1.Checked == true) {
                return 0;
            }
            else
            {
                return 0;
            }
        }

        double fSin(double x)
        {
            if (checkBox1.Checked == true)
                return Math.Sqrt(7 - 3 * Math.Pow(Math.Sin(x), 2));
            else
                return Math.Sqrt(29 - 14 * Math.Pow(Math.Cos(x), 2));
        }

        void setR()
        {
            R = 14;
        }

        double fPolar(double phi)
        {
            if (checkBox1.Checked == true)
                return Math.Sqrt(3 * Math.Pow(Math.Cos(phi), 2) + 7 * Math.Pow(Math.Sin(phi), 2));
            else
                return Math.Sqrt(24 * Math.Pow(Math.Cos(phi), 2) + 4 * Math.Pow(Math.Sin(phi), 2));
        }
        
        Point Intersection(Func<double, double> f1, Func<double, double> f2)
        {
            double x = -0.01;
            bool found = false;
            while (!found)
            {
                x += 0.01;
                if (Math.Abs(f1(x) - f2(x)) < 0.001)
                {
                    found = true;
                }
            }
            return new Point(x, f1(x));
        }

        Point IntersectionOY(Func<double, double> f1)
        {
            return new Point(0, f1(0));
        }

        Point IntersectionOX(Func<double, double> f1)
        {
            return Intersection(f1, f3);
        }

        PointPairList drawFunc(Func<double, double> f1, double startX, double endX)
        {
            PointPairList ppl1 = new PointPairList();
            if(startX > endX)
            {
                double tmp=startX;
                startX = endX;
                endX = tmp;
            }
            double step = (endX - startX) / 1000.0;
            while(startX <= endX)
            {
                 ppl1.Add(startX, f1(startX));
                 startX += step;
                
            }
            return ppl1;
        }

        PointPairList drawFuncOY(Func<double, double> f1, double startY, double endY, double x)
        {
            PointPairList ppl1 = new PointPairList();
            double step = (endY - startY) / 1000.0;
            while (startY <= endY)
            {
                ppl1.Add(x, startY);
                startY += step;

            }
            return ppl1;
        }

    PointPairList drawParam(double R)
        {
            PointPairList ppl1 = new PointPairList();
            double teta = 0;
            double step = (2.0*Math.PI) / 1000.0;
            do
            {
                ppl1.Add(R+R * Math.Cos(teta),R+ R * Math.Sin(teta));
                teta += step;
            } while (teta< 2.0 * Math.PI);
                return ppl1;
        }

        PointPairList drawPolar(Func<double, double> f1)
        {
            PointPairList ppl1 = new PointPairList();
            double teta = 0;
            double step = (2.0 * Math.PI) / 1000.0;
            do
            {
                ppl1.Add(f1(teta)*Math.Cos(teta), f1(teta) * Math.Sin(teta));
                teta += step;
            } while (teta < 2.0 * Math.PI);
            return ppl1;
        }

        double distance(Point p1, Point p2)
        {
            double distance = 0;
            double dx = Math.Pow(p1.x - p2.x,2);
            double dy = Math.Pow(p1.y - p2.y,2);

            distance = Math.Sqrt(dx + dy);

            return distance;
        }

        double Geron(Point p12, Point p23, Point p13)
        {
            double S = 0.0;
            double a = distance(p12, p23);
            double b = distance(p12, p13);
            double c = distance(p23, p13);
            double p = (a+b+c)/2.0;

            S=Math.Sqrt(p*(p-a)*(p-b)*(p-c));

            return S;
        }

        void InsideTriangle(Point p12, Point p23, Point p13)
        {

            int numP = int.Parse(textBox5.Text);

            ppdIn.Clear();
            ppdOut.Clear();

            Random random = new Random();

            double minX = Math.Min(p12.x, Math.Min(p13.x, p23.x));
            double maxX = Math.Max(p12.x, Math.Max(p13.x, p23.x));

            double minY = Math.Min(p12.y, Math.Min(p13.y, p23.y));
            double maxY = Math.Max(p12.y, Math.Max(p13.y, p23.y));

            for (int i = 0; i < numP; i++)
            {
                double rx = random.NextDouble() * (maxX - minX) + minX;
                double ry = random.NextDouble() * (maxY - minY) + minY;
                Point p = new Point(rx, ry);

                
                if (Math.Abs(Geron(p12,p23,p)+ Geron(p12, p13, p)+ Geron(p13, p23, p)-Geron(p12,p13,p23))<0.01)
                {
                    ppdIn.Add(new PointPair(rx, ry));
                }
                else ppdOut.Add(new PointPair(rx, ry));
            }
        }

        void insideSinCos(Func<double, double> f1, double minX, double maxX, double minY, double maxY)
        {
            int numP = int.Parse(textBox5.Text);

            ppdIn.Clear();
            ppdOut.Clear();

            Random random = new Random();

            for (int i = 0; i < numP; i++)
            {
                double rx = random.NextDouble() * (maxX - minX) + minX;
                double ry = random.NextDouble() * (maxY - minY) + minY;

                if (ry < f1(rx))
                {
                    ppdIn.Add(new PointPair(rx, ry));
                }
                else ppdOut.Add(new PointPair(rx, ry));
            }
        }

        void insideCircle(double R)
        {
            int numP = int.Parse(textBox5.Text);

            ppdIn.Clear();
            ppdOut.Clear();

            Random random = new Random();

            double minX = -R;
            double maxX = R;

            double minY = -R;
            double maxY = R;


            for(int i=0; i<numP; i++)
            {
                double rx = random.NextDouble() * (maxX - minX) + minX+R;
                double ry = random.NextDouble() * (maxY - minY) + minY+R;

                if (Math.Pow((rx-R),2) + Math.Pow((ry-R),2) < Math.Pow(R, 2))
                {
                    ppdIn.Add(new PointPair(rx, ry));
                }
                else ppdOut.Add(new PointPair(rx, ry));
            }
        }

        double MinY(PointPairList ppl)
        {
            double miny = ppl[0].Y;
            for (int i = 1; i < ppl.Count; i++)
                if (ppl[i].Y < miny)
                    miny = ppl[i].Y;
            return miny;
        }

        double MaxY(PointPairList ppl)
        {
            double maxy = ppl[0].Y;
            for (int i = 1; i < ppl.Count; i++)
                if (ppl[i].Y > maxy)
                    maxy = ppl[i].Y;
            return maxy;
        }

        double MinX(PointPairList ppl)
        {
            double minx = ppl[0].X;
            for (int i = 1; i < ppl.Count; i++)
                if (ppl[i].X < minx)
                    minx = ppl[i].X;
            return minx;
        }

        double MaxX(PointPairList ppl)
        {
            double maxx = ppl[0].X;
            for (int i = 1; i < ppl.Count; i++)
                if (ppl[i].X > maxx)
                    maxx = ppl[i].X;
            return maxx;
        }

        void insidePolar(Func<double, double> f1, PointPairList ppl1)
        {
            int numP = int.Parse(textBox5.Text);

            ppdIn.Clear();
            ppdOut.Clear();

            Random random = new Random();

            double minX = MinX(ppl1);
            double maxX = MaxX(ppl1);

            double minY = MinY(ppl1);
            double maxY = MaxY(ppl1);

            for (int i = 0; i < numP; i++)
            {
                double rx = random.NextDouble() * (maxX - minX) + minX;
                double ry = random.NextDouble() * (maxY - minY) + minY;

                double r = Math.Sqrt(Math.Pow(rx, 2) + Math.Pow(ry, 2));

                double phi=0.0;

                if (rx > 0) phi = Math.Atan(ry / rx);
                else if (rx < 0) phi = Math.PI + Math.Atan(ry / rx);
                else if (ry > 0) phi = Math.PI / 2.0;
                else if (ry < 0) phi = -Math.PI / 2.0;
                else phi = 0;

                if (r<f1(phi))
                {
                    ppdIn.Add(new PointPair(rx, ry));
                }
                else ppdOut.Add(new PointPair(rx, ry));
            }
        }

        //public delegate TResult Func2<in T, in T1, in T2, out TResult>(T arg, T1 arg1, T2 arg2);

        //bool condCirle(double R, double rx, double ry)
        //{
        //    return Math.Pow((rx - R), 2) + Math.Pow((ry - R), 2) < Math.Pow(R, 2);
        //}

        //bool condPolar(Func<double, double> f1, double rx, double ry)
        //{
        //    double r = Math.Sqrt(Math.Pow(rx, 2) + Math.Pow(ry, 2));

        //    double phi = 0.0;

        //    if (rx > 0) phi = Math.Atan(ry / rx);
        //    else if (rx < 0) phi = Math.PI + Math.Atan(ry / rx);
        //    else if (ry > 0) phi = Math.PI / 2.0;
        //    else if (ry < 0) phi = -Math.PI / 2.0;
        //    else phi = 0;
        //    if (r < f1(phi))
        //        return true;
        //    else return false;
        //}

        //bool condTriangle(double rx, double ry, Point p12, Point p13, Point p23)
        //{
        //    Point p = new Point(rx, ry);

        //    if (Math.Abs(Geron(p12, p23, p) + Geron(p12, p13, p) + Geron(p13, p23, p) - Geron(p12, p13, p23)) < 0.01)
        //    {
        //        return true;
        //    }
        //    else return false;
        //}

        //bool condSinCos(Func<double, double> f1, double rx, double ry)
        //{
        //    if (ry < f1(rx))
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //void insideFigure(Func<double, double> f1, double minX, double maxX, double minY, double maxY)
        //{
        //    int numP = int.Parse(textBox5.Text);

        //    Random random = new Random();

        //    for (int i = 0; i < numP; i++)
        //    {
        //        double rx = random.NextDouble() * (maxX - minX) + minX;
        //        double ry = random.NextDouble() * (maxY - minY) + minY;

        //        if (ry < f1(rx))
        //        {
        //            ppdIn.Add(new PointPair(rx, ry));
        //        }
        //        else ppdOut.Add(new PointPair(rx, ry));
        //    }
        //}

        double calcEPS(int numP)
        {
            return 1.0 / Math.Sqrt(numP);
        }


        public void Draw()
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            PointPairList ppl1 = new PointPairList();
            PointPairList ppl2 = new PointPairList();
            PointPairList ppl3 = new PointPairList();
            Point p12 = Intersection(f1, f2);
            Point p23 = new Point();
            Point p13 = new Point();
            f3(0);
            if (checkBox1.Checked)
            {
                p23 = Intersection(f2, f3);
                p13 = Intersection(f1, f3);
            }
            else
            {
                p23 = IntersectionOY(f2);
                p13 = IntersectionOY(f1);
            }

            ppl1 = drawFunc(f1, p13.x, p12.x);
            ppl2 = drawFunc(f2, p12.x, p23.x);
            if (checkBox1.Checked)
            {
                ppl3 = drawFunc(f3, p13.x, p23.x);
            }
            else
            {
                ppl3 = drawFuncOY(f3, p13.y, p23.y, p13.x);
            }

            LineItem curve1 = pane.AddCurve("Curve1", ppl1, Color.BlueViolet, SymbolType.None);
            LineItem curve2 = pane.AddCurve("Curve2", ppl2, Color.Green, SymbolType.None);
            LineItem curve3 = pane.AddCurve("Curve3", ppl3, Color.Goldenrod, SymbolType.None);

            InsideTriangle(p12,p23,p13);

            LineItem curve4 = pane.AddCurve("Curve4", ppdIn, Color.Red, SymbolType.Circle);
            LineItem curve5 = pane.AddCurve("Curve5", ppdOut, Color.Gray, SymbolType.Circle);
            curve4.Line.IsVisible = false;
            curve5.Line.IsVisible = false;

            double minX = Math.Min(p12.x, Math.Min(p13.x, p23.x));
            double maxX = Math.Max(p12.x, Math.Max(p13.x, p23.x));

            double minY = Math.Min(p12.y, Math.Min(p13.y, p23.y));
            double maxY = Math.Max(p12.y, Math.Max(p13.y, p23.y));

            double a = (maxX - minX);
            double b = (maxY - minY);

            label1.Text = (((double)ppdIn.Count / ((double)ppdIn.Count + (double)ppdOut.Count)) * (a) * (b)).ToString();
            textBox1.Text = calcEPS(int.Parse(textBox5.Text)).ToString();
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

        }

        public void Draw2()
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            PointPairList ppl1 = new PointPairList();
            PointPairList ppl2 = new PointPairList();
            PointPairList ppl3 = new PointPairList();

            double leX;
            double riX;
            if(checkBox1.Checked == true)
            {
                leX = 0.0;
                riX = 8.0;
            }
            else
            {
                leX = 0.0;
                riX = 7.0;
            }

            Point p1 = new Point(leX, fSin(leX));
            Point p2 = new Point(riX, fSin(riX));
            Point p3 = new Point(0, 0);

            ppl1 = drawFunc(fSin, p1.x, p2.x);
            ppl2 = drawFuncOY(fSin, p3.y, p1.y, p1.x);
            ppl3 = drawFuncOY(fSin, p3.y, p2.y, p2.x);

            LineItem curve1 = pane.AddCurve("Curve1", ppl1, Color.BlueViolet, SymbolType.None);
            LineItem curve2 = pane.AddCurve("Curve2", ppl2, Color.Green, SymbolType.None);
            LineItem curve3 = pane.AddCurve("Curve3", ppl3, Color.Goldenrod, SymbolType.None);

            double minX = Math.Min(MinX(ppl1), Math.Min(MinX(ppl2), MinX(ppl3)));
            double maxX = Math.Max(MaxX(ppl1), Math.Max(MaxX(ppl2), MaxX(ppl3)));

            double minY = Math.Min(MinY(ppl1), Math.Min(MinY(ppl2), MinY(ppl3)));
            double maxY = Math.Max(MaxY(ppl1), Math.Max(MaxY(ppl2), MaxY(ppl3)));

            insideSinCos(fSin, minX, maxX, minY, maxY);

            LineItem curve4 = pane.AddCurve("Curve4", ppdIn, Color.Red, SymbolType.Circle);
            LineItem curve5 = pane.AddCurve("Curve5", ppdOut, Color.Gray, SymbolType.Circle);
            curve4.Line.IsVisible = false;
            curve5.Line.IsVisible = false;

            double a = (maxX - minX);
            double b = (maxY - minY);

            label2.Text = (((double)ppdIn.Count / ((double)ppdIn.Count + (double)ppdOut.Count)) * (a) * (b)).ToString();
            textBox2.Text = calcEPS(int.Parse(textBox5.Text)).ToString();
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

        }

        public void Draw3()
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            PointPairList ppl1 = new PointPairList();
            if (checkBox1.Checked)
                R = 33;
            else R = 14;
            ppl1 = drawParam(R);

            LineItem curve1 = pane.AddCurve("Curve1", ppl1, Color.BlueViolet, SymbolType.None);

            insideCircle(R);

            LineItem curve4 = pane.AddCurve("Curve4", ppdIn, Color.Red, SymbolType.Circle);
            LineItem curve5 = pane.AddCurve("Curve5", ppdOut, Color.Gray, SymbolType.Circle);
            curve4.Line.IsVisible = false;
            curve5.Line.IsVisible = false;

            double minX = -R;
            double maxX = R;

            double minY = -R;
            double maxY = R;

            label3.Text = (4.0*(double)ppdIn.Count/((double)ppdOut.Count+ (double)ppdIn.Count)).ToString();
            textBox3.Text = calcEPS(int.Parse(textBox5.Text)).ToString();
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

        }

        public void Draw4()
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            PointPairList ppl1 = new PointPairList();

            ppl1 = drawPolar(fPolar);

            LineItem curve1 = pane.AddCurve("Curve1", ppl1, Color.BlueViolet, SymbolType.None);

            insidePolar(fPolar, ppl1);

            LineItem curve4 = pane.AddCurve("Curve4", ppdIn, Color.Red, SymbolType.Circle);
            LineItem curve5 = pane.AddCurve("Curve5", ppdOut, Color.Gray, SymbolType.Circle);
            curve4.Line.IsVisible = false;
            curve5.Line.IsVisible = false;

            double minX = MinX(ppl1);
            double maxX = MaxX(ppl1);

            double minY = MinY(ppl1);
            double maxY = MaxY(ppl1);

            double a = (maxX- minX)/2.0;
            double b = (maxY- minY)/2.0;

            label4.Text = ((double)ppdIn.Count / ((double)ppdOut.Count + (double)ppdIn.Count) * a * b * 4.0).ToString();
            textBox4.Text = calcEPS(int.Parse(textBox5.Text)).ToString();
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

        }


        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

