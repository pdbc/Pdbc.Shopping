namespace Pdbc.Shopping.Core.CQRS.Resources.Errors.List
{
    public class ListErrorMessagesQuery : IQuery<ListErrorMessagesViewModel>
    {
        public string Language { get; set; }
    }
}