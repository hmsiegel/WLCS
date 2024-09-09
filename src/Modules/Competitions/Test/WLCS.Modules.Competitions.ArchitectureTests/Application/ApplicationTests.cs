﻿// <copyright file="ApplicationTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.ArchitectureTests.Application;

public class ApplicationTests : BaseTest
{
  [Fact]
  public void Command_Should_BeSealed()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .ImplementInterface(typeof(ICommand))
      .Or()
      .ImplementInterface(typeof(ICommand<>))
      .Should()
      .BeSealed()
      .GetResult()
      .ShouldBeSuccessful();
  }

  [Fact]
  public void Command_ShouldHave_NameEndingWith_Command()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .ImplementInterface(typeof(ICommand))
      .Or()
      .ImplementInterface(typeof(ICommand<>))
      .Should()
      .HaveNameEndingWith("Command", StringComparison.InvariantCulture)
      .GetResult()
      .ShouldBeSuccessful();
  }

  [Fact]
  public void CommandHandler_Should_BeSealed()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .ImplementInterface(typeof(ICommandHandler<>))
      .Or()
      .ImplementInterface(typeof(ICommandHandler<,>))
      .Should()
      .BeSealed()
      .GetResult()
      .ShouldBeSuccessful();
  }

  [Fact]
  public void CommandHandler_Should_NotBePublic()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .ImplementInterface(typeof(ICommandHandler<>))
      .Or()
      .ImplementInterface(typeof(ICommandHandler<,>))
      .Should()
      .NotBePublic()
      .GetResult()
      .ShouldBeSuccessful();
  }

  [Fact]
  public void CommandHandler_ShouldHave_NameEndingWith_CommandHandler()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .ImplementInterface(typeof(ICommandHandler<>))
      .Or()
      .ImplementInterface(typeof(ICommandHandler<,>))
      .Should()
      .HaveNameEndingWith("CommandHandler", StringComparison.InvariantCulture)
      .GetResult()
      .ShouldBeSuccessful();
  }

  [Fact]
  public void Query_Should_BeSealed()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .ImplementInterface(typeof(IQuery<>))
      .Should()
      .BeSealed()
      .GetResult()
      .ShouldBeSuccessful();
  }

  [Fact]
  public void Query_ShouldHave_NameEndingWith_Query()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .ImplementInterface(typeof(IQuery<>))
      .Should()
      .HaveNameEndingWith("Query", StringComparison.InvariantCulture)
      .GetResult()
      .ShouldBeSuccessful();
  }

  [Fact]
  public void QueryHandler_Should_BeSealed()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .ImplementInterface(typeof(IQueryHandler<,>))
      .Should()
      .BeSealed()
      .GetResult()
      .ShouldBeSuccessful();
  }

  [Fact]
  public void QueryHandler_Should_NotBePublic()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .ImplementInterface(typeof(IQueryHandler<,>))
      .Should()
      .NotBePublic()
      .GetResult()
      .ShouldBeSuccessful();
  }

  [Fact]
  public void QueryHandler_ShouldHave_NameEndingWith_QueryHandler()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .ImplementInterface(typeof(IQueryHandler<,>))
      .Should()
      .HaveNameEndingWith("QueryHandler", StringComparison.InvariantCulture)
      .GetResult()
      .ShouldBeSuccessful();
  }

  [Fact]
  public void Validator_Should_BeSealed()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .Inherit(typeof(AbstractValidator<>))
      .Should()
      .BeSealed()
      .GetResult()
      .ShouldBeSuccessful();
  }

  [Fact]
  public void Validator_ShouldHave_NameEndingWith_Validator()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .Inherit(typeof(AbstractValidator<>))
      .Should()
      .HaveNameEndingWith("Validator", StringComparison.InvariantCulture)
      .GetResult()
      .ShouldBeSuccessful();
  }

  [Fact]
  public void Validator_Should_NotBePublic()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .Inherit(typeof(AbstractValidator<>))
      .Should()
      .NotBePublic()
      .GetResult()
      .ShouldBeSuccessful();
  }

  [Fact]
  public void DomainEventHandler_Should_BeSealed()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .ImplementInterface(typeof(IDomainEventHandler<>))
      .Should()
      .BeSealed()
      .GetResult()
      .ShouldBeSuccessful();
  }

  [Fact]
  public void DomainEventHandler_ShouldHave_NameEndingWith_DomainEventHandler()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .ImplementInterface(typeof(IDomainEventHandler<>))
      .Should()
      .HaveNameEndingWith("DomainEventHandler", StringComparison.InvariantCulture)
      .GetResult()
      .ShouldBeSuccessful();
  }

  [Fact]
  public void DomainEventHandler_Should_NotBePublic()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .ImplementInterface(typeof(IDomainEventHandler<>))
      .Should()
      .NotBePublic()
      .GetResult()
      .ShouldBeSuccessful();
  }
}