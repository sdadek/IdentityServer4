﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Hosting;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer4.Endpoints.Results
{
    /// <summary>
    /// Result for the jwks document
    /// </summary>
    /// <seealso cref="IdentityServer4.Hosting.IEndpointResult" />
    public class JsonWebKeysResult : IEndpointResult
    {
        /// <summary>
        /// Gets the web keys.
        /// </summary>
        /// <value>
        /// The web keys.
        /// </value>
        public IEnumerable<JsonWebKey> WebKeys { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonWebKeysResult"/> class.
        /// </summary>
        /// <param name="webKeys">The web keys.</param>
        public JsonWebKeysResult(IEnumerable<JsonWebKey> webKeys)
        {
            WebKeys = webKeys;
        }

        /// <summary>
        /// Executes the result.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <returns></returns>
        public Task ExecuteAsync(HttpContext context)
        {
            return context.Response.WriteJsonAsync(new { keys = WebKeys });
        }
    }
}