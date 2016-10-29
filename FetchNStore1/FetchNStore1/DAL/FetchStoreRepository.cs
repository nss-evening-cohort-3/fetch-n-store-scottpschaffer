using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FetchNStore1.Models;

namespace FetchNStore1.DAL
{
    public class FetchStoreRepository
    {
        public FetchStoreContext Context { get; set; }

        public FetchStoreRepository()
        {
            Context = new FetchStoreContext();
        }

        public FetchStoreRepository(FetchStoreContext _context)
        {
            Context = _context;
        }

        public List<Response> GetResponses()
        {
            return Context.Responses.ToList();
        }

        public void AddResponse(Response response)
        {
            Context.Responses.Add(response);
            Context.SaveChanges();
        }

        public void AddResonse(string status_code, string url, int response_time)
        {
            Response response = new Response { StatusCode = status_code, URL = url, ResponseTime = response_time };
            Context.Responses.Add(response);
            Context.SaveChanges();
        }

        public Response FindResponseByURL(string url)
        {
            Response foundResponse = Context.Responses.FirstOrDefault(a => a.URL.ToLower() == url.ToLower());
            return foundResponse;
        }

        public Response RemoveResponse(string url)
        {
            Response found_response = FindResponseByURL(url);
            if (found_response != null)
            {
                Context.Responses.Remove(found_response);
                Context.SaveChanges();
            }
            return found_response;
        }

    }
}