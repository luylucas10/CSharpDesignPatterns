namespace DesignPatterns
{
	public class RelatorioComplexo : Relatorio
	{
		protected override void Cabecalho() =>
			Console.WriteLine("Banco - Endereço - Telefone");

		protected override void Corpo(List<Conta> contas)
		{
			foreach (var conta in contas)
				Console.WriteLine($@"{conta.Titular} - {conta.Agencia} - {conta.Numero} - {conta.Saldo}");
		}

		protected override void Rodape() =>
			Console.WriteLine($"Email - {DateTime.Now}");
	}
}
