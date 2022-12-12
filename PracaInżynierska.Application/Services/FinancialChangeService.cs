using AutoMapper;
using PracaInzynierska.Application.Dto;
using PracaInzynierska.Application.Interfaces;
using PracaInzynierska.Domain.IRepositories;
using PracaInzynierska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracaInzynierska.Application.Services
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

        public async Task<bool> SetReduction(int id1, int id2)
        {
            var fc1 = await _financialChangeRepository.FindByIdAsync(id1);
            var fc2 = await _financialChangeRepository.FindByIdAsync(id2);
            if (fc1 != null && fc2 != null)
            {
                fc1.Reduction = fc2;
                fc2.Reduction = fc1;
                _financialChangeRepository.Update(fc1);
                _financialChangeRepository.Update(fc2);
                _financialChangeRepository.SaveAsync();
                return true;
            }
            else throw new ArgumentException("Record not exist");
        }

        public async Task<bool> DeleteReduction(int id1, int id2)
        {
            var fc1 = await _financialChangeRepository.FindByIdAsync(id1);
            var fc2 = await _financialChangeRepository.FindByIdAsync(id2);
            if (fc1 != null && fc2 != null)
            {
                fc1.Reduction = null;
                fc2.Reduction = null;
                _financialChangeRepository.Update(fc1);
                _financialChangeRepository.Update(fc2);
                _financialChangeRepository.SaveAsync();
                return true;
            }
            else throw new ArgumentException("Record not exist");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var fc = await _financialChangeRepository.FindByIdAsync(id);
                _financialChangeRepository.Delete(fc);
                _financialChangeRepository.SaveAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

       

        public async Task<List<FinancialChangeDto>> GetAllAsync(Guid guid)
        {
            return _mapper.Map<List<FinancialChangeDto>>(await _financialChangeRepository.FindForGuid(guid));
        }
    }
}
