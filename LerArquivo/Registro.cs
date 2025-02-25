using System.Text;

namespace LerArquivo
{

    public class Registro
    {
        private IList<Campo> listaCampos;
        public Registro()
        {
            listaCampos = new List<Campo>();
        }
        public virtual IList<Campo> ListaCampos { get { return listaCampos; } set { listaCampos = value; } }

        public override string ToString()
        {
            StringBuilder sb = new();

            foreach (var item in ListaCampos)
            {
                sb.Append(item.ToString());
            }

            return sb.ToString();
        }
    }
}