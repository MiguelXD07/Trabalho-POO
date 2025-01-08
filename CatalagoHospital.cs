public class CatalagoHospital
{
    public Hospital[] Hospitais;

    public int numeroStaff;

    private int MAXFunc = 10;

    public CatalagoHospital()
    {
        this.numeroStaff = 0;
        this.Hospitais = new Hospital[MAXFunc];
    }

    public void AdicionarStaff(Hospital hospital)
    {
        Hospitais[numeroStaff] = hospital;
        this.numeroStaff++;
    }

    public void ListaStaff()
    {
        Console.WriteLine("");
        for (int i = 0; i < this.numeroStaff; i++)
        {
            Console.Write("{0}: ", i);
            System.Console.WriteLine(this.Hospitais[i]);
        }
        Console.WriteLine("");
    }

    public void RemoverStaff(int indice)
    {
        if (indice >= 0 && indice < this.numeroStaff)
        {
            for(int i = indice; i < this.numeroStaff - 1; i++)
            {
                this.Hospitais[i] = this.Hospitais[i + 1]; //shift para a esquerda

            }
            Hospitais[this.numeroStaff - 1] = null; //limpa o ultimo elemento
            this.numeroStaff--;
            System.Console.WriteLine("Staff Despedido.");
        }
        else
        {
            System.Console.WriteLine("Indice Inválido");
        }
    }

    public void PesquisarStaffPorNome(string staff)
    {
        Console.WriteLine("");
        for(int i = 0; i < this.numeroStaff; i++)
        {
            Hospital h = Hospitais[i];

            if(h.Staff.Contains(staff))
            {
                System.Console.WriteLine("" + h);
            }
            else
            {
                System.Console.WriteLine("Nome do Staff incorreto.");
            }
        }
        Console.WriteLine("");
    }

}
