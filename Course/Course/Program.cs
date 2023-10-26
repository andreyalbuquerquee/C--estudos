

using System.Globalization;

namespace Course {

    class Aluno {
        public string Name { get; set; }
        public int Grade { get; set; }
    }

    class Program {
        static void Main(string[] args) {

            List<Aluno> alunos = new List<Aluno> {
                { new Aluno { Name = "João", Grade = 8 } },
                { new Aluno { Name = "Maria", Grade = 3 } },
                { new Aluno { Name = "Pedro", Grade = 9 } },
                { new Aluno { Name = "Ana", Grade = 5 } },
                { new Aluno { Name = "Carlos", Grade = 10 } },
            };

            foreach (Aluno aluno in alunos) {
                string gradeSituation = aluno.Grade >= 6 ? "APROVADO!" : "REPROVADO!";
                Console.WriteLine($"O aluno(a) {aluno.Name} está {gradeSituation}");
            }


        }
    }
}
