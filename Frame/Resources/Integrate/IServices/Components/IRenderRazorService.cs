using Microsoft.AspNetCore.Mvc;

namespace Integrate.IServices.Components
{
    public interface IRenderRazorService
    {
        Task<string> RenderToStringAsync(string viewName, object model);
        Task<string> RenderToStringAsync(Controller controller, string viewName, object model);
    }
}
