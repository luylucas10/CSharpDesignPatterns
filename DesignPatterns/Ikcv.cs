namespace DesignPatterns
{
	public class Ikcv : Imposto
	{
		public Ikcv()
		{
		}

		public Ikcv(IImposto proximo) : base(proximo)
		{
		}

		public override double CalcularTaxaMaxima(Orcamento orcamento) =>
			orcamento.Valor * 0.1;

		public override double CalcularTaxaMinima(Orcamento orcamento) =>
			orcamento.Valor * 0.06;

		public override bool RegraTaxacaoMaxima(Orcamento orcamento) =>
			orcamento.Valor > 500 && orcamento.Itens.Any(x => x.Valor > 100);
	}
}
