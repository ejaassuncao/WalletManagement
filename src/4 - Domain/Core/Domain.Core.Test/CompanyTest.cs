using Domain.Commons.Validate;
using Domain.Core.Model;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Domain.Core.Test.Mock
{
    public class CompanyTest
    {
        internal static  Company GetMagazineLuizaMock()
        {
            return new Company("magazine luiza", new List<string>  { "Mglu3" });         
           
        }
        internal static Company GetPetrobras()
        {
            return new Company("Petrobrás", new List<string> { "PETR4", "PETR3", "PETR11" });
        }

        internal static Company GetCopel()
        {
           return new Company("Copel", new List<string> { "CPLE3", "CPLE4", "CPLE6", "CPLE11" });
           
        }

        public static Company GetHabt11()
        {
            return new Company("Habitat II - Fundo de Investimento Imobiliario", new List<string> { "HABT11"});
        }


        [Fact]
        public void GetTiker()
        {
            Action cene = () => {
                GetPetrobras().GettTiker(EnumActionTypeTicker.PN);
            };

            cene.Should().NotThrow<Exception>();         
        }

        [Fact]
        public void GetTikerUniq()
        {
            Action cene = () => {
                GetHabt11().GettTiker();
            };

            cene.Should().NotThrow<Exception>();
        }

        /// <summary>
        /// Teste para crição de compania
        /// </summary>       
        [Theory]
        [InlineData(null, null )]
        [InlineData("", null)]
        public void CreateCompanyFaill(string nome, List<string> ticker) 
        {
            Action cene = () => new Company(nome, ticker);            
            cene.Should().Throw<ExceptionDomainValidation>();
        }   

        [Fact] 
        public void CreateCompanySucess()
        {
            Action cene = () => {
                GetCopel();
                GetPetrobras();
                GetMagazineLuizaMock();
            };
            cene.Should().NotThrow<ExceptionDomainValidation>();
        }
    }
}
