﻿using backend_dotnet.Core.Dtos.Auth;
using backend_dotnet.Core.Dtos.General;
using System.Security.Claims;

namespace backend_dotnet.Core.Interfaces
{
    public interface iAuthService
    {
        Task<GeneralServiceResponseDto> SeedRolesAsync();
        Task<GeneralServiceResponseDto> RegisterAsync(RegisterDto registerDto);
        Task<LoginServiceResponceDto> LoginAsync(LoginDto loginDto);
        Task<GeneralServiceResponseDto> UpdateRoleAsync(ClaimsPrincipal User, UpdateRoleDto updateRoleDto);
        Task<LoginServiceResponceDto> MeAsync(MeDto meDto);
        Task<IEnumerable<UserInfoResult>> GetUsersListAsync();
        Task<UserInfoResult> GetUserDetailsByUserNameAsync(string userName);
        Task<IEnumerable<string>> GetUserNameListAsync();
    }

  
}
