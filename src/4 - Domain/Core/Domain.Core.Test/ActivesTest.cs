using Domain.Core.Model;
using Domain.Core.Model.Actives;
using Domain.Core.Test.Mock;
using Domain.Core.Validate;
using FluentAssertions;
using System;
using Xunit;
using Action = System.Action;

namespace Domain.Core.Test
{
    public class ActivesTest
    {
        [Fact]
        public void TickerIsNotFound()
        {
            var company = CompanyTest.GetMagazineLuiza();
            Action action = () => new Stocks(company, "egi3", 52, 39.79);
            action.Should().Throw<ExceptionDomainValidation>().WithMessage("Ticker not found");
        }

        [Fact]
        public void TickerIsValid()
        {
            var company = CompanyTest.GetPetrobras();

            Action action = () => new Stocks(company, "Petr4", 52, 39.79);

            action.Should().NotThrow<ExceptionDomainValidation>();

        }

        [Fact]
        public void TickerIsNull()
        {
            var magazine = CompanyTest.GetMagazineLuiza();

            Action action = () => new Stocks(magazine, null, 52, 39.79);

            action.Should().Throw<ExceptionDomainValidation>();
        }

        [Fact]
        public void CompanyIsNull()
        {
            var magazine = CompanyTest.GetMagazineLuiza();

            Action action = () => new Stocks(null, "MGLU3", 52, 39.79);

            action.Should().Throw<ExceptionDomainValidation>().WithMessage("company is null");

        }

        [Theory]
        [InlineData(EnumTypeTicker.Ordinaria, "petr3")]
        [InlineData(EnumTypeTicker.Preferencial, "petr4")]
        [InlineData(EnumTypeTicker.Units, "petr11")]
        public void GetTikersLengtMaxZero(EnumTypeTicker type, string ticker)
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
        [InlineData(EnumTypeTicker.Ordinaria, "CPLE3")]
        [InlineData(EnumTypeTicker.Preferencial, "CPLE4")]
        [InlineData(EnumTypeTicker.ClasseB, "CPLE6")]
        [InlineData(EnumTypeTicker.Units, "CPLE11")]
        public void CheckTickersClassA(EnumTypeTicker type, string ticker)
        {
            var company = CompanyTest.GetCopel();
            Assert.Equal(ticker.ToUpper(), company.GettTiker(type));
        }


        [Theory]
        [InlineData(60, 16, 960)]
        [InlineData(50, 100, 5000)]
        public static void SuccessTotalCost(int amount, double unitCost, double expected)
        {
            var wallet = new Wallet("Ativos BR");
            var magazine = CompanyTest.GetMagazineLuiza();

            var actions = new Actions(magazine, magazine.GettTiker(), amount, unitCost);          

            Assert.Equal(expected, actions.TotalCost);

        }
    }
}
