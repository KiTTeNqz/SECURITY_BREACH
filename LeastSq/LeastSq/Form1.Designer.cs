using System;
using System.Collections.Generic;
using System.Drawing;
using ZedGraph;

namespace LeastSq
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 12);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(776, 426);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;

        double[] xs = new double[] { 1, 2, 3, 4, 5, 6 };
        double[] ys = new double[] { 1.0, 1.5, 3.0, 4.5, 7.0, 8.5 };
        double n = 6;

        List<PointPairList> pointsPairs = new List<PointPairList>();

        private void Linear() {

            double xmin = 0;
            double xmax = 10;

            double xmin_limit = 0;
            double xmax_limit = 10;

            double ymin_limit = 0;
            double ymax_limit = 10;

            GraphPane pane = zedGraphControl1.GraphPane;

            double meanX = 0;
            for (int i=0; i<xs.Length; i++) {
                meanX+=xs[i];
            }

            double meanY = 0;
                for (int i = 0; i < ys.Length; i++) {
                    meanY+=ys[i];
                }

            double meanXSq = 0;
            for (int i = 0; i < xs.Length; i++)
            {
                meanXSq += Math.Pow(xs[i], 2);
            }

            double meanXY = 0;
            for (int i = 0; i < xs.Length; i++)
            {
                meanXY += xs[i] * ys[i];
            }

            // !!!

            pane.XAxis.Scale.Max = xmax_limit;

            // !!!

            pane.YAxis.Scale.Max = ymax_limit;

            double dif = (n * meanXSq - meanX * meanX);
            double a = (n * meanXY - meanX * meanY) / dif;
            double b = meanY / n - (a * meanX) / n;

            double[] drawX = new double[101];
            double[] drawYLinear = new double[101];

            
            double step = 0;
            int j = 0;
            while (step < 10)
            {
                drawX[j] = step;
                drawYLinear[j] = drawX[j]*a+b;
                step += 0.1;
                j += 1;
            }

            PointPairList linearPoints = new PointPairList(drawX, drawYLinear);

            PointPairList listDots = new PointPairList(xs,ys);

            pointsPairs.Add(listDots);
            pointsPairs.Add(linearPoints);

            Math.Log(xmax, Math.E);
            LineItem dots = pane.AddCurve("Cords", listDots, Color.Red, SymbolType.Circle);
            LineItem curveLinear = pane.AddCurve("Linear", linearPoints, Color.Blue, SymbolType.None);
            dots.Line.IsVisible = false;
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Refresh();
            
        }

        private void Step()
        {

            double xmax = 10;

            double xmax_limit = 10;

            double ymax_limit = 10;

            GraphPane pane = zedGraphControl1.GraphPane;

            double[] newX = new double[(int)n];
            double[] newY = new double[(int)n];
            for(int i=0; i<(int)n; i++)
            {
                newX[i] = Math.Log(xs[i], Math.E);
                newY[i] = Math.Log(ys[i], Math.E);
            }

            double meanX = 0;
            for (int i = 0; i < xs.Length; i++)
            {
                meanX += newX[i];
            }

            double meanY = 0;
            for (int i = 0; i < ys.Length; i++)
            {
                meanY += newY[i];
            }

            double meanXSq = 0;
            for (int i = 0; i < xs.Length; i++)
            {
                meanXSq += Math.Pow(newX[i], 2);
            }

            double meanXY = 0;
            for (int i = 0; i < xs.Length; i++)
            {
                meanXY += newX[i] * newY[i];
            }


            pane.XAxis.Scale.Max = xmax_limit;

            pane.YAxis.Scale.Max = ymax_limit;

            double dif = (n * meanXSq - meanX * meanX);
            double a = (n * meanXY - meanX * meanY) / dif;
            double b = meanY / n - (a * meanX) / n;

            double beta = Math.Pow(Math.E, b);

            double[] drawX = new double[101];
            double[] drawYLinear = new double[101];


            double step = 0;
            int j = 0;
            while (step < 10)
            {
                drawX[j] = step;
                drawYLinear[j] = beta*Math.Pow(drawX[j],a);
                step += 0.1;
                j += 1;
            }
            Console.WriteLine(a+" "+beta);


            PointPairList linearPoints = new PointPairList(drawX, drawYLinear);

            PointPairList listDots = new PointPairList(xs, ys);

            LineItem curveLinear = pane.AddCurve("Stepen", linearPoints, Color.Red, SymbolType.None);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Refresh();

        }

        private void Pokaz()
        {

            double xmax = 10;

            double xmax_limit = 10;

            double ymax_limit = 10;

            GraphPane pane = zedGraphControl1.GraphPane;

            double[] newX = new double[(int)n];
            double[] newY = new double[(int)n];
            for (int i = 0; i < (int)n; i++)
            {
                newX[i] = xs[i];
                newY[i] = Math.Log(ys[i], Math.E);
            }

            double meanX = 0;
            for (int i = 0; i < xs.Length; i++)
            {
                meanX += newX[i];
            }

            double meanY = 0;
            for (int i = 0; i < ys.Length; i++)
            {
                meanY += newY[i];
            }

            double meanXSq = 0;
            for (int i = 0; i < xs.Length; i++)
            {
                meanXSq += Math.Pow(newX[i], 2);
            }

            double meanXY = 0;
            for (int i = 0; i < xs.Length; i++)
            {
                meanXY += newX[i] * newY[i];
            }


            pane.XAxis.Scale.Max = xmax_limit;

            pane.YAxis.Scale.Max = ymax_limit;

            double dif = (n * meanXSq - meanX * meanX);
            double a = (n * meanXY - meanX * meanY) / dif;
            double b = meanY / n - (a * meanX) / n;

            double beta = Math.Pow(Math.E, b);

            double[] drawX = new double[101];
            double[] drawYLinear = new double[101];


            double step = 0;
            int j = 0;
            while (step < 10)
            {
                drawX[j] = step;
                drawYLinear[j] = beta * Math.Pow(Math.E, a*drawX[j]);
                step += 0.1;
                j += 1;
            }
            Console.WriteLine(a + " " + beta);


            PointPairList linearPoints = new PointPairList(drawX, drawYLinear);

            PointPairList listDots = new PointPairList(xs, ys);

            LineItem curveLinear = pane.AddCurve("Pokaz", linearPoints, Color.CadetBlue, SymbolType.None);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Refresh();

        }

        private void Sq()
        {

            double xmin = 0;
            double xmax = 10;

            double xmin_limit = 0;
            double xmax_limit = 10;

            double ymin_limit = 0;
            double ymax_limit = 10;

            GraphPane pane = zedGraphControl1.GraphPane;

            double meanX = 0;
            for (int i = 0; i < xs.Length; i++)
            {
                meanX += xs[i];
            }

            double meanY = 0;
            for (int i = 0; i < ys.Length; i++)
            {
                meanY += ys[i];
            }

            double meanX2 = 0;
            for (int i = 0; i < xs.Length; i++)
            {
                meanX2 += Math.Pow(xs[i], 2);
            }

            double meanXY = 0;
            for (int i = 0; i < xs.Length; i++)
            {
                meanXY += xs[i] * ys[i];
            }

            double meanX4 = 0;
            for (int i = 0; i < xs.Length; i++)
            {
                meanX4 += Math.Pow(xs[i], 4);
            }

            double meanX3 = 0;
            for (int i = 0; i < xs.Length; i++)
            {
                meanX3 += Math.Pow(xs[i], 3);
            }

            double meanX2Y = 0;
            for (int i = 0; i < xs.Length; i++)
            {
                meanX2Y += Math.Pow(xs[i], 2)*ys[i];
            }

            double det = meanX4 * meanX2 * n +
                        +meanX3*meanX*meanX2 +
                        +meanX3*meanX*meanX2 -
                        -meanX2*meanX2*meanX2-
                        -meanX4*meanX*meanX-
                        -meanX3*meanX3*n;


            // !!!

            pane.XAxis.Scale.Max = xmax_limit;

            // !!!

            pane.YAxis.Scale.Max = ymax_limit;

            double dif = (n * meanX2 - meanX * meanX);
            double a = (n * meanXY - meanX * meanY) / dif;
            double b = meanY / n - (a * meanX) / n;

            double[] drawX = new double[101];
            double[] drawYLinear = new double[101];


            double step = 0;
            int j = 0;
            while (step < 10)
            {
                drawX[j] = step;
                drawYLinear[j] = drawX[j] * a + b;
                step += 0.1;
                j += 1;
            }

            PointPairList linearPoints = new PointPairList(drawX, drawYLinear);

            LineItem curveLinear = pane.AddCurve("Linear", linearPoints, Color.Goldenrod, SymbolType.None);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Refresh();

        }

        public void Draw()
        {

        }

    }
}

