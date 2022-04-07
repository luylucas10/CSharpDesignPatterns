namespace DesignPatterns
{
	public class InvestimentoConservador : IInvestimento
	{
		public InvestimentoConservador()
		{
		}

		public double CalcularRetorno(Conta conta) =>
				conta.SaldoInvestimento * 0.8;
	}

}
