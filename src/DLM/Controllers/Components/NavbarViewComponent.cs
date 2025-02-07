using Microsoft.AspNetCore.Mvc;

namespace DLM.Controllers.Components;

public class NavbarViewComponent : ViewComponent
{
    public Task<IViewComponentResult> InvokeAsync()
    {
        return Task.FromResult((IViewComponentResult)View("Default"));
    }
}