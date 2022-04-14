using Domain.Core.Validate;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Core.Model
{
    public sealed class Company :EntityBase
    {
        public string Name { get; private set; }

        public string CNPJ { get; private set; }

        private readonly IDictionary<EnumActionTypeTicker, string> _ticker = new Dictionary<EnumActionTypeTicker, string>();

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

        public string GettTiker(EnumActionTypeTicker type)
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

                
                var lastCharacter = (ticker.Length == 5)? ticker[^1..] : ticker[^2..];
               
                ExceptionDomainValidation.When(!lastCharacter.All(char.IsDigit), "Ticker invalid");

                switch (lastCharacter)
                {
                    case "3":
                        _ticker.Add(EnumActionTypeTicker.Ordinaria, ticker.ToUpper());
                        break;
                    case "4":
                        _ticker.Add(EnumActionTypeTicker.Preferencial, ticker.ToUpper());
                        break;
                    case "11":
                        _ticker.Add(EnumActionTypeTicker.Units, ticker.ToUpper());
                        break;
                    case "6":
                        _ticker.Add(EnumActionTypeTicker.ClasseB, ticker.ToUpper());
                        break;
                }
            }

            Name = name;
            CNPJ = cnpj;
        }       
    }
    
}
