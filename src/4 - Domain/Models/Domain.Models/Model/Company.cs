using Domain.Commons.Entity;
using Domain.Commons.Validate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Core.Model
{
    public sealed class Company : EntityBase
    {
        #region MSG Validate   
        public const string MSG_NAME_IS_NULL_OR_EMPTY = "Name is null or empty";
        public static string MSG_NAME_IS_MIN_LENGTH_3 = "Name is min length 3";
        public static string MSG_NAME_IS_MAX_LENGTH_255 = "Name is max length 255";
        public static string MSG_TICKERS_IS_NOT_NULL = "Tickers is not null";
        public static string MSG_TICKERS_NOT_FOUND = "Tickers not found";
        public static string MSG_TICKERS_IS_NOT_NULL_OR_EMPTY = "Ticker is null or empty";
        public static string MSG_NAME_IS_MIN_LENGTH_5 = "Name is min length 5";
        public static string MSG_NAME_IS_MAX_LENGTH_5 = "Name is max length 5";
        public static string MSG_TICKERS_INVALID = "Ticker invalid";
        #endregion

        #region properties
        public string Name { get; init; }

        public string CNPJ { get; init; }

        public Sector Setor { get; init; }

        private readonly IDictionary<EnumActionTypeTicker, string> _ticker = new Dictionary<EnumActionTypeTicker, string>();

        #endregion

        #region metods

        public Company()
        {

        }

        public Company(Guid id, string name, string cnpj = null) : base(id)
        {           
            Name = name;
            CNPJ = cnpj;           
        }

        public Company(Guid id, string name, List<string> tickers, string cnpj = null, Sector setor = null) : base(id)
        {
            ValidateDomain(name, tickers, cnpj);
            Name = name;
            CNPJ = cnpj;
            Setor = setor;
        }

        public Company(string name, List<string> tickers, string cnpj = null, Sector setor = null)
        {
            ValidateDomain(name, tickers, cnpj);
            Name = name;
            CNPJ = cnpj;
            Setor = setor;
        }

        public string GettTiker(EnumActionTypeTicker type)
        {
            ExceptionDomainValidation.When(!_ticker.ContainsKey(type), MSG_TICKERS_NOT_FOUND);
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
            ExceptionDomainValidation.When(string.IsNullOrEmpty(name), MSG_NAME_IS_NULL_OR_EMPTY);
            ExceptionDomainValidation.When(name.Length < 3, MSG_NAME_IS_MIN_LENGTH_3);
            ExceptionDomainValidation.When(name.Length > 255, MSG_NAME_IS_MAX_LENGTH_255);
            ExceptionDomainValidation.When(tickers == null, MSG_TICKERS_IS_NOT_NULL);
            ExceptionDomainValidation.When(tickers.Count == 0, MSG_TICKERS_NOT_FOUND);

            foreach (var ticker in tickers)
            {
                //regras para ticker BR
                ExceptionDomainValidation.When(string.IsNullOrEmpty(ticker), MSG_TICKERS_IS_NOT_NULL_OR_EMPTY);
                ExceptionDomainValidation.When(ticker.Length < 5, MSG_NAME_IS_MIN_LENGTH_5);
                ExceptionDomainValidation.When(ticker.Length > 6, MSG_NAME_IS_MAX_LENGTH_5);


                var lastCharacter = (ticker.Length == 5) ? ticker[^1..] : ticker[^2..];

                ExceptionDomainValidation.When(!lastCharacter.All(char.IsDigit), MSG_TICKERS_INVALID);

                switch (lastCharacter)
                {
                    case "3":
                        _ticker.Add(EnumActionTypeTicker.ON, ticker.ToUpper());
                        break;
                    case "4":
                        _ticker.Add(EnumActionTypeTicker.PN, ticker.ToUpper());
                        break;
                    case "11":
                        _ticker.Add(EnumActionTypeTicker.Units, ticker.ToUpper());
                        break;
                    case "6":
                        _ticker.Add(EnumActionTypeTicker.ClassB, ticker.ToUpper());
                        break;
                }
            }        
        }
        #endregion
    }

    public enum EnumActionTypeTicker : byte
    {
        ON = 0, //Final 3 
        PN = 1, // final 4
        Units = 3, //final 11
        ClassB = 4  // final 6   
    }
}
