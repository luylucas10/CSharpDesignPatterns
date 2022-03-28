namespace DesignPatterns
{
	public interface IImposto
	{
		double Calcular(Orcamento orcamento);
	}

	#region Template Method

	public abstract class Imposto : IImposto
	{
		public double Calcular(Orcamento orcamento)
		{
			return RegraTaxacaoMaxima(orcamento)
				? CalcularTaxaMaxima(orcamento)
				: CalcularTaxaMinima(orcamento);
		}

		public abstract bool RegraTaxacaoMaxima(Orcamento orcamento);
		public abstract double CalcularTaxaMinima(Orcamento orcamento);
		public abstract double CalcularTaxaMaxima(Orcamento orcamento);
	}

	public class Icpp : Imposto
	{
		public override double CalcularTaxaMaxima(Orcamento orcamento) =>
			orcamento.Valor * 0.07;

		public override double CalcularTaxaMinima(Orcamento orcamento) =>
			orcamento.Valor * 0.05;

		public override bool RegraTaxacaoMaxima(Orcamento orcamento) =>
			orcamento.Valor > 500;
	}

	public class Ickv : Imposto
	{
		public override double CalcularTaxaMaxima(Orcamento orcamento) =>
			orcamento.Valor * 0.1;

		public override double CalcularTaxaMinima(Orcamento orcamento) =>
			orcamento.Valor * 0.06;

		public override bool RegraTaxacaoMaxima(Orcamento orcamento) =>
			orcamento.Valor > 500 && orcamento.Itens.Any(x => x.Valor > 100);
	}

	public class Ihit : Imposto
	{
		public override double CalcularTaxaMaxima(Orcamento orcamento) =>
			orcamento.Valor * 0.13 + 100;

		public override double CalcularTaxaMinima(Orcamento orcamento) =>
			orcamento.Valor * (0.01 * orcamento.Itens.Count);

		public override bool RegraTaxacaoMaxima(Orcamento orcamento) =>
			orcamento.Itens.GroupBy(x => x.Nome).Select(x => new { x.Key, qnt = x.Count() }).Any(a => a.qnt > 2);
	}

	public abstract class Relatorio
	{
		public void ImprimirRelatorio(List<Conta> contas)
		{
			Cabecalho();
			Corpo(contas);
			Rodape();
		}

		protected abstract void Cabecalho();
		protected abstract void Corpo(List<Conta> contas);
		protected abstract void Rodape();
	}

	public class RelatorioSimples : Relatorio
	{
		protected override void Cabecalho() =>
			Console.WriteLine("Banco - Telefone");

		protected override void Corpo(List<Conta> contas)
		{
			foreach (var conta in contas)
				Console.WriteLine($@"{conta.Titular} - {conta.Saldo}");
		}

		protected override void Rodape() =>
			Console.WriteLine("Banco - Telefone");
	}

	public class RelatorioComplexo : Relatorio
	{
		protected override void Cabecalho() =>
			Console.WriteLine("Banco - Endereço - Telefone");

		protected override void Corpo(List<Conta> contas)
		{
			foreach (var conta in contas)
				Console.WriteLine($@"{conta.Titular} - {conta.Agencia} - {conta.Numero} - {conta.Saldo}");
		}

		protected override void Rodape() =>
			Console.WriteLine($"Email - {DateTime.Now}");
	}

	#endregion

	public class Icms : IImposto
	{
		public double Calcular(Orcamento orcamento)
		{
			return orcamento.Valor * 0.05 + 50;
		}
	}

	public class Iss : IImposto
	{
		public double Calcular(Orcamento orcamento)
		{
			return orcamento.Valor * 0.06;
		}
	}

	public class Iccc : IImposto
	{
		public double Calcular(Orcamento orcamento)
		{
			if (orcamento.Valor < 1000)
				return orcamento.Valor * 0.05;
			if (orcamento.Valor <= 3000)
				return orcamento.Valor * 0.07;
			return orcamento.Valor * 0.08 + 30;
		}
	}
}
