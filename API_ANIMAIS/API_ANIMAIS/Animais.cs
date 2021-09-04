using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ANIMAIS
{
    //Classe Animais, usada pelo programa para retornar listas de valores retirados do banco de dados
    public class Animais
    {
        public int Id_A { get; set; }
        public string Nome { get; set; }
        public string Classe { get; set; }
        public int Pes { get; set; }
        public bool Voa { get; set; }

        public Animais(int id_a, string nome, string classe, int pes, bool voa)
        {

            this.Id_A = id_a;
            this.Nome = nome;
            this.Classe = classe;
            this.Pes = pes;
            this.Voa = voa;

        }
    }
}
