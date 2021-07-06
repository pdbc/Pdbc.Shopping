using System;
using System.Threading.Tasks;

namespace Pdbc.Shopping.Api.Contracts.Services
{
    public interface ICrashService
    {
        Task CrashGet(Int32 exceptionType);

        Task CrashPost(Int32 exceptionType);
    }
}