﻿using Orders.Shared.DTOs;
using Orders.Shared.Entities;
using Orders.Shared.Repositories;

namespace Orders.Backend.UnitOfWork.Interfaces
{
    public interface ICountriesUnitOfWork
    {
        Task<ActionResponse<Country>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<Country>>> GetAsync();
        Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination);
    }
}
