using ClubNautico.Data;
using ClubNautico.Models;
using MediatR;

namespace ClubNautico.Services.Socios.Commands
{
    public class SaveSocio
    {
        public Socio Socio { get; internal set; }

        public class SaveSocioCommand : IRequest<Socio>
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }

            public SaveSocioCommand(int id, string nombre, string apellido)
            {
                Id = id;
                Nombre = nombre;
                Apellido = apellido;
            }
        }

        public class SaveSocioHandler: IRequestHandler<SaveSocioCommand, Socio>
        {
            private readonly ApplicationContext _context; //TODO: CREAMOS UNA INSTANCIA DEL CONTEXTO DE LA BASE DE DATOS

            public SaveSocioHandler(ApplicationContext context)
            {
                _context = context;
            }

            public async Task<Socio> Handle(SaveSocioCommand request, CancellationToken cancellationToken)
            {
                try //TODO: BUSCAMOS EL SOCIO POR ID
                {
                    Socio socio = null; //TODO: CREAMOS UNA INSTANCIA DE SOCIO
                    if (request.Id == 0) //TODO: SI EL ID ES 0, CREAMOS UN NUEVO SOCIO
                    {
                        socio = new Socio();
                        socio.Nombre = request.Nombre;
                        socio.Apellido = request.Apellido;
                        await _context.Socios.AddAsync(socio);
                    }
                    else //TODO: SI EL ID NO ES 0, ACTUALIZAMOS EL SOCIO
                    {
                        socio = await _context.Socios.FindAsync(request.Id);
                        socio.Nombre = request.Nombre;
                        socio.Apellido = request.Apellido;
                    }
                    await _context.SaveChangesAsync(); //TODO: GUARDAMOS LOS CAMBIOS EN LA BASE DE DATOS
                    return socio;
                }
                catch (Exception ex)
                {
                    throw ex; //TODO: SI OCURRE UN ERROR, LANZAMOS UNA EXCEPCION
                }
            }
        }
        

    }
}
