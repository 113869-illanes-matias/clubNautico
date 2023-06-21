using AutoMapper;
using ClubNautico.Data;
using ClubNautico.DTO;
using ClubNautico.Models;
using ClubNautico.Validations;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ClubNautico.Services.Socios.Queries
{
    public class GetSocioById
    {
        public class GetSocioByIdQuery : IRequest<SocioDTO> //todo: usamos el dto 
        {
            public int Id { get; set; }
        }

        public class GetSocioByIdHandler : IRequestHandler<GetSocioByIdQuery, SocioDTO>
        {
            private readonly ApplicationContext _context;
            private readonly GetSocioByIdQueryValidations _validator;
            private readonly IMapper _mapper;

            public GetSocioByIdHandler(ApplicationContext context, GetSocioByIdQueryValidations validator, IMapper mapper)
            {
                _context = context;
                _validator = validator;
                _mapper = mapper;
            }

            public async Task<SocioDTO> Handle(GetSocioByIdQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    await _validator.ValidateAndThrowAsync(request);

                    var socio = await _context.Socios.FindAsync(request.Id);
                    var socioMapped = _mapper.Map<Socio, SocioDTO>(socio);
                    return socioMapped;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}