﻿using Orders.Shared.DTOs;
using Orders.Shared.Entities;
using Orders.Shared.Repositories;

namespace Orders.Backend.UnitOfWork.Interfaces
{
    public interface ICitiesUnitOfWork
    {
        Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination);
        Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination);
    }
}
