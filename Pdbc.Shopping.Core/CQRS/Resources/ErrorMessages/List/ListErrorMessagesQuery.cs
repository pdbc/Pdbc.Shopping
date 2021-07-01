namespace Pdbc.Shopping.Core.CQRS.Resources.ErrorMessages.List
{
    public class ListErrorMessagesQuery : IQuery<ListErrorMessagesViewModel>
    {
        public string Language { get; set; }
    }
}