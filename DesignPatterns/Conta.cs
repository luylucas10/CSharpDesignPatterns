namespace DesignPatterns
{
	public interface IContaEstado
	{
		void Depositar(Conta conta, double deposito);
		double Sacar(Conta conta, double saque);
		void ContaPositivada(Conta conta);
		void ContaNegativada(Conta conta);
	}

	public class Positivado : IContaEstado
	{
		public void ContaNegativada(Conta conta) =>
			conta.AtualizarEstado(new Negativado());

		public void ContaPositivada(Conta conta) =>
			throw new Exception("A conta já está no estado positivo");

		public void Depositar(Conta conta, double deposito) =>
			conta.AtualizarSaldo(conta.Saldo + deposito * 0.98);

		public double Sacar(Conta conta, double saque)
		{
			conta.AtualizarSaldo(conta.Saldo - saque);
			if (conta.Saldo < 0)
				conta.NegativarConta();
			return saque;
		}
	}
	public class Negativado : IContaEstado
	{
		public void ContaNegativada(Conta conta) =>
				throw new Exception("A conta já está no estado negativado");

		public void ContaPositivada(Conta conta) =>
			conta.AtualizarEstado(new Positivado());

		public void Depositar(Conta conta, double deposito)
		{
			conta.AtualizarSaldo(conta.Saldo + deposito * 0.95);
			if (conta.Saldo > 0)
				conta.PositivarConta();
		}

		public double Sacar(Conta conta, double saque) =>
			throw new Exception("Não é possível realizar o saque");
	}
	public class Conta
	{
		public string Titular { get; private set; }
		public string Agencia { get; private set; }
		public string Numero { get; private set; }
		public double Saldo { get; private set; }
		public double SaldoInvestimento { get; private set; }
		public DateTime Abertura { get; private set; }

		public IContaEstado Estado { get; private set; }
		public Conta(double saldoInvestimento)
		{
			SaldoInvestimento = saldoInvestimento;
		}

		public Conta(string titular, double saldo)
		{
			Titular = titular;
			Saldo = saldo;
			Estado = saldo > 0 ? new Positivado() : new Negativado();
		}

		public void AtualizarSaldo(double novoSaldo) =>
			Saldo = novoSaldo;

		public void AtualizarEstado(IContaEstado novoEstado) => Estado = novoEstado;

		public void PositivarConta() => Estado.ContaPositivada(this);
		public void NegativarConta() => Estado.ContaNegativada(this);

		public void Depositar(double value) =>
			Estado.Depositar(this, value);

		public double Sacar(double value) =>
			Estado.Sacar(this, value);
	}

}
