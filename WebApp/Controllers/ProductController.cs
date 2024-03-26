using Abstraction.GenericModels;
using Abstraction.GenericModels.Components;
using Abstraction.GenericModels.Configurations;
using Abstraction.LibrariesModels.DataTable;
using Integrate.IServices.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Net.Security;
using System.Reflection;
using Tools.Utils;
using WebApp.Models.Common;

namespace WebApp.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly string _subDirectoryLink = "product";

        private readonly IServiceProvider _serviceProvider;
        private readonly ApiSettings _apiSettings;

        private readonly IRenderRazorService _renderRazorSvc;

        public ProductController(ILogger<ProductController> logger, IServiceProvider serviceProvider, IRenderRazorService renderRazorSvc) : base(logger)
        {
            _serviceProvider = serviceProvider;
            _apiSettings = _serviceProvider.GetRequiredService<ApiSettings>();
            _renderRazorSvc = renderRazorSvc;
        }

        public IActionResult Index()
        {
            if (IsTokenExpired()) {
                return RedirectToAction("Index", "Account");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> _Add()
        {
            var jsonResponse = new JsonResponse.PartialViewVal() { };

            try {
                if (IsTokenExpired()) {
                    jsonResponse.SetPartialView(ConstantValue.JsonResult.TokenExpired, "token expired.");
                    return Json(jsonResponse);
                }

                var model = new ProductAddViewModel();

                var partialView = await _renderRazorSvc.RenderToStringAsync("_Add", model);

                jsonResponse.SetPartialView(ConstantValue.JsonResult.Success, "success", partialView);
            } catch (Exception ex) {
                _logger.LogError(ex, ex.Message);
                jsonResponse.SetPartialView(ConstantValue.JsonResult.Failure, ex.Message);
            }

            return Json(jsonResponse);
        }

        [HttpPost]
        public async Task<IActionResult> _Add(ProductAddViewModel model)
        {
            var jsonResponse = new JsonResponse.ObjectVal();

            try {
                if (IsTokenExpired()) {
                    jsonResponse.SetObjectVal(ConstantValue.JsonResult.TokenExpired, "token expired.");
                    return Json(jsonResponse);
                }

                if (!ModelState.IsValid) {
                    jsonResponse.SetObjectVal(ConstantValue.JsonResult.ModelStateInvalid, "Model state invalid!.");
                } else {
                    var options = new RestClientOptions(_apiSettings.APIsUrl.rnd_app) {
                        RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
                    };
                    var client = new RestClient(options);
                    var request = new RestRequest($"{_subDirectoryLink}/create", Method.Post) { 
                        RequestFormat = DataFormat.Json
                    };
                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("Authorization", $"Bearer {GetTokenFromCookies()}");
                    request.AddBody(JsonConvert.SerializeObject(model));
                    var queryResult = await client.PostAsync(request);

                    if (!queryResult.IsSuccessful) {
                        jsonResponse.SetObjectVal(ConstantValue.JsonResult.Failure, "fail");
                    } else {
                        jsonResponse.SetObjectVal(ConstantValue.JsonResult.Success, "success", JsonConvert.DeserializeObject<Dictionary<dynamic, dynamic>>(queryResult.Content));
                    }
                }
            } catch (Exception ex) {
                _logger.LogError(ex, ex.Message);

                jsonResponse.SetObjectVal(ConstantValue.JsonResult.Failure, ex.Message);
            }

            return Json(jsonResponse);
        }

        [HttpGet]
        public async Task<IActionResult> _Update(Guid id)
        {
            var jsonResponse = new JsonResponse.PartialViewVal() { };

            try {
                if (IsTokenExpired()) {
                    jsonResponse.SetPartialView(ConstantValue.JsonResult.TokenExpired, "token expired.");
                    return Json(jsonResponse);
                }

                var options = new RestClientOptions(_apiSettings.APIsUrl.rnd_app) {
                    RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
                };
                var client = new RestClient(options);
                var request = new RestRequest($"{_subDirectoryLink}/read/{id}", Method.Get);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", $"Bearer {GetTokenFromCookies()}");
                var queryResult = await client.GetAsync(request);

                if (queryResult.IsSuccessful) {
                    var partialView = await _renderRazorSvc.RenderToStringAsync("_Update", 
                        JsonConvert.DeserializeObject<JsonResponse.ApiResponseVal<ProductUpdateViewModel>>(queryResult.Content).Datas
                    );

                    jsonResponse.SetPartialView(ConstantValue.JsonResult.Success, "success", partialView);
                } else {
                    jsonResponse.SetPartialView(ConstantValue.JsonResult.Failure, "fail");
                }

                var tt = JsonConvert.DeserializeObject<JsonResponse.ApiResponseVal<ProductUpdateViewModel>>(queryResult.Content);

            } catch (Exception ex) {
                _logger.LogError(ex, ex.Message);
                jsonResponse.SetPartialView(ConstantValue.JsonResult.Failure, ex.Message);
            }

            return Json(jsonResponse);
        }

        [HttpPost]
        public async Task<IActionResult> _Update(Guid id, ProductUpdateViewModel model)
        {
            var jsonResponse = new JsonResponse.ObjectVal();

            try {
                if (IsTokenExpired()) {
                    jsonResponse.SetObjectVal(ConstantValue.JsonResult.TokenExpired, "token expired.");
                    return Json(jsonResponse);
                }

                if (!ModelState.IsValid) {
                    jsonResponse.SetObjectVal(ConstantValue.JsonResult.ModelStateInvalid, "Model state invalid!.");
                } else {
                    var options = new RestClientOptions(_apiSettings.APIsUrl.rnd_app) {
                        RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
                    };
                    var client = new RestClient(options);
                    var request = new RestRequest($"{_subDirectoryLink}/update/{id}", Method.Put) {
                        RequestFormat = DataFormat.Json
                    };
                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("Authorization", $"Bearer {GetTokenFromCookies()}");
                    request.AddBody(JsonConvert.SerializeObject(model));
                    var queryResult = await client.PutAsync(request);

                    if (!queryResult.IsSuccessful) {
                        jsonResponse.SetObjectVal(ConstantValue.JsonResult.Failure, "fail");
                    } else {
                        jsonResponse.SetObjectVal(ConstantValue.JsonResult.Success, "success", JsonConvert.DeserializeObject<Dictionary<dynamic, dynamic>>(queryResult.Content));
                    }
                }
            } catch (Exception ex) {
                _logger.LogError(ex, ex.Message);

                jsonResponse.SetObjectVal(ConstantValue.JsonResult.Failure, ex.Message);
            }

            return Json(jsonResponse);
        }

        public async Task<IActionResult> _Delete(Guid id)
        {
            var jsonResponse = new JsonResponse.ObjectVal();

            try {
                if (IsTokenExpired()) {
                    jsonResponse.SetObjectVal(ConstantValue.JsonResult.TokenExpired, "token expired.");
                    return Json(jsonResponse);
                }

                var options = new RestClientOptions(_apiSettings.APIsUrl.rnd_app) {
                    RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
                };
                var client = new RestClient(options);
                var request = new RestRequest($"{_subDirectoryLink}/delete/{id}", Method.Delete);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", $"Bearer {GetTokenFromCookies()}");
                var queryResult = await client.DeleteAsync(request);

                if (!queryResult.IsSuccessful) {
                    jsonResponse.SetObjectVal(ConstantValue.JsonResult.Failure, "fail");
                } else {
                    jsonResponse.SetObjectVal(ConstantValue.JsonResult.Success, "success", JsonConvert.DeserializeObject<Dictionary<dynamic, dynamic>>(queryResult.Content));
                }
            } catch (Exception ex) {
                _logger.LogError(ex, ex.Message);

                jsonResponse.SetObjectVal(ConstantValue.JsonResult.Failure, ex.Message);
            }

            return Json(jsonResponse);
        }

        [HttpPost]
        public async Task<IActionResult> _ProcessTable(DataTable_postModel model)
        {
            var jsonResponse = new JsonResponse.ObjectVal();
            var requireVal = new DataTable_getModel_Parameter() { draw = model.draw };

            try {
                if (IsTokenExpired()) {
                    jsonResponse.SetObjectVal(ConstantValue.JsonResult.TokenExpired, "token expired.");
                    return Json(jsonResponse);
                }

                var options = new RestClientOptions(_apiSettings.APIsUrl.rnd_app) {
                    RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
                };
                var client = new RestClient(options);
                var request = new RestRequest($"{_subDirectoryLink}/ProcessTable", Method.Post) {
                    RequestFormat = DataFormat.Json
                };
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", $"Bearer {GetTokenFromCookies()}");
                request.AddBody(JsonConvert.SerializeObject(model));
                var queryResult = await client.PostAsync(request);

                var requestedVal = JsonConvert.DeserializeObject<JsonResponse.ApiResponseVal<DT_requestedValue<DT_productViewDtoModel>>>(queryResult.Content);

                if (requestedVal?.Datas != null) {
                    requireVal.recordsTotal = requireVal.recordsFiltered = requestedVal.Datas.Count;

                    if (requestedVal.Datas.Model != null && requestedVal.Datas.Model.Any()) {
                        requireVal.AddDataList(DataTableUtil.TransformDataSrcList(requestedVal.Datas.Model.Select((x, i) => new DT_productViewModel() {
                            SeqNo = model.start + (i + 1),
                            Name = x.Name,
                            Description = x.Description,
                            Price = $"RM {string.Format("{0:N2}", x.Price)}",
                            Quantity = x.Quantity,
                            IsActive = x.IsActive ? "Active" : "Inactive",
                            ActionBtn = DataTableUtil.JoinActionButtonDataSrc(new string[] {
                                $@"<a href='javascript:void(0)' 
                                    class='btn-sm action-btn-custom-dt btn-primary btn-edit' 
                                    style='margin-left: 5px;' 
                                    data-ajax='true' 
                                    data-ajax-method='GET' 
                                    data-ajax-failure='_UpdateFormFailure' 
                                    data-ajax-success='_UpdateFormSuccess'
                                    data-ajax-url='{Url.Action("_Update", "Product", new { x.Id })}'>
                                        <i class='fa fa-edit'></i> Edit
                                 </a>",
                                $@"<a href='javascript:void(0)' 
                                    class='btn-sm action-btn-custom-dt btn-warning btn-delete' 
                                    style='margin-left: 5px;' 
                                    data-ajax='true' 
                                    data-ajax-method='GET' 
                                    data-ajax-failure='_DeleteFailure' 
                                    data-ajax-success='_DeleteSuccess'
                                    data-ajax-confirm='Are you sure?'
                                    data-ajax-url='{Url.Action("_delete", "Product", new { x.Id })}'>
                                        <i class='fa fa-trash'></i> Delete
                                 </a>"
                            })
                        }).ToList<object>()));
                    }
                }

                jsonResponse.SetObjectVal(ConstantValue.JsonResult.Success, "success", requireVal);
            } catch (Exception ex) {
                _logger.LogError(ex, ex.Message);
                jsonResponse.SetObjectVal(ConstantValue.JsonResult.Failure, ex.Message, requireVal);
            }

            return Json(jsonResponse);
        }
    }
}
