using AutoMapper;
using PracaInżynierska.Application.Dto;
using PracaInżynierska.Application.Interfaces;
using PracaInżynierska.Domain.IRepositories;
using PracaInżynierska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInżynierska.Application.Services
{
    public class AssetTypeService : IAssetTypeService
    {
        private readonly IAssetTypeRepository _assetTypeRepository;
        private readonly IMapper _mapper;
        public AssetTypeService(IAssetTypeRepository assetTypeRepository, IMapper mapper)
        {
            _assetTypeRepository = assetTypeRepository;
            _mapper = mapper;
        }

        public AssetType AddAssetType(string name)
        {
            AssetType assetType = new AssetType{ Name = name, };
            var at = _assetTypeRepository.Create(assetType);
            if (at == null) return new AssetType { Name = "AlreadyExist" };
            return at;
        }

        public async Task<List<AssetTypeDto>> GetAllAssetTypesAsync()
        {
            return _mapper.Map<List<AssetTypeDto>>(await _assetTypeRepository.FindAllAsync());
        }
    }
}
