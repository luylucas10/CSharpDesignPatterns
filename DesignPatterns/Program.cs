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
//var orcamento = new Orcamento(500);
//orcamento.AdicionarItem(new Item("Caneta", 500));
//orcamento.AdicionarItem(new Item("Lápis", 500));
//orcamento.AdicionarItem(new Item("Geladeira", 500));
//orcamento.AdicionarItem(new Item("Guarda-Chuva", 500));
//orcamento.AdicionarItem(new Item("Teclado", 500));
//orcamento.AdicionarItem(new Item("Violão", 500));

//desconto = calculadora.Calcula(orcamento);

//var calculadora = new CalculadoraImposto();
//calculadora.Calcular(orcamento, new Icpp(new Iss()));
//calculadora.Calcular(orcamento, new Ikcv());
//Console.WriteLine(desconto);

//Orcamento reforma = new(500.0);

//reforma.AplicaDescontoExtra();
//Console.WriteLine(reforma.Valor); // imprime 475,00 pois descontou 5%
//reforma.Aprova(); // aprova nota!

//reforma.AplicaDescontoExtra();
//reforma.AplicaDescontoExtra();
//Console.WriteLine(reforma.Valor); // imprime 465,50 pois descontou 2%

//reforma.Finaliza();

//reforma.AplicaDescontoExtra(); //lancaria excecao, pois não pode dar desconto nesse estado
//reforma.Aprova();// lança exceção, pois não pode ir para aprovado

Conta c = new Conta("Luy", 300);
Console.WriteLine(c.Saldo);
Console.WriteLine(c.Sacar(400));
Console.WriteLine(c.Saldo);
c.Depositar(500);
Console.WriteLine(c.Saldo);
Console.ReadKey();
