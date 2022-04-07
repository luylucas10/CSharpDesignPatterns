namespace DesignPatterns.ChainResponsability
{
	public class DescontoVendaCasada : IDesconto
	{
		public IDesconto Proximo { get; set; }

		public double Desconta(Orcamento orcamento) =>
				orcamento.Itens.Any(x => x.Nome.Equals("Caneta") || x.Nome.Equals("Lápis"))
				? orcamento.Itens.Sum(x => x.Valor) * 0.05
				: Proximo.Desconta(orcamento);
	}
}
