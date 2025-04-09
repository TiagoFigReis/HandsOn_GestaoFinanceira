namespace Core.Enums
{
    public enum UserStatus
    {
        Active,
        Inactive,
        Deleted
    }

    public static class StatusExtension
    {
        public static string ToFriendlyString(this UserStatus status)
        {
            return status switch
            {
                UserStatus.Active => "Active",
                UserStatus.Inactive => "Inactive",
                UserStatus.Deleted => "Deleted",
                _ => "Unknown",
            };
        }

        public static UserStatus ToStatus(this string status)
        {
            return status switch
            {
                "Active" => UserStatus.Active,
                "Inactive" => UserStatus.Inactive,
                "Deleted" => UserStatus.Deleted,
                _ => UserStatus.Active,
            };
        }
    }
}