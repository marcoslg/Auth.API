using Auth.Application.Permisions.Queries.GetByUser.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Auth.Application.UT.Permissions.DataProvaiders
{
    public class UserGetPermissionsQueryNoValidProvider : TheoryData<GetPermissionsQuery>
    {
        public UserGetPermissionsQueryNoValidProvider()
        {
            Add(new GetPermissionsQuery());
            Add(new GetPermissionsQuery()
            { 
                ApplicationName ="test"
            });
            Add(new GetPermissionsQuery()
            { 
                Username ="test"
            });
        }
    }
}
