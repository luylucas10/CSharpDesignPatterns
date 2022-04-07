namespace DesignPatterns
{
	public abstract class Imposto : IImposto
	{
		public Imposto() =>
			Proximo = null;

		public Imposto(IImposto proximo) =>
			Proximo = proximo;

		protected IImposto? Proximo { get; private set; }

		public double Calcular(Orcamento orcamento)
		{
			var valor = RegraTaxacaoMaxima(orcamento)
				? CalcularTaxaMaxima(orcamento)
				: CalcularTaxaMinima(orcamento);
			valor += Proximo?.Calcular(orcamento) ?? 0;
			return valor;
		}

		public abstract bool RegraTaxacaoMaxima(Orcamento orcamento);
		public abstract double CalcularTaxaMinima(Orcamento orcamento);
		public abstract double CalcularTaxaMaxima(Orcamento orcamento);
	}
}
