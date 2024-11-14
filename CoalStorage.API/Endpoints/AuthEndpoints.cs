namespace CoalStorage.API.Endpoints;

public static class AuthEndpoints
{
    public static void AddAuthEndpoints(this WebApplication app)
    {
        app.MapPost("/api/auth", (LoginModel model, [FromServices] ITokenService tokenService) => AuthUser(model, tokenService));
    }

    private static async Task<IResult> AuthUser(LoginModel loginModel, ITokenService tokenService)
    {
        var response = new APIResponse();
        try
        {
            var token = tokenService.GenerateToken(loginModel.Username, loginModel.Password);

            if (token == null)
            {
                return Results.Unauthorized();
            }

            return Results.Ok(new { Token = token });
        }
        catch (DbException dbEx)
        {
            response.DbException(dbEx);
            return Results.BadRequest(response);
        }
        catch (Exception ex)
        {
            response.FatalException(ex);
            return Results.BadRequest(response);
        }
    }
}
