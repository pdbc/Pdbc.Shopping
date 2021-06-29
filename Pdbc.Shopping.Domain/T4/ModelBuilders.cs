




using System;
using System.Linq;



using Pdbc.Shopping.Common;

namespace Pdbc.Shopping.Domain.Model {
    public partial class AddressBuilder : ObjectBuilder<Pdbc.Shopping.Domain.Model.Address>
	{
       protected System.String Street { get; set; }		
public AddressBuilder WithStreet(System.String street)
{
    this.Street = street;
	return this;
}	
protected System.String Number { get; set; }		
public AddressBuilder WithNumber(System.String number)
{
    this.Number = number;
	return this;
}	
protected System.String City { get; set; }		
public AddressBuilder WithCity(System.String city)
{
    this.City = city;
	return this;
}	
protected System.String CreatedBy { get; set; }		
public AddressBuilder WithCreatedBy(System.String createdby)
{
    this.CreatedBy = createdby;
	return this;
}	
protected System.DateTimeOffset CreatedOn { get; set; }		
public AddressBuilder WithCreatedOn(System.DateTimeOffset createdon)
{
    this.CreatedOn = createdon;
	return this;
}	
protected System.String ModifiedBy { get; set; }		
public AddressBuilder WithModifiedBy(System.String modifiedby)
{
    this.ModifiedBy = modifiedby;
	return this;
}	
protected System.DateTimeOffset ModifiedOn { get; set; }		
public AddressBuilder WithModifiedOn(System.DateTimeOffset modifiedon)
{
    this.ModifiedOn = modifiedon;
	return this;
}	
protected System.Int64 Id { get; set; }		
public AddressBuilder WithId(System.Int64 id)
{
    this.Id = id;
	return this;
}	



public override Address Build()
{
    var item = (Address)Activator.CreateInstance(typeof(Address));
    	
		
	item.Street = Street;
	    	
		
	item.Number = Number;
	    	
		
	item.City = City;
	    	
		
	item.CreatedBy = CreatedBy;
	    	
		
	item.CreatedOn = CreatedOn;
	    	
		
	item.ModifiedBy = ModifiedBy;
	    	
		
	item.ModifiedOn = ModifiedOn;
	    	
		
	item.Id = Id;
	    
    return item;
}
       
    }
}

namespace Pdbc.Shopping.Domain.Model {
    public partial class ArticleBuilder : ObjectBuilder<Pdbc.Shopping.Domain.Model.Article>
	{
       protected System.String Name { get; set; }		
public ArticleBuilder WithName(System.String name)
{
    this.Name = name;
	return this;
}	
protected System.String Brand { get; set; }		
public ArticleBuilder WithBrand(System.String brand)
{
    this.Brand = brand;
	return this;
}	
protected System.String CreatedBy { get; set; }		
public ArticleBuilder WithCreatedBy(System.String createdby)
{
    this.CreatedBy = createdby;
	return this;
}	
protected System.DateTimeOffset CreatedOn { get; set; }		
public ArticleBuilder WithCreatedOn(System.DateTimeOffset createdon)
{
    this.CreatedOn = createdon;
	return this;
}	
protected System.String ModifiedBy { get; set; }		
public ArticleBuilder WithModifiedBy(System.String modifiedby)
{
    this.ModifiedBy = modifiedby;
	return this;
}	
protected System.DateTimeOffset ModifiedOn { get; set; }		
public ArticleBuilder WithModifiedOn(System.DateTimeOffset modifiedon)
{
    this.ModifiedOn = modifiedon;
	return this;
}	
protected System.Int64 Id { get; set; }		
public ArticleBuilder WithId(System.Int64 id)
{
    this.Id = id;
	return this;
}	



public override Article Build()
{
    var item = (Article)Activator.CreateInstance(typeof(Article));
    	
		
	item.Name = Name;
	    	
		
	item.Brand = Brand;
	    	
		
	item.CreatedBy = CreatedBy;
	    	
		
	item.CreatedOn = CreatedOn;
	    	
		
	item.ModifiedBy = ModifiedBy;
	    	
		
	item.ModifiedOn = ModifiedOn;
	    	
		
	item.Id = Id;
	    
    return item;
}
       
    }
}

namespace Pdbc.Shopping.Domain.Model {
    public partial class ShoppingListBuilder : ObjectBuilder<Pdbc.Shopping.Domain.Model.ShoppingList>
	{
       protected Pdbc.Shopping.Domain.Model.Store Store { get; set; }		
public ShoppingListBuilder WithStore(Pdbc.Shopping.Domain.Model.Store store)
{
    this.Store = store;
	return this;
}	

public ShoppingListBuilder WithStore(Action<Pdbc.Shopping.Domain.Model.StoreBuilder> storeBuilder)
{
	var b = new Pdbc.Shopping.Domain.Model.StoreBuilder();
	storeBuilder.Invoke(b);
	this.Store = b.Build();
	return this;
}


protected System.Collections.Generic.IList<Pdbc.Shopping.Domain.Model.Article> Articles { get; set; } = new System.Collections.Generic.List<Pdbc.Shopping.Domain.Model.Article>();
		
public ShoppingListBuilder WithArticles(params Pdbc.Shopping.Domain.Model.Article[] articles)
{
	Articles = articles.ToList();
	return this;
}
			


public virtual ShoppingListBuilder AddArticlesItem(Pdbc.Shopping.Domain.Model.Article item)
{
	if (Articles == null) {
		Articles = new System.Collections.Generic.List<Pdbc.Shopping.Domain.Model.Article>();
	}

	this.Articles.Add(item);
	return this;
}

public virtual bool ContainsArticlesItem(Pdbc.Shopping.Domain.Model.Article item)
{
    if (Articles != null)
    {
        return this.Articles.Contains(item);
    }
    return false;
}

public virtual ShoppingListBuilder RemoveArticlesItem(Pdbc.Shopping.Domain.Model.Article item)
{
	if (Articles == null) {
		Articles = new System.Collections.Generic.List<Pdbc.Shopping.Domain.Model.Article>();
	}

	this.Articles.Remove(item);
	return this;
}
public virtual ShoppingListBuilder ClearArticles()
{
	if (Articles == null) {
		Articles = new System.Collections.Generic.List<Pdbc.Shopping.Domain.Model.Article>();
	}

	this.Articles.Clear();
	return this;
}




//public virtual ShoppingListBuilder WithArticles(params Action<Pdbc.Shopping.Domain.Model.ArticleBuilder>[] builders)
//{
	//var articles = new System.Collections.Generic.List<Pdbc.Shopping.Domain.Model.Article>();
//
	//foreach(var builder in builders)
	//{
		//var b = new Pdbc.Shopping.Domain.Model.ArticleBuilder();
		//builder.Invoke(b);
		//articles.Add(b.Build());
	//}
//
	//this.Articles  = articles;
//
	//return this;
//}

//public ShoppingListBuilder AddArticlesItem(Pdbc.Shopping.Domain.Model.Article item)
//{
	//if (Articles == null) {
		//Articles = new System.Collections.Generic.List<Pdbc.Shopping.Domain.Model.Article>();
	//}
//
	//this.Articles.Add(item);
	//return this;
//}


protected System.String CreatedBy { get; set; }		
public ShoppingListBuilder WithCreatedBy(System.String createdby)
{
    this.CreatedBy = createdby;
	return this;
}	
protected System.DateTimeOffset CreatedOn { get; set; }		
public ShoppingListBuilder WithCreatedOn(System.DateTimeOffset createdon)
{
    this.CreatedOn = createdon;
	return this;
}	
protected System.String ModifiedBy { get; set; }		
public ShoppingListBuilder WithModifiedBy(System.String modifiedby)
{
    this.ModifiedBy = modifiedby;
	return this;
}	
protected System.DateTimeOffset ModifiedOn { get; set; }		
public ShoppingListBuilder WithModifiedOn(System.DateTimeOffset modifiedon)
{
    this.ModifiedOn = modifiedon;
	return this;
}	
protected System.Int64 Id { get; set; }		
public ShoppingListBuilder WithId(System.Int64 id)
{
    this.Id = id;
	return this;
}	



public override ShoppingList Build()
{
    var item = (ShoppingList)Activator.CreateInstance(typeof(ShoppingList));
    	
		
	item.Store = Store;
	    	
		
	item.Articles = Articles;
	    	
		
	item.CreatedBy = CreatedBy;
	    	
		
	item.CreatedOn = CreatedOn;
	    	
		
	item.ModifiedBy = ModifiedBy;
	    	
		
	item.ModifiedOn = ModifiedOn;
	    	
		
	item.Id = Id;
	    
    return item;
}
       
    }
}

namespace Pdbc.Shopping.Domain.Model {
    public partial class StoreBuilder : ObjectBuilder<Pdbc.Shopping.Domain.Model.Store>
	{
       protected System.String Name { get; set; }		
public StoreBuilder WithName(System.String name)
{
    this.Name = name;
	return this;
}	
protected Pdbc.Shopping.Domain.Model.Address Address { get; set; }		
public StoreBuilder WithAddress(Pdbc.Shopping.Domain.Model.Address address)
{
    this.Address = address;
	return this;
}	

public StoreBuilder WithAddress(Action<Pdbc.Shopping.Domain.Model.AddressBuilder> addressBuilder)
{
	var b = new Pdbc.Shopping.Domain.Model.AddressBuilder();
	addressBuilder.Invoke(b);
	this.Address = b.Build();
	return this;
}


protected Pdbc.Shopping.Domain.Model.Article[] Articles { get; set; }		
public StoreBuilder WithArticles(Pdbc.Shopping.Domain.Model.Article[] articles)
{
    this.Articles = articles;
	return this;
}	
protected System.String CreatedBy { get; set; }		
public StoreBuilder WithCreatedBy(System.String createdby)
{
    this.CreatedBy = createdby;
	return this;
}	
protected System.DateTimeOffset CreatedOn { get; set; }		
public StoreBuilder WithCreatedOn(System.DateTimeOffset createdon)
{
    this.CreatedOn = createdon;
	return this;
}	
protected System.String ModifiedBy { get; set; }		
public StoreBuilder WithModifiedBy(System.String modifiedby)
{
    this.ModifiedBy = modifiedby;
	return this;
}	
protected System.DateTimeOffset ModifiedOn { get; set; }		
public StoreBuilder WithModifiedOn(System.DateTimeOffset modifiedon)
{
    this.ModifiedOn = modifiedon;
	return this;
}	
protected System.Int64 Id { get; set; }		
public StoreBuilder WithId(System.Int64 id)
{
    this.Id = id;
	return this;
}	



public override Store Build()
{
    var item = (Store)Activator.CreateInstance(typeof(Store));
    	
		
	item.Name = Name;
	    	
		
	item.Address = Address;
	    	
		
	item.Articles = Articles;
	    	
		
	item.CreatedBy = CreatedBy;
	    	
		
	item.CreatedOn = CreatedOn;
	    	
		
	item.ModifiedBy = ModifiedBy;
	    	
		
	item.ModifiedOn = ModifiedOn;
	    	
		
	item.Id = Id;
	    
    return item;
}
       
    }
}
