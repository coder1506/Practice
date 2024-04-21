using Practice.Core.Model;

namespace Practice.Core.Util
{
    public class HandleUtil
    {
        public static void HandleException(Exception ex, ServiceResult resultService)
        {
            if (resultService != null)
            {
                resultService.Success = false;
            }

            if (ex != null)
            {

            }
        }

        public static void HandleException(Exception ex)
        {
            if (ex != null)
            {

            }
        }
    }
}
