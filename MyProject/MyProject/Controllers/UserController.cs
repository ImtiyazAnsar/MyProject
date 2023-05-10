using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Models;
using System.Text;
using System.Data;

namespace MyProject.Controllers
{
    public class UserController : Controller
    {
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(string Email, string Password)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["Message"] = "";
            string[,] Param = new string[,]

                  {
                    { "@Email",Email },
                     { "@Password",Password },
                };
            DataTable dt = Common.ExecuteProcedure("UserLogin", Param);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Status"].ToString() == "1")
                {
                    HttpContext.Session["Email"] = dt.Rows[0]["EmailId"].ToString();
                    HttpContext.Session["Name"] = dt.Rows[0]["UserName"].ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Response.Write("<script>alert('Invalid User Id Or Password')</script>");
                  //  return RedirectToAction("UserLogin");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("UserLogin", "User");
        }

        public ActionResult UserRegistration()
        {
            return View();
        }

        public JsonResult IU_New_Reistration(string Id, string CountryName, string StateName, string CityName, string Name, string FatherName, string MotherName, string Address, string Number, string Email, string Password, string DOB, string Gender, bool IsActive)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["Message"] = "";
            try
            {
                string[,] Param = new string[,]
                {
                    {"@id",Id },
                    {"@CountryName",CountryName },
                    {"@StateName",StateName },
                    {"@CityName",CityName },
                    {"@Name",Name },
                    {"@FatherName",FatherName },
                    {"@MotherName",MotherName },                
                    {"@Address",Address },
                    {"@Number",Number },
                    {"@Email",Email },
                    {"@Password",Password },
                    {"@DOB",DOB },
                    {"@Gender",Gender },
                    {"@IsActive",IsActive?"1":"0" },
                };
                DataTable dt = Common.ExecuteProcedure("IU_New_Reistration", Param);
                if (dt.Rows.Count > 0)
                {
                    dic["Message"] = dt.Rows[0]["Msg"].ToString();
                }

            }
            catch (Exception ex)
            {
                dic["Message"] = ex.Message;
            }
            return Json(dic);
        }

        public JsonResult ShowRegistrationData()
        {
            StringBuilder Sb = new StringBuilder();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["Message"] = "";
            dic[""] = "";
            try
            {
                DataTable dt = Common.ExecuteProcedure("ShowRegistrationData");
                if (dt.Rows.Count > 0)
                {
                    Sb.Append("<table class='table table-responsive' id='tbl'><tr'>");
                    Sb.Append("<th>Edit</th>");
                    Sb.Append("<th>Delete</th>");
                    Sb.Append("<th>CountryName</th>");
                    Sb.Append("<th>StateName</th>");
                    Sb.Append("<th>CityName</th>");
                    Sb.Append("<th>Name</th>");
                    Sb.Append("<th>FatherName</th>");
                    Sb.Append("<th>MotherName</th>");                 
                    Sb.Append("<th>Address</th>");
                    Sb.Append("<th>Number</th>");
                    Sb.Append("<th>Email</th>");
                    Sb.Append("<th>Password</th>");
                    Sb.Append("<th>DOB</th>");
                    Sb.Append("<th>Gender</th>");
                    Sb.Append("<th>IsActive</th></tr>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Sb.Append("<tr id='tableRow'>");
                        Sb.Append("<td > <button onclick='EditRecord(" + dt.Rows[i]["Id"].ToString() + ")'  id='Edit'>Edit</button></td>");//class='btn-info'
                        Sb.Append("<td> <button onclick='DeleteRecord(" + dt.Rows[i]["Id"].ToString() + ")' id='Delete'>Delete</button></td>");//class='btn-warning'
                        Sb.Append("<td>" + dt.Rows[i]["CountryName"].ToString() + "</td>");
                        Sb.Append("<td>" + dt.Rows[i]["StateName"].ToString() + "</td>");
                        Sb.Append("<td>" + dt.Rows[i]["CityName"].ToString() + "</td>");
                        Sb.Append("<td>" + dt.Rows[i]["Name"].ToString() + "</td>");
                        Sb.Append("<td>" + dt.Rows[i]["FatherName"].ToString() + "</td>");
                        Sb.Append("<td>" + dt.Rows[i]["MotherName"].ToString() + "</td>");
                        Sb.Append("<td>" + dt.Rows[i]["Number"].ToString() + "</td>");
                        Sb.Append("<td>" + dt.Rows[i]["Address"].ToString() + "</td>");
                        Sb.Append("<td>" + dt.Rows[i]["Email"].ToString() + "</td>");
                        Sb.Append("<td>************</td>");
                        Sb.Append("<td>" + dt.Rows[i]["DOB"].ToString() + "</td>");
                        Sb.Append("<td>" + dt.Rows[i]["Gender"].ToString() + "</td>");
                        Sb.Append("<td>" + dt.Rows[i]["IsActive"].ToString() + "</td> </tr>");
                    }
                    Sb.Append("</table>");
                    dic["Grid"] = Sb.ToString();

                }
            }
            catch (Exception ex)
            {
                dic["Message"] = ex.Message;
            }
            return Json(dic);
        }

        public JsonResult EditRecord(string Id)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["Message"] = "";
            dic["Id"] = "";
            dic["CountryName"] = "";
            dic["StateName"] = "";
            dic["CityName"] = "";
            dic["Name"] = "";
            dic["FatherName"] = "";
            dic["MotherName"] = "";         
            dic["Address"] = "";
            dic["Number"] = "";
            dic["Email"] = "";
            dic["Password"] = "";
            dic["DOB"] = "";
            dic["Gender"] = "";
            dic["IsActive"] = "";

            try
            {
                string[,] Param = new string[,]
                {
                    {"@Id",Id }
                };
                DataTable dt = Common.ExecuteProcedure("ShowRegistrationData", Param);
                if (dt.Rows.Count > 0)
                {
                    dic["Id"] = dt.Rows[0]["Id"].ToString();
                    dic["CountryName"] = dt.Rows[0]["CountryName"].ToString();
                    dic["StateName"] = dt.Rows[0]["StateName"].ToString();
                    dic["CityName"] = dt.Rows[0]["CityName"].ToString();
                    dic["Name"] = dt.Rows[0]["Name"].ToString();
                    dic["FatherName"] = dt.Rows[0]["FatherName"].ToString();
                    dic["MotherName"] = dt.Rows[0]["MotherName"].ToString();               
                    dic["Address"] = dt.Rows[0]["Address"].ToString();
                    dic["Number"] = dt.Rows[0]["Number"].ToString();
                    dic["Email"] = dt.Rows[0]["Email"].ToString();
                    dic["Password"] = dt.Rows[0]["Password"].ToString();
                    dic["DOB"] = dt.Rows[0]["DOB"].ToString();
                    dic["Gender"] = dt.Rows[0]["Gender"].ToString();
                    dic["IsActive"] = dt.Rows[0]["IsActive"].ToString();
                }
            }
            catch (Exception ex)
            {
                dic["Message"] = ex.Message;
            }
            return Json(dic);
        }

        public JsonResult DeleteRecord(string Id)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["Message"] = "";
            try
            {
                string[,] Param = new string[,]
                {
                    {"@Id",Id }
                };
                DataTable dt = Common.ExecuteProcedure("DeleteRecord", Param);
                if (dt.Rows.Count > 0)
                {
                    dic["Message"] = dt.Rows[0]["Msg"].ToString();
                }
            }
            catch (Exception ex)
            {
                dic["Message"] = ex.Message;
            }
            return Json(dic);
        }
        //--------------------------------------------------State Binding----------------------------///

        public JsonResult StateBind(string CountryName)
        {
            StringBuilder Sb = new StringBuilder();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["Message"] = "";
            try
            {
                string[,] Param = new string[,]
                {

                    {"@CountryName",CountryName },
                };
                DataTable dt = Common.ExecuteProcedure("StateBind", Param);
                Sb.Append("<select>");
                Sb.Append("<option value=''>-----Select State--------</option> ");
                if (dt.Rows.Count > 0)
                {
                    dic["Status"] = dt.Rows[0]["Status"].ToString();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Sb.Append("<option value='"+dt.Rows[i]["StateName"].ToString()+"'>"+dt.Rows[i]["StateName"].ToString()+"</option>");
                    }
                }
                Sb.Append("</select>");
                dic["StateName"] = Sb.ToString();

            }
            catch (Exception ex)
            {
                dic["Message"] = ex.Message;
            }
            return Json(dic);

        }
    }
}