namespace Core.Enums
{
    public enum UserRole
    {
        Admin,
        Owner,
        Consultant,
        Manager,
        Collaborator
    }

    public static class RoleExtension
    {
        public static string ToFriendlyString(this UserRole role)
        {
            return role switch
            {
                UserRole.Admin => "Admin",
                UserRole.Owner => "Owner",
                UserRole.Consultant => "Consultant",
                UserRole.Manager => "Manager",
                UserRole.Collaborator => "Collaborator",
                _ => "Unknown",
            };
        }

        public static UserRole ToRole(this string role)
        {
            return role.Replace(" ", "") switch
            {
                "Admin" => UserRole.Admin,
                "Owner" => UserRole.Owner,
                "Consultant" => UserRole.Consultant,
                "Manager" => UserRole.Manager,
                "Collaborator" => UserRole.Collaborator,
                _ => UserRole.Admin,
            };
        }

        public static UserRole[] GetValues()
        {
            return [UserRole.Admin, UserRole.Owner, UserRole.Consultant, UserRole.Manager, UserRole.Collaborator];
        }
    }
}