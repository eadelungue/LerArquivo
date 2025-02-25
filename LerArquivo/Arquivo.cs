using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LerArquivo
{
    internal class Arquivo
    {
        private Layout layout;
        public Guid Identificador { get; set; }
        public Layout LayoutArquivo { get { return layout; } }
        public string Nome 
        {
            get
            {
                return Path.GetFileName(CaminhoCompleto);
            }
        }
        public string Diretorio
        {
            get
            {                
                return Path.GetDirectoryName(CaminhoCompleto);
            }
        }
        public string CaminhoCompleto { get; }
        public IList<Registro> RegistrosArquivo { get; set; }
        
        public Arquivo(Layout layoutArquivo, string caminhoCompleto) : this(Guid.NewGuid(), layoutArquivo, caminhoCompleto) { }
        
        public Arquivo(Guid identificador, Layout layoutArquivo, string caminhoCompleto)
        {
            if (string.IsNullOrEmpty(caminhoCompleto))
                throw new ArgumentNullException("Caminho não informado");

            if (!Path.Exists(caminhoCompleto))            
                throw new Exception("Arquivo inexixatente");            

            Identificador = identificador;
            CaminhoCompleto = caminhoCompleto;
            layout = layoutArquivo;
            RegistrosArquivo = new List<Registro>();
        }

        public void Ler()
        {
            int id = 0;
            using (StreamReader sr = new StreamReader(this.CaminhoCompleto))
            {
                while (sr.Peek() >= 0)
                {
                    setRegistros(id++, sr.ReadLine());
                }
            };

        }
        internal virtual void setRegistros(int id, string? linha) { }

        public override string ToString()
        {            
            return string.Format("Nome: {0}, Diretorio: {1}, Quantidade de Registros: {2}, Identificador: {3}", Nome,Diretorio,RegistrosArquivo.Count,Identificador);
        }
    }
}
