using FluentValidation;
using static ClubNautico.Services.Socios.Queries.GetSocioById;

namespace ClubNautico.Validations
{
    public class GetSocioByIdQueryValidations: AbstractValidator<GetSocioByIdQuery>
    {
        public GetSocioByIdQueryValidations()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El id no puede ser vacio");
        }
    }
}
