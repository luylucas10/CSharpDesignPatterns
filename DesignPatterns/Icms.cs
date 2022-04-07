namespace DesignPatterns
{
	public class Icms : IImposto
	{
		public double Calcular(Orcamento orcamento)
		{
			return orcamento.Valor * 0.05 + 50;
		}
	}
}
