using DiGi.Harness.Classes;
using System;

namespace DiGi.Harness
{
    public static partial class Query
    {
        /// <summary>
        /// Checks that a user may chat: the harness is enabled, the user id is known, and <see cref="HarnessConfiguration.AllowedUserIds"/> is empty or contains it (ordinal, ignoring case).
        /// </summary>
        /// <param name="harnessConfiguration">The configuration.</param>
        /// <param name="userId">The user id resolved by the host; null or empty is never allowed.</param>
        /// <returns>True when the user may chat.</returns>
        public static bool IsAllowed(this HarnessConfiguration? harnessConfiguration, string? userId)
        {
            if (harnessConfiguration is null || !harnessConfiguration.Enabled || string.IsNullOrWhiteSpace(userId))
            {
                return false;
            }

            if (harnessConfiguration.AllowedUserIds is null || harnessConfiguration.AllowedUserIds.Count == 0)
            {
                return true;
            }

            foreach (string allowedUserId in harnessConfiguration.AllowedUserIds)
            {
                if (string.Equals(allowedUserId, userId, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
