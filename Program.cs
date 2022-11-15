var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Saladeaula sala = new Saladeaula("A",1,2);

app.MapGet("/", () => sala.listar());
app.MapGet("/entrar/{naluno}/{nome}", (string naluno, string nome ) => sala.entrar(new Aluno(naluno,nome)));
app.MapGet("/sair/{naluno}", (string naluno) => sala.sair(naluno));
app.Run();


class Aluno
{
    public String naluno;
    public String nome;

    public Aluno(String naluno, String nome)
    {
        this.naluno = naluno;
        this.nome = nome;
    }
}

class Saladeaula
{
    //Lista dinâmica (Não precisa de tamanho)
    List<Aluno> emsala = new List<Aluno>();
    public String letra;
    int bloco;
    int capacidade;

    //Constructor
    public Saladeaula (String letra, int bloco, int capacidade)
    {
        this.letra = letra;
        this.bloco = bloco;
        this.capacidade = capacidade;
    }

    public String listar()
    {
        String alunos = "Em Sala:\n";

        foreach (Aluno al in emsala)
        {
            alunos += "Nome: " + al.nome + " Nº: " + al.naluno +  "\n";
        }

        return alunos;

    }
    
    public String entrar(Aluno al)
    {
        //Ver se existe lugar
        if (emsala.Count < capacidade)
        {
            emsala.Add(al);
            return $"O Aluno {al.nome} Nº{al.naluno} entrou na sala.";
        }
        else
        {
            return "Sala completa";
        }
    }

    
    //Sair um carro no parque
    public String sair(String naluno)
    {
        Aluno toRemove = null;

        foreach (Aluno al in emsala)
        {
            if (al.naluno.Equals(naluno))
            {
                toRemove = al;
                break;
            }
        }

        if (toRemove != null)
        {
            emsala.Remove(toRemove);
            return $"O Aluno {toRemove.naluno} saiu da sala.";
        }
        else
        {
            return "O Aluno não se encontra na sala.";
        }
    } 
}
