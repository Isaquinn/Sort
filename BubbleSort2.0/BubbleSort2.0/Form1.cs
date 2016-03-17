using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace BubbleSort2._0
{
	public partial class Form1 : Form
	{
		Graphics g;
		public static List<int> numeros = new List<int>();
		int valor;
		Stopwatch stopwatch = new Stopwatch();
		TimeSpan time;
		public static int contador;
		Random random = new Random();
		public Form1()
		{
			InitializeComponent();
		}



		static void BubbleSort(List<int> numeros)
		{
			for (int i = 0; i < numeros.Count; i++)
			{
				for (int k = i + 1; k < numeros.Count; k++)
				{
					if (numeros[i] > numeros[k])
					{
						int temp = numeros[i];
						numeros[i] = numeros[k];
						numeros[k] = temp;
					}
				}
			}
		}

		static bool NoRepeat(int item)
		{

			if (!numeros.Contains(item))
			{

				numeros.Add(item);
				return false;
			}
			else
			{
				return true;
			}
		}
		

		private void button1_Click(object sender, EventArgs e)
		{
			//listBox1.Items.Clear();
			
			contador = numeros.Count;
			for (int i = 10; i < 2000; i+=5)
			{
				numeros.Clear();
				for (int j = 0; j < i; j++)
				{
					numeros.Add(random.Next(0, 3000));
				}
				stopwatch.Restart();
				BubbleSort(numeros);
				stopwatch.Stop();
				
				chart1.Series[0].Points.AddXY(i, stopwatch.Elapsed.TotalMilliseconds);
				Tempo.Text = time.ToString();
			}
		}
	}
}
