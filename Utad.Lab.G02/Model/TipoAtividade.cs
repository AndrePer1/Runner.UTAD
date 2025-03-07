using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utad.Lab.G02.Model
{
    public class TipoAtividade : Tipo
    {
        public TipoAtividade()
        {
            id = 00;
            nome = "";

        }

        public TipoAtividade(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

    }
}
