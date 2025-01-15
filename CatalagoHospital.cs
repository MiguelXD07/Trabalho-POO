using System.Diagnostics;
using System.Text.Json.Serialization;

public class CatalagoHospital
{
    //Staff
    public Hospital[] Staff { get; set; }
    public int numeroStaff { get; set; }
    private int MAXFunc = 20;

    //Consultas e Camas
    public ConsultasPacientes[] Consultas { get; set; }
    public int numeroConsultas { get; set; }
    public List<int> consultasDisponiveis { get; set; } //Lista para armazenar consultas disponíveis
    private int MAXConsultas = 20;

    public int numeroCamas { get; set; }
    public List<int> camasDisponiveis { get; set; } //Lista para armazenar camas disponíveis
    private int MAXCamas = 20;

    public int numeroConsultasRealizadas { get; set; }
    public List<ConsultasPacientes> ConsultasRealizadas { get; set; }   //Nova lista para armazenar consultas realizadas
    private int MAXConsultRealizadas = 100;


    public CatalagoHospital()
    {
        this.numeroStaff = 0;
        this.Staff = new Hospital[MAXFunc];

        this.numeroConsultas = 0;
        this.Consultas = new ConsultasPacientes[MAXConsultas];

        this.numeroCamas = 0;
        this.camasDisponiveis = new List<int>(); //Inicializa a lista de camas disponíveis
        this.consultasDisponiveis = new List<int>(); //Inicializa a lista de consultas disponíveis

        this.numeroConsultasRealizadas = 0;
        this.ConsultasRealizadas = new List<ConsultasPacientes>(); // Inicializa a lista de consultas realizadas

        //Preenche a lista de camas disponíveis
        for (int i = 1; i <= MAXCamas; i++)
        {
            camasDisponiveis.Add(i); //Adiciona camas de 1 a 10
        }

        // Preenche a lista de consultas disponíveis
        for (int i = 1; i <= MAXConsultas; i++)
        {
            consultasDisponiveis.Add(i); //Adiciona consultas de 1 a 10
        }

    }


    //STAFF
    public void AdicionarStaff(Hospital hospital)
    {
        Staff[numeroStaff] = hospital;
        this.numeroStaff++;
    }

    public void ListaStaff()
    {
        Console.WriteLine("");
        Console.WriteLine("Staff Contratada:");
        Console.WriteLine("");
        for (int i = 0; i < this.numeroStaff; i++)
        {
            Console.Write("{0}: ", i);
            System.Console.WriteLine(this.Staff[i]);
        }
        Console.WriteLine("");
    }

    public void RemoverStaff(int indice)
    {
        if (indice >= 0 && indice < this.numeroStaff)
        {
            for (int i = indice; i < this.numeroStaff - 1; i++)
            {
                this.Staff[i] = this.Staff[i + 1]; //shift para a esquerda

            }
            Staff[this.numeroStaff - 1] = null; //limpa o ultimo elemento
            this.numeroStaff--;
            System.Console.WriteLine("Staff Despedido.");
        }
        else
        {
            System.Console.WriteLine("Indice Inválido");
        }
    }

    public void PesquisarStaffPorCategoria(string nome)
    {
        Console.WriteLine("");
        for (int i = 0; i < this.numeroStaff; i++)
        {
            Hospital h = Staff[i];

            if (h.Categorias.Contains(nome))
            {
                System.Console.WriteLine("" + h);
            }
            else
            {
                System.Console.WriteLine("Categoria do Staff incorreto.");
            }
        }
        Console.WriteLine("");
    }


    //CONSULTAS E PACIENTES
    public void AdicionarConsulta(ConsultasPacientes consultas)
    {
        if (numeroConsultas < MAXConsultas)
        {
            Consultas[numeroConsultas] = consultas;
            this.numeroConsultas++;
            this.numeroCamas++;
            camasDisponiveis.Remove(consultas.Cama); //Remove a cama da lista de disponíveis
            consultasDisponiveis.Remove(consultas.Consulta); //Remove a consulta da lista de disponíveis
        }
        else
        {
            Console.WriteLine("Não há consultas disponíveis.");
        }
    }

    //Camas e consultas disponiveis
    public void ListaCamasDisponiveis()
    {
        Console.WriteLine("Camas disponíveis: " + string.Join(", ", camasDisponiveis));
    }
    public void ListaConsultasDisponiveis()
    {
        Console.WriteLine("Consultas disponíveis: " + string.Join(", ", consultasDisponiveis));
    }


    public void ListaConsultas()
    {
        Console.WriteLine("");
        Console.WriteLine("Consultas Marcadas: ");
        Console.WriteLine("");
        for (int i = 0; i < this.numeroConsultas; i++)
        {
            Console.Write("{0}: ", i);
            System.Console.WriteLine(this.Consultas[i]);
        }
        Console.WriteLine("");
    }

    public void RemoverConsultas(int indice)
    {
        if (indice >= 0 && indice < this.numeroConsultas)
        {
            //Adiciona a consulta removida à lista de consultas realizadas
            ConsultasRealizadas.Add(Consultas[indice]); //Adiciona a consulta removida

            // Reinserir a cama e a consulta nas listas de disponíveis
            camasDisponiveis.Add(Consultas[indice].Cama); //Adiciona a cama de volta à lista de disponíveis
            consultasDisponiveis.Add(Consultas[indice].Consulta); //Adiciona a consulta de volta à lista de disponíveis

            for (int i = indice; i < this.numeroConsultas - 1; i++)
            {
                this.Consultas[i] = this.Consultas[i + 1]; //Shift para a esquerda
            }
            Consultas[this.numeroConsultas - 1] = null; //Limpa o último elemento
            this.numeroConsultas--;
            this.numeroCamas--;
            this.numeroConsultasRealizadas++;
            System.Console.WriteLine("Consulta Realizada.");
            Console.WriteLine("");
        }
        else
        {
            System.Console.WriteLine("Índice Inválido");
        }
    }

    public void ListaConsultasRealizadas()
    {
        Console.WriteLine("");
        Console.WriteLine("Consultas Realizadas: ");
        Console.WriteLine("");
        for (int i = 0; i < this.ConsultasRealizadas.Count; i++)
        {
            Console.Write("{0}: ", i);
            System.Console.WriteLine(this.ConsultasRealizadas[i]);
        }
        Console.WriteLine("");
    }
}
