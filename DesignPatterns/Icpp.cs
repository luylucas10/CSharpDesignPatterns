namespace DesignPatterns
{
	public class Icpp : Imposto
	{
		public Icpp()
		{
		}

		public Icpp(IImposto proximo) : base(proximo)
		{
		}

		public override double CalcularTaxaMaxima(Orcamento orcamento) =>
			orcamento.Valor * 0.07;

		public override double CalcularTaxaMinima(Orcamento orcamento) =>
			orcamento.Valor * 0.05;

		public override bool RegraTaxacaoMaxima(Orcamento orcamento) =>
			orcamento.Valor > 500;
	}
}
