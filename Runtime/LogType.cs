
namespace Quartzified.Resolve
{
    public enum LogType
    {
        /// <summary>
        /// Log Type used for regular logs.
        /// </summary>
        Log,

        /// <summary>
        /// Log Type used for Warnings.
        /// </summary>
        Warning,

        /// <summary>
        /// Log Type used for Errors.
        /// </summary>
        Error,

        /// <summary>
        /// Log Type used for Exceptions.
        /// </summary>
        Exception,

        /// <summary>
        /// Log Type used for Asserts. [Unused]
        /// </summary>
        Assert
    }
}