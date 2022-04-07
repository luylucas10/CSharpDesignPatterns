namespace DesignPatterns
{
	public class ItemDaNota
	{
		public string Nome { get; private set; }
		public double Valor { get; private set; }

		public ItemDaNota(string nome, double valor)
		{
			Nome = nome;
			Valor = valor;
		}
	}

	public class CriadorItem
	{
		private string _nome;
		private double _valor;

		public CriadorItem ComNome(string nome)
		{
			_nome = nome;
			return this;
		}

		public CriadorItem ComValor(double valor)
		{
			_valor = valor;
			return this;
		}

		public ItemDaNota Construir() =>
			new(_nome, _valor);
	}

	public class NotaFiscal
	{
		public string RazaoSocial { get; private set; }
		public string Cnpj { get; private set; }
		public DateTime DataDeEmissao { get; private set; }
		public double ValorBruto { get; private set; }
		public double Impostos { get; private set; }
		public IList<ItemDaNota> Itens { get; private set; }
		public string Observacoes { get; private set; }

		public NotaFiscal(string razaoSocial, string cnpj, DateTime dataDeEmissao,
									double valorBruto, double impostos, IList<ItemDaNota> itens,
									string observacoes)
		{
			RazaoSocial = razaoSocial;
			Cnpj = cnpj;
			DataDeEmissao = dataDeEmissao;
			ValorBruto = valorBruto;
			Impostos = impostos;
			Itens = itens;
			Observacoes = observacoes;
		}
	}

	public class CriadorNota
	{
		private string _razao;
		private string _cnpj;
		private double _valorTotal;
		private double _impostos;
		private IList<ItemDaNota> _itens = new List<ItemDaNota>();
		private DateTime _data;
		private string _observacao;

		private IList<IAcao> _acoes = new List<IAcao>();

		public CriadorNota()
		{
			NaData(DateTime.Now);
		}

		public CriadorNota ParaEmpresa(string razao)
		{
			_razao = razao;
			return this;
		}

		public CriadorNota ComCnpj(string cnpj)
		{
			_cnpj = cnpj;
			return this;
		}

		public CriadorNota NaData(DateTime data)
		{
			_data = data;
			return this;
		}
		public CriadorNota ComItem(ItemDaNota item)
		{
			_itens.Add(item);
			_valorTotal += item.Valor;
			_impostos += item.Valor * 0.05;
			return this;
		}

		public CriadorNota ComObservação(string observacao)
		{
			_observacao = observacao;
			return this;
		}

		public CriadorNota Nova(IAcao acao)
		{
			_acoes.Add(acao);
			return this;
		}

		public NotaFiscal Contruir()
		{
			var nf = new NotaFiscal(_razao, _cnpj, _data, _valorTotal, _impostos, _itens, _observacao);
			foreach (var a in _acoes)
				a.Executa(nf);
			return nf;
		}
	}

	public interface IAcao
	{
		void Executa(NotaFiscal nf);
	}

	public class EnviarEmail : IAcao
	{
		public void Executa(NotaFiscal nf) =>
			Console.WriteLine("E-Mail");
	}
	public class SalvarBanco : IAcao
	{
		public void Executa(NotaFiscal nf) =>
			Console.WriteLine("Banco");
	}
	public class EnviarSms : IAcao
	{
		public void Executa(NotaFiscal nf) =>
			Console.WriteLine("SMS");
	}

	public class Multiplicador : IAcao
	{
		public double Fator { get; private set; }

		public Multiplicador(double fator)
		{
			Fator = fator;
		}

		public void Executa(NotaFiscal nf) =>
			Console.WriteLine(nf.ValorBruto * Fator);
	}

}
