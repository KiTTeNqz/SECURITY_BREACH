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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(823, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Линейная ошибка";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(823, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Степенная ошибка";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(823, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Экспоненциальная ошибка";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(823, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Квадратичная ошибка";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1001, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1001, 77);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(1001, 118);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(1001, 163);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(929, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Рисовать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(845, 383);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Количество точек";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(1001, 380);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 11;
            this.textBox5.Text = "100";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 450);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;

        double[] xs = new double[] { 1, 2, 3, 4, 5, 6 };
        double[] ys = new double[] { 1.0, 1.5, 3.0, 4.5, 7.0, 8.5 };
        double[] ysD = new double[] { 1.0, 1.5, 3.0, 4.5, 7.0, 8.5 };
        double n = 6;

        List<PointPairList> pointsPairs = new List<PointPairList>();
        List<PointPairList> dotsPairs = new List<PointPairList>();

        private double deter3(double[,] matr)
        {
            double plus = matr[0, 0] * matr[1, 1] * matr[2, 2] + matr[1, 0] * matr[2, 1] * matr[0, 2] + matr[0, 1] * matr[1, 2] * matr[2, 0];
            double minus = matr[0, 2] * matr[1, 1] * matr[2, 0] + matr[2, 1] * matr[1, 2] * matr[0, 0] + matr[1, 0] * matr[0, 1] * matr[2, 2];
            return plus - minus;
        }

        private double[,] swapColumns(double[,] matr, int idx, double[] column)
        {
            double[,] copy = new double[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    copy[i, j] = matr[i, j];
            for (int i = 0; i < column.Length; i++)
                copy[i, idx] = column[i];
            return copy;
        }

        private void Linear(int N)
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

            double step = 10.0 / (double)N;
            int count = 0;
            int j = 0;

            double sumX = 0;

            double[] drawX = new double[N];
            double[] drawYLinear = new double[N];
            while (count < N)
            {
                drawX[j] = sumX;
                drawYLinear[j] = drawX[j] * a + b;
                count++;
                sumX += step;
                j += 1;
            }

            PointPairList linearPoints = new PointPairList(drawX, drawYLinear);

            PointPairList listDots = new PointPairList(xs, ys);
            for (int i = 0; i < xs.Length; i++)
            {
                ysD[i] = xs[i] * a + b;
            }
            PointPairList dots = new PointPairList(xs, ysD);
            pointsPairs.Add(listDots);
            pointsPairs.Add(linearPoints);
            dotsPairs.Add(dots);

        }

        private void Step(int N)
        {

            double xmax = 10;

            double xmax_limit = 10;

            double ymax_limit = 10;

            GraphPane pane = zedGraphControl1.GraphPane;

            double[] newX = new double[(int)n];
            double[] newY = new double[(int)n];
            for (int i = 0; i < (int)n; i++)
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

            double step = 10.0 / (double)N;
            int count = 0;
            int j = 0;

            double sumX = 0;

            double[] drawX = new double[N];
            double[] drawYLinear = new double[N];
            while (count < N)
            {
                drawX[j] = sumX;
                drawYLinear[j] = beta * Math.Pow(drawX[j], a);
                count++;
                sumX += step;
                j += 1;
            }
            Console.WriteLine(a + " " + beta);


            PointPairList linearPoints = new PointPairList(drawX, drawYLinear);

            
            for (int i=0; i<xs.Length; i++)
            {
                ysD[i]= beta * Math.Pow(xs[i], a);
            }
            PointPairList dotsPoints = new PointPairList(xs,ysD);
            pointsPairs.Add(linearPoints);
            dotsPairs.Add(dotsPoints);

        }

        private void Pokaz(int N)
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

            double step = 10.0 / (double)N;
            int count = 0;
            int j = 0;

            double sumX = 0;

            double[] drawX = new double[N];
            double[] drawYLinear = new double[N];
            while (count < N)
            {
                drawX[j] = sumX;
                drawYLinear[j] = beta * Math.Pow(Math.E, a * drawX[j]);
                count++;
                sumX += step;
                j += 1;
            }

            Console.WriteLine(a + " " + beta);


            PointPairList linearPoints = new PointPairList(drawX, drawYLinear);
            for (int i = 0; i < xs.Length; i++)
            {
                ysD[i] = beta * Math.Pow(Math.E, a * xs[i]);
            }
            PointPairList dotsPoints = new PointPairList(xs, ysD);

            pointsPairs.Add(linearPoints);
            dotsPairs.Add(dotsPoints);
        }

        private void Sq(int N)
        {

            double xmax_limit = 10;
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
                meanX2Y += Math.Pow(xs[i], 2) * ys[i];
            }

            double[,] matr = new double[3, 3];
            matr[0, 0] = meanX4;
            matr[0, 1] = meanX3;
            matr[0, 2] = meanX2;
            matr[1, 0] = meanX3;
            matr[1, 1] = meanX2;
            matr[1, 2] = meanX;
            matr[2, 0] = meanX2;
            matr[2, 1] = meanX;
            matr[2, 2] = n;

            double[] col = new double[3];
            col[0] = meanX2Y;
            col[1] = meanXY;
            col[2] = meanY;

            double det = deter3(matr);
            double[,] matrA = swapColumns(matr, 0, col);
            double[,] matrB = swapColumns(matr, 1, col);
            double[,] matrC = swapColumns(matr, 2, col);
            double detA = deter3(matrA);
            double detB = deter3(matrB);
            double detC = deter3(matrC);

            pane.XAxis.Scale.Max = xmax_limit;
            pane.YAxis.Scale.Max = ymax_limit;

            double a = detA / det;
            double b = detB / det;
            double c = detC / det;

            double step = 10.0/(double)N;
            int count = 0;
            int j = 0;

            double sumX=0;

            double[] drawX = new double[N];
            double[] drawYLinear = new double[N];
            while (count < N)
            {
                drawX[j] = sumX;
                drawYLinear[j] = Math.Pow(drawX[j],2) * a + drawX[j]*b+c;
                count++;
                sumX+= step;
                j += 1;
            }

            PointPairList linearPoints = new PointPairList(drawX, drawYLinear);
            for (int i = 0; i < xs.Length; i++)
            {
                ysD[i] = Math.Pow(xs[i], 2) * a + xs[i] * b + c;
            }
            PointPairList dotsPoints = new PointPairList(xs, ysD);
            pointsPairs.Add(linearPoints);
            dotsPairs.Add(dotsPoints);
        }

        public void Draw()
        {
            dotsPairs.Clear();
            pointsPairs.Clear();

            GraphPane pane = zedGraphControl1.GraphPane;
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();

            Linear(int.Parse(textBox5.Text.ToString()));
            Step(int.Parse(textBox5.Text.ToString()));
            Pokaz(int.Parse(textBox5.Text.ToString()));
            Sq(int.Parse(textBox5.Text.ToString()));

            LineItem dots = pane.AddCurve("Linear", pointsPairs[0], Color.Red, SymbolType.Circle);
            dots.Line.IsVisible = false;
            LineItem curve1 = pane.AddCurve("Linear",pointsPairs[1],Color.Blue, SymbolType.None);
            LineItem curve2 = pane.AddCurve("Stepen",pointsPairs[2],Color.DarkOliveGreen, SymbolType.None);
            LineItem curve3 = pane.AddCurve("Pokaz",pointsPairs[3],Color.MediumVioletRed, SymbolType.None);
            LineItem curve4 = pane.AddCurve("Square",pointsPairs[4],Color.Goldenrod, SymbolType.None);

            drawDots();
            double[] errs = calcErr();

            textBox1.Text = errs[0].ToString();
            textBox2.Text = errs[1].ToString();
            textBox3.Text = errs[2].ToString();
            textBox4.Text = errs[3].ToString();

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Refresh();
        }

        private void drawDots()
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            LineItem dots2 = pane.AddCurve("LinearD", dotsPairs[0], Color.Blue, SymbolType.TriangleDown);
            dots2.Line.IsVisible = false;
            LineItem dots3 = pane.AddCurve("StepenD", dotsPairs[1], Color.DarkOliveGreen, SymbolType.Square);
            dots3.Line.IsVisible = false;
            LineItem dots4 = pane.AddCurve("PokazD", dotsPairs[2], Color.MediumVioletRed, SymbolType.Diamond);
            dots4.Line.IsVisible = false;
            LineItem dots5 = pane.AddCurve("SquareD", dotsPairs[3], Color.Goldenrod, SymbolType.XCross);
            dots5.Line.IsVisible = false;

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Refresh();
        }

        private double[] calcErr()
        {
            double[] errors = new double[4] {0,0,0,0};
            for(int i=0; i<dotsPairs.Count; i++)
            {
                for (int j = 0; j < ys.Length; j++)
                {
                    errors[i]+= Math.Pow(ys[j] - dotsPairs[i].InterpolateX(xs[j]), 2);
                }
            }
            return errors;
        }


        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
    }
}

