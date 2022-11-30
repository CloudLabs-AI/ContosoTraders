using ContosoTraders.Api.Core.Models.Implementations.Dao;
using Microsoft.EntityFrameworkCore;
using Type = ContosoTraders.Api.Core.Models.Implementations.Dao.Type;

namespace ContosoTraders.Api.Core.Services.Implementations;

internal class ProductService : ContosoTradersServiceBase, IProductService
{
    private readonly ProductsDbContext _productRepository;

    public ProductService(ProductsDbContext productDbContext, IMapper mapper, IConfiguration configuration, ILogger<ProductService> logger) : base(mapper, configuration, logger)
    {
        _productRepository = productDbContext;
    }

    /// <remarks>
    ///     @TODO: Just a placeholder implementation for now. Fix this later.
    /// </remarks>
    public ProductDto GetProduct(int id)
    {
        var productDao = _productRepository.Products.SingleOrDefault(product => product.Id == id);

        if (productDao is null) throw new ProductNotFoundException(id);

        var productDto = CustomMapping(productDao,
            _productRepository.Brands.ToArray(),
            _productRepository.Types.ToArray(),
            _productRepository.Features.ToArray(),
            false);

        return productDto;
    }

    /// <remarks>
    ///     @TODO: Just a placeholder implementation for now. Fix this later.
    /// </remarks>
    public IEnumerable<ProductDto> GetProducts(int[] brands, int[] typeIds,string searchterm)
    {
        var responseDaos = brands.Any() || typeIds.Any() || !String.IsNullOrEmpty(searchterm)
            ? GetProductsByFilter(brands, typeIds, searchterm)
            : GetAllProducts();

        var allBrands = _productRepository.Brands.ToArray();
        var allTypes = _productRepository.Types.ToArray();
        var allFeatures = _productRepository.Features.ToArray();


        var responseDtos = responseDaos.ToArray()
            .Select(dao => CustomMapping(dao, allBrands, allTypes, allFeatures));

        return responseDtos;
    }

    public IEnumerable<ProductDto> GetProducts(string searchTerm)
    {
        var responseDaos = _productRepository.Products
            .Where(product => EF.Functions.Like(product.Name, $"%{searchTerm}%"));

        var allTypes = _productRepository.Types.ToArray();

        var responseDtos = responseDaos.ToArray()
            .Select(dao => CustomMapping(dao, null, allTypes, null));

        return responseDtos;
    }

    public IEnumerable<Brand> GetBrands()
    {
        return _productRepository.Brands.ToList();
    }

    public IEnumerable<Type> GetTypes()
    {
        return _productRepository.Types.ToList();
    }

    #region Private Helper Methods

    private IEnumerable<Product> GetAllProducts()
    {
        return _productRepository.Products.ToList();
    }

    private IEnumerable<Product> GetProductsByFilter(int[] brands, int[] typeIds,string searchterm)
    {
        var filteredProducts = _productRepository.Products
            .ToList()
            .Where(p =>
            ((brands.Any() ? brands.Contains(p.BrandId.GetValueOrDefault()) : false) &&
            (typeIds.Any() ? typeIds.Contains(p.TypeId.GetValueOrDefault()) : false)) ||
                  (searchterm.Any() ? searchterm.Contains(p.Name) : true)
                );

        return filteredProducts;
    }

    private ProductDto CustomMapping(Product productDao, IEnumerable<Brand> brands, IEnumerable<Type> types, IEnumerable<Feature> features, bool thumbnailImages = true)
    {
        var imagesEndpoint = Configuration[KeyVaultConstants.SecretNameImagesEndpoint];

        var imagesType = thumbnailImages ? "product-list" : "product-details";

        var productDto = new ProductDto
        {
            Id = productDao.Id,
            Name = productDao.Name,
            Price = productDao.Price,
            ImageUrl = $"{imagesEndpoint}/{imagesType}/{productDao.ImageName}",
            Brand = brands?.FirstOrDefault(brand => brand.Id == productDao.BrandId),
            Type = types?.FirstOrDefault(type => type.Id == productDao.TypeId),
            Features = features?.Where(feature => feature.ProductItemId == productDao.Id).ToList()
        };

        return productDto;
    }

    #endregion
}