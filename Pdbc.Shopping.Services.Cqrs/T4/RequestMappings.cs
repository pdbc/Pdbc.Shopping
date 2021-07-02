







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
  
// DependencyCheckRequest DependencyCheckCommand
  
// DependencyCheckRequest DependencyCheckCommand
  
// DependencyCheckRequest DependencyCheckCommand
  
// DependencyCheckRequest DependencyCheckCommand
  
// DependencyCheckRequest DependencyCheckCommand
  
// DependencyCheckRequest DependencyCheckCommand
  
// DependencyCheckRequest DependencyCheckCommand
          
// DependencyCheckResponse DependencyCheckResult
  
// DependencyCheckResponse DependencyCheckResult
  
// DependencyCheckResponse DependencyCheckResult
  
// DependencyCheckResponse DependencyCheckResult
  
// DependencyCheckResponse DependencyCheckResult
  
// DependencyCheckResponse DependencyCheckResult
  
// DependencyCheckResponse DependencyCheckResult
  
// DependencyCheckResponse DependencyCheckResult
          
// LifelineCheckRequest LifelineCheckCommand
  
// LifelineCheckRequest LifelineCheckCommand
  
// LifelineCheckRequest LifelineCheckCommand
  
// LifelineCheckRequest LifelineCheckCommand
  
// LifelineCheckRequest LifelineCheckCommand
  
// LifelineCheckRequest LifelineCheckCommand
  
// LifelineCheckRequest LifelineCheckCommand
  
// LifelineCheckRequest LifelineCheckCommand
          
// LifelineCheckResponse LifelineCheckResult
  
// LifelineCheckResponse LifelineCheckResult
  
// LifelineCheckResponse LifelineCheckResult
  
// LifelineCheckResponse LifelineCheckResult
  
// LifelineCheckResponse LifelineCheckResult
  
// LifelineCheckResponse LifelineCheckResult
  
// LifelineCheckResponse LifelineCheckResult
  
// LifelineCheckResponse LifelineCheckResult
          
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
