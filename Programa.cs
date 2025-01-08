Console.WriteLine("Bem-vindo ao Hospital ->Arruinado<-");

CatalagoHospital hospital = new CatalagoHospital();
int opcao;
string nome;


hospital.AdicionarStaff(new Hospital("Miguel", "Medico", "Sirurgiao"));
hospital.AdicionarStaff(new Hospital("Fernando", "Medico", "Neurosirurgiao"));
hospital.AdicionarStaff(new Hospital("Ana", "Medica", "Medica de Familia"));
hospital.AdicionarStaff(new Hospital("Gabriel", "Enfermeiro", "Assitente em operacoes"));
hospital.AdicionarStaff(new Hospital("Rodrigo", "Enfermeiro", "Assitente"));
hospital.AdicionarStaff(new Hospital("Daniel", "Funcionario", "Limpezas"));
hospital.AdicionarStaff(new Hospital("Margarida", "Secretaria", "Secetariado"));

do
{
    Console.WriteLine("Escolha uma das opções:");
    Console.WriteLine("1-Ver Staff\n2-Adicionar Staff\n3-Despedir Staff\n4-Pesquisar Staff\n0-Sair");
    opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 1:
            hospital.ListaStaff();
            break;

        case 2:
            AdicionarStaff();
            break;

        case 3:
            RemoverStaff();
            break;

        case 4:
            PesquisarStaffPorNome();
            break;
        case 0:
            Console.WriteLine("Adeus");
            break;
    }
} while (opcao != 0);


void AdicionarStaff()
{
    Console.WriteLine("Escreva o Nome:");
    string staff = Console.ReadLine();

    Console.WriteLine("Escreva a Categoria (Medico, Enfermeiro, Secretaria, Funcionario):");
    string categorias = Console.ReadLine();

    Console.WriteLine("Escreva a Especialidade:");
    string especialidades = Console.ReadLine();

    Hospital hospital1 = new Hospital(staff, categorias, especialidades);
    hospital.AdicionarStaff(hospital1);
}

void RemoverStaff()
{
    //1. Lista Livros
    hospital.ListaStaff();

    //2. Livro a remover (numero)
    System.Console.WriteLine("Staff a Despedir: ");
    int indice = int.Parse(Console.ReadLine());

    //3. Remover livro
    hospital.RemoverStaff(indice);
}

void PesquisarStaffPorNome()
{
    System.Console.WriteLine("Nome de um Staff: ");
    nome = Console.ReadLine();

    hospital.PesquisarStaffPorNome(nome);
}
