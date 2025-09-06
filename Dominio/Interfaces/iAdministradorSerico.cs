using MinimalApi.DTOs;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Infraestrutura.DB;

namespace MinimalApi.Dominio.Interfaces;

public interface IAdministradorServico
{ 
    List<Administrador> Login(LoginDTO loginDTO);
}