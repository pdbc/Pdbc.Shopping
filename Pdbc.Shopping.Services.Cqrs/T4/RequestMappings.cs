





using System;
using System.Linq;

using AutoMapper;
using Pdbc.Shopping.Core.CQRS.Resources.Errors.Get;

public class RequestToCqrsMappings : Profile
{
    public RequestToCqrsMappings()
    {
        
            // CreateArtistDto CreateArtistInfo

            // CreateArtistDto CreateArtistInfo

            // CreateArtistDto CreateArtistInfo

            // CreateArtistDto CreateArtistInfo

            // CreateArtistDto CreateArtistInfo

            // CreateArtistDto CreateArtistInfo
        
            // CreateArtistRequest CreateArtistCommand

            // CreateArtistRequest CreateArtistCommand

            // CreateArtistRequest CreateArtistCommand

            // CreateArtistRequest CreateArtistCommand

            // CreateArtistRequest CreateArtistCommand

            // CreateArtistRequest CreateArtistCommand
        
            // ListArtistsRequest ListArtistsQuery

            // ListArtistsRequest ListArtistsQuery

            // ListArtistsRequest ListArtistsQuery

            // ListArtistsRequest ListArtistsQuery

            // ListArtistsRequest ListArtistsQuery

            // ListArtistsRequest ListArtistsQuery
        
            // ListArtistsResponse ListArtistsViewModel

            // ListArtistsResponse ListArtistsViewModel

            // ListArtistsResponse ListArtistsViewModel

            // ListArtistsResponse ListArtistsViewModel

            // ListArtistsResponse ListArtistsViewModel

            // ListArtistsResponse ListArtistsViewModel
        
            // MusicRequest MusicCommand

            // MusicRequest MusicCommand

            // MusicRequest MusicCommand

            // MusicRequest MusicCommand

            // MusicRequest MusicCommand

            // MusicRequest MusicCommand
        
            // MusicResponse MusicResult

            // MusicResponse MusicResult

            // MusicResponse MusicResult

            // MusicResponse MusicResult

            // MusicResponse MusicResult

            // MusicResponse MusicResult
        
            // GetErrorMessageRequest GetErrorMessageQuery
CreateMap<Pdbc.Music.Api.Contracts.Requests.Errors.GetErrorMessageRequest, Pdbc.Music.Core.CQRS.ErrorMessages.Get.GetErrorMessageQuery>();
        
            // GetErrorMessageResponse GetErrorMessageViewModel

            // GetErrorMessageResponse GetErrorMessageViewModel
CreateMap<GetErrorMessageViewModel, Pdbc.Music.Api.Contracts.Requests.Errors.GetErrorMessageResponse>();
        
            // ListErrorMessagesRequest ListErrorMessagesQuery

            // ListErrorMessagesRequest ListErrorMessagesQuery

            // ListErrorMessagesRequest ListErrorMessagesQuery
CreateMap<Pdbc.Music.Api.Contracts.Requests.Errors.ListErrorMessagesRequest, Pdbc.Music.Core.CQRS.ErrorMessages.List.ListErrorMessagesQuery>();
        
            // ListErrorMessagesResponse ListErrorMessagesViewModel

            // ListErrorMessagesResponse ListErrorMessagesViewModel

            // ListErrorMessagesResponse ListErrorMessagesViewModel

            // ListErrorMessagesResponse ListErrorMessagesViewModel
CreateMap<Pdbc.Music.Core.CQRS.ErrorMessages.List.ListErrorMessagesViewModel, Pdbc.Music.Api.Contracts.Requests.Errors.ListErrorMessagesResponse>();
        
            // IsServiceRunningRequest IsServiceRunningQuery

            // IsServiceRunningRequest IsServiceRunningQuery

            // IsServiceRunningRequest IsServiceRunningQuery

            // IsServiceRunningRequest IsServiceRunningQuery

            // IsServiceRunningRequest IsServiceRunningQuery
CreateMap<Pdbc.Music.Api.Contracts.Requests.HealthCheck.IsServiceRunningRequest, Pdbc.Music.Core.CQRS.HealthCheck.IsServiceRunning.IsServiceRunningQuery>();
        
            // IsServiceRunningResponse IsServiceRunningViewModel

            // IsServiceRunningResponse IsServiceRunningViewModel

            // IsServiceRunningResponse IsServiceRunningViewModel

            // IsServiceRunningResponse IsServiceRunningViewModel

            // IsServiceRunningResponse IsServiceRunningViewModel

            // IsServiceRunningResponse IsServiceRunningViewModel
CreateMap<Pdbc.Music.Core.CQRS.HealthCheck.IsServiceRunning.IsServiceRunningViewModel, Pdbc.Music.Api.Contracts.Requests.HealthCheck.IsServiceRunningResponse>();
            }
}