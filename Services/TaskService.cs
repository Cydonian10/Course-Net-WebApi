using webapi.Context;
using webapi.Models;

namespace webapi.Services
{
    public class TaskService : ITaskService
    {
        TareasContext context;

        public TaskService(TareasContext context)
        {
            this.context = context;
        }

        public IEnumerable<Tarea> Get()
        {
            return context.Tareas!;
        }

        public async Task Save( Tarea tarea) 
        {
            await context.AddAsync(tarea);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Tarea tarea) 
        {
            var tareaActual = context.Tareas?.Find(id);

            if( tareaActual != null)
            {
                tareaActual!.Titulo = tarea.Titulo;
                tareaActual.Description = tarea.Description;
                tareaActual.PrioridadTarea = tarea.PrioridadTarea;
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var tareaActual = context.Tareas?.Find(id);

            if (tareaActual != null)
            {
                context.Tareas?.Remove(tareaActual!);
                await context.SaveChangesAsync();
            }
        }

    }


    public interface ITaskService
    {
        IEnumerable<Tarea> Get();
        Task Save(Tarea tarea);
        Task Update(Guid id, Tarea tarea);
        Task Delete(Guid id);
    }
}