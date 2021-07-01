using Pdbc.Music.Core.CQRS.ErrorMessages.Get;

namespace Pdbc.Shopping.Core.CQRS.Resources.ErrorMessages.Get
{
    public class GetErrorMessageQuery : IQuery<GetErrorMessageViewModel>
    {
        public string Language { get; set; }

        public string Key { get; set; }
    }
}