// <copyright file="Competition.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Competitions;

public sealed class Competition : Entity
{
  private Competition(
    Guid meetId,
    string name,
    Scope scope,
    CompetitionType competitionType,
    AgeDivision ageDivisions,
    Guid? id = null)
  {
    MeetId = meetId;
    Id = id ?? Guid.NewGuid();
    Name = Guard.Against.NullOrWhiteSpace(name);
    Scope = Guard.Against.Default(scope);
    CompetitionType = Guard.Against.Default(competitionType);
    AgeDivision = Guard.Against.Default(ageDivisions);
  }

  private Competition()
  {
  }

  public Guid Id { get; private set; }

  public Guid MeetId { get; private set; }

  public string Name { get; private set; } = string.Empty;

  public Scope Scope { get; private set; } = Scope.IWF;

  public CompetitionType CompetitionType { get; private set; } = CompetitionType.International;

  public AgeDivision AgeDivision { get; private set; } = AgeDivision.Senior;

  public static Competition Create(
    Guid meetId,
    string name,
    Scope scope,
    CompetitionType competitionType,
    AgeDivision ageDivisions)
  {
    var competition = new Competition(
      meetId,
      name,
      scope,
      competitionType,
      ageDivisions);

    competition.Raise(new CompetitionCreatedDomainEvent(competition.Id));

    return competition;
  }
}
