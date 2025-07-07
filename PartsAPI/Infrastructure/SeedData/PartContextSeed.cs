using PartsAPI.Infrastructure.Data;
using System.Text.Json;

namespace PartsAPI.Infrastructure.SeedData
{
    public class PartContextSeed
    {
        public static async Task SeedAsync(PartContext context)
        {
            try
            {
                if (context.Parts.Any()) return;

                context.Parts.AddRange(
                    new Core.Entities.Part { PartNumber = "001", Description = "Door", QuantityOnHand = 50, LocationCode = "VR", LastStockTake = DateTime.Now},
                    new Core.Entities.Part { PartNumber = "002", Description = "WindScreen", QuantityOnHand = 100, LocationCode = "XR", LastStockTake = DateTime.Now },
                    new Core.Entities.Part { PartNumber = "003", Description = "Bumper", QuantityOnHand = 200, LocationCode = "CA", LastStockTake = DateTime.Now }
                    );

                if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }
    }
}
