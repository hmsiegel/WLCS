global using Application.Abstractions.Authentication;
global using Application.Abstractions.Services;

global using Domain.Authorization;
global using Domain.Enums;
global using Domain.UserAggregate;

global using Infrastructure.Authentication.Options;
global using Infrastructure.Authentication.Permissions;

global using Microsoft.AspNetCore.Authorization;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;

global using Persistence;

global using System.IdentityModel.Tokens.Jwt;
global using System.Reflection;
global using System.Security.Claims;
global using System.Text;
