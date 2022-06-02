using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Persistence.Contrato;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public class EventoPersist : IEventoPersist
    {
        private readonly ProEventosContext _context;

        public EventoPersist(ProEventosContext context)
        {
            _context = context;
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(x => x.Lotes)
                .Include(x => x.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(x => x.PalestrantesEventos)
                    .ThenInclude(x => x.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(x => x.Lotes)
                .Include(x => x.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(x => x.PalestrantesEventos)
                    .ThenInclude(x => x.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id)
                .Where(x => x.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(x => x.Lotes)
                .Include(x => x.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(x => x.PalestrantesEventos)
                    .ThenInclude(x => x.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id)
                .Where(x => x.Tema.ToLower()
                .Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}
