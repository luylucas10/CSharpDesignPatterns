using DesignPatterns;

//double desconto;
// padrão Strategy: separar o comportamento comum e usar a abstração;
//var calculadora = new CalculadorImposto();
//calculadora.RealizaCalculo(new Orcamento(500), new Icms());
//calculadora.RealizaCalculo(new Orcamento(500), new Iss());
//calculadora.RealizaCalculo(new Orcamento(900), new Iccc());
//calculadora.RealizaCalculo(new Orcamento(2000), new Iccc());
//calculadora.RealizaCalculo(new Orcamento(5000), new Iccc());

//var calculadoraInvestimento = new CalculadoraInvestimento();
//calculadoraInvestimento.Calcular(new Conta(100), new InvestimentoConservador());
//calculadoraInvestimento.Calcular(new Conta(100), new InvestimentoModerado());
//calculadoraInvestimento.Calcular(new Conta(100), new InvestimentoArrojado());

// padrão Chain of Responsability: faz o ligamento entre estratégias equivalentes (como uma corrente de desconto);

//var calculadora = new CalculadoraDesconto();
var orcamento = new Orcamento(500);
orcamento.AdicionarItem(new Item("Caneta", 500));
orcamento.AdicionarItem(new Item("Lápis", 500));
orcamento.AdicionarItem(new Item("Geladeira", 500));
orcamento.AdicionarItem(new Item("Guarda-Chuva", 500));
orcamento.AdicionarItem(new Item("Teclado", 500));
orcamento.AdicionarItem(new Item("Violão", 500));

//desconto = calculadora.Calcula(orcamento);

var calculadora = new CalculadoraImposto();
calculadora.Calcular(orcamento, new Icpp());
calculadora.Calcular(orcamento, new Ickv());
//Console.WriteLine(desconto);


Console.ReadKey();
