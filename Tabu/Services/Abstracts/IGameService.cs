﻿using Tabu.DTOs.Games;
using Tabu.DTOs.Words;
using Tabu.Entities;

namespace Tabu.Services.Abstracts
{
    public interface IGameService
    {
        Task CreateAsync(Game Dto);
        Task StartAsync(Guid Id);
        Task FailAsync(Guid Id);
        Task SuccessAsync(Guid Id);
        Task SkipAsync(Guid Id);
        Task EndAsync(Guid Id);
    }
}