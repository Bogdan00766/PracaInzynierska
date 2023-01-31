using AutoMapper;
using PracaInzynierska.Application.Dto;
using PracaInzynierska.Application.Interfaces;
using PracaInzynierska.Domain.IRepositories;
using PracaInzynierska.Domain.Models;

namespace PracaInzynierska.Application.Services
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
            AssetType assetType = new AssetType { Name = name, };
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
