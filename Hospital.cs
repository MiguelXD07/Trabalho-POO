public class Hospital
{
    public string Staff;

    public string Categorias;

    public string Especialidades;



    public Hospital(string staff, string categorias, string especialidades)
    {
        this.Staff = staff;
        this.Categorias = categorias;
        this.Especialidades = especialidades;
    }
    override public string ToString()
    {
        return "Staff: " + Staff + ", Categoria: " + Categorias + ", Especialidade: " + Especialidades;
    }
}
