﻿using Agu.Domain.Core;
using Agu.Domain.DTO;
using Agu.Interface.Business;
using Agu.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agu.Business
{
    public class UserRoleManager : IUserRoleManager
    {
        private IAgDbContext _agDbContext;

        public UserRoleManager(IAgDbContext agDbContext)
        {
            _agDbContext = agDbContext;
        }
        public void AddDefaultUserRole()
        {
            var superAdmin = _agDbContext.UserRoles.Where(x => x.Name == "Super Admin").FirstOrDefault();
            if (superAdmin == null)
            {
                var userRole = new UserRole
                {
                    Name = "Super Admin",
                    Active = true,
                    CreatedOn = DateTime.Now
                };

                _agDbContext.UserRoles.Add(userRole);
                _agDbContext.SaveChanges();
            }
        }

        public List<UserRoleDTO> GetRoleList()
        {
            return _agDbContext.UserRoles.Select(x => new UserRoleDTO
            {
                Id = x.Id,
                Name = x.Name,
                Active = x.Active,
                CreatedOn = x.CreatedOn,
                UpdatedOn = x.UpdatedOn,
            }).ToList();
        }
        public ResponseDTO AddUserRole(UserRoleDTO userRoleDTO)
        {
            ResponseDTO responseDTO = new ResponseDTO();
            try
            {
                if (!_agDbContext.UserRoles.Any(x => x.Name == userRoleDTO.Name))
                {

                    _agDbContext.UserRoles.Add(new UserRole
                    {
                        Name = userRoleDTO.Name,
                        Active = userRoleDTO.Active,
                        CreatedOn = DateTime.Now

                    });
                    int result = _agDbContext.SaveChanges();

                    if (result > 0)
                    {
                        responseDTO.Status = true;
                        responseDTO.StatusCode = (int)System.Net.HttpStatusCode.OK;
                        responseDTO.StatusMessage = string.Format("Role '{0}' Added successfully", userRoleDTO.Name);
                    }
                    else
                    {
                        responseDTO.StatusCode = (int)System.Net.HttpStatusCode.OK;
                        responseDTO.Status = false;
                        responseDTO.StatusMessage = string.Format("Something went wrong. Role '{0}' not Added", userRoleDTO.Name);
                    }
                }
                else
                {
                    responseDTO.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    responseDTO.Status = false;
                    responseDTO.StatusMessage = string.Format("Role '{0}' already exists", userRoleDTO.Name);
                }

            }
            catch (Exception ex)
            {
                responseDTO.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                responseDTO.Status = false;
                responseDTO.StatusMessage = string.Format("An exception occurred while adding user role {0}", ex.Message);
            }
            return responseDTO;
        }

        public ResponseDTO EditUserRole(UserRoleDTO userRoleDTO)
        {
            ResponseDTO responseDTO = new ResponseDTO();
            try
            {
                var role = _agDbContext.UserRoles.Where(x => x.Id == userRoleDTO.Id).FirstOrDefault();
                if (role == null)
                {
                    responseDTO.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                    responseDTO.Status = false;
                    responseDTO.StatusMessage = string.Format("Role id '{0}' not found in our database", userRoleDTO.Id);
                }
                else
                {
                    if (!_agDbContext.UserRoles.Any(x => x.Name == userRoleDTO.Name && x.Id != userRoleDTO.Id))
                    {
                        role.Name = userRoleDTO.Name;
                        role.Active = userRoleDTO.Active;
                        role.UpdatedOn = DateTime.Now;
                        _agDbContext.UserRoles.Update(role);
                        int result = _agDbContext.SaveChanges();

                        if (result > 0)
                        {
                            responseDTO.Status = true;
                            responseDTO.StatusCode = (int)System.Net.HttpStatusCode.OK;
                            responseDTO.StatusMessage = string.Format("Role Updated successfully", userRoleDTO.Name);
                        }
                        else
                        {
                            responseDTO.StatusCode = (int)System.Net.HttpStatusCode.OK;
                            responseDTO.Status = false;
                            responseDTO.StatusMessage = string.Format("Something went wrong. Role '{0}' not updated", userRoleDTO.Name);
                        }
                    }
                    else
                    {
                        responseDTO.StatusCode = (int)System.Net.HttpStatusCode.OK;
                        responseDTO.Status = false;
                        responseDTO.StatusMessage = string.Format("Role '{0}' already exists", userRoleDTO.Name);
                    }
                }

            }
            catch (Exception ex)
            {
                responseDTO.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                responseDTO.Status = false;
                responseDTO.StatusMessage = string.Format("An exception occurred while updating user role {0}", ex.Message);
            }
            return responseDTO;
        }
    }

}
