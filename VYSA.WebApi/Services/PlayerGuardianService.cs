﻿using System;
using System.Collections.Generic;
using System.Linq;
using VYSA.Domain.Abstract;
using VYSA.Domain.Concrete;
using VYSA.Domain.Entities;
using VYSA.WebApi.Models.Resource;

namespace VYSA.WebApi.Services
{
    public class PlayerGuardianService
    {
        private readonly UnitOfWork _unitOfWork;

        public PlayerGuardianService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = (UnitOfWork)unitOfWork;
        }

        public PlayerGuardian GetPlayerGuardian(int id)
        {
            return _unitOfWork.PlayerGuardianRepository.GetByID(id);
        }

        public PlayerGuardian GetPlayerGuardian(int playerId, int guardianId)
        {
            return _unitOfWork.PlayerGuardianRepository
                    .Get(e => e.IsActive && e.GuardianId == guardianId && e.PlayerId == playerId)
                    .SingleOrDefault();
        }

        public IEnumerable<PlayerGuardianResourceModel> GetPlayerGuardianDtoListFromGuardianList(ICollection<PlayerGuardian> playerGuardianList)
        {
            var list = new List<PlayerGuardianResourceModel>();
            if (playerGuardianList != null)
            {
                var guardianService = new GuardianService(_unitOfWork);
                playerGuardianList
                    .ToList()
                      .ForEach(x =>
                      {
                          if (x.IsActive)
                              list.Add(x.ConvertToResourceModel(guardianService.GetGuardianDto(x.GuardianId)));
                      });
            }
            return list;
        }

        public PlayerGuardianResourceModel AddPlayerGuardian(PlayerGuardianResourceModel newPlayerGuardianDto, string lastUpdateBy)
        {
            bool onCreate = newPlayerGuardianDto.GuardianId == 0;

            //first create new Guardian
            var newGuardianDto = new GuardianResourceModel
                                    {
                                        FirstName = newPlayerGuardianDto.FirstName,
                                        LastName = newPlayerGuardianDto.LastName,
                                        Email = newPlayerGuardianDto.Email,
                                        Phone = newPlayerGuardianDto.Phone
                                    };

            Guardian guardian = null; 
            if (onCreate)
            {
                guardian = new Guardian().PopulateEntityWithResourceModel(newGuardianDto, lastUpdateBy, true);
                _unitOfWork.GuardianRepository.Insert(guardian);
            }
            else
            {
                guardian = new GuardianService(_unitOfWork).GetGuardian(newPlayerGuardianDto.GuardianId);
                _unitOfWork.GuardianRepository.Update(guardian); 
            }

            newPlayerGuardianDto.GuardianId = guardian.Id;
            PlayerGuardian newPlayerGuardian = new PlayerGuardian().PopulateEntityWithResourceModel(newPlayerGuardianDto, lastUpdateBy, true);
            _unitOfWork.PlayerGuardianRepository.Insert(newPlayerGuardian);
            _unitOfWork.Save();

            return newPlayerGuardian.ConvertToResourceModel(guardian.ConvertToResourceModel());
        }

        public void AddPlayerGuardians(IEnumerable<PlayerGuardianResourceModel> playerGuardianDtos, string lastUpdateBy)
        {
            foreach (var guardianDto in playerGuardianDtos)
            {
                bool onCreate = guardianDto.GuardianId == 0;

                var newGuardianDto = new GuardianResourceModel
                {
                    Id = guardianDto.GuardianId,
                    FirstName = guardianDto.FirstName,
                    LastName = guardianDto.LastName,
                    Email = guardianDto.Email,
                    Phone = guardianDto.Phone
                };

                var guardian = new Guardian().PopulateEntityWithResourceModel(newGuardianDto, lastUpdateBy, onCreate);
                if (onCreate)
                {
                    _unitOfWork.GuardianRepository.Insert(guardian);
                }
                else
                {
                    _unitOfWork.GuardianRepository.Update(guardian);
                }

                guardianDto.GuardianId = guardian.Id;
                PlayerGuardian newPlayerGuardian = new PlayerGuardian().PopulateEntityWithResourceModel(guardianDto, lastUpdateBy, true);
                _unitOfWork.PlayerGuardianRepository.Insert(newPlayerGuardian);
                _unitOfWork.Save();
            }

        }

        public PlayerGuardianResourceModel UpdatePlayerGuardian(PlayerGuardianResourceModel playerGuardianDto, string lastUpdateBy)
        {
            var guardian = _unitOfWork.GuardianRepository.GetByID(playerGuardianDto.GuardianId);
            if (guardian == null) return null;

            var guardianDto = new GuardianResourceModel
            {
                Id = playerGuardianDto.GuardianId,
                FirstName = playerGuardianDto.FirstName,
                LastName = playerGuardianDto.LastName,
                Email = playerGuardianDto.Email,
                Phone = playerGuardianDto.Phone
            };

            guardian.PopulateEntityWithResourceModel(guardianDto, lastUpdateBy, false);
            _unitOfWork.GuardianRepository.Update(guardian);

            var playerGuardian = GetPlayerGuardian(playerGuardianDto.PlayerId, playerGuardianDto.GuardianId);
            if (playerGuardian == null) return null;

            playerGuardian.PopulateEntityWithResourceModel(playerGuardianDto, lastUpdateBy, false);
            _unitOfWork.PlayerGuardianRepository.Update(playerGuardian);
            _unitOfWork.Save();

            return playerGuardian.ConvertToResourceModel(guardianDto);
        }

        public PlayerGuardianResourceModel SoftDeletePlayerGuardian(Int32 id, string lastUpdateBy)
        {
            var playerGuardian = GetPlayerGuardian(id);
            if (playerGuardian == null) return null;

            playerGuardian.IsActive = false;
            playerGuardian.LastUpdateUtc = DateTime.UtcNow;
            playerGuardian.LastUpdateBy = lastUpdateBy;
            _unitOfWork.PlayerGuardianRepository.Update(playerGuardian);
            _unitOfWork.Save();

            var guardianDto = new GuardianService(_unitOfWork).GetGuardianDto(playerGuardian.GuardianId);
            if(guardianDto == null) return null;

            return playerGuardian.ConvertToResourceModel(guardianDto);
        }
    }
}