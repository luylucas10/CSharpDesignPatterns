namespace DesignPatterns
{
	public class ImpostoMuitoAlto : Imposto
	{
		public ImpostoMuitoAlto()
		{
		}

		public ImpostoMuitoAlto(IImposto proximo) : base(proximo)
		{
		}

		public override double CalcularTaxaMaxima(Orcamento orcamento) =>
			orcamento.Valor * 0.2;

		public override double CalcularTaxaMinima(Orcamento orcamento) =>
			orcamento.Valor * 0.2;

		public override bool RegraTaxacaoMaxima(Orcamento orcamento) =>
			true;
	}
}
