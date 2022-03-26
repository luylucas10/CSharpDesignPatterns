using DesignPatterns;

// padrão Strategy: separar o comportamento comum e usar a abstração;
//var calculadora = new CalculadorImposto();
//calculadora.RealizaCalculo(new Orcamento(500), new Icms());
//calculadora.RealizaCalculo(new Orcamento(500), new Iss());
//calculadora.RealizaCalculo(new Orcamento(900), new Iccc());
//calculadora.RealizaCalculo(new Orcamento(2000), new Iccc());
//calculadora.RealizaCalculo(new Orcamento(5000), new Iccc());

var calculadoraInvestimento = new CalculadoraInvestimento();
calculadoraInvestimento.Calcular(new Conta(100), new InvestimentoConservador());
calculadoraInvestimento.Calcular(new Conta(100), new InvestimentoModerado());
calculadoraInvestimento.Calcular(new Conta(100), new InvestimentoArrojado());
Console.ReadKey();
