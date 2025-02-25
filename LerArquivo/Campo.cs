using System.ComponentModel.Design;
using System.Globalization;

namespace LerArquivo
{
    public class Campo
    {       
        public string Nome { get; set; }
        
        public object? Valor { get; set; }

        public override string ToString()
        {
            return string.Format("{0}:{1}\n",Nome, Valor);
        }

    }
}