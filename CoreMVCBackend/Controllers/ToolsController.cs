using Microsoft.AspNetCore.Mvc;

namespace CoreMVCBackend.Backend{
    public class ToolsController:BaseController{
        public IActionResult Encoder(){

            return PartialView();
        }
    }
}