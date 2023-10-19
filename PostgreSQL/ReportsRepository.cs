﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Models;
using PostgreSQL.Abstractions;

namespace PostgreSQL;

public sealed class ReportsRepository
    : IReportsRepository
{
    public ReportsRepository(
        IServiceProvider provider,
        ILogger<UsersRepository> logger)
    {
        _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        _logger.LogInformation("Reports repository was created just now");
    }

    public async Task AddAsync(Report report, CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(report);

        token.ThrowIfCancellationRequested();

        using var scope = _provider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        _repositoryContext = scope.ServiceProvider.GetRequiredService<IRepositoryContext>();

        await _repositoryContext.Reports.AddAsync(report, token);

        SaveChanges();
    }

    public async Task<Report?> GetReportByIdAsync(int reportId, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();

        using var scope = _provider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        _repositoryContext = scope.ServiceProvider.GetRequiredService<IRepositoryContext>();

        return await _repositoryContext.Reports.FindAsync(
            new object?[]
            {
                reportId
            }, token);
    }

    public Task<List<Report>> GetAllReportsAsync(CancellationToken token)
    {
        token.ThrowIfCancellationRequested();

        using var scope = _provider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        _repositoryContext = scope.ServiceProvider.GetRequiredService<IRepositoryContext>();

        return _repositoryContext.Reports.ToListAsync(token);
    }

    public async Task DeleteAsync(int reportId, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();

        using var scope = _provider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        _repositoryContext = scope.ServiceProvider.GetRequiredService<IRepositoryContext>();

        var report = await _repositoryContext.Reports.FindAsync(
            new object?[]
            {
                reportId
            }, token);

        if (report != null)
        {
            _repositoryContext.Reports.Entry(report).State = EntityState.Deleted;
        }

        SaveChanges();
    }

    public async Task UpdateAsync(Report report, CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(report);

        token.ThrowIfCancellationRequested();

        using var scope = _provider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        _repositoryContext = scope.ServiceProvider.GetRequiredService<IRepositoryContext>();

        var localReport = await _repositoryContext.Reports.FindAsync(
            new object?[]
            {
                report.Id
            }, token);

        if (localReport != null)
        {
            _repositoryContext.Reports.Entry(localReport).CurrentValues.SetValues(report);
        }

        SaveChanges();
    }

    public void SaveChanges()
    {
        _repositoryContext.SaveChanges();

        _logger.LogInformation("The changes of reports were sent to DB");
    }

    private readonly IServiceProvider _provider;
    private IRepositoryContext _repositoryContext;
    private readonly ILogger _logger;
}
