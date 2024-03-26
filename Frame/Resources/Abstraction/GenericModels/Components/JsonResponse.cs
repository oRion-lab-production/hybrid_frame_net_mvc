using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Entities.Components;

namespace Abstraction.GenericModels.Components
{
    public class JsonResponse
    {
        public class ApiResponseVal<T>
        {
            public string Result { get; set; }
            public string Description { get; set; }
            public T Datas { get; set; }

            public ApiResponseVal() { }
        }

        private static string getConsValResult(ConstantValue.JsonResult result)
        {
            return result switch {
                ConstantValue.JsonResult.Failure => ConstantValue.JsonResult.Failure.ToString(),
                ConstantValue.JsonResult.Success => ConstantValue.JsonResult.Success.ToString(),
                ConstantValue.JsonResult.ModelStateInvalid => ConstantValue.JsonResult.ModelStateInvalid.ToString(),
                ConstantValue.JsonResult.TokenExpired => ConstantValue.JsonResult.TokenExpired.ToString(),
                _ => null,
            };
        }

        public class PartialViewVal : JsonResponseBaseModel
        {
            public string PartialView { get; set; }

            public PartialViewVal() { }

            public PartialViewVal(ConstantValue.JsonResult resultVal, string descriptionVal, string partialViewVal)
            {
                this.Result = getConsValResult(resultVal);
                this.Description = descriptionVal;
                this.PartialView = !string.IsNullOrWhiteSpace(partialViewVal) ? partialViewVal : null;
            }

            public void SetPartialView(ConstantValue.JsonResult resultVal, string descriptionVal)
            {
                this.Result = getConsValResult(resultVal);
                this.Description = descriptionVal;
            }

            public void SetPartialView(ConstantValue.JsonResult resultVal, string descriptionVal, string partialViewVal)
            {
                this.Result = getConsValResult(resultVal);
                this.Description = descriptionVal;
                this.PartialView = !string.IsNullOrWhiteSpace(partialViewVal) ? partialViewVal : null;
            }

            public void SetResult(ConstantValue.JsonResult resultVal) => this.Result = getConsValResult(resultVal);

            public void SetDescription(string desciptionVal) => this.Description = desciptionVal;

            public void SetPartialView(string partialViewVal) => this.PartialView =
                !string.IsNullOrWhiteSpace(partialViewVal) ? partialViewVal : null;
        }

        public class ObjectVal : JsonResponseBaseModel
        {
            public object Values { get; set; }

            public ObjectVal() { }

            public ObjectVal(ConstantValue.JsonResult resultVal, string descriptionVal, object valuesVal)
            {
                this.Result = getConsValResult(resultVal);
                this.Description = descriptionVal;
                this.Values = valuesVal;
            }

            public void SetObjectVal(ConstantValue.JsonResult resultVal, string descriptionVal)
            {
                this.Result = getConsValResult(resultVal);
                this.Description = descriptionVal;
            }

            public void SetObjectVal(ConstantValue.JsonResult resultVal, string descriptionVal, object valuesVal)
            {
                this.Result = getConsValResult(resultVal);
                this.Description = descriptionVal;
                this.Values = valuesVal;
            }

            public void SetResult(ConstantValue.JsonResult resultVal) => this.Result = getConsValResult(resultVal);

            public void SetDescription(string desciptionVal) => this.Description = desciptionVal;

            public void SetObjectVal(object valuesVal) => this.Values = valuesVal;
        }
    }
}
