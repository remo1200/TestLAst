using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

public partial class SqlDbContext : DbContext
{
    public virtual DbSet<InventoryByCategoryId> InventoriesByCategoryId { get; set; }

    public async Task<List<InventoryByCategoryId>> SPGetInventoryByCategoryId(int QuantityId)
    {

        var QuantityIdParam = new SqlParameter("@CategoryId", QuantityId);

        return await InventoriesByCategoryId.FromSqlRaw("EXEC InventorySchema.sp_getInventoryByCategoryId @CategoryId", QuantityIdParam).ToListAsync();
    }
}