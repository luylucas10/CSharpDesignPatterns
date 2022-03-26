namespace DesignPatterns
{
    public interface IImposto
    {
        double Calcular(Orcamento orcamento);
    }

    public class Icms : IImposto
    {
        public double Calcular(Orcamento orcamento)
        {
            return orcamento.Valor * 0.05 + 50;
        }
    }

    public class Iss : IImposto
    {
        public double Calcular(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06;
        }
    }

    public class Iccc : IImposto
    {
        public double Calcular(Orcamento orcamento)
        {
            if (orcamento.Valor < 1000)
                return orcamento.Valor * 0.05;
            if (orcamento.Valor <= 3000)
                return orcamento.Valor * 0.07;
            return orcamento.Valor * 0.08 + 30;
        }
    }

    public class Orcamento
    {
        public double Valor { get; private set; }

        public Orcamento(double valor)
        {
            Valor = valor;
        }
    }

    public class CalculadorImposto
    {
        public void RealizaCalculo(Orcamento orcamento, IImposto imposto)
        {
            Console.WriteLine(imposto.Calcular(orcamento));
        }
    }
}
