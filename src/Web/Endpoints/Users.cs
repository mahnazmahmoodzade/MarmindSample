using MarmindSample.Infrastructure.Identity;

namespace MarmindSample.Web.Endpoints;

public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup("api/users").WithTags("Users")
            .MapIdentityApi<ApplicationUser>();
    }
}
