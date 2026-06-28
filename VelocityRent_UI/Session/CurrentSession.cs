using DTO.User;

namespace Velocity_Rent.Session
{
    public static class CurrentSession
    {
        public static UserDto CurrentUser { get; set; }
        public static bool IsLoggedIn => CurrentUser != null;
        public static void Logout() => CurrentUser = null;
    }
}
