using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartsAPI.Core.Entities;
using PartsAPI.Infrastructure.Data;
using System;
namespace PartsApi.Tests;

public class PartsAPITests
{

    private PartContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<PartContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .Options;
        return new PartContext(options);
    }

    [Fact]
    public async Task GetParts_Returns_EmptyList_Initially()
    {
        var context = GetDbContext();
        var repository = new PartRepository(context);

        var result = await repository.GetAllAsync();

        Assert.Empty(result);
    }

    [Fact]
    public async Task CreatePart_Adds_Part_Successfully()
    {
        var context = GetDbContext();
        var repository = new PartRepository(context);

        var part = new Part
        {
            PartNumber = "X1",
            Description = "Test Part",
            QuantityOnHand = 5,
            LocationCode = "LOCX",
            LastStockTake = DateTime.UtcNow
        };

        var result = await repository.CreateAsync(part);
        Assert.Single(context.Parts);
    }
}
