namespace CoalStorage.API.Services
{
    public static class AuthenticationNAuthorization
    {
        public static void addAuthentificaionNAuthorization(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
