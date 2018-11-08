using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace JarvisEF.Service
{
    public class ApiClient
    {
        private readonly HttpClient _client;
        private readonly Uri _endpoint;

        public ApiClient(HttpClient client, Uri endpoint)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
        }
    }
}
