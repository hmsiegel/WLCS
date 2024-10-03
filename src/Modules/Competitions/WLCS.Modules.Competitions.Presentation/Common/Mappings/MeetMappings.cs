// <copyright file="MeetMappings.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Common.Mappings;

internal sealed class MeetMappings : IRegister
{
  public void Register(TypeAdapterConfig config)
  {
    config.NewConfig<GetMeetResponse, MeetResponse>()
      .Map(dest => dest, src => src);
  }
}
