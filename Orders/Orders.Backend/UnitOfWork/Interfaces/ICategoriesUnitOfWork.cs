﻿using Orders.Shared.DTOs;
using Orders.Shared.Entities;
using Orders.Shared.Repositories;

namespace Orders.Backend.UnitOfWork.Interfaces
{
    public interface ICategoriesUnitOfWork
    {
        Task<ActionResponse<IEnumerable<Category>>> GetAsync(PaginationDTO pagination);
        Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination);
    }
}
