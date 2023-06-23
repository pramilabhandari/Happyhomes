using Dapper;
using Helper.Dapper;
using Models.Model;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class UserService:IUser
    {

        public UserService() { }
        public async Task<dynamic> user(Models.Model.User users) // a requ est
        {
            var res = new ResponseValues(); //model class ko obj pass to res(response variable)

            {
                var sql = "sp_user"; // var is data type not integer "sp_blog" is store procedure name.
                var parameters = new DynamicParameters(); // this is inbuilt class(Dapper ko class) yo class store procedure ma parameter pathauana use hunxa. so yasko obj refrence variable ma pathako
                                                          // model ma banako prop(req) lai service bata server ma pathauna @ use garne
                                                          // it add @primary property to the parameters
                parameters.Add("@firstname", users.FirstName);
                parameters.Add("@middlename", users.MiddleName);

                parameters.Add("@lastname", users.LastName);
                parameters.Add("@userimage", users.UserImage);
                parameters.Add("@usertype", users.UserType);
                parameters.Add("@email", users.Email);
                parameters.Add("@userid", users.UserID);
                parameters.Add("@password", users.Password);
                parameters.Add("@flag", users.Flag);
                parameters.Add("@contact", users.Contact);
                parameters.Add("@phn_num", users.PhnNum);
                parameters.Add("@address", users.Address);
                parameters.Add("@district", users.District);
                parameters.Add("@defhousenum", users.DefHouseNum);
                parameters.Add("@isallow", users.IsAllow);
                parameters.Add("@isverified", users.IsVerified);
                parameters.Add("@branchid", users.BranchID);
                parameters.Add("@fiscalid", users.FiscalID);
                parameters.Add("@memid", users.MemID);
                parameters.Add("@isallow", users.IsAllow);
                parameters.Add("@isactive", users.IsActive);







                var data = await DbHelper.RunProc<dynamic>(sql, parameters); // it run the stored procedure with the help of DbHelper and pass result to the data.
                if (data.Count() != 0 && data.FirstOrDefault().Message == null)
                {
                    res.Values = data.ToList();
                    res.StatusCode = 200;
                    res.Message = "Success";

                }
                else if (data.Count() == 1 && data.FirstOrDefault().Message != null) //here is error combined in stored procedure
                {
                    res.Values = null;
                    res.StatusCode = data.FirstOrDefault().StatusCode;
                    res.Message = data.FirstOrDefault().Message;

                }
                else
                {
                    res.Values = null;
                    res.StatusCode = 400;
                    res.Message = "no data";

                }
            }
            return res;
        }
    }
}
