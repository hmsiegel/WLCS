// <copyright file="UserMappings.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Presentation.Common.Mappings;

internal sealed class UserMappings : IRegister
{
  public void Register(TypeAdapterConfig config)
  {
    config.NewConfig<GetUserResponse, UserResponse>();
  }
}
