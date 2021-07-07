






using System;
using System.Linq;
using Pdbc.Shopping.Common;
namespace Pdbc.Shopping.Core.CQRS.Articles.Create {
    public partial class CreateArticleCommandBuilder : ObjectBuilder<Pdbc.Shopping.Core.CQRS.Articles.Create.CreateArticleCommand>
	{
       protected Pdbc.Shopping.DTO.Articles.IArticleCreateDto Article { get; set; }		
public CreateArticleCommandBuilder WithArticle(Pdbc.Shopping.DTO.Articles.IArticleCreateDto article)
{
    this.Article = article;
	return this;
}	

       
public override CreateArticleCommand Build()
{
    var item = (CreateArticleCommand)Activator.CreateInstance(typeof(CreateArticleCommand));
    	
		
	item.Article = Article;
	    
    return item;
}
      
    }
}

namespace Pdbc.Shopping.Core.CQRS.Articles.Create {
    public partial class CreateArticleResultBuilder : ObjectBuilder<Pdbc.Shopping.Core.CQRS.Articles.Create.CreateArticleResult>
	{
       protected Pdbc.Shopping.DTO.Articles.IArticleDetailDto Article { get; set; }		
public CreateArticleResultBuilder WithArticle(Pdbc.Shopping.DTO.Articles.IArticleDetailDto article)
{
    this.Article = article;
	return this;
}	

       
public override CreateArticleResult Build()
{
    var item = (CreateArticleResult)Activator.CreateInstance(typeof(CreateArticleResult));
    	
		
	item.Article = Article;
	    
    return item;
}
      
    }
}

namespace Pdbc.Shopping.Core.CQRS.Health.DependencyCheck {
    public partial class DependencyCheckCommandBuilder : ObjectBuilder<Pdbc.Shopping.Core.CQRS.Health.DependencyCheck.DependencyCheckCommand>
	{
       
       
public override DependencyCheckCommand Build()
{
    var item = (DependencyCheckCommand)Activator.CreateInstance(typeof(DependencyCheckCommand));
    
    return item;
}
      
    }
}

namespace Pdbc.Shopping.Core.CQRS.Health.DependencyCheck {
    public partial class DependencyCheckResultBuilder : ObjectBuilder<Pdbc.Shopping.Core.CQRS.Health.DependencyCheck.DependencyCheckResult>
	{
       
       
public override DependencyCheckResult Build()
{
    var item = (DependencyCheckResult)Activator.CreateInstance(typeof(DependencyCheckResult));
    
    return item;
}
      
    }
}

namespace Pdbc.Shopping.Core.CQRS.Health.LifelineCheck {
    public partial class LifelineCheckCommandBuilder : ObjectBuilder<Pdbc.Shopping.Core.CQRS.Health.LifelineCheck.LifelineCheckCommand>
	{
       
       
public override LifelineCheckCommand Build()
{
    var item = (LifelineCheckCommand)Activator.CreateInstance(typeof(LifelineCheckCommand));
    
    return item;
}
      
    }
}

namespace Pdbc.Shopping.Core.CQRS.Health.LifelineCheck {
    public partial class LifelineCheckResultBuilder : ObjectBuilder<Pdbc.Shopping.Core.CQRS.Health.LifelineCheck.LifelineCheckResult>
	{
       
       
public override LifelineCheckResult Build()
{
    var item = (LifelineCheckResult)Activator.CreateInstance(typeof(LifelineCheckResult));
    
    return item;
}
      
    }
}

namespace Pdbc.Shopping.Core.CQRS.Resources.Errors.Get {
    public partial class GetErrorMessageQueryBuilder : ObjectBuilder<Pdbc.Shopping.Core.CQRS.Resources.Errors.Get.GetErrorMessageQuery>
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

namespace Pdbc.Shopping.Core.CQRS.Resources.Errors.Get {
    public partial class GetErrorMessageViewModelBuilder : ObjectBuilder<Pdbc.Shopping.Core.CQRS.Resources.Errors.Get.GetErrorMessageViewModel>
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

namespace Pdbc.Shopping.Core.CQRS.Resources.Errors.List {
    public partial class ListErrorMessagesQueryBuilder : ObjectBuilder<Pdbc.Shopping.Core.CQRS.Resources.Errors.List.ListErrorMessagesQuery>
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

namespace Pdbc.Shopping.Core.CQRS.Resources.Errors.List {
    public partial class ListErrorMessagesViewModelBuilder : ObjectBuilder<Pdbc.Shopping.Core.CQRS.Resources.Errors.List.ListErrorMessagesViewModel>
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

namespace Pdbc.Shopping.DTO.Articles {
    public partial class ArticleCreateDtoBuilder : ObjectBuilder<Pdbc.Shopping.DTO.Articles.ArticleCreateDto>
	{
       protected System.String Name { get; set; }		
public ArticleCreateDtoBuilder WithName(System.String name)
{
    this.Name = name;
	return this;
}	

       
public override ArticleCreateDto Build()
{
    var item = (ArticleCreateDto)Activator.CreateInstance(typeof(ArticleCreateDto));
    	
		
	item.Name = Name;
	    
    return item;
}
      
    }
}

namespace Pdbc.Shopping.DTO.Articles {
    public partial class ArticleDetailDtoBuilder : ObjectBuilder<Pdbc.Shopping.DTO.Articles.ArticleDetailDto>
	{
       protected System.String Name { get; set; }		
public ArticleDetailDtoBuilder WithName(System.String name)
{
    this.Name = name;
	return this;
}	

       
public override ArticleDetailDto Build()
{
    var item = (ArticleDetailDto)Activator.CreateInstance(typeof(ArticleDetailDto));
    	
		
	item.Name = Name;
	    
    return item;
}
      
    }
}

namespace Pdbc.Shopping.DTO.Articles {
    public partial class ArticleInfoDtoBuilder : ObjectBuilder<Pdbc.Shopping.DTO.Articles.ArticleInfoDto>
	{
       protected System.String Name { get; set; }		
public ArticleInfoDtoBuilder WithName(System.String name)
{
    this.Name = name;
	return this;
}	

       
public override ArticleInfoDto Build()
{
    var item = (ArticleInfoDto)Activator.CreateInstance(typeof(ArticleInfoDto));
    	
		
	item.Name = Name;
	    
    return item;
}
      
    }
}

namespace Pdbc.Shopping.DTO.Articles {
    public partial class ArticleListItemDtoBuilder : ObjectBuilder<Pdbc.Shopping.DTO.Articles.ArticleListItemDto>
	{
       protected System.Int64 Id { get; set; }		
public ArticleListItemDtoBuilder WithId(System.Int64 id)
{
    this.Id = id;
	return this;
}	
protected System.String Name { get; set; }		
public ArticleListItemDtoBuilder WithName(System.String name)
{
    this.Name = name;
	return this;
}	

       
public override ArticleListItemDto Build()
{
    var item = (ArticleListItemDto)Activator.CreateInstance(typeof(ArticleListItemDto));
    	
		
	item.Id = Id;
	    	
		
	item.Name = Name;
	    
    return item;
}
      
    }
}

namespace Pdbc.Shopping.DTO.Articles {
    public partial class ArticleUpdateDtoBuilder : ObjectBuilder<Pdbc.Shopping.DTO.Articles.ArticleUpdateDto>
	{
       protected System.String Name { get; set; }		
public ArticleUpdateDtoBuilder WithName(System.String name)
{
    this.Name = name;
	return this;
}	
protected System.Int64 Id { get; set; }		
public ArticleUpdateDtoBuilder WithId(System.Int64 id)
{
    this.Id = id;
	return this;
}	

       
public override ArticleUpdateDto Build()
{
    var item = (ArticleUpdateDto)Activator.CreateInstance(typeof(ArticleUpdateDto));
    	
		
	item.Name = Name;
	    	
		
	item.Id = Id;
	    
    return item;
}
      
    }
}

