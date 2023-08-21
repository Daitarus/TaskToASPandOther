using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IMyServise
    {
        public Response ExecuteExercise(Request request);
    }
}
