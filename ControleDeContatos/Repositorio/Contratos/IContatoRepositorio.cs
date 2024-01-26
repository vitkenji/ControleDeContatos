using ControleDeContatos.Models;
using System.Collections.Generic;

namespace ControleDeContatos.Repositorio.Contratos
{
    public interface IContatoRepositorio
    {
        ContatoModel Adicionar(ContatoModel contato);
        List<ContatoModel> Buscar();
    }
}
