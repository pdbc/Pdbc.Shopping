using System;

namespace Pdbc.Shopping.Common
{
    public static class UserContext
    {
        public static String GetUsername()
        {
            // TODO - get from claims principal/httpcontext/....
            return "Patrick";
        }
    }
}
