using System.Text.Json;



CatalagoHospital hospital = new CatalagoHospital();

int opcao;
string nome;
float fundos = 10000;

//Para ler para o Json
string filepath = @"C:\Users\m1nij\Documents\Poo\.vscode\Fichas\Trabalho\Ficheiro.json";

//Staff ja implementada
hospital.AdicionarStaff(new Hospital("Miguel", "Medico", "Cirurgiao"));
hospital.AdicionarStaff(new Hospital("Fernando", "Medico", "Medico de Familia"));
hospital.AdicionarStaff(new Hospital("Ana", "Medico", "Medica de Familia"));
hospital.AdicionarStaff(new Hospital("Gabriel", "Enfermeiro", "Assistente em operacoes"));
hospital.AdicionarStaff(new Hospital("Rodrigo", "Enfermeiro", "Assistente"));
hospital.AdicionarStaff(new Hospital("Daniel", "Funcionario", "Limpezas"));
hospital.AdicionarStaff(new Hospital("Margarida", "Secretario", "Secetariado"));

//Consultas ja implementadas
hospital.AdicionarConsulta(new ConsultasPacientes(01, "Miguel", 01));
hospital.AdicionarConsulta(new ConsultasPacientes(02, "Mario", 02));
hospital.AdicionarConsulta(new ConsultasPacientes(03, "Susana", 03));

//loop para escolher a opção a realizar
do
{
    Console.Clear();
    Console.WriteLine("\x1b[3J");

    Console.WriteLine("Bem-vindo ao Hospital ->Arruinado<-");
    System.Console.WriteLine($"Fundos do Hospital: {fundos}\n");
    Console.WriteLine("Escolha uma das opções:");
    Console.WriteLine("1-Ver Staff\n2-Adicionar Staff\n3-Despedir Staff\n4-Pesquisar Staff\n5-Lista de Consultas\n6-Consultas Realizadas\n7-Adicionar Consulta\n8-Realizar Consulta\n9-Grava Json\n10-Lê Json\n\n0-Sair");
    opcao = int.Parse(Console.ReadLine());



    switch (opcao)
    {

        case 1:
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            hospital.ListaStaff();
            System.Console.WriteLine("Precione qualquer tecla");
            Console.ReadKey();

            break;

        case 2:
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            AdicionarStaff();
            System.Console.WriteLine("Precione qualquer tecla");
            Console.ReadKey();

            break;

        case 3:
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            RemoverStaff();
            System.Console.WriteLine("Precione qualquer tecla");
            Console.ReadKey();

            break;

        case 4:
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            PesquisarStaffPorCategoria();
            System.Console.WriteLine("Precione qualquer tecla");
            Console.ReadKey();

            break;

        case 5:
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            hospital.ListaConsultas();
            System.Console.WriteLine("Precione qualquer tecla");
            Console.ReadKey();

            break;

        case 6:
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            hospital.ListaConsultasRealizadas();
            System.Console.WriteLine("Precione qualquer tecla");
            Console.ReadKey();

            break;

        case 7:
            Console.Clear();
            AdicionarConsulta();
            System.Console.WriteLine("Precione qualquer tecla");
            Console.ReadKey();

            break;

        case 8:
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            RemoverConsultas();
            System.Console.WriteLine("Precione qualquer tecla");
            Console.ReadKey();


            break;

        case 9:
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            GravaCatalogo(hospital);
            System.Console.WriteLine("Precione qualquer tecla");
            Console.ReadKey();


            break;

        case 10:
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            hospital = LerCatalago();
            hospital.ListaStaff();
            hospital.ListaConsultas();
            hospital.ListaConsultasRealizadas();
            System.Console.WriteLine("Precione qualquer tecla");
            Console.ReadKey();

            break;


        case 0:
            Console.WriteLine("Adeus");
            break;
    }
} while (opcao != 0);

//Funções para Staff
void AdicionarStaff()
{
    Console.WriteLine("Escreva o Nome:");
    string nome = Console.ReadLine();

    nome = CapitalizarPrimeiraLetra(nome);

    Console.WriteLine("Escreva a Categoria (Medico, Enfermeiro, Secretaria, Funcionario):");
    string categorias = Console.ReadLine();

    categorias = CapitalizarPrimeiraLetra(categorias);

    Console.WriteLine("Escreva a Especialidade:");
    string especialidades = Console.ReadLine();

    Hospital hospital1 = new Hospital(nome, categorias, especialidades);
    hospital.AdicionarStaff(hospital1);
}

void RemoverStaff()
{
    //1.Lista Staff
    hospital.ListaStaff();

    //2.Staff a Remover(numero)
    System.Console.WriteLine("Staff a Despedir: ");
    int indice = int.Parse(Console.ReadLine());

    //3.Remover Staff
    hospital.RemoverStaff(indice);
}

void PesquisarStaffPorCategoria()
{
    System.Console.WriteLine("Categoria de um Staff (Letra inicial Maiúscula): ");
    nome = Console.ReadLine();

    nome = CapitalizarPrimeiraLetra(nome);

    hospital.PesquisarStaffPorCategoria(nome);
}



//Funções para Consultas
void AdicionarConsulta()
{
    if (hospital.numeroConsultas < 10) //Verifica se há consultas disponíveis
    {
        hospital.ListaConsultasDisponiveis(); //Mostra as consultas disponíveis
        Console.WriteLine("Número da consulta:");
        int consulta = int.Parse(Console.ReadLine());

        Console.WriteLine("Escreva o Nome do Paciente:");
        string paciente = Console.ReadLine();

        hospital.ListaCamasDisponiveis(); //Mostra as camas disponíveis
        Console.WriteLine("Insira o número da cama:");
        int cama = int.Parse(Console.ReadLine());

        if (hospital.camasDisponiveis.Contains(cama)) //Verifica se a cama está disponível
        {
            if (hospital.consultasDisponiveis.Contains(consulta)) //Verifica se a consulta está disponível
            {
                ConsultasPacientes consultas1 = new ConsultasPacientes(consulta, paciente, cama);
                hospital.AdicionarConsulta(consultas1);
            }
            else
            {
                Console.WriteLine("Número da consulta já utilizado. Por favor, escolha outra consulta.");
            }
        }
        else
        {
            Console.WriteLine("Cama indisponível. Por favor, escolha outra cama.");
        }
    }
    else
    {
        Console.WriteLine("Lista de consultas cheio.");
    }
}

void RemoverConsultas()
{
    // Lista Consultas
    hospital.ListaConsultas();

    //Consulta a remover (número)
    System.Console.WriteLine("Consulta a realizar: ");
    int indice = int.Parse(Console.ReadLine());

    //Verifica se o índice é válido
    if (indice >= 0 && indice < hospital.numeroConsultas)
    {
        //Consulta a ser removida
        ConsultasPacientes consultaRemover = hospital.Consultas[indice];

        //Exibe os detalhes da consulta
        Console.WriteLine($"Paciente: {consultaRemover.Paciente}, Cama: {consultaRemover.Cama}");

        //Cria um objeto Detalhes e preenche com as informações da consulta removida
        Detalhes detalhes = new Detalhes();
        Random random = new Random();
        int number = random.Next(1, 7); //Gera um número entre 1 e 6

        switch (number)
        {
            case 1:
                detalhes.Preco = 3000;
                detalhes.Exame = "Cancro";
                detalhes.Diagnostico = "Quimioterapia";
                break;

            case 2:
                detalhes.Preco = 500;
                detalhes.Exame = "Epilepsia";
                detalhes.Diagnostico = "Medicamentos anti epileptiocos";
                break;

            case 3:
                detalhes.Preco = 4000;
                detalhes.Exame = "Leucemia";
                detalhes.Diagnostico = "Radioterapia";
                break;

            case 4:
                detalhes.Preco = 300;
                detalhes.Exame = "Diabetes";
                detalhes.Diagnostico = "Exame ao Sangue";
                break;

            case 5:
                detalhes.Preco = 500;
                detalhes.Exame = "Perna Partida";
                detalhes.Diagnostico = "Fisioterapia";
                break;

            case 6:
                detalhes.Preco = 200;
                detalhes.Exame = "Infeção urinária";
                detalhes.Diagnostico = "Medicação anti infeção";
                break;

            default:
                Console.WriteLine("Opção inválida.");
                break;
        }

        // Exibe os detalhes da consulta removida
        Console.WriteLine(detalhes.ToString());

        fundos = fundos + detalhes.Preco;

        // Remove a consulta
        hospital.RemoverConsultas(indice);
    }
    else
    {
        System.Console.WriteLine("Índice Inválido");
    }
}



//Ficheiro Json
void GravaCatalogo(CatalagoHospital catalago)
{
    var option = new JsonSerializerOptions { WriteIndented = true };
    string conteudo = JsonSerializer.Serialize(catalago, option);
    File.WriteAllText(filepath, conteudo);
    Console.WriteLine("Ficheiro Guardado com Êxito");
    Console.WriteLine("");
}

CatalagoHospital LerCatalago()
{
    string conteudo = File.ReadAllText(filepath);
    return JsonSerializer.Deserialize<CatalagoHospital>(conteudo);
}

string CapitalizarPrimeiraLetra(string str)//função para fazer a primeira letra maiuscula
{
    if (string.IsNullOrEmpty(str))
        return str;

    return char.ToUpper(str[0]) + str.Substring(1).ToLower();
}
