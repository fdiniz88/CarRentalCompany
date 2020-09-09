﻿using System.Collections.Generic;

namespace CarRentalCompany.Microservices.IamMicroservice.Admin.Api.Dtos.ApiResources
{
    public class ApiScopesApiDto
    {
        public ApiScopesApiDto()
        {
            Scopes = new List<ApiScopeApiDto>();
        }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public List<ApiScopeApiDto> Scopes { get; set; }
    }
}




