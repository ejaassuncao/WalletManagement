# System of Wallet Management
1. Create a system to control investment portfolio (Assets)
2. So which main entities?
3. Portfolio and Assets
4. A portfolio composes a set of assets
5. There are a variety of assets:
6. Fixed Income Assets, and Variable Income Assets
7. Among the assets we can mention some:
8. Stokes/Shares, Fiis/Reits, ETfs, BDRs, Debentures, LCI, LCA, Direct Treasury, Rents, Investment, personal stuff etc. etc.
9. I enter my assets in this portfolio as I go shopping
10. Verified what the real value of the asset is, and how much it returns to me in Income or Dividends or Interest on Capital;
11. I can see the total value of my equity
12. How much I invested
13. When the portfolio has yielded, whether I am in profit or loss, my price is half, etc..

## Database Patterns
- Table names: tb_{name table}
- All tables must have an abbreviation.
- Columns Table Name: abbreviation_{NameColumn}.The abbreviation must have 3 characters. The column name is unique name in sgdb
- View names: vw_{name view}
- Procedure names: prc_{name procedure}

## Modules:

### [Domain]
- Core   -> The basic funcionality (Permission, Autentication, User, Person, Helpers, Extension);
- Model  -> What application do? (Rules bussines)
- Usercase(domain.Services) -> communication between models

### [Infra]
- efcore
- dapper
- nosql
- email
- rabbitMq/kafka
- Redis

### [Application]
- CQRS => Communication between Usercase(domain.Services) + infra + events
- Mediator

### [Presentation]
- MCV
- Blazor
- WebAPI
- Graphql
- Console
- Desktop
