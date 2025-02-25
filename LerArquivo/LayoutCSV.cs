namespace LerArquivo
{
    public class LayoutCSV: Layout
    {   
        public LayoutCSV(int id, string mascara, string codigo, string nome, RegistroLayout registroLayout, Boolean possuiCabecario) : base( id,  mascara,  codigo,  nome, registroLayout)
        {
            PossuiCabecario = possuiCabecario;           
        }

        public Boolean PossuiCabecario { get; set; }

        
    }

   
}