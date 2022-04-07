namespace DesignPatterns.ChainResponsability
{
	public class DescontoSeteProCentoParaQuinhentosOuMais : IDesconto
	{
		public IDesconto Proximo { get; set; }

		public double Desconta(Orcamento orcamento) =>
				orcamento.Itens.Sum(x => x.Valor) > 500 ? orcamento.Itens.Sum(x => x.Valor) * 0.07 : Proximo.Desconta(orcamento);
	}
}
