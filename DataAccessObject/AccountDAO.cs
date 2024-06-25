using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        public static readonly object instanceLock = new object();
        private AccountDAO() { }
        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if(instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }
            }
        }
        //-------------------------------------
        public AccountMember GetAccountByID(string id)
        {
            var accountMember = new AccountMember();
            try
            {
                using var context = new MyStoreContext();
                accountMember = context.AccountMembers.FirstOrDefault(c => c.MemberId.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return accountMember;
        }
    }
}
