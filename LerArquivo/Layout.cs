namespace LerArquivo
{
    public class Layout
    {   
        public Layout(int id, string mascara, string codigo, string nome, RegistroLayout registroLayout) 
        {
            Id = id;
            Mascara = mascara;
            Codigo = codigo;
            Nome = nome;    
            LayoutRegistros = registroLayout; 
        }

        public int Id { get; set; }
        public string Mascara { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public RegistroLayout LayoutRegistros { get; set; }
        
    }

   
}