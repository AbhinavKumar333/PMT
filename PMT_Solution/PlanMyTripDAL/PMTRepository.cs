using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
namespace PlanMyTripDAL
{
    public class PMTRepository
    {
        PlanMyTripDBEntities planMyTripDBContext = null;
        public PMTRepository()
        {
            planMyTripDBContext = new PlanMyTripDBEntities();
        }
        public PMTRepository(PlanMyTripDBEntities context)
        {
            planMyTripDBContext = context;
        }
        public bool AddUser(User userEnt)
        {
            planMyTripDBContext.Users.Add(userEnt);
            int result = planMyTripDBContext.SaveChanges();
            if (result > 0) { return true; }
            else { return false; }
        }
        public bool UpdateUser(User user)
        {
            User tuser = planMyTripDBContext.Users.Find(user.UserId);
            tuser.UserId = user.UserId;
            tuser.FirstName = user.FirstName;
            tuser.LastName = user.LastName;
            tuser.Password = user.Password;
            tuser.EmailId = user.EmailId;
            int result = planMyTripDBContext.SaveChanges();
            if (result > 0) { return true; }
            else { return false; }
        }
        public bool DeleteUser(int usrId)
        {
            User tuser = planMyTripDBContext.Users.Find(usrId);
            planMyTripDBContext.Users.Remove(tuser);
            int result = planMyTripDBContext.SaveChanges();
            if (result > 0) { return true; }
            else { return false; }
        }
        public int ValidateUser(string emailId,string password)
        {
            List<User> result = (from c in planMyTripDBContext.Users
                          where c.EmailId == emailId && c.Password == password select c).ToList();
            if (result.Count > 0) { return result.Count; }
            else { return -1; }
        }
        public List<User> ViewAll()
        {
            return planMyTripDBContext.Users.ToList();
        }
        public User View(int id)
        {
            return planMyTripDBContext.Users.Find(id);
        }



    }
}
