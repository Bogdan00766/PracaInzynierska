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
using System.Xml.Linq;

namespace PracaInżynierska.Application.Services
{
    public class FinancialChangeService : IFinancialChangeService
    {
        private readonly IMapper _mapper;
        private readonly IFinancialChangeRepository _financialChangeRepository;
        private readonly IAssetTypeRepository _atRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;

        public FinancialChangeService(IMapper mapper, IUserRepository userRepository, IFinancialChangeRepository financialChangeRepository, IAssetTypeRepository atRepository, ICategoryRepository cRepository)
        {
            _mapper = mapper;
            _financialChangeRepository = financialChangeRepository;
            _atRepository = atRepository;
            _categoryRepository = cRepository;
            _userRepository = userRepository;
        }

        public FinancialChange Add(FinancialChangeDto dto, Guid guid)
        {
            FinancialChange financialChange = _mapper.Map<FinancialChange>(dto);
            financialChange.AssetType = _atRepository.FindByName(dto.AssetTypeName);
            financialChange.Category = _categoryRepository.FindByName(dto.CategoryName);
            financialChange.Owner = _userRepository.FindUserByGUID(guid);
            //financialChange.User
            if (financialChange.Owner == null || financialChange.AssetType is null || financialChange.Category is null) throw new Exception("Category or AssetType or User not exist");
            var fic = _financialChangeRepository.Create(financialChange);
            if (fic == null) throw new Exception("Not Created");
            _financialChangeRepository.SaveAsync();
            return fic;
        }

        public async Task<List<FinancialChangeDto>> GetAllAsync(Guid guid)
        {
            return _mapper.Map<List<FinancialChangeDto>>(await _financialChangeRepository.FindForGuid(guid));
        }
    }
}
