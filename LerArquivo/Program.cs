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
                
        IList<CampoLayout> campos = new List<CampoLayout>();
        campos.Add(new CampoLayout() { Ordem = 0, Tipo = CampoLayout.TipoCampo.Inteiro, Nome = "Id" });
        campos.Add(new CampoLayout() { Ordem = 1, Tipo = CampoLayout.TipoCampo.Inteiro, Nome = "Pedido" });
        campos.Add(new CampoLayout() { Ordem = 2, Tipo = CampoLayout.TipoCampo.Data, Nome = "Data", Formato = "dd/MM/yyyy" });
        campos.Add(new CampoLayout() { Ordem = 3, Tipo = CampoLayout.TipoCampo.Texto, Nome = "Categoria" });
        campos.Add(new CampoLayout() { Ordem = 4, Tipo = CampoLayout.TipoCampo.Decimal, Nome = "Valor" });

        RegistroLayout layoutRegistro = new RegistroLayout(campos);

        listaLayout.Add(new LayoutCSV(1, "*Bahia*.csv", "CSB", "Casas Bhaia CSV", layoutRegistro, true));


        foreach (var itemLayout in listaLayout)
        {
            string[] aquivos =  Directory.GetFiles(pasta, itemLayout.Mascara);

            foreach (var arquivo in aquivos)
            {
                if (itemLayout is LayoutCSV)
                {
                    ArquivoCSV csv = new ArquivoCSV(arquivo, itemLayout);
                    csv.Ler();
                    Console.WriteLine(csv.ToString());
                    if (csv.RegistrosArquivo != null && csv.RegistrosArquivo.Count() > 0)
                        foreach (var item in csv.RegistrosArquivo)
                        {
                            Console.WriteLine(item.ToString());
                        }
                }
            }
        }
    }
}