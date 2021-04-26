﻿using DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IRepositoryAdministrador : IRepository<Administrador>
    {
        Task<IEnumerable<Administrador>> GetAllWithAsync();
        Task<Administrador> GetOneByIdWithAsync(int id);
    }
}
