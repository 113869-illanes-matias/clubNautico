using AutoMapper;
using ClubNautico.Data;
using ClubNautico.DTO;
using ClubNautico.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClubNautico.Service.Socios.Queries
{
    public class GetAllSocios
    {
        public class GetAllSociosQuery : IRequest<List<SocioDTO>>
        {
            public List<SocioDTO> Socios { get; set; }
        }

        public class GetAllSociosHandler : IRequestHandler<GetAllSociosQuery, List<SocioDTO>>
        {
            private readonly ApplicationContext _context;
            private readonly IMapper _mapper;

            public GetAllSociosHandler(ApplicationContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<SocioDTO>> Handle(GetAllSociosQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var socios = await _context.Socios.ToListAsync();
                    var sociosMapped = _mapper.Map<List<Socio>, List<SocioDTO>>(socios);
                    return sociosMapped;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }






    }
}
