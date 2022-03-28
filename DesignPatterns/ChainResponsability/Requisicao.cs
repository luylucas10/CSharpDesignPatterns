namespace DesignPatterns.ChainResponsability
{
    public enum Formato
    {
        XML, CSV, PORCENTO
    }

    public interface IFormato
    {
        IFormato Proximo { get; set; }
        string FormatarConta(Conta conta, Formato formato);
    }

    public class XmlFormato : IFormato
    {
        public IFormato Proximo { get; set; }

        public XmlFormato(IFormato proximo)
        {
            Proximo = proximo;
        }

        public string FormatarConta(Conta conta, Formato formato)
        {
            return formato == Formato.XML ? $@"<conta><agencia>{conta.Agencia}</agencia><numero>{conta.Numero}</numero></conta>" : Proximo?.FormatarConta(conta, formato) ?? "";
        }
    }

    public class CsvFormato : IFormato
    {
        public CsvFormato(IFormato proximo)
        {
            Proximo = proximo;
        }

        public IFormato Proximo { get; set; }

        public string FormatarConta(Conta conta, Formato formato)
        {
            return formato == Formato.CSV ? $@"{conta.Agencia}, {conta.Numero}" : Proximo?.FormatarConta(conta, formato) ?? "";
        }
    }

    public class ProcentagemFormato : IFormato
    {
        public ProcentagemFormato(IFormato proximo)
        {
            Proximo = proximo;
        }

        public IFormato Proximo { get; set; }

        public string FormatarConta(Conta conta, Formato formato)
        {
            return formato == Formato.CSV ? $@"%agencia%{conta.Agencia}%numero%{conta.Numero}%" : Proximo?.FormatarConta(conta, formato) ?? "";
        }
    }

    public class SemFormato : IFormato
    {
        public IFormato Proximo { get; set; }

        public string FormatarConta(Conta conta, Formato formato) => conta?.ToString() ?? "";
    }

    public class Requisicao
    {
        public Formato Formato { get; private set; }

        public Requisicao(Formato formato)
        {
            Formato = formato;
        }

        public string FormatarConta(Conta conta)
        {
            var formatador = new CsvFormato(new XmlFormato(new ProcentagemFormato(new SemFormato())));
            return formatador.FormatarConta(conta, Formato);
        }
    }
}
