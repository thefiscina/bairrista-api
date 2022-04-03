using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bairrista.Dominio
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = loggerFactory?.CreateLogger<ExceptionMiddleware>() ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BairristaException ex)
            {
                if (context.Response.HasStarted)
                {
                    _logger.LogWarning("The response has already started, the http status code middleware will not be executed.");
                    throw;
                }

                //context.Response.Clear();
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                context.Response.StatusCode = (int)ex.StatusCode;
                context.Response.ContentType = ex.ContentType;
                await context.Response.WriteAsync(ex.SerializeObject());
            }

            catch (UnauthorizedAccessException ex)
            {
                if (context.Response.HasStarted)
                {
                    _logger.LogWarning("The response has already started, the http status code middleware will not be executed.");
                    throw;
                }
                //context.Response.Clear();
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                context.Response.StatusCode = 401;
                context.Response.ContentType = @"text/plain";
                await context.Response.WriteAsync(ex.Message);
            }

            catch (ArgumentNullException ex)
            {
                if (context.Response.HasStarted)
                {
                    _logger.LogWarning("The response has already started, the http status code middleware will not be executed.");
                    throw;
                }

                List<BairristaError> erros = new List<BairristaError>();
                try { erros.Add(new BairristaError { Codigo = "0", Propriedade = "Message", Messagem = ex.Message }); } catch { }
                try { erros.Add(new BairristaError { Codigo = "1", Propriedade = "ParamName", Messagem = ex.ParamName }); } catch { }

                BairristaException BairristaException = new BairristaException(ExceptionEnum.BadRequest, "Argumento nulo ou inválido", ex, erros);
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                context.Response.StatusCode = (int)BairristaException.StatusCode;
                context.Response.ContentType = BairristaException.ContentType;
                await context.Response.WriteAsync(BairristaException.SerializeObject());
                return;
            }

            catch (DbUpdateException ex)
            {
                if (context.Response.HasStarted)
                {
                    _logger.LogWarning("The response has already started, the http status code middleware will not be executed.");
                    throw;
                }

                List<BairristaError> erros = new List<BairristaError>();
                try { erros.Add(new BairristaError { Codigo = ((Npgsql.PostgresException)ex.InnerException).Code, Propriedade = ((Npgsql.PostgresException)ex.InnerException).ColumnName, Messagem = ((Npgsql.PostgresException)ex.InnerException).MessageText }); } catch { }

                BairristaException BairristaException = new BairristaException(ExceptionEnum.BadRequest, "Ocorreu erro inesperado", erros);                
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                context.Response.StatusCode = (int)BairristaException.StatusCode;
                context.Response.ContentType = BairristaException.ContentType;
                await context.Response.WriteAsync(BairristaException.SerializeObject());
            }
            catch (Exception ex)
            {
                if (context.Response.HasStarted)
                {
                    _logger.LogWarning("The response has already started, the http status code middleware will not be executed.");
                    throw;
                }

                List<BairristaError> erros = new List<BairristaError>();
                try { erros.Add(new BairristaError { Codigo = "0", Propriedade = "Message", Messagem = ex.Message }); } catch { }

                BairristaException BairristaException = new BairristaException(ExceptionEnum.InternalServerError, "Ocorreu erro inesperado no servidor", ex, erros);
                //context.Response.Clear();
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                context.Response.StatusCode = (int)BairristaException.StatusCode;
                context.Response.ContentType = BairristaException.ContentType;
                await context.Response.WriteAsync(BairristaException.SerializeObject());
                return;
            }
        }
    }
}