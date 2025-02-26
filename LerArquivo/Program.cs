// See https://aka.ms/new-console-template for more information
using LerArquivo;

internal class Program
{
    private static void Main(string[] args)
    {

        string pasta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"ArquivoTeste");

        if (args !=null && args.Length > 0) 
        {
            pasta = args[0];
        }
        
        IList<Layout> listaLayout = new List<Layout>();

        //csv        
        IList<CampoLayout> campos = new List<CampoLayout>();
        campos.Add(new CampoLayout() { Ordem = 0, Tipo = CampoLayout.TipoCampo.Inteiro, Nome = "Id" });
        campos.Add(new CampoLayout() { Ordem = 1, Tipo = CampoLayout.TipoCampo.Inteiro, Nome = "Pedido" });
        campos.Add(new CampoLayout() { Ordem = 2, Tipo = CampoLayout.TipoCampo.Data, Nome = "Data", Formato = "dd/MM/yyyy" });
        campos.Add(new CampoLayout() { Ordem = 3, Tipo = CampoLayout.TipoCampo.Texto, Nome = "Categoria" });
        campos.Add(new CampoLayout() { Ordem = 4, Tipo = CampoLayout.TipoCampo.Decimal, Nome = "Valor" });

        RegistroLayout layoutRegistro = new RegistroLayout(campos);

        listaLayout.Add(new LayoutCSV(1, "*Bahia*.csv", "CSB", "Casas Bhaia CSV", layoutRegistro, true));

        //posicinal
        IList<CampoLayout> camposPos = new List<CampoLayout>();
        camposPos.Add(new CampoLayout() { PosicaoInicial = 0, QuantidadeCaracteres = 1, Tipo = CampoLayout.TipoCampo.Inteiro, Nome = "IdentitificadorRegistro" });
        camposPos.Add(new CampoLayout() { PosicaoInicial = 1, QuantidadeCaracteres = 12, Tipo = CampoLayout.TipoCampo.Inteiro, Nome = "Pedido" });
        camposPos.Add(new CampoLayout() { PosicaoInicial = 11, QuantidadeCaracteres = 8, Tipo = CampoLayout.TipoCampo.Data, Nome = "Data", Formato = "ddMMyyyy" });
        camposPos.Add(new CampoLayout() { PosicaoInicial = 19, QuantidadeCaracteres = 28, Tipo = CampoLayout.TipoCampo.Texto, Nome = "Categoria" });
        camposPos.Add(new CampoLayout() { PosicaoInicial = 47, QuantidadeCaracteres = 13, Tipo = CampoLayout.TipoCampo.Decimal, Nome = "Valor" });

        RegistroLayout layoutRegistroPos = new RegistroLayout(camposPos);

        listaLayout.Add(new LayoutPosicional(1, "*Amazon*.txt", "AMZ", "Arquivo amazon posicional", layoutRegistroPos,"1",null,"0", null,"2"));

        foreach (var itemLayout in listaLayout)
        {
            string[] aquivos =  Directory.GetFiles(pasta, itemLayout.Mascara);

            foreach (var arquivo in aquivos)
            {
                Arquivo arq;

                if (itemLayout is LayoutCSV)
                {
                    arq = new ArquivoCSV(arquivo, itemLayout);                    
                }
                else
                {
                    arq = new ArquivoPosicional(arquivo, itemLayout);                    
                }

                arq.Ler();
                Console.WriteLine(arq.ToString());
                if (arq.RegistrosArquivo != null && arq.RegistrosArquivo.Count() > 0)
                    foreach (var item in arq.RegistrosArquivo)
                    {
                        Console.WriteLine(item.ToString());
                    }
            }
        }
    }
}