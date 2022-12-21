using Domain.Commons.Validate;
using Domain.Core.Model;
using Domain.Core.Model.Actives;
using Domain.Core.Test.Mock;
using FluentAssertions;
using Xunit;
using Action = System.Action;

namespace Domain.Core.Test
{
    public class ActivesTest
    {
        [Fact]
        public void TickerIsNotFound()
        {
            var company = CompanyTest.GetMagazineLuizaMock();
            Action action = () => new Stocks(company, "egi3");
            action.Should().Throw<ExceptionDomainValidation>().WithMessage("Ticker not found");
        }

        [Fact]
        public void TickerIsValid()
        {
            var company = CompanyTest.GetPetrobras();

            Action action = () => new Stocks(company, "Petr4");

            action.Should().NotThrow<ExceptionDomainValidation>();
        }

        [Fact]
        public void TickerIsNull()
        {
            var magazine = CompanyTest.GetMagazineLuizaMock();

            Action action = () => new Stocks(magazine, null);

            action.Should().Throw<ExceptionDomainValidation>();
        }

        [Fact]
        public void CompanyIsNull()
        {
            var magazine = CompanyTest.GetMagazineLuizaMock();

            Action action = () => new Stocks(null, "MGLU3");

            action.Should().Throw<ExceptionDomainValidation>().WithMessage("company is null");

        }

        [Theory]
        [InlineData(EnumActionTypeTicker.ON, "petr3")]
        [InlineData(EnumActionTypeTicker.PN, "petr4")]
        [InlineData(EnumActionTypeTicker.Units, "petr11")]
        public void GetTikersLengtMaxZero(EnumActionTypeTicker type, string ticker)
        {
            var company = CompanyTest.GetPetrobras();
            Assert.Equal(ticker.ToUpper(), company.GettTiker(type));
        }

        [Theory]
        [InlineData("petr3")]
        [InlineData("petr4")]
        public void CheckTickers(string ticker)
        {
            var company = CompanyTest.GetPetrobras();
            Assert.True(company.ExistsTicker(ticker));
        }

        [Theory]
        [InlineData(EnumActionTypeTicker.ON, "CPLE3")]
        [InlineData(EnumActionTypeTicker.PN, "CPLE4")]
        [InlineData(EnumActionTypeTicker.ClassB, "CPLE6")]
        [InlineData(EnumActionTypeTicker.Units, "CPLE11")]
        public void CheckTickersClassA(EnumActionTypeTicker type, string ticker)
        {
            var company = CompanyTest.GetCopel();
            Assert.Equal(ticker.ToUpper(), company.GettTiker(type));
        }
    }
}
