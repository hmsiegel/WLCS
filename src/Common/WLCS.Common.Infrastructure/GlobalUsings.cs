// <copyright file="GlobalUsings.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

global using System.Buffers;
global using System.Collections.Concurrent;
global using System.Data;
global using System.Data.Common;
global using System.Reflection;
global using System.Security.Claims;
global using System.Text.Json;

global using Dapper;

global using MassTransit;

global using Microsoft.AspNetCore.Authentication;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Diagnostics;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Caching.Distributed;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;

global using MongoDB.Bson;
global using MongoDB.Bson.Serialization;
global using MongoDB.Bson.Serialization.Serializers;
global using MongoDB.Driver;
global using MongoDB.Driver.Core.Extensions.DiagnosticSources;

global using Newtonsoft.Json;

global using Npgsql;

global using OpenTelemetry.Resources;
global using OpenTelemetry.Trace;

global using Quartz;

global using StackExchange.Redis;

global using WLCS.Common.Application.Authorization;
global using WLCS.Common.Application.Caching;
global using WLCS.Common.Application.Clock;
global using WLCS.Common.Application.Data;
global using WLCS.Common.Application.EventBus;
global using WLCS.Common.Application.Exceptions;
global using WLCS.Common.Application.Messaging;
global using WLCS.Common.Domain;
global using WLCS.Common.Infrastructure.Authentication;
global using WLCS.Common.Infrastructure.Authorization;
global using WLCS.Common.Infrastructure.Caching;
global using WLCS.Common.Infrastructure.Clock;
global using WLCS.Common.Infrastructure.Data;
global using WLCS.Common.Infrastructure.EventBus;
global using WLCS.Common.Infrastructure.Outbox;
global using WLCS.Common.Infrastructure.Serialization;
