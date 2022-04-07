namespace DesignPatterns
{
	public class CalculadoraInvestimento
	{
		public void Calcular(Conta conta, IInvestimento investimento) =>
				Console.WriteLine(investimento.CalcularRetorno(conta));
	}

}
