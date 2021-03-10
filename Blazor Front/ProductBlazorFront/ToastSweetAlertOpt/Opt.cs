using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProductBlazorFront.ToastSweetAlertOpt
{
    public class Opt
    {

    }

    public class Swal
    {
        public static Dictionary<string, object> Param()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("title", "Are you sure?");
            param.Add("text", "You won't be able to revert this!");
            param.Add("icon", "warning");
            param.Add("showCancelButton", true);
            param.Add("confirmButtonColor", "#3085d6");
            param.Add("cancelButtonColor", "#d33");
            param.Add("confirmButtonText", "Yes, delete it!");
            return param;
        }
    }

    public class JsonResponse
    {
        [JsonPropertyName("dismiss")]
        public string Dismiss { get; set; }

        [JsonPropertyName("value")]
        public bool Value { get; set; }
    }
}
