﻿using ApollosLibrary.IDP.Application.Enums;
using ApollosLibrary.IDP.Application.Exceptions;
using ApollosLibrary.WebApi.Filters;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApollosLibrary.IDP.Filters
{
    class ErrorNode
    {
        [JsonProperty("Message")]
        public string Message { get; set; }
    }

    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        //private readonly ILogger _logger;
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        //public ApiExceptionFilterAttribute(ILogger logger)
        public ApiExceptionFilterAttribute()
        {
            //_logger = logger;

            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(BadRequestException), HandleBadRequestException },
                { typeof(NotFoundException), HandleObjectNotFoundException },
                { typeof(UnauthorizedException), HandleUnauthorizedException },
                { typeof(ValidationException), HandleValidationException }
            };

        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();

            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }


        }

        private void HandleValidationException(ExceptionContext context)
        {
            List<string> errors = new();
            var exception = context.Exception as Application.Common.Exceptions.ValidationException;
            foreach(var e in exception.Errors)
            {
                //_logger.Warn("Validation Error {ErrorCode}: {ErrorValue}", e);
                var message = ErrorCodeTranslation.GetErrorMessageFromCode((int)Enum.Parse(typeof(ErrorCodeEnum), e, true));
                if (message != null)
                {
                    errors.Add(message);
                }
                //else
                    //_logger.Error("Cannot find ErrorCode {ErrorCode}", e);
            }
            context.Result = new BadRequestObjectResult(errors);

            context.ExceptionHandled = true;
        }

        private void HandleBadRequestException(ExceptionContext context)
        {
            var exception = context.Exception as ErrorCodeException;
            List<string> errors = new ();

            string message = ErrorCodeTranslation.GetErrorMessageFromCode((int)exception.ErrorCode);
           // _logger.Warn("Bad data in request. Error {ErrorCode}: {ErrorValue}", exception.ErrorCode, exception.Message);
            //if (message == null)
                //_logger.Error("Cannot find ErrorCode {ErrorCode}", exception.ErrorCode);
            //else
            if (message != null)
                errors.Add(message);

            context.Result = new ObjectResult(errors)
            {
                StatusCode = StatusCodes.Status400BadRequest
            };

            context.ExceptionHandled = true;
        }

        private void HandleObjectNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as ErrorCodeException;
            List<string> errors = new ();

            string message = ErrorCodeTranslation.GetErrorMessageFromCode((int)exception.ErrorCode);
            //_logger.Warn("Object not found. Error {ErrorCode}: {ErrorValue}", exception.ErrorCode, exception.Message);
            if (message != null)
                //_logger.Error("Cannot find ErrorCode {ErrorCode}", exception.ErrorCode);
            //else
                errors.Add(message);

            context.Result = new ObjectResult(errors)
            {
                StatusCode = StatusCodes.Status404NotFound
            };

            context.ExceptionHandled = true;
        }

        private void HandleUnauthorizedException(ExceptionContext context)
        {
            var exception = context.Exception as UnauthorizedException;
            List<string> errors = new ();

            string message = ErrorCodeTranslation.GetErrorMessageFromCode((int)exception.ErrorCode);
            //_logger.Warn("Authorisation Error {ErrorCode}: {ErrorValue}", exception.ErrorCode, exception.Message);
            if (message == null)
            {
                message = ErrorCodeTranslation.GetErrorMessageFromCode((int)ErrorCodeEnum.SystemError);
                //_logger.Error("Cannot find ErrorCode {ErrorCode}", exception.ErrorCode);
            }

            errors.Add(message);

            context.Result = new ObjectResult(errors)
            {
                StatusCode = StatusCodes.Status403Forbidden
            };

            context.ExceptionHandled = true;
        }
    }
}
