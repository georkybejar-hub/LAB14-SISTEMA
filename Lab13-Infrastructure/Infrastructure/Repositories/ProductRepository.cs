using Lab13ClosedXML.Application.DTOs;
using Lab13ClosedXML.Application.Interfaces;
using Lab13ClosedXML.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab13ClosedXML.Infrastructure.Repositories;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task<List<ProductSalesReportDto>> GetProductSalesReportAsync(CancellationToken cancellationToken)
    {
        return await context.Products
            .AsNoTracking()
            .Select(p => new ProductSalesReportDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                UnitsSold = p.Orderdetails.Sum(d => (int?)d.Quantity) ?? 0,
                TotalSales = p.Orderdetails.Sum(d => (decimal?)(d.Quantity * p.Price)) ?? 0
            })
            .OrderByDescending(p => p.TotalSales)
            .ToListAsync(cancellationToken);
    }
}