
using AutoMapper;
using WShop.MarsRover.Application.Common.Interfaces;

namespace WShop.MarsRover.Application.Common.Bases
{
    public abstract class BaseHandler
    {        
        protected readonly IMapper _mapper;

        protected BaseHandler(IMapper mapper)
        {           
            _mapper = mapper;
        }
    }
}

