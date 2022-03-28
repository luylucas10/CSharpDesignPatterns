namespace DesignPatterns.ChainResponsability
{
    public interface IDesconto
    {
        IDesconto Proximo { get; set; }
        double Desconta(Orcamento orcamento);
    }

    public class DescontoPorCincoItens : IDesconto
    {
        public IDesconto Proximo { get; set; }

        public double Desconta(Orcamento orcamento) =>
            orcamento.Itens.Count > 5 ? orcamento.Valor * 0.1 : Proximo.Desconta(orcamento);
    }

    public class DescontoMaisQuinhentosReais : IDesconto
    {
        public IDesconto Proximo { get; set; }

        public double Desconta(Orcamento orcamento) =>
            orcamento.Valor > 500 ? orcamento.Valor * 0.007 : Proximo.Desconta(orcamento);
    }

    public class SemDesconto : IDesconto
    {
        public IDesconto Proximo { get; set; }

        public double Desconta(Orcamento orcamento) => 0;
    }

    public class DescontoDezPorCentoParaSeisItensOuMais : IDesconto
    {
        public IDesconto Proximo { get; set; }

        public double Desconta(Orcamento orcamento)
        {
            return orcamento.Itens.Count >= 6 ? orcamento.Valor * 0.1 : Proximo.Desconta(orcamento);
        }
    }

    public class DescontoSeteProCentoParaQuinhentosOuMais : IDesconto
    {
        public IDesconto Proximo { get; set; }

        public double Desconta(Orcamento orcamento) =>
            orcamento.Itens.Sum(x => x.Valor) > 500 ? orcamento.Itens.Sum(x => x.Valor) * 0.07 : Proximo.Desconta(orcamento);
    }

    public class DescontoVendaCasada : IDesconto
    {
        public IDesconto Proximo { get; set; }

        public double Desconta(Orcamento orcamento) =>
            orcamento.Itens.Any(x => x.Nome.Equals("Caneta") || x.Nome.Equals("Lápis"))
            ? orcamento.Itens.Sum(x => x.Valor) * 0.05
            : Proximo.Desconta(orcamento);
    }
}
