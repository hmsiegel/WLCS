﻿// <copyright file="Competition.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Competitions;

public sealed class Competition : Entity<CompetitionId>
{
  private readonly List<Athlete> _athletes = [];

  private Competition(
    MeetId meetId,
    CompetitionName name,
    Scope scope,
    CompetitionType competitionType,
    AgeDivision ageDivisions,
    CompetitionId? id = null)
  {
    MeetId = Guard.Against.Default(meetId);
    Id = id ?? CompetitionId.CreateUnique();
    Name = Guard.Against.Default(name);
    Scope = Guard.Against.Default(scope);
    CompetitionType = Guard.Against.Default(competitionType);
    AgeDivision = Guard.Against.Default(ageDivisions);
  }

  private Competition()
  {
  }

  public MeetId MeetId { get; private set; } = default!;

  public CompetitionName Name { get; private set; } = default!;

  public Scope Scope { get; private set; } = Scope.IWF;

  public CompetitionType CompetitionType { get; private set; } = CompetitionType.International;

  public AgeDivision AgeDivision { get; private set; } = AgeDivision.Senior;

  public IReadOnlyCollection<Athlete> Athletes => [.. _athletes];

  public static Competition Create(
    MeetId meetId,
    CompetitionName name,
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

    competition.Raise(new CompetitionCreatedDomainEvent(competition.Id.Value, meetId.Value));

    return competition;
  }

  public void AddAthlete(Athlete athlete)
  {
    if (_athletes.Contains(athlete))
    {
      return;
    }

    _athletes.Add(athlete);
  }

  public void RemoveAthlete(Athlete athlete)
  {
    if (!_athletes.Contains(athlete))
    {
      return;
    }

    _athletes.Remove(athlete);
  }

  public void Update(
    CompetitionName competitionName,
    Scope scope,
    CompetitionType competitionType,
    AgeDivision ageDivision)
  {
    Name = Guard.Against.Default(competitionName);
    Scope = Guard.Against.Default(scope);
    CompetitionType = Guard.Against.Default(competitionType);
    AgeDivision = Guard.Against.Default(ageDivision);

    Raise(new CompetitionUpdatedDomainEvent(Id.Value, MeetId.Value));
  }
}
