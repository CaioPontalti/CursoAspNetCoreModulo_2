using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppEntityFramework
{
    public class Estudante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public bool EstaExcluido { get; set; }
        public Endereco Endereco { get; set; }
        public int TurmaId { get; set; }
        public List<EstudanteCurso> EstudantesCursos;
    }
}
