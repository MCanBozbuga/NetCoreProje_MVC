using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class AppUserRole : IdentityRole<int>
    {
        public string ExampleProperty { get; set; }
    }
}
