







using System;
using System.Linq;

using AutoMapper;

public class RequestToCqrsMappings : Profile
{
    public RequestToCqrsMappings()
    {
        AddGlobalIgnore("Notifications");

          
// ShoppingRequest ShoppingCommand
  
// ShoppingRequest ShoppingCommand
  
// ShoppingRequest ShoppingCommand
  
// ShoppingRequest ShoppingCommand
  
// ShoppingRequest ShoppingCommand
  
// ShoppingRequest ShoppingCommand
  
// ShoppingRequest ShoppingCommand
  
// ShoppingRequest ShoppingCommand
          
// ShoppingResponse ShoppingResult
  
// ShoppingResponse ShoppingResult
  
// ShoppingResponse ShoppingResult
  
// ShoppingResponse ShoppingResult
  
// ShoppingResponse ShoppingResult
  
// ShoppingResponse ShoppingResult
  
// ShoppingResponse ShoppingResult
  
// ShoppingResponse ShoppingResult
          
// DependencyCheckRequest DependencyCheckCommand
CreateMap<Pdbc.Shopping.Api.Contracts.Requests.Health.DependencyCheckRequest, Pdbc.Shopping.Core.CQRS.Health.DependencyCheck.DependencyCheckCommand>();
          
// DependencyCheckResponse DependencyCheckResult
  
// DependencyCheckResponse DependencyCheckResult
CreateMap<Pdbc.Shopping.Core.CQRS.Health.DependencyCheck.DependencyCheckResult, Pdbc.Shopping.Api.Contracts.Requests.Health.DependencyCheckResponse>();
          
// LifelineCheckRequest LifelineCheckCommand
  
// LifelineCheckRequest LifelineCheckCommand
  
// LifelineCheckRequest LifelineCheckCommand
CreateMap<Pdbc.Shopping.Api.Contracts.Requests.Health.LifelineCheckRequest, Pdbc.Shopping.Core.CQRS.Health.LifelineCheck.LifelineCheckCommand>();
          
// LifelineCheckResponse LifelineCheckResult
  
// LifelineCheckResponse LifelineCheckResult
  
// LifelineCheckResponse LifelineCheckResult
  
// LifelineCheckResponse LifelineCheckResult
CreateMap<Pdbc.Shopping.Core.CQRS.Health.LifelineCheck.LifelineCheckResult, Pdbc.Shopping.Api.Contracts.Requests.Health.LifelineCheckResponse>();
          
// GetErrorMessageRequest GetErrorMessageQuery
  
// GetErrorMessageRequest GetErrorMessageQuery
  
// GetErrorMessageRequest GetErrorMessageQuery
  
// GetErrorMessageRequest GetErrorMessageQuery
  
// GetErrorMessageRequest GetErrorMessageQuery
CreateMap<Pdbc.Shopping.Api.Contracts.Requests.Errors.GetErrorMessageRequest, Pdbc.Shopping.Core.CQRS.Resources.Errors.Get.GetErrorMessageQuery>();
          
// GetErrorMessageResponse GetErrorMessageViewModel
  
// GetErrorMessageResponse GetErrorMessageViewModel
  
// GetErrorMessageResponse GetErrorMessageViewModel
  
// GetErrorMessageResponse GetErrorMessageViewModel
  
// GetErrorMessageResponse GetErrorMessageViewModel
  
// GetErrorMessageResponse GetErrorMessageViewModel
CreateMap<Pdbc.Shopping.Core.CQRS.Resources.Errors.Get.GetErrorMessageViewModel, Pdbc.Shopping.Api.Contracts.Requests.Errors.GetErrorMessageResponse>();
          
// ListErrorMessagesRequest ListErrorMessagesQuery
  
// ListErrorMessagesRequest ListErrorMessagesQuery
  
// ListErrorMessagesRequest ListErrorMessagesQuery
  
// ListErrorMessagesRequest ListErrorMessagesQuery
  
// ListErrorMessagesRequest ListErrorMessagesQuery
  
// ListErrorMessagesRequest ListErrorMessagesQuery
  
// ListErrorMessagesRequest ListErrorMessagesQuery
CreateMap<Pdbc.Shopping.Api.Contracts.Requests.Resources.Errors.ListErrorMessagesRequest, Pdbc.Shopping.Core.CQRS.Resources.Errors.List.ListErrorMessagesQuery>();
          
// ListErrorMessagesResponse ListErrorMessagesViewModel
  
// ListErrorMessagesResponse ListErrorMessagesViewModel
  
// ListErrorMessagesResponse ListErrorMessagesViewModel
  
// ListErrorMessagesResponse ListErrorMessagesViewModel
  
// ListErrorMessagesResponse ListErrorMessagesViewModel
  
// ListErrorMessagesResponse ListErrorMessagesViewModel
  
// ListErrorMessagesResponse ListErrorMessagesViewModel
  
// ListErrorMessagesResponse ListErrorMessagesViewModel
CreateMap<Pdbc.Shopping.Core.CQRS.Resources.Errors.List.ListErrorMessagesViewModel, Pdbc.Shopping.Api.Contracts.Requests.Resources.Errors.ListErrorMessagesResponse>();
            }
}
