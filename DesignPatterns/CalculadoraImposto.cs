namespace DesignPatterns
{
	public class CalculadoraImposto
	{
		public void Calcular(Orcamento orcamento, IImposto imposto)
		{
			Console.WriteLine(imposto.Calcular(orcamento));
		}
	}
}
