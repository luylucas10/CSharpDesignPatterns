namespace DesignPatterns2
{
	public interface INota
	{
		int Frequencia { get; }
	}

	public class Do : INota
	{
		public int Frequencia => 262;
	}

	public class Re : INota
	{
		public int Frequencia => 294;
	}
	public class Mi : INota
	{
		public int Frequencia => 330;
	}
	public class Fa : INota
	{
		public int Frequencia => 349;
	}
	public class Sol : INota
	{
		public int Frequencia => 392;
	}
	public class La : INota
	{
		public int Frequencia => 440;
	}
	public class Si : INota
	{
		public int Frequencia => 490;
	}

	public class Notas
	{
		private static IDictionary<string, INota> notas =
				new Dictionary<string, INota>() {
				{ "do", new Do() } ,
				{ "re", new Re() } ,
				{ "mi", new Mi() },
				{ "fa", new Fa() },
				{ "sol", new Sol() },
				{ "la", new La() },
				{ "si", new Si() }
		};


		public INota Pega(string nome) =>
			notas[nome];
	}

	public class Piano
	{
		public void Toca(List<INota> musica)
		{
			foreach (INota nota in musica)
				Console.Beep(nota.Frequencia, 300);
		}
	}
}
