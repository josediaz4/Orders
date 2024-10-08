﻿using Orders.Backend.Repositories.Interfaces;
using Orders.Backend.UnitOfWork.Interfaces;
using Orders.Shared.Entities;
using Orders.Shared.Repositories;

namespace Orders.Backend.UnitOfWork.Implementations
{
    public class CountriesUnitOfWork : GenericUnitOfWork<Country>, ICountriesUnitOfWork
    {
        private readonly ICountriesRepository _countriesRepository;

        public CountriesUnitOfWork(IGenericRepository<Country> repository, ICountriesRepository countriesRepository) :
            base(repository)
        {
            _countriesRepository = countriesRepository;
        }

        public override async Task<ActionResponse<Country>> GetAsync(int id) => await _countriesRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync() => await _countriesRepository.GetAsync();
    }
}
