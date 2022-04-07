namespace DesignPatterns
{
	public abstract class Relatorio
	{
		public void ImprimirRelatorio(List<Conta> contas)
		{
			Cabecalho();
			Corpo(contas);
			Rodape();
		}

		protected abstract void Cabecalho();
		protected abstract void Corpo(List<Conta> contas);
		protected abstract void Rodape();
	}
}
