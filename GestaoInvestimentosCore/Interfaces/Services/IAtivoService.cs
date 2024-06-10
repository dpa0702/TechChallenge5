using GestaoInvestimentosCore.DTO.Ativo;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Enums;

namespace GestaoInvestimentosCore.Interfaces.Services
{
    public interface IAtivoService
    {
        Ativo GetAtivoByIdAsync(int id);
        IEnumerable<Ativo> GetAllAtivosAsync(int? id, int? tipoAtivo, string nome, string codigo);
        void AddAtivoAsync(CreateAtivoDTO createAtivoDTO);
        void UpdateAtivoAsync(UpdateAtivoDTO updateAtivoDTO);
        void DeleteAtivoAsync(int id);
        bool TipoAtivoIsValid(int? tipoAtivo);
    }
}
