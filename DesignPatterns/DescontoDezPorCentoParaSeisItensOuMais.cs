namespace DesignPatterns.ChainResponsability
{
	public class DescontoDezPorCentoParaSeisItensOuMais : IDesconto
	{
		public IDesconto Proximo { get; set; }

		public double Desconta(Orcamento orcamento)
		{
			return orcamento.Itens.Count >= 6 ? orcamento.Valor * 0.1 : Proximo.Desconta(orcamento);
		}
	}
}
