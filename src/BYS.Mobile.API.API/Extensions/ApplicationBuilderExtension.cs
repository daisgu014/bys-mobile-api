using BYS.Mobile.API.Shared.Enums;
using BYS.Mobile.API.Shared.Exceptions;
using BYS.Mobile.API.Shared.Models.Commons.Responses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace BYS.Mobile.API.API.Extensions
{
    public static class ApplicationBuilderExtension
    {
        private static readonly DefaultContractResolver _contractResolver = new DefaultContractResolver()
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        };

        public static void ConfigGlobalException<TApplicationBuilder>(this TApplicationBuilder applicationBuilder)
            where TApplicationBuilder : IApplicationBuilder
        {
            applicationBuilder.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    // Luôn set content type là JSON
                    context.Response.ContentType = "application/json";

                    // Lấy thông tin exception
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature?.Error != null)
                    {
                        var ex = contextFeature.Error;
                        object responseObj;
                        int httpStatusCode = (int)HttpStatusCode.BadRequest;

                        // Nếu là DomainException (có thể lồng thêm IResultException)
                        if (ex is DomainException domainException)
                        {
                            if (domainException is IResultException resultException)
                            {
                                responseObj = new FailActionResponse<object>()
                                {
                                    Data = resultException.Result,
                                    ErrorCode = (int)domainException.ErrorCode,
                                    SubErrorCode = domainException.SubErrorCode,
                                    SubErrorCodeString = domainException.SubErrorCodeString,
                                    ErrorMessage = domainException.Message
                                };
                            }
                            else
                            {
                                responseObj = new FailActionResponse()
                                {
                                    ErrorCode = (int)domainException.ErrorCode,
                                    ErrorCodeString = domainException.ErrorCode.ToString(),
                                    SubErrorCode = domainException.SubErrorCode,
                                    SubErrorCodeString = domainException.SubErrorCodeString,
                                    ErrorMessage = domainException.Message
                                };
                            }
                        }
                        else
                        {
                            // Tất cả lỗi khác (hệ thống, null reference, v.v.)
                            responseObj = new FailActionResponse()
                            {
                                ErrorCode = (int)ErrorCode.System,
                                ErrorCodeString = ErrorCode.System.ToString(),
                                ErrorMessage = ex.Message
                            };
                        }

                        // Chuyển StatusCode về BadRequest (400) hoặc có thể tùy chỉnh theo kiểu exception
                        context.Response.StatusCode = httpStatusCode;

                        // Viết JSON ra response
                        var json = JsonConvert.SerializeObject(responseObj, new JsonSerializerSettings
                        {
                            ContractResolver = _contractResolver,
                            Formatting = Formatting.None
                        });

                        await context.Response.WriteAsync(json);
                    }
                });
            });
        }
    }
}
