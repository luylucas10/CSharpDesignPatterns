namespace DesignPatterns.ChainResponsability
{
	public class SemDesconto : IDesconto
	{
		public IDesconto Proximo { get; set; }

		public double Desconta(Orcamento orcamento) => 0;
	}
}
