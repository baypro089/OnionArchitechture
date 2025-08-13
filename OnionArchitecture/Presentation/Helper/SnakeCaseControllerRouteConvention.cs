using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Text.RegularExpressions;

namespace Presentation.Helper
{
    public class SnakeCaseControllerNameConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            // Lấy tên controller (loại bỏ hậu tố "Controller")
            var controllerName = controller.ControllerName;

            // Chuyển sang snake_case
            var snakeCaseName = Regex.Replace(controllerName, "(?<!^)([A-Z])", "_$1").ToLower();

            // Duyệt qua các route attribute có [controller]
            foreach (var selector in controller.Selectors)
            {
                if (selector.AttributeRouteModel != null &&
                    selector.AttributeRouteModel.Template.Contains("[controller]"))
                {
                    selector.AttributeRouteModel = new AttributeRouteModel
                    (
                        new Microsoft.AspNetCore.Mvc.RouteAttribute(
                            selector.AttributeRouteModel.Template.Replace("[controller]", snakeCaseName)
                        )
                    );
                }
            }
        }
    }
}
