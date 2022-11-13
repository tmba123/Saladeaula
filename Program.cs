var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Saladeaula sala = new Saladeaula("A",1,3);

app.MapGet("/", () => sala.listar());
//app.MapGet("/entrar/{naluno}", (string naluno) => sala.entrar(new Aluno(naluno)));
app.MapGet("/entrar/{naluno}/{nome}", (string naluno, string nome ) => sala.entrar(new Aluno(naluno,nome)));
//app.MapGet("/sair/{matricula}", (string matricula) => parque.sair(matricula));
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
            return "Sala completo";
        }
    }
    
    
    /*
    //Sair um carro no parque
    public String sair(String matricula)
    {
        Carro toRemove = null;

        foreach (Carro car in estacionados)
        {
            if (car.matricula.Equals(matricula))
            {
                toRemove = car;
                break;
            }
        }

        if (toRemove != null)
        {
            estacionados.Remove(toRemove);
            return $"O carro {toRemove.matricula} saiu do parque.";
        }
        else
        {
            return "O carro não se encontra no parque.";
        }
    }

    */
}