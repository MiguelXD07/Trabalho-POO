using System.Text.Json.Serialization;

//Para a Staff
public class Hospital
{
    public string Nome { get; set; }
    public string Categorias { get; set; }
    public string Especialidades { get; set; }

    //Construtor padrão necessário para deserialização
    public Hospital() { }

    public Hospital(string nome, string categorias, string especialidades)
    {
        this.Nome = nome;
        this.Categorias = categorias;
        this.Especialidades = especialidades;
    }

    override public string ToString()
    {
        return "Staff: " + Nome + ", Categoria: " + Categorias + ", Especialidade: " + Especialidades;
    }
}

//Para Consultas e Pacientes
public class ConsultasPacientes
{
    public int Consulta { get; set; }
    public string Paciente { get; set; }
    public int Cama { get; set; }

    //Construtor padrão necessário para deserialização
    public ConsultasPacientes() { }

    public ConsultasPacientes(int consulta, string paciente, int camas)
    {
        this.Consulta = consulta;
        this.Paciente = paciente;
        this.Cama = camas;
    }

    override public string ToString()
    {
        return "Consulta:  0" + Consulta + ", Paciente: " + Paciente + ", Cama: 0" + Cama;
    }
}
