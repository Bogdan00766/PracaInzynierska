using PracaInżynierska.Application.Dto;
using PracaInżynierska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInżynierska.Application.Interfaces
{
    public interface IAssetTypeService
    {
        AssetType AddAssetType(string name);
        Task<List<AssetTypeDto>> GetAllAssetTypesAsync();
    }
}
