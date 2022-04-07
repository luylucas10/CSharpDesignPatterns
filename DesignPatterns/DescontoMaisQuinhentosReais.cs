namespace DesignPatterns.ChainResponsability
{
	public class DescontoMaisQuinhentosReais : IDesconto
	{
		public IDesconto Proximo { get; set; }

		public double Desconta(Orcamento orcamento) =>
				orcamento.Valor > 500 ? orcamento.Valor * 0.007 : Proximo.Desconta(orcamento);
	}
}
