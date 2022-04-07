namespace DesignPatterns
{
	public class InvestimentoModerado : IInvestimento
	{
		public double CalcularRetorno(Conta conta) =>
				 conta.SaldoInvestimento * new Random().Next(101) > 50 ? 0.025 : 0.07;
	}

}
