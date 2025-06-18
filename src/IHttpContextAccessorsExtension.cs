using Soenneker.Extensions.HttpContext;
using System.Diagnostics.Contracts;

namespace Soenneker.Extensions.IHttpContextAccessors;

/// <summary>
/// A collection of helpful IHttpContextAccessor extension methods
/// </summary>
// ReSharper disable once InconsistentNaming
public static class IHttpContextAccessorsExtension
{
    /// <summary>
    /// Retrieves the client IP address from the current <see cref="Microsoft.AspNetCore.Http.HttpContext"/> using standard proxy headers
    /// such as "CF-Connecting-IP" and "X-Forwarded-For", or falls back to the remote IP address.
    /// </summary>
    /// <param name="accessor">The HTTP context accessor providing access to the current request context.</param>
    /// <returns>
    /// The client IP address as a string, or <c>null</c> if the context or IP address could not be determined.
    /// </returns>
    /// <remarks>
    /// This method delegates to <see cref="HttpContextExtension.GetRequestIp(Microsoft.AspNetCore.Http.HttpContext)"/> and is useful in scenarios
    /// where only <see cref="Microsoft.AspNetCore.Http.IHttpContextAccessor"/> is available via dependency injection (e.g., background services).
    /// </remarks>
    [Pure]
    public static string? GetRequestIp(this Microsoft.AspNetCore.Http.IHttpContextAccessor accessor)
    {
        return accessor.HttpContext?.GetRequestIp();
    }
}