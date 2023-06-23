using Dapper;
using Helper.Dapper;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class RegisterService
    {
        public RegisterService() { }
        public async Task<dynamic> register(Models.Model.Register reg) // a requ est
        {
            var res = new ResponseValues(); //model class ko obj pass to res(response variable)

            {
                var sql = "sp_register"; // var is data type not integer "sp_blog" is store procedure name.
                var parameters = new DynamicParameters(); // this is inbuilt class(Dapper ko class) yo class store procedure ma parameter pathauana use hunxa. so yasko obj refrence variable ma pathako
                                                          // model ma banako prop(req) lai service bata server ma pathauna @ use garne
                                                          // it add @primary property to the parameters
                parameters.Add("@firstname", reg.FirstName);
                parameters.Add("@middlename", reg.MiddleName);

                parameters.Add("@lastname", reg.LastName);
                parameters.Add("@userimage", reg.UserImage);
                parameters.Add("@usertype", reg.UserType);
                parameters.Add("@email", reg.Email);
                parameters.Add("@userimage", reg.UserImage);
                parameters.Add("@password", reg.Password);
                parameters.Add("@source", reg.Source);
                parameters.Add("@device", reg.Device);






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
