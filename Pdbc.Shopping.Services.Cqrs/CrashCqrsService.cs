using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Pdbc.Shopping.Api.Contracts.Services;
using Pdbc.Shopping.Common.Exceptions;
using Pdbc.Shopping.Common.Validation;
using Pdbc.Shopping.I18N;
using Pdbc.Shopping.Services.Cqrs.Base;
using Pdbc.Shopping.Services.Cqrs.Interfaces;

namespace Pdbc.Shopping.Services.Cqrs
{
    public class CrashCqrsService : CqrsService, ICrashCqrsService
    {
        public CrashCqrsService(IMediator mediator, IMapper mapper, ValidationBag validationBag) : base(mediator, mapper, validationBag)
        {
        }

        public Task CrashGet(int exceptionType)
        {
            ThrowExceptionForExceptionType(exceptionType);
            return Task.CompletedTask;
        }

        public Task CrashPost(int exceptionType)
        {
            ThrowExceptionForExceptionType(exceptionType);
            return Task.CompletedTask;
        }


        private void ThrowExceptionForExceptionType(int exceptionType)
        {
            switch (exceptionType)
            {
                case 0:
                    throw new ShoppingException(nameof(ErrorResources.UnexpectedGeneralError));
                case 1:
                    throw new NullReferenceException($"You requested ExceptionType: {exceptionType}");
                default:
                    throw new ShoppingException($"You requested no valid exception type");
            }
        }
    }
}