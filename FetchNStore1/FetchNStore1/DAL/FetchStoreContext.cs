using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FetchNStore1.Models;
using System.Data.Entity;

namespace FetchNStore1.DAL
{
    public class FetchStoreContext
    {
        public virtual DbSet<Response> Responses { get; set; }
    }
}