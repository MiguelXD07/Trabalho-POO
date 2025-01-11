using System.Globalization;
using System.Reflection;
using System.Security.Cryptography;
using System.Xml.Serialization;
using System.Text.Json;

Console.WriteLine("Bem-vindo ao Hospital ->Arruinado<-");

CatalagoHospital hospital = new CatalagoHospital();

int opcao;
string nome;

//Para ler para o Json
string filepath = @"C:\Users\migue\Desktop\Faculdade\P.O.O\TrabalhoDeGrupo\TrabalhoDeGrupo\Catalago.json";

//Staff ja implementada
hospital.AdicionarStaff(new Hospital("Miguel", "Medico", "Sirurgiao"));
hospital.AdicionarStaff(new Hospital("Fernando", "Medico", "Neurosirurgiao"));
hospital.AdicionarStaff(new Hospital("Ana", "Medica", "Medica de Familia"));
hospital.AdicionarStaff(new Hospital("Gabriel", "Enfermeiro", "Assitente em operacoes"));
hospital.AdicionarStaff(new Hospital("Rodrigo", "Enfermeiro", "Assitente"));
hospital.AdicionarStaff(new Hospital("Daniel", "Funcionario", "Limpezas"));
hospital.AdicionarStaff(new Hospital("Margarida", "Secretaria", "Secetariado"));

//Consultas ja implementadas
hospital.AdicionarConsulta(new ConsultasPacientes(01, "Miguel", 01));
hospital.AdicionarConsulta(new ConsultasPacientes(07, "Mario", 02));
hospital.AdicionarConsulta(new ConsultasPacientes(10, "Susana", 03));


do
{
    Console.WriteLine("Escolha uma das opções:");
    Console.WriteLine("1-Ver Staff\n2-Adicionar Staff\n3-Despedir Staff\n4-Pesquisar Staff\n5-Lista de Consultas\n6-Adicionar Consulta\n7-Grava Json\n8-Lê Json\n0-Sair");
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

        case 5:
            hospital.ListaConsultas();

            break;

        case 6:
            AdicionarConsulta();

            break;

        case 7:
            GravaCatalogo(hospital);

            break;

        case 8:
            hospital = LerCatalago();
            hospital.ListaStaff();
            hospital.ListaConsultas();

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

    Console.WriteLine("Escreva a Categoria (Medico, Enfermeiro, Secretaria, Funcionario):");
    string categorias = Console.ReadLine();

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

void PesquisarStaffPorNome()
{
    System.Console.WriteLine("Nome de um Staff: ");
    nome = Console.ReadLine();

    hospital.PesquisarStaffPorNome(nome);
}


//Funções para Consultas
void AdicionarConsulta()
{
    if (hospital.numeroConsultas < 10) //Verifica se há consultas disponíveis
    {
        hospital.ListaConsultasDisponiveis(); //Mostra as consultas disponíveis
        Console.WriteLine("Número da consulta (2 dígitos):");
        int consulta = int.Parse(Console.ReadLine());

        Console.WriteLine("Escreva o Nome do Paciente:");
        string paciente = Console.ReadLine();

        hospital.ListaCamasDisponiveis(); //Mostra as camas disponíveis
        Console.WriteLine("Insira o número da cama (2 dígitos):");
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
