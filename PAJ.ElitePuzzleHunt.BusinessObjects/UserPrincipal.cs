using System;
using System.Security.Principal;

namespace PAJ.ElitePuzzleHunt.BusinessObjects
{
    /// <summary>
    /// A custom principal object for the Elite Puzzle Hunt.
    /// </summary>
    [Serializable]
    public class UserPrincipal : MarshalByRefObject, IPrincipal
    {
        private readonly UserPermissions _Role;

        /// <summary>
        /// Gets the identity of the current principal.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Security.Principal.IIdentity"/> object associated with the current principal.
        /// </returns>
        public IIdentity Identity { get; private set; }

        /// <summary>
        /// Creates an instance of the custom principal object.
        /// </summary>
        /// <param name="identity">The <see cref="IIdentity" /> belonging to the principal.</param>
        /// <param name="role">The role group to which the principal belongs.</param>
        public UserPrincipal(IIdentity identity, UserPermissions role)
        {
            Identity = identity;
            _Role = role;
        }

        /// <summary>
        /// Determines whether the current principal belongs to the specified role.
        /// </summary>
        /// <returns>
        /// true if the current principal is a member of the specified role; otherwise, false.
        /// </returns>
        /// <param name="role">The name of the role for which to check membership. 
        ///                 </param>
        public bool IsInRole(string role)
        {
            try
            {
                var roleValue = (UserPermissions)Enum.Parse(
                   typeof(UserPermissions), role);
                if (Enum.IsDefined(typeof(UserPermissions), roleValue))
                {
                    var isInRole = ((_Role & roleValue) == roleValue);
                    return isInRole;
                }
                return false;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }  
        }

        /// <summary>
        /// Obtains a lifetime service object to control the lifetime policy for this instance.
        /// </summary>
        /// <returns>
        /// An object of type <see cref="T:System.Runtime.Remoting.Lifetime.ILease"/> used to control the lifetime policy for this instance. This is the current lifetime service object for this instance if one exists; otherwise, a new lifetime service object initialized to the value of the <see cref="P:System.Runtime.Remoting.Lifetime.LifetimeServices.LeaseManagerPollTime"/> property.
        /// </returns>
        /// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission. </exception><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="RemotingConfiguration, Infrastructure"/></PermissionSet>
        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}
