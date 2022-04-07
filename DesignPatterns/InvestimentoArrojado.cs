namespace DesignPatterns
{
	public class InvestimentoArrojado : IInvestimento
	{
		public double CalcularRetorno(Conta conta)
		{
			var r = new Random().Next(101);
			if (r <= 20)
				return conta.SaldoInvestimento * 0.05;
			if (r <= 30)
				return conta.SaldoInvestimento * 0.03;
			return conta.SaldoInvestimento * 0.06;
		}
	}

}
