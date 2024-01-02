namespace IsubuSatis.Siparis.Api.Services
{
    public interface IIdentityHelperService
    {
        string GetUserId();
    }

    public class IdentityHelperService : IIdentityHelperService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityHelperService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public string GetUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;
        }
    }
}
