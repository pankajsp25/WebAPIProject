using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class EmpController : ApiController
    {
      
        // GET api/<controller>
        public IEnumerable<emp> Get()
        {
            WebAPIEntities1 emplist = new WebAPIEntities1();
            return emplist.emps.ToList().OrderBy(e=>e.emp_name);
            
            //return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [BasicAuthentication]
        public HttpResponseMessage Get(int id)
        {
            WebAPIEntities1 emplist = new WebAPIEntities1();
            var entity= emplist.emps.FirstOrDefault(e => e.id == id);

            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            }


           // return "";
        }

        // POST api/<controller>

        //public HttpResponseMessage Post([FromBody] emp emp)
        //{
        //    try
        //    {
        //        WebAPIEntities1 emplist = new WebAPIEntities1();
        //        var entity = emplist.emps.FirstOrDefault(e => e.id == emp.id);
        //        if (entity != null)
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.Found, "This item already exists");
        //        }
        //        else
        //        {
        //            emplist.emps.Add(emp);
        //            emplist.SaveChanges();


        //            return Request.CreateResponse(HttpStatusCode.Created, emp);
        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}

        [HttpPost]
        [ActionName("Add")]
        public HttpResponseMessage Add( emp emp)
        {
            try
            {
                WebAPIEntities1 emplist = new WebAPIEntities1();
                var entity = emplist.emps.FirstOrDefault(e => e.id == emp.id);
                if (entity != null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Found, "This item already exists");
                }
                else
                {
                    emplist.emps.Add(emp);
                    emplist.SaveChanges();


                    return Request.CreateResponse(HttpStatusCode.Created, emp);
                }



            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}