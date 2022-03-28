using DesignPatterns.ChainResponsability;

namespace DesignPatterns
{
    public class CalculadoraImposto
    {
        public void Calcular(Orcamento orcamento, IImposto imposto)
        {
            Console.WriteLine(imposto.Calcular(orcamento));
        }
    }

    public class CalculadoraDesconto
    {
        public double Calcula(Orcamento orcamento)
        {
            // antes do padrão:
            //if (orcamento.Itens.Count > 5)
            //    return orcamento.Valor * 0.1;

            //if (orcamento.Valor > 500)
            //    return orcamento.Valor * 0.07;


            //return 0;

            //var desconto = new DescontoPorCincoItens().Desconta(orcamento);
            //if (desconto == 0)
            //    desconto = new DescontoMaisQuinhentosReais().Desconta(orcamento);
            //return desconto;

            // com padrão
            //var desconto1 = new DescontoPorCincoItens();
            //var desconto2 = new DescontoMaisQuinhentosReais();
            //desconto1.Proximo = desconto2;
            //desconto2.Proximo = new SemDesconto();

            var desconto1 = new DescontoDezPorCentoParaSeisItensOuMais()
            {
                Proximo = new DescontoSeteProCentoParaQuinhentosOuMais()
                {
                    Proximo = new DescontoVendaCasada()
                    {
                        Proximo = new SemDesconto()
                    }
                }
            };


            return desconto1.Desconta(orcamento);
        }

    }
}
