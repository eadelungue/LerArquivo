using System.Linq.Expressions;

namespace LerArquivo
{
    public class LayoutPosicional : Layout
    {   
        public LayoutPosicional(int id, string mascara, string codigo, string nome, RegistroLayout registroLayout, string identificadorRegistro, RegistroLayout? registroLayoutCabecario, string identificadorCabecario, RegistroLayout? registroLayoutRodape, string identificadorRodape) : base( id,  mascara,  codigo,  nome, registroLayout)
        {
            RegistroLayoutCabecario = registroLayoutCabecario;
            RegistroLayoutRodape = registroLayoutRodape;
            IdentificadorCabecario = identificadorCabecario;
            IdentificadorRegistro = identificadorRegistro;
            IdentificadorRodape = identificadorRodape;
        }

        public RegistroLayout? RegistroLayoutCabecario { get; set; }

        public string IdentificadorCabecario { get; set; }
        public string IdentificadorRegistro { get; set; }
        public string IdentificadorRodape { get; set; }

        public RegistroLayout? ObterLayoutRegistro(string linha)
        {
            switch (linha.Substring(0, 1).ToUpper())
            {
                case "0":
                    return RegistroLayoutCabecario;                    
                case "2":
                    return RegistroLayoutRodape;                    
                default:
                    return LayoutRegistros;                    
            } 
        }
        public Boolean LinhaConteudo(string linha)
        {
            return linha.Substring(0, 1).ToUpper() == "1";            
        }

        public RegistroLayout? RegistroLayoutRodape { get; set; }


    }

   
}