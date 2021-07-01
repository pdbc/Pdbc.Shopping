






using System;
using System.Linq;
using Pdbc.Shopping.Common;
namespace Pdbc.Shopping.Core.CQRS.Resources.ErrorMessages.Get {
    public partial class GetErrorMessageQueryBuilder : ObjectBuilder<Pdbc.Shopping.Core.CQRS.Resources.ErrorMessages.Get.GetErrorMessageQuery>
	{
       protected System.String Language { get; set; }		
public GetErrorMessageQueryBuilder WithLanguage(System.String language)
{
    this.Language = language;
	return this;
}	
protected System.String Key { get; set; }		
public GetErrorMessageQueryBuilder WithKey(System.String key)
{
    this.Key = key;
	return this;
}	

       
public override GetErrorMessageQuery Build()
{
    var item = (GetErrorMessageQuery)Activator.CreateInstance(typeof(GetErrorMessageQuery));
    	
		
	item.Language = Language;
	    	
		
	item.Key = Key;
	    
    return item;
}
      
    }
}

namespace Pdbc.Music.Core.CQRS.ErrorMessages.Get {
    public partial class GetErrorMessageViewModelBuilder : ObjectBuilder<Pdbc.Music.Core.CQRS.ErrorMessages.Get.GetErrorMessageViewModel>
	{
       protected System.String Message { get; set; }		
public GetErrorMessageViewModelBuilder WithMessage(System.String message)
{
    this.Message = message;
	return this;
}	

       
public override GetErrorMessageViewModel Build()
{
    var item = (GetErrorMessageViewModel)Activator.CreateInstance(typeof(GetErrorMessageViewModel));
    	
		
	item.Message = Message;
	    
    return item;
}
      
    }
}

namespace Pdbc.Shopping.Core.CQRS.Resources.ErrorMessages.List {
    public partial class ListErrorMessagesQueryBuilder : ObjectBuilder<Pdbc.Shopping.Core.CQRS.Resources.ErrorMessages.List.ListErrorMessagesQuery>
	{
       protected System.String Language { get; set; }		
public ListErrorMessagesQueryBuilder WithLanguage(System.String language)
{
    this.Language = language;
	return this;
}	

       
public override ListErrorMessagesQuery Build()
{
    var item = (ListErrorMessagesQuery)Activator.CreateInstance(typeof(ListErrorMessagesQuery));
    	
		
	item.Language = Language;
	    
    return item;
}
      
    }
}

namespace Pdbc.Shopping.Core.CQRS.Resources.ErrorMessages.List {
    public partial class ListErrorMessagesViewModelBuilder : ObjectBuilder<Pdbc.Shopping.Core.CQRS.Resources.ErrorMessages.List.ListErrorMessagesViewModel>
	{
       protected System.Collections.Generic.IDictionary<System.String, System.String> Resources { get; set; }		
public ListErrorMessagesViewModelBuilder WithResources(System.Collections.Generic.IDictionary<System.String, System.String> resources)
{
    this.Resources = resources;
	return this;
}	

       
public override ListErrorMessagesViewModel Build()
{
    var item = (ListErrorMessagesViewModel)Activator.CreateInstance(typeof(ListErrorMessagesViewModel));
    	
		
	item.Resources = Resources;
	    
    return item;
}
      
    }
}

