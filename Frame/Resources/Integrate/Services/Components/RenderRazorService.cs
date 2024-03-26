using Integrate.IServices.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;

namespace Integrate.Services.Components
{
    public class RenderRazorService : IRenderRazorService
    {
        private readonly IRazorViewEngine _razorViewEngine;
        private readonly ICompositeViewEngine _compositeViewEngine;
        private readonly ITempDataProvider _tempDataProvider;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IServiceProvider _serviceProvider;

        public RenderRazorService(IRazorViewEngine razorViewEngine, ICompositeViewEngine compositeViewEngine, ITempDataProvider tempDataProvider,
            IHttpContextAccessor contextAccessor, IServiceProvider serviceProvider)
        {
            _razorViewEngine = razorViewEngine;
            _compositeViewEngine = compositeViewEngine;
            _tempDataProvider = tempDataProvider;
            _contextAccessor = contextAccessor;
            _serviceProvider = serviceProvider;
        }

        public async Task<string> RenderToStringAsync(string viewName, object model)
        {
            var actionContext = new ActionContext(_contextAccessor.HttpContext, _contextAccessor.HttpContext.GetRouteData(), new ActionDescriptor());
            //urlhelper not rendered -> GetActionContext()
            //var actionContext = GetActionContext();

            using var sw = new StringWriter();
            var viewResult = FindView(actionContext, viewName);

            if (viewResult == null)
                throw new ArgumentNullException($"{viewName} does not match any available view");

            var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary()) {
                Model = model
            };

            var viewContext = new ViewContext(
                actionContext,
                viewResult,
                viewDictionary,
                new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
                sw,
                new HtmlHelperOptions()
            );

            await viewResult.RenderAsync(viewContext);
            return sw.ToString();
        }

        public async Task<string> RenderToStringAsync(Controller controller, string viewName, object model)
        {
            using var sw = new StringWriter();
            var viewResult = FindView(controller, viewName);

            if (viewResult == null)
                throw new ArgumentNullException($"{viewName} does not match any available view");

            controller.ViewData.Model = model;

            var viewContext = new ViewContext(
                controller.ControllerContext,
                viewResult,
                controller.ViewData,
                controller.TempData,
                sw,
                new HtmlHelperOptions()
            );

            await viewResult.RenderAsync(viewContext);
            return sw.ToString();
        }

        private IView FindView(Controller controller, string viewName)
        {
            var viewResult = viewName.EndsWith(".cshtml")
                ? _compositeViewEngine.GetView(viewName, viewName, false)
                : _compositeViewEngine.FindView(controller.ControllerContext, viewName, false);

            if (viewResult.Success)
                return viewResult.View;

            var errorMessage = string.Join(
                Environment.NewLine,
                new[] { $"Unable to find view '{viewName}'. The following locations were searched:" }.Concat(viewResult.SearchedLocations));
            ;

            throw new InvalidOperationException(errorMessage);
        }

        private IView FindView(ActionContext actionContext, string viewName)
        {
            var getViewResult = _razorViewEngine.GetView(executingFilePath: null, viewPath: viewName, isMainPage: false);
            if (getViewResult.Success)
                return getViewResult.View;

            var findViewResult = _razorViewEngine.FindView(actionContext, viewName, isMainPage: false);
            if (findViewResult.Success)
                return findViewResult.View;

            var searchedLocations = getViewResult.SearchedLocations.Concat(findViewResult.SearchedLocations);
            var errorMessage = string.Join(
                Environment.NewLine,
                new[] { $"Unable to find view '{viewName}'. The following locations were searched:" }.Concat(searchedLocations));
            ;

            throw new InvalidOperationException(errorMessage);
        }

        private ActionContext GetActionContext()
        {
            var httpContext = new DefaultHttpContext {
                RequestServices = _serviceProvider
            };

            return new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
        }
    }
}
