using System.Runtime.CompilerServices;

namespace ProductApi.Utilities
{
    public static class ReflectionUtilities
    {
        /// <summary>
        /// Gets the name of the currently executing function.
        /// </summary>
        /// <param name="memberName">The name of the member. This is automatically populated by the compiler.</param>
        /// <returns>The name of the currently executing function.</returns>
        public static string GetCurrentFunctionName([CallerMemberName] string memberName = "")
        {
            return memberName;
        }
        
    }



}
