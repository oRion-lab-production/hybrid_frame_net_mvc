using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Utils
{
    public static class DataTableUtil
    {
        static DataTableUtil() { }

        #region object dataSrcModel
        public static Dictionary<string, dynamic> TransformDataSrc(object dataSrcModel) => dataSrcModel != null
            ? dataSrcModel.GetType().GetProperties().ToDictionary(xKey => xKey.Name, yVal => yVal.GetValue(dataSrcModel, null))
            : new Dictionary<string, object>();

        public static Dictionary<string, dynamic> TransformDataSrc(object dataSrcModel, string[] ignoreDataSrcParameters_value) => dataSrcModel != null
            ? dataSrcModel.GetType().GetProperties()
                .Where(x => ignoreDataSrcParameters_value != null && !ignoreDataSrcParameters_value.Contains(x.Name))
                .ToDictionary(xKey => xKey.Name, yVal => yVal.GetValue(dataSrcModel, null))
            : new Dictionary<string, object>();

        public static Dictionary<string, dynamic> TransformDataSrc(object dataSrcModel, Dictionary<string, dynamic> additionalData)
        {
            var dataSrc = TransformDataSrc(dataSrcModel);

            if (additionalData != null && additionalData.Any())
                foreach (var data in additionalData)
                    if (!dataSrc.ContainsKey(data.Key))
                        dataSrc.Add(data.Key, data.Value);

            return dataSrc;
        }

        public static Dictionary<string, dynamic> TransformDataSrc(object dataSrcModel, string[] ignoreDataSrcParameters_value, Dictionary<string, dynamic> additionalData)
        {
            var dataSrc = TransformDataSrc(dataSrcModel, ignoreDataSrcParameters_value);

            if (additionalData != null && additionalData.Any())
                foreach (var data in additionalData)
                    if (!dataSrc.ContainsKey(data.Key))
                        dataSrc.Add(data.Key, data.Value);

            return dataSrc;
        }
        #endregion

        #region List<object> dataSrcModelList
        public static List<Dictionary<string, dynamic>> TransformDataSrcList(List<object> dataSrcModelList) => dataSrcModelList != null && dataSrcModelList.Any()
            ? dataSrcModelList.Select(x => TransformDataSrc(x)).ToList()
            : new List<Dictionary<string, object>>();

        public static List<Dictionary<string, dynamic>> TransformDataSrcList(List<object> dataSrcModelList, string[] ignoreDataSrcParameters_value) => dataSrcModelList != null && dataSrcModelList.Any()
            ? dataSrcModelList.Select(x => TransformDataSrc(x, ignoreDataSrcParameters_value)).ToList()
            : new List<Dictionary<string, object>>();

        public static List<Dictionary<string, dynamic>> TransformDataSrcList(List<object> dataSrcModelList, Dictionary<string, dynamic> additionalData) => dataSrcModelList != null && dataSrcModelList.Any()
            ? dataSrcModelList.Select(x => TransformDataSrc(x, additionalData)).ToList()
            : new List<Dictionary<string, object>>();

        public static List<Dictionary<string, dynamic>> TransformDataSrcList(List<object> dataSrcModelList, List<Dictionary<string, dynamic>> additionalDataList) => dataSrcModelList != null && dataSrcModelList.Any()
            ? additionalDataList != null && additionalDataList.Any()
                ? dataSrcModelList.Select((x, i) => TransformDataSrc(x, additionalDataList[i])).ToList()
                : TransformDataSrcList(dataSrcModelList)
            : new List<Dictionary<string, object>>();

        public static List<Dictionary<string, dynamic>> TransformDataSrcList(List<object> dataSrcModelList, string[] ignoreDataSrcParameters_value, Dictionary<string, dynamic> additionalData) => dataSrcModelList != null && dataSrcModelList.Any()
            ? dataSrcModelList.Select(x => TransformDataSrc(x, ignoreDataSrcParameters_value, additionalData)).ToList()
            : new List<Dictionary<string, object>>();

        public static List<Dictionary<string, dynamic>> TransformDataSrcList(List<object> dataSrcModelList, string[] ignoreDataSrcParameters_value, List<Dictionary<string, dynamic>> additionalDataList) => dataSrcModelList != null && dataSrcModelList.Any()
            ? additionalDataList != null && additionalDataList.Any()
                ? dataSrcModelList.Select((x, i) => TransformDataSrc(x, ignoreDataSrcParameters_value, additionalDataList[i])).ToList()
                : TransformDataSrcList(dataSrcModelList, ignoreDataSrcParameters_value)
            : new List<Dictionary<string, object>>();
        #endregion

        public static string JoinActionButtonDataSrc(string[] actionBtns) => actionBtns.Any() ? string.Join(" ", actionBtns) : null;
    }
}
