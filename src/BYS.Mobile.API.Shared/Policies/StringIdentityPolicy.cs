using BYS.Mobile.API.Shared.Models;

namespace BYS.Mobile.API.Shared.Policies
{
    public class StringIdentityPolicy<T> : IInsertPolicy<T> where T : IIdentity<string>
    {
        public StringIdentityPolicy()
        {
        }

        public void PrepareInsert(T entity)
        {
        }
    }
}
