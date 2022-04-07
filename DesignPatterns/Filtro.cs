namespace DesignPatterns
{
	public abstract class Filtro
	{
		protected Filtro? Proximo { get; }

		public Filtro()
		{
			Proximo = null;
		}

		public Filtro(Filtro proximo)
		{
			Proximo = proximo;
		}

		public abstract List<Conta> Filtrar(List<Conta> contas);
	}

	public class SaldoMenorQueCemReaisFiltro : Filtro
	{
		public SaldoMenorQueCemReaisFiltro()
		{
		}

		public SaldoMenorQueCemReaisFiltro(Filtro proximo) : base(proximo)
		{
		}

		public override List<Conta> Filtrar(List<Conta> contas) =>
			contas.Where(x => x.Saldo < 100).ToList();
	}

	public class SaldoMaiorQueQuinhentosMilReaisFiltro : Filtro
	{
		public SaldoMaiorQueQuinhentosMilReaisFiltro()
		{
		}

		public SaldoMaiorQueQuinhentosMilReaisFiltro(Filtro proximo) : base(proximo)
		{
		}

		public override List<Conta> Filtrar(List<Conta> contas) =>
			contas.Where(x => x.Saldo < 500000).ToList();
	}

	public class ContasRecentesFiltro : Filtro
	{
		public ContasRecentesFiltro()
		{
		}

		public ContasRecentesFiltro(Filtro proximo) : base(proximo)
		{
		}

		public override List<Conta> Filtrar(List<Conta> contas) =>
			contas.Where(x => x.Abertura.Month == DateTime.Now.Month && x.Abertura.Year == DateTime.Now.Year).ToList();
	}
}
