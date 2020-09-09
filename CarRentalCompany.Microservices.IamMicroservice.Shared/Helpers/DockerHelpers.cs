﻿using Microsoft.Extensions.Configuration;
using CarRentalCompany.Microservices.IamMicroservice.Shared.Configuration.Common;

namespace CarRentalCompany.Microservices.IamMicroservice.Shared.Helpers
{
    public class DockerHelpers
    {
        public static void UpdateCaCertificates()
        {
            "update-ca-certificates".Bash();
        }

        public static void ApplyDockerConfiguration(IConfiguration configuration)
        {
            var dockerConfiguration = configuration.GetSection(nameof(DockerConfiguration)).Get<DockerConfiguration>();

            if (dockerConfiguration != null && dockerConfiguration.UpdateCaCertificate)
            {
                UpdateCaCertificates();
            }
        }
    }
}




