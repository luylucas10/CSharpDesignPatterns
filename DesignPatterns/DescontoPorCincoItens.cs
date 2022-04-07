namespace DesignPatterns.ChainResponsability
{
	public class DescontoPorCincoItens : IDesconto
    {
        public IDesconto Proximo { get; set; }

        public double Desconta(Orcamento orcamento) =>
            orcamento.Itens.Count > 5 ? orcamento.Valor * 0.1 : Proximo.Desconta(orcamento);
    }
}
