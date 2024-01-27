using System.Security.Claims;
using TrackerX.UserAccessor;

namespace TrackerX.Web.Accessors
{
    public class ApplicationUserAccessor : IApplicationUserAccessor
    {
        private readonly IHttpContextAccessor _context;
        public ApplicationUserAccessor(IHttpContextAccessor context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns User Id when logged in. For SuperAdmin returns 0, for anonymous returns -1
        /// </summary>
        /// <returns>User Id</returns>
        public int GetUserId()
        {
            var claims = _context.HttpContext.User.Claims;
            if (!claims.Any())
                return -1;

            int userId;

            if (!int.TryParse(claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value, out userId))
            {
                return -1;
            }

            return userId;
        }
    }
}
