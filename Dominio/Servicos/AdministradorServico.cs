namespace MinimalApi.Dominio.Servicos;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.DTOs;
using MinimalApi.Infraestrutura.DB;

public class AdministradorServico : IAdministradorServico
{
    private readonly DbContexto _contexto;
    public AdministradorServico(DbContexto contexto)
    {
        _contexto = contexto;
    }
    public List<Administrador> Login(LoginDTO loginDTO)
    {
        if (_contexto.Administradores.Where(a => a.Email == loginDTO.Email &&
            a.Senha == loginDTO.Senha).Any())
        {
            return _contexto.Administradores.Where(a => a.Email == loginDTO.Email &&
                a.Senha == loginDTO.Senha).ToList();
        }
        return new List<Administrador>();
    }
}
