using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Utad.Lab.G02.Model
{
    public class GestorAtividade
    {
        private List<Atividade> listAtividade;

        //Delegates, poderiam ter sidos declarados num outro ficheiro à parte
        public delegate void aceitarAtividade(Atividade at);
        public delegate void Valida(string mensagem);
        public delegate void Sucesso(string mensagem);
        //Eventos
        public event aceitarAtividade atividade_adicionada;
        public event Valida Dados;
        public event Sucesso Suc;

        public void AtividadeAdd (Atividade atividade)
        {
                atividade_adicionada(atividade);
                Suc("Atividade registada com sucesso");
        }

        public void AtividadeAddLoaded (Atividade atividade)
        {
                atividade_adicionada(atividade);
        }

        public List<Atividade> ListAtividade
        {
            get => listAtividade;
            set => listAtividade = value;
        }

        public GestorAtividade() 
        { 
            listAtividade = new List<Atividade>();
        }

     
    }
}
