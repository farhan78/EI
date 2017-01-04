using AutoMapper;
using EI.Data.Infrastructure;
using EI.Data.Repositories;
using EI.Entities;
using EI.Web.Infrastructure.Core;
using EI.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EI.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/email")]
    public class EmailController : System.Web.Http.ApiController
    {
        public EmailController()
        {
            
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, string email)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EI"].ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("dbo.usp_add_email", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@IsVip", 1);

                    var data = cmd.ExecuteNonQuery();
                }
            }

            HttpResponseMessage response = request.CreateResponse(HttpStatusCode.Created);

            return response;
        }

    }
}