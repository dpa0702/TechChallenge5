using GestaoInvestimentosCore.DTO.Ativo;
using GestaoInvestimentosCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoInvestimentosCore.Interfaces.Services
{
    public interface IAtivoService
    {
        Ativo GetAtivoByIdAsync(int id);
        IEnumerable<Ativo> GetAllAtivosAsync();
        void AddAtivoAsync(CreateAtivoDTO createAtivoDTO);
        void UpdateAtivoAsync(UpdateAtivoDTO updateAtivoDTO);
        void DeleteAtivoAsync(Ativo ativo);
    }
}
