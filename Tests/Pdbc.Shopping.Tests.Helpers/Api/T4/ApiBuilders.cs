







using System;
using System.Linq;

using Pdbc.Shopping.Common;
namespace Pdbc.Shopping.Api.Contracts.Requests {
    public partial class ShoppingRequestBuilder : ObjectBuilder<Pdbc.Shopping.Api.Contracts.Requests.ShoppingRequest>
	{
       
       
public override ShoppingRequest Build()
{
    var item = (ShoppingRequest)Activator.CreateInstance(typeof(ShoppingRequest));
    
    return item;
}
      
    }
}

namespace Pdbc.Shopping.Api.Contracts.Requests {
    public partial class ShoppingResponseBuilder : ObjectBuilder<Pdbc.Shopping.Api.Contracts.Requests.ShoppingResponse>
	{
       protected Pdbc.Shopping.Api.Contracts.Requests.ValidationResult Notifications { get; set; }		
public ShoppingResponseBuilder WithNotifications(Pdbc.Shopping.Api.Contracts.Requests.ValidationResult notifications)
{
    this.Notifications = notifications;
	return this;
}	

       
public override ShoppingResponse Build()
{
    var item = (ShoppingResponse)Activator.CreateInstance(typeof(ShoppingResponse));
    	
		
	item.Notifications = Notifications;
	    
    return item;
}
      
    }
}

namespace Pdbc.Shopping.Api.Contracts.Requests.Health {
    public partial class DependencyCheckRequestBuilder : ObjectBuilder<Pdbc.Shopping.Api.Contracts.Requests.Health.DependencyCheckRequest>
	{
       
       
public override DependencyCheckRequest Build()
{
    var item = (DependencyCheckRequest)Activator.CreateInstance(typeof(DependencyCheckRequest));
    
    return item;
}
      
    }
}

namespace Pdbc.Shopping.Api.Contracts.Requests.Health {
    public partial class DependencyCheckResponseBuilder : ObjectBuilder<Pdbc.Shopping.Api.Contracts.Requests.Health.DependencyCheckResponse>
	{
       protected Pdbc.Shopping.Api.Contracts.Requests.ValidationResult Notifications { get; set; }		
public DependencyCheckResponseBuilder WithNotifications(Pdbc.Shopping.Api.Contracts.Requests.ValidationResult notifications)
{
    this.Notifications = notifications;
	return this;
}	

       
public override DependencyCheckResponse Build()
{
    var item = (DependencyCheckResponse)Activator.CreateInstance(typeof(DependencyCheckResponse));
    	
		
	item.Notifications = Notifications;
	    
    return item;
}
      
    }
}

namespace Pdbc.Shopping.Api.Contracts.Requests.Health {
    public partial class LifelineCheckRequestBuilder : ObjectBuilder<Pdbc.Shopping.Api.Contracts.Requests.Health.LifelineCheckRequest>
	{
       
       
public override LifelineCheckRequest Build()
{
    var item = (LifelineCheckRequest)Activator.CreateInstance(typeof(LifelineCheckRequest));
    
    return item;
}
      
    }
}

namespace Pdbc.Shopping.Api.Contracts.Requests.Health {
    public partial class LifelineCheckResponseBuilder : ObjectBuilder<Pdbc.Shopping.Api.Contracts.Requests.Health.LifelineCheckResponse>
	{
       protected Pdbc.Shopping.Api.Contracts.Requests.ValidationResult Notifications { get; set; }		
public LifelineCheckResponseBuilder WithNotifications(Pdbc.Shopping.Api.Contracts.Requests.ValidationResult notifications)
{
    this.Notifications = notifications;
	return this;
}	

       
public override LifelineCheckResponse Build()
{
    var item = (LifelineCheckResponse)Activator.CreateInstance(typeof(LifelineCheckResponse));
    	
		
	item.Notifications = Notifications;
	    
    return item;
}
      
    }
}

namespace Pdbc.Shopping.Api.Contracts.Requests.Errors {
    public partial class GetErrorMessageRequestBuilder : ObjectBuilder<Pdbc.Shopping.Api.Contracts.Requests.Errors.GetErrorMessageRequest>
	{
       protected System.String Language { get; set; }		
public GetErrorMessageRequestBuilder WithLanguage(System.String language)
{
    this.Language = language;
	return this;
}	
protected System.String Key { get; set; }		
public GetErrorMessageRequestBuilder WithKey(System.String key)
{
    this.Key = key;
	return this;
}	

       
public override GetErrorMessageRequest Build()
{
    var item = (GetErrorMessageRequest)Activator.CreateInstance(typeof(GetErrorMessageRequest));
    	
		
	item.Language = Language;
	    	
		
	item.Key = Key;
	    
    return item;
}
      
    }
}

namespace Pdbc.Shopping.Api.Contracts.Requests.Errors {
    public partial class GetErrorMessageResponseBuilder : ObjectBuilder<Pdbc.Shopping.Api.Contracts.Requests.Errors.GetErrorMessageResponse>
	{
       protected System.String Message { get; set; }		
public GetErrorMessageResponseBuilder WithMessage(System.String message)
{
    this.Message = message;
	return this;
}	
protected Pdbc.Shopping.Api.Contracts.Requests.ValidationResult Notifications { get; set; }		
public GetErrorMessageResponseBuilder WithNotifications(Pdbc.Shopping.Api.Contracts.Requests.ValidationResult notifications)
{
    this.Notifications = notifications;
	return this;
}	

       
public override GetErrorMessageResponse Build()
{
    var item = (GetErrorMessageResponse)Activator.CreateInstance(typeof(GetErrorMessageResponse));
    	
		
	item.Message = Message;
	    	
		
	item.Notifications = Notifications;
	    
    return item;
}
      
    }
}

namespace Pdbc.Shopping.Api.Contracts.Requests.Resources.Errors {
    public partial class ListErrorMessagesRequestBuilder : ObjectBuilder<Pdbc.Shopping.Api.Contracts.Requests.Resources.Errors.ListErrorMessagesRequest>
	{
       protected System.String Language { get; set; }		
public ListErrorMessagesRequestBuilder WithLanguage(System.String language)
{
    this.Language = language;
	return this;
}	

       
public override ListErrorMessagesRequest Build()
{
    var item = (ListErrorMessagesRequest)Activator.CreateInstance(typeof(ListErrorMessagesRequest));
    	
		
	item.Language = Language;
	    
    return item;
}
      
    }
}

namespace Pdbc.Shopping.Api.Contracts.Requests.Resources.Errors {
    public partial class ListErrorMessagesResponseBuilder : ObjectBuilder<Pdbc.Shopping.Api.Contracts.Requests.Resources.Errors.ListErrorMessagesResponse>
	{
       protected System.Collections.Generic.IDictionary<System.String, System.String> Resources { get; set; }		
public ListErrorMessagesResponseBuilder WithResources(System.Collections.Generic.IDictionary<System.String, System.String> resources)
{
    this.Resources = resources;
	return this;
}	
protected Pdbc.Shopping.Api.Contracts.Requests.ValidationResult Notifications { get; set; }		
public ListErrorMessagesResponseBuilder WithNotifications(Pdbc.Shopping.Api.Contracts.Requests.ValidationResult notifications)
{
    this.Notifications = notifications;
	return this;
}	

       
public override ListErrorMessagesResponse Build()
{
    var item = (ListErrorMessagesResponse)Activator.CreateInstance(typeof(ListErrorMessagesResponse));
    	
		
	item.Resources = Resources;
	    	
		
	item.Notifications = Notifications;
	    
    return item;
}
      
    }
}

