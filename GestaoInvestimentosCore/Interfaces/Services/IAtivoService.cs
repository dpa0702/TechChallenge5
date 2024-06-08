using GestaoInvestimentosCore.DTO.Ativo;
using GestaoInvestimentosCore.Entities;

namespace GestaoInvestimentosCore.Interfaces.Services
{
    public interface IAtivoService
    {
        Ativo GetAtivoByIdAsync(int id);
        IEnumerable<Ativo> GetAllAtivosAsync();
        void AddAtivoAsync(CreateAtivoDTO createAtivoDTO);
        void UpdateAtivoAsync(UpdateAtivoDTO updateAtivoDTO);
        void DeleteAtivoAsync(int id);
    }
}
