using System;

namespace Task3
{
    class Program
    {
		static void Main(string[] args)
		{
			ArithmeticalProgression progression = new ArithmeticalProgression(1, 5);
			Console.WriteLine("Прогрессия: {0},{1},{2}", progression[0], progression[1], progression[2]);
			double[] elements = new double[] { progression[0], progression[1], progression[2] };
			List list = new List(elements);
			Console.WriteLine("Лист значений выше: {0},{1},{2}", list[0], list[1], list[2]);
			Console.ReadLine();
		}

    }

	public interface ISeries
	{
		double GetCurrent();
		bool MoveNext();
		void Reset();
	}

	public class ArithmeticalProgression : ISeries, IIndexable
	{
		double start, step;
		int currentIndex;

		public ArithmeticalProgression(double start, double step)
		{
			this.start = start;
			this.step = step;
			this.currentIndex = 1;
		}

		public double GetCurrent()
		{
			return start + step * currentIndex;
		}

		public bool MoveNext()
		{
			currentIndex++;
			return true;
		}

		public void Reset()
		{
			currentIndex = 1;
		}

		public double this[int index]
		{
			get
			{
				return start + step * index;
			}
		}
	}

	public class List : ISeries, IIndexable
	{
		private double[] Series;
		private int currentIndex;

		public List(double[] series)
		{
			this.Series = series;
			currentIndex = 0;
		}


        public double GetCurrent()
		{
			return Series[currentIndex];
		}

		public bool MoveNext()
		{
			currentIndex = currentIndex < Series.Length - 1 ? currentIndex + 1 : 0;
			return true;
		}

		public void Reset()
		{
			currentIndex = 0;
		}

		public double this[int index]
		{
			get { return Series[index]; }
		}
	}

	public interface IIndexable
	{
		double this[int index] { get; }
	}
}
