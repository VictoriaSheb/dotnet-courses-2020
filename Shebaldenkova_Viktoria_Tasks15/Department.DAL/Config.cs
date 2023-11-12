using Department.DAL.BD;
using Department.DAL.Interfaces;
using Department.DAL.SQL;
using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department.DAL
{
    public static class Config
    {
        static public IUserDAO GetDataSourceForUser() 
        {
            if (bool.Parse(ConfigurationManager.AppSettings["useDataBase"]))
                return new UserSqlDAO();
            else
                return new UserDAO();
        }

        static public IEntityDAO<Reward,RewardShort> GetDataSourceForReward()
        {
            return new RewardSqlDAO();
            return new RewardDAO();
        }


    }
}
