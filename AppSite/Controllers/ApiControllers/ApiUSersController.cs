

using Application.Srvices;
using Modal;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using System.Web.Http.Results;
using System.Collections.Generic;
using System.Web.Http.ModelBinding;

namespace CelebsApp.Controllers.ApiControllers
{



    public class ApiUsersController : ApiController
    {
        private readonly UsersService service;

        public ApiUsersController()
        {
            service = new UsersService();
        }
        public HttpResponseMessage GetAllUsers()
        {
            var result = service.Get();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }


        [HttpGet]
        public HttpResponseMessage GetUser(string search)
        {
            if (!string.IsNullOrEmpty(search))
                return Request.CreateResponse(HttpStatusCode.OK, service.Get(x => x.FirstName.Contains(search)));

            return Request.CreateResponse(HttpStatusCode.OK, service.Get());
        }


        [HttpPost]
        public HttpResponseMessage CreateUser(User user)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, ErrMsgs(ModelState.Values));

            return CreateResponseMessage(() =>
           {
               return service.Create(user);
           });
        }



        [HttpPost]
        public HttpResponseMessage UpdateUser(User user)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, ErrMsgs(ModelState.Values));


            return CreateResponseMessage(() =>
            {
                return service.Edit(user);
            });
        }


        [HttpPost]
        public HttpResponseMessage DeleteUser(User user)
        {


            return CreateResponseMessage(() =>
           {
               return service.Delete(user);
           });
        }


        private HttpResponseMessage CreateResponseMessage(Func<int> func)
        {
            var test = func.Invoke();

            if (test > -1)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }

            return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
        }


        private string ErrMsgs(ICollection<ModelState> values)
        {
            return string.Join(",", values.SelectMany(x => x.Errors).Select(x => x.Exception));
        }
    }
}