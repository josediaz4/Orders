﻿using System.Net;

namespace Orders.Frontend.Repositories
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public T? Response { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponseMessage { get; }

        public async Task<string?> GetErrorMessageAsync()
        {
            if (!Error)
            {
                return null;
            }

            var statusCode = HttpResponseMessage.StatusCode;
            if (statusCode == HttpStatusCode.BadRequest)
            {
                return "Recurso no encontrado.";
            }

            if (statusCode == HttpStatusCode.NotFound)
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();
            }

            if (statusCode == HttpStatusCode.Unauthorized)
            {
                return "Tienes que estar logueado para realizar esta operación.";
            }

            if (statusCode == HttpStatusCode.Forbidden)
            {
                return "No tienes permiso para realizar esta operación";
            }

            return "Ha ocurrido un error insesperado.";
        }


    }
}
