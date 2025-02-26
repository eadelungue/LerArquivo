using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LerArquivo
{
    internal class ArquivoPosicional : Arquivo
    {

        private LayoutPosicional layoutPosicional;

        public ArquivoPosicional(string caminhoArquivo, Layout LayoutArquivo) : base(LayoutArquivo, caminhoArquivo)
        {                 
            if(LayoutArquivo is LayoutPosicional)
            {
                layoutPosicional = (LayoutPosicional)LayoutArquivo;
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
                if (layoutPosicional.LayoutRegistros != null && layoutPosicional.LinhaConteudo(linha))
                {
                    Registro registro = new Registro();
                    
                    registro.ListaCampos = new List<Campo>();

                    foreach (CampoLayout item in layoutPosicional.LayoutRegistros.ListaCampos)
                    {                        
                        registro.ListaCampos.Add(new Campo(item.Nome, item.Formatar(item.ObterTextoPosicional(linha))));
                    }                    
                    this.RegistrosArquivo.Add(registro);
                }
            } 
        }
    }
}
