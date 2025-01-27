﻿using Tabu.DTOs.Games;
using Tabu.DTOs.Words;
using Tabu.Entities;

namespace Tabu.Services.Abstracts
{
    public interface IGameService
    {
        Task<Guid> CreateAsync(GameCreateDto dto);
        Task<WordForInDto> Start(Guid Id);
        Task<WordForInDto> Fail(Guid Id);
        Task<WordForInDto> Success(Guid Id);
        Task<WordForInDto> Skip(Guid Id);
        Task<int> End(Guid Id);
    }
}
