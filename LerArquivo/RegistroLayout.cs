using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LerArquivo
{
    public class RegistroLayout
    {
        private IList<CampoLayout>  listaCampos;       
        public RegistroLayout(IList<CampoLayout> campoLayout)
        {
            listaCampos = campoLayout;
        }
        public IList<CampoLayout> ListaCampos { get { return listaCampos; } set { listaCampos = value; } }
    }
}
