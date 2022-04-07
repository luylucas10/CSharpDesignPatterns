namespace DesignPatterns
{
	public class RelatorioSimples : Relatorio
	{
		protected override void Cabecalho() =>
			Console.WriteLine("Banco - Telefone");

		protected override void Corpo(List<Conta> contas)
		{
			foreach (var conta in contas)
				Console.WriteLine($@"{conta.Titular} - {conta.Saldo}");
		}

		protected override void Rodape() =>
			Console.WriteLine("Banco - Telefone");
	}
}
