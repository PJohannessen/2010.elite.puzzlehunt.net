using System;

namespace PAJ.ElitePuzzleHunt.BusinessObjects
{
    /// <summary>
    /// List of permissions granted in the Elite Puzzle Hunt.
    /// </summary>
    [Serializable]
    [Flags]
    public enum UserPermissions
    {
        /// <summary>
        /// Permission required for basic operations.
        /// </summary>
        Basic,

        /// <summary>
        /// Permission required for administritive operations.
        /// </summary>
        Administritive,

        /// <summary>
        /// The permission granted for a user who has logged in successfully.
        /// </summary>
        AuthenticatedUser = Basic,

        /// <summary>
        /// The permission granted for an administrator who has logged in successfully.
        /// </summary>
        AuthenticatedAdmin = AuthenticatedUser + Administritive
    }
}
