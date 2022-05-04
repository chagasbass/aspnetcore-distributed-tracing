﻿using MinimalApi.Extensions.Entities;

namespace MinimalApiUm.ApplicationServices.Contracts
{
    public interface ICategoriaExternalServices
    {
        Task<CommandResult> BuscarCategoriaAsync(Guid id);
    }
}
