namespace DesignPatterns
{
	// Atividade investimento
	public interface IInvestimento
	{
		public double CalcularRetorno(Conta conta);
	}

	public class InvestimentoConservador : IInvestimento
	{
		public double CalcularRetorno(Conta conta) =>
				conta.SaldoInvestimento * 0.8;
	}
	public class InvestimentoModerado : IInvestimento
	{
		public double CalcularRetorno(Conta conta) =>
				 conta.SaldoInvestimento * new Random().Next(101) > 50 ? 0.025 : 0.07;
	}
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
	public class Conta
	{
		public string Titular { get; private set; }

		public string Agencia { get; private set; }
		public string Numero { get; private set; }
		public double Saldo { get; private set; }
		public double SaldoInvestimento { get; private set; }

		public Conta(double saldoInvestimento)
		{
			SaldoInvestimento = saldoInvestimento;
		}
	}

	public class CalculadoraInvestimento
	{
		public void Calcular(Conta conta, IInvestimento investimento) =>
				Console.WriteLine(investimento.CalcularRetorno(conta));
	}

}
