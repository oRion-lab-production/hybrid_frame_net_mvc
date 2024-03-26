using Abstraction.GenericModels;
using Abstraction.GenericModels.Components;
using Abstraction.GenericModels.Configurations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using WebApp.Models.Common;
using WebApp.Models.Membership;

namespace WebApp.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly string _subDirectoryLink = "user";

        private readonly IServiceProvider _serviceProvider;
        private readonly ApiSettings _apiSettings;

        public AccountController(ILogger<AccountController> logger, IServiceProvider serviceProvider) : base(logger) 
        {
            _serviceProvider = serviceProvider;
            _apiSettings = _serviceProvider.GetRequiredService<ApiSettings>();
        }

        public IActionResult Index() => RedirectToAction("Login");

        public IActionResult Login()
        {
            if(GetTokenFromCookies() != null) {
                Response.Cookies.Delete("Token");
            }

            return View(new AccountLoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(AccountLoginViewModel model)
        {
            if (!ModelState.IsValid) {
                TempData["Message"] = "Please unsure the details are correct!.";
                return View(model);
            }

            var options = new RestClientOptions(_apiSettings.APIsUrl.rnd_app) {
                RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            };
            var client = new RestClient(options);
            var request = new RestRequest($"{_subDirectoryLink}/login", Method.Get) {
                RequestFormat = DataFormat.Json
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(JsonConvert.SerializeObject(model));
            var queryResult = await client.GetAsync(request);

            if (!queryResult.IsSuccessful) {
                TempData["ErrorMessage"] = "Uh-oh!. Something not right, Please contact system administrator.";
                return View(model);
            }

            var resultContent = JsonConvert.DeserializeObject<JsonResponse.ApiResponseVal<string>>(queryResult.Content);

            if (resultContent.Result == ConstantValue.JsonResult.Failure.ToString()) {
                TempData["Message"] = resultContent.Description;
                return View(model);
            }

            var cookieOptions = new CookieOptions {
                Expires = DateTime.Now.AddDays(1),
                Path = "/"
            };
            Response.Cookies.Append("Token", resultContent.Datas, cookieOptions);

            return RedirectToAction("Index", "Product");
        }

        public IActionResult Register()
        {
            if (GetTokenFromCookies() != null) {
                Response.Cookies.Delete("Token");
            }

            return View(new AccountRegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(AccountRegisterViewModel model)
        {
            if (!ModelState.IsValid) {
                TempData["Message"] = "Please unsure the details are correct!.";
                return View(model);
            }

            var options = new RestClientOptions(_apiSettings.APIsUrl.rnd_app) {
                RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            };
            var client = new RestClient(options);
            var request = new RestRequest($"{_subDirectoryLink}/register", Method.Post) {
                RequestFormat = DataFormat.Json
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(JsonConvert.SerializeObject(model));
            var queryResult = await client.PostAsync(request);

            if (!queryResult.IsSuccessful) {
                TempData["ErrorMessage"] = "Uh-oh!. Something not right, Please contact system administrator.";
                return View(model);
            }

            var resultContent = JsonConvert.DeserializeObject<JsonResponse.ApiResponseVal<object>>(queryResult.Content);

            if (resultContent.Result == ConstantValue.JsonResult.Failure.ToString()) {
                TempData["Message"] = resultContent.Description;
                return View(model);
            }

            return RedirectToAction("Login", "Account");
        }

        public IActionResult LogoutAsync()
        {
            if (GetTokenFromCookies() != null) {
                Response.Cookies.Delete("Token");
            }

            return RedirectToAction("Index");
        }
    }
}
