﻿using MochiApi.Dtos;
using MochiApi.Models;

namespace MochiApi.Services
{
    public interface IBudgetService
    {
        Task<Budget> CreateBudget(int userId, CreateBudgetDto createDto);
        Task DeleteBudget(int id, int walletId);
        Task<IEnumerable<Budget>> GetBudgets(int walletId, int month, int year);
        Task<BudgetSummary> StatisticBudget(int walletId, int month, int year);
        Task UpdateBudget(int id, int walletId, UpdateBudgetDto updateDto);
        Task UpdateSpentAmount(int categoryId, int month, int year, int amount, bool saveChanges = false);
    }
}