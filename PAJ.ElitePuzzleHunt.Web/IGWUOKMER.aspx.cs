using System;
using PAJ.ElitePuzzleHunt.Data;

namespace PAJ.ElitePuzzleHunt.Web
{
    public partial class IGWUOKMER : RoutableHuntPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/");
            }
            else
            {
                using (var dataContext = new DatabaseDataContext(DatabaseConfig.ConnectionString))
                {
                    Logging log = new Logging
                                      {
                                          Message = string.Format("{0} loaded secret page 'IGWUOKMER' (correct)", User.Identity.Name),
                                          Time = DateTime.UtcNow
                                      };
                    dataContext.Loggings.InsertOnSubmit(log);
                    dataContext.SubmitChanges();

                }
            }
        }
    }
}
