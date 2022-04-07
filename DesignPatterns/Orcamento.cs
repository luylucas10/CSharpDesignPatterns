namespace DesignPatterns
{
	public interface IEstadoOrcamento
	{
		void AplicarDesconto(Orcamento orcamento);
		void Aprova(Orcamento orcamento);
		void Reprova(Orcamento orcamento);
		void Finaliza(Orcamento orcamento);
	}

	public class EmAprovacao : IEstadoOrcamento
	{
		private bool _descontoAplicado = false;

		public void AplicarDesconto(Orcamento orcamento)
		{
			if (!_descontoAplicado)
			{
				orcamento.AtualizaValor(orcamento.Valor * 0.95);
				_descontoAplicado = true;
			}
			else
				throw new Exception("O desconto já foi aplicado");
		}

		public void Aprova(Orcamento orcamento) =>
			orcamento.AtualizaEstado(new Aprovado());

		public void Finaliza(Orcamento orcamento) =>
			orcamento.AtualizaEstado(new Finalizado());

		public void Reprova(Orcamento orcamento) =>
			orcamento.AtualizaEstado(new Reprovado());
	}

	public class Aprovado : IEstadoOrcamento
	{
		private bool _descontoAplicado = false;
		public void AplicarDesconto(Orcamento orcamento)
		{
			if (!_descontoAplicado)
			{
				orcamento.AtualizaValor(orcamento.Valor * 0.98);
				_descontoAplicado = true;
			}
			else
				throw new Exception("O desconto já foi aplicado");

		}

		public void Aprova(Orcamento orcamento) =>
			throw new Exception("Orçamento já está em estado de aprovação");

		public void Finaliza(Orcamento orcamento) =>
			orcamento.AtualizaEstado(new Finalizado());

		public void Reprova(Orcamento orcamento) =>
			throw new Exception("Orçamento está em estado de aprovação e não pode ser reprovado");
	}

	public class Reprovado : IEstadoOrcamento
	{
		public void AplicarDesconto(Orcamento orcamento) =>
			throw new Exception("Orçamentos reprovados não recebem desconto extra!");

		public void Aprova(Orcamento orcamento) =>
			throw new Exception("Orçamentos reprovados não podem ser aprovados");

		public void Finaliza(Orcamento orcamento) =>
			orcamento.AtualizaEstado(new Finalizado());

		public void Reprova(Orcamento orcamento) =>
			throw new Exception("Orçamento está em estado de reprovação");
	}

	public class Finalizado : IEstadoOrcamento
	{
		public void AplicarDesconto(Orcamento orcamento) =>
			throw new Exception("Orçamentos finalizados não recebem desconto extra!");

		public void Aprova(Orcamento orcamento) =>
			throw new Exception("Orçamentos finalizados não podem ser aprovados");

		public void Finaliza(Orcamento orcamento) =>
			throw new Exception("Orçamento já finalizado");

		public void Reprova(Orcamento orcamento) =>
			throw new Exception("Orçamentos finalizados não podem ser reprovados");

	}

	public class Orcamento
	{
		public double Valor { get; private set; }
		public IList<Item> Itens { get; private set; }
		public IEstadoOrcamento Estado { get; private set; }

		public Orcamento(double valor)
		{
			Valor = valor;
			Itens = new List<Item>();
			Estado = new EmAprovacao();
		}

		public void AdicionarItem(Item item) => Itens.Add(item);
		public void AtualizaValor(double novoValor) =>
			Valor = novoValor > 0
			? Valor = novoValor
			: Valor = Valor;

		public void AtualizaEstado(IEstadoOrcamento novoEstado) =>
			Estado = novoEstado;

		public void AplicaDescontoExtra() =>
			Estado.AplicarDesconto(this);

		public void Aprova() =>
			Estado.Aprova(this);

		public void Reprova() =>
			Estado.Reprova(this);

		public void Finaliza() =>
			Estado.Finaliza(this);
	}
}
