﻿using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using FilesSafeReserve.App.Entities.Results.Basic;
using FilesSafeReserve.App.Models;

namespace FilesSafeReserve.Infra.Repositories;

public class ReservationRepo(FsrDbContext dbContext) : IReservationRepo
{
    public FsrDbContext DbContext { get; } = dbContext;

    public async Task<ValueResult<ReservationModel?>> GetByIdAsync(Guid id)
    {
        return await DbContext.Reservations
            .Include(field => field.Safe)
                .ThenInclude(field => field.Details)
                    .ThenInclude(field => field.Logs)
                        .ThenInclude(field => field.Operations)
            .Include(field => field.Files)
            .Include(field => field.Directories)
            .FirstOrDefaultAsync(el => el.Id == id);
    }

    public ValueResult<ReservationModel?> GetById(Guid id)
    {
        return DbContext.Reservations
            .Include(field => field.Safe)
                .ThenInclude(field => field.Details)
                    .ThenInclude(field => field.Logs)
                        .ThenInclude(field => field.Operations)
            .Include(field => field.Files)
            .Include(field => field.Directories)
            .FirstOrDefault(el => el.Id == id);
    }

    public async Task<List<ReservationModel>> ToListAsync()
    {
        return await DbContext.Reservations
            .Include(field => field.Safe)
                .ThenInclude(field => field.Details)
                    .ThenInclude(field => field.Logs)
                        .ThenInclude(field => field.Operations)
            .Include(field => field.Files)
            .Include(field => field.Directories)
            .ToListAsync();
    }

    public List<ReservationModel> ToList()
    {
        return [.. DbContext.Reservations
            .Include(field => field.Safe)
                .ThenInclude(field => field.Details)
                    .ThenInclude(field => field.Logs)
                        .ThenInclude(field => field.Operations)
            .Include(field => field.Files)
            .Include(field => field.Directories)];
    }
}
