using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppEntityFramework
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Estudante> Estudantes { get; set; }
    }
}
