using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsApi.Tests
{
    using PartsAPI.Core.Entities;
    using System.ComponentModel.DataAnnotations;
    using Xunit;

    public class PartValidationTests
    {
        private List<ValidationResult> ValidateModel(Part part)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(part, null, null);
            Validator.TryValidateObject(part, context, results, true);
            return results;
        }

        [Fact]
        public void Part_ShouldBeValid_WhenAllFieldsAreCorrect()
        {
            var part = new Part
            {
                PartNumber = "P100",
                Description = "Screw",
                QuantityOnHand = 50,
                LocationCode = "C1",
                LastStockTake = DateTime.UtcNow
            };

            var results = ValidateModel(part);

            Assert.Empty(results);
        }

        [Fact]
        public void Part_ShouldFail_WhenQuantityIsNegative()
        {
            var part = new Part
            {
                PartNumber = "P101",
                Description = "Nail",
                QuantityOnHand = -5,
                LocationCode = "C1",
                LastStockTake = DateTime.UtcNow
            };

            var results = ValidateModel(part);

            Assert.Contains(results, r => r.ErrorMessage!.Contains("Quantity must be >= 0"));
        }

        [Fact]
        public void Part_ShouldFail_WhenPartNumberIsMissing()
        {
            var part = new Part
            {
                Description = "Nut",
                QuantityOnHand = 10,
                LocationCode = "C1",
                LastStockTake = DateTime.UtcNow
            };

            var results = ValidateModel(part);

            Assert.Contains(results, r => r.MemberNames.Contains("PartNumber"));
        }

        [Fact]
        public void Part_ShouldFail_WhenLocationCodeIsMissing()
        {
            var part = new Part
            {
                PartNumber = "P102",
                Description = "Nut",
                QuantityOnHand = 10,
                LocationCode = "",
                LastStockTake = DateTime.UtcNow
            };

            var results = ValidateModel(part);

            Assert.Contains(results, r => r.MemberNames.Contains("LocationCode"));
        }
    }

}
