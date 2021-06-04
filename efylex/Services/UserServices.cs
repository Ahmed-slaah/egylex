using efylex.Data;
using egylex.Models.Movies;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace egylex.Services
{
    public interface IUserServices
    {
    }
    public class UserServices:IUserServices
    {
        readonly ApplicationDbContext _db;
        public UserServices(ApplicationDbContext db)
        {
            _db = db;
        }
       
    }
}
//IOC