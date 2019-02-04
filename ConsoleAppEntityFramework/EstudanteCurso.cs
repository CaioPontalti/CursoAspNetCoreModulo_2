using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppEntityFramework
{
    public class EstudanteCurso
    {
        public int EstudanteId { get; set; }
        public int CursoId { get; set; }
        public bool Ativo { get; set; }
        public Estudante Estudante { get; set; }
        public Curso Curso { get; set; }
    }
}
