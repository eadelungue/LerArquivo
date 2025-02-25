using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LerArquivo
{
    internal class ArquivoCSV : Arquivo
    {

        private LayoutCSV layoutCSV;

        public ArquivoCSV(string caminhoArquivo, Layout LayoutArquivo) : base(LayoutArquivo, caminhoArquivo)
        {                 
            if(LayoutArquivo is LayoutCSV)
            {
                layoutCSV = (LayoutCSV)LayoutArquivo;
            }
            else
            {
                throw new ArgumentException("Layout Inválido");
            }
        }
        
        internal override void setRegistros(int id, string? linha)
        {
            if (linha != null)
            {
                Boolean linhaCabecario = id == 0 && layoutCSV.PossuiCabecario;                
                
                if (layoutCSV.LayoutRegistros != null && !linhaCabecario)
                {
                    Registro registro = new Registro();
                    string[] campos = linha.Split(';');
                    registro.ListaCampos = new List<Campo>();

                    foreach (CampoLayout item in layoutCSV.LayoutRegistros.ListaCampos)
                    {                        
                        registro.ListaCampos.Add(new Campo(item.Nome, item.Formatar(campos[item.Ordem])));
                    }                    
                    this.RegistrosArquivo.Add(registro);
                }
            } 
        }
    }
}
