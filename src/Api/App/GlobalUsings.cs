global using App.Extensions;
global using App.Utility;

global using Infrastructure.BackgroundJobs;
global using Infrastructure.Configuration;
global using Infrastructure.Extensions;

global using MassTransit;

global using Microsoft.AspNetCore.Authentication;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.Extensions.Options;
global using Microsoft.Net.Http.Headers;
global using Microsoft.OpenApi.Models;

global using Quartz;

global using Serilog;
global using Serilog.Events;

global using Shared.Extensions;

global using Swashbuckle.AspNetCore.SwaggerGen;
global using Swashbuckle.AspNetCore.SwaggerUI;

global using System.Diagnostics.CodeAnalysis;
global using System.Globalization;
global using System.IdentityModel.Tokens.Jwt;
global using System.Net;
global using System.Reflection;
global using System.Security.Claims;
