﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace ProductManagement.Products;

public class ProductAppService : ProductManagementAppService, IProductAppService
{
    private readonly IRepository<Product, Guid> _productRepository;
    public ProductAppService(
    IRepository<Product, Guid> productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<PagedResultDto<ProductDto>> GetListAsync(
    PagedAndSortedResultRequestDto input)
    {
        /* TODO: Implementation */
        var queryable = await _productRepository
        .WithDetailsAsync(x => x.Category);
        queryable = queryable
        .Skip(input.SkipCount)
        .Take(input.MaxResultCount)
        .OrderBy(input.Sorting ?? nameof(Product.Name));
        var products = await
       AsyncExecuter.ToListAsync(queryable);
        var count = await _productRepository.GetCountAsync();
        return new PagedResultDto<ProductDto>(
        count,
        ObjectMapper.Map<List<Product>, List<ProductDto>>
       (products)
        );
    }
}
