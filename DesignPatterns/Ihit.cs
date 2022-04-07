namespace DesignPatterns
{
	public class Ihit : Imposto
	{
		public Ihit()
		{
		}

		public Ihit(IImposto proximo) : base(proximo)
		{
		}

		public override double CalcularTaxaMaxima(Orcamento orcamento) =>
			orcamento.Valor * 0.13 + 100;

		public override double CalcularTaxaMinima(Orcamento orcamento) =>
			orcamento.Valor * (0.01 * orcamento.Itens.Count);

		public override bool RegraTaxacaoMaxima(Orcamento orcamento) =>
			orcamento.Itens.GroupBy(x => x.Nome).Select(x => new { x.Key, qnt = x.Count() }).Any(a => a.qnt > 2);
	}
}
