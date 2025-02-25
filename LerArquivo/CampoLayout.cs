using System.ComponentModel.Design;
using System.Globalization;

namespace LerArquivo
{
    public class CampoLayout: Campo
    {

        public CampoLayout(string nome, object? valor) : base(nome, valor)
        {   
                   
        }
        public CampoLayout(): base()
        {
           
        }

        public enum TipoCampo
        {
            Texto = 1,
            Inteiro = 2,
            Decimal = 3,
            Data = 4
        }
        public int Ordem { get; set; }
        public string Descricao { get; set; }
        public TipoCampo Tipo  { get; set; }
        public string Formato { get; set; }

        public object Formatar(string valor)
        {
            if (Tipo == TipoCampo.Data)
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                DateTime? data= DateTime.ParseExact(valor, Formato, provider);
                return data;
            }
            else if (Tipo == TipoCampo.Inteiro)
            {                
                int? data = int.Parse(valor);
                return data;
            }
            else if (Tipo == TipoCampo.Decimal)
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                decimal? data = decimal.Parse(valor, provider);
                return data;
            }
            else
            {
                return valor;
            }
        }

    }
}