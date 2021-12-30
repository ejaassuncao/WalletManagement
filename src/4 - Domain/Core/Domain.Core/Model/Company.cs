using Domain.Core.Validate;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Core.Model
{
    public sealed class Company :EntityBase
    {
        public string Name { get; private set; }

        public string CNPJ { get; private set; }

        private readonly IDictionary<EnumTypeTicker, string> _ticker = new Dictionary<EnumTypeTicker, string>();

        public Company(int id, string name, List<string> tickers, string cnpj = null)
        {
            ExceptionDomainValidation.When(id<=0, "Id is min or egual 0");
            Id = id;
            ValidateDomain(name, tickers, cnpj);
        }

        public Company(string name, List<string> tickers, string cnpj=null) 
        {
            ValidateDomain(name, tickers, cnpj);
        }       

        public string GettTiker(EnumTypeTicker type)
        {            
            ExceptionDomainValidation.When(!_ticker.ContainsKey(type), "Ticker not found");
            return _ticker[type];
        }

        public string GettTiker()
        {
            return _ticker.Values.ToList()[0];           
        }

        public bool ExistsTicker(string ticker)
        {  
            return _ticker.Values.Any(x => x == ticker?.ToUpper());
        }

        private void ValidateDomain(string name, List<string> tickers, string cnpj)
        {
            ExceptionDomainValidation.When(string.IsNullOrEmpty(name), "Name is null or empty");
            ExceptionDomainValidation.When(name.Length < 3, "Name is min length 3");
            ExceptionDomainValidation.When(name.Length > 255, "Name is max length 255");


            ExceptionDomainValidation.When(tickers==null, "Tickers is not null");
            ExceptionDomainValidation.When(tickers.Count ==0, "Tickers not found");

            foreach (var ticker in tickers)
            {
                //regras para ticker BR
                ExceptionDomainValidation.When(string.IsNullOrEmpty(ticker), "Ticker is null or empty");
                ExceptionDomainValidation.When(ticker.Length < 5, "Name is min length 5");
                ExceptionDomainValidation.When(ticker.Length > 6, "Name is max length 5");

                
                var lastCharacter = (ticker.Length == 5)? ticker.Substring(ticker.Length - 1): ticker.Substring(ticker.Length - 2);
               
                ExceptionDomainValidation.When(!lastCharacter.All(char.IsDigit), "Ticker invalid");

                switch (lastCharacter)
                {
                    case "3":
                        _ticker.Add(EnumTypeTicker.Ordinaria, ticker.ToUpper());
                        break;
                    case "4":
                        _ticker.Add(EnumTypeTicker.Preferencial, ticker.ToUpper());
                        break;
                    case "11":
                        _ticker.Add(EnumTypeTicker.Units, ticker.ToUpper());
                        break;
                    case "6":
                        _ticker.Add(EnumTypeTicker.ClasseB, ticker.ToUpper());
                        break;
                }
            }

            Name = name;
            CNPJ = cnpj;
        }       
    }

    public enum EnumTypeTicker
    { 
        Ordinaria=0, //Final 3 
        Preferencial=1, // final 4
        Units=3, //final 11
        ClasseB=4  // final 6   
    }
}
