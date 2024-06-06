﻿using GestaoInvestimentosCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoInvestimentosCore.Interfaces.Repository
{
    public interface ITransacaoRepository : IRepository<Transacao>
    {
        IEnumerable<Transacao> GetAllAsync();
    }
}
