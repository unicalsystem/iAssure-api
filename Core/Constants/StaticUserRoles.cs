using System.Globalization;

namespace backend_dotnet.Core.Constants
{
    //This class will be use to avoid typing errors
    public static class StaticUserRoles
    {
        public const string OWNER = "OWNER";
        public const string ADMIN = "ADMIN";
        public const string CHIEF_AUDITOR = "CHIEF_AUDITOR";
        public const string AUDITOR = "AUDITOR";
        public const string USER = "USER";

        public const string OwnerAdmin = "OWNER,ADMIN";
        public const string OwnerAdminChiefAuditor = "OWNER,ADMIN,CHIEF_AUDITOR";
        public const string OwnerAdminChiefAuditorAuditor = "OWNER,ADMIN,CHIEF_AUDITOR,AUDITOR";
        public const string OwnerAdminChiefAuditorAuditorUser = "OWNER,ADMIN,CHIEF_AUDITOR,AUDITOR,USER";
    }
}
