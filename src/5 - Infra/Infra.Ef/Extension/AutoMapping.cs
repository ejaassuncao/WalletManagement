using AutoMapper;
using Domain.Commons.Entity;
using Domain.Core.Model;
using Domain.Core.Model.Actives;
using Infra.Ef.DataModel;

namespace Infra.Ef.Extension
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<TbUser, User>();
            CreateMap<TbActive, AbstractActives>().ReverseMap();
            CreateMap<TbActivesOfCompany, ActivesOfCompany>().ReverseMap();
            CreateMap<TbBroker, Broker>().ReverseMap();
            CreateMap<TbCompany, Company>().ReverseMap();
            CreateMap<TbSector, Sector>().ReverseMap();
            CreateMap<TbWallet, Wallet>().ReverseMap();
        }
    }
}
