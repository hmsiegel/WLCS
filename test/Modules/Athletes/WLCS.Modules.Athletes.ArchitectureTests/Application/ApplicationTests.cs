// <copyright file="ApplicationTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.ArchitectureTests.Application;

/// <summary>
/// Tests the naming conventions and dependencies of the Application layer of the Administration module.
/// </summary>
public class ApplicationTests : BaseTest
{
  /// <summary>
  /// Asserts that a command should be sealed.
  /// </summary>
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

  /// <summary>
  /// Asserts that a command type should end with "Command".
  /// </summary>
  [Fact]
  public void Command_ShouldHave_NameEndingWith_Command()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .ImplementInterface(typeof(ICommand))
      .Or()
      .ImplementInterface(typeof(ICommand<>))
      .Should()
      .HaveNameEndingWith("Command", StringComparison.InvariantCultureIgnoreCase)
      .GetResult()
      .ShouldBeSuccessful();
  }

  /// <summary>
  /// Asserts that a command handler should not be public.
  /// </summary>
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

  /// <summary>
  /// Asserts that a command should be sealed.
  /// </summary>
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

  /// <summary>
  /// Asserts that a command handler type should end with "CommandHandler".
  /// </summary>
  [Fact]
  public void CommandHandler_ShouldHave_NameEndingWith_CommandHandler()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .ImplementInterface(typeof(ICommandHandler<>))
      .Or()
      .ImplementInterface(typeof(ICommandHandler<,>))
      .Should()
      .HaveNameEndingWith("CommandHandler", StringComparison.InvariantCultureIgnoreCase)
      .GetResult()
      .ShouldBeSuccessful();
  }

  /// <summary>
  /// Asserts that a query should be sealed.
  /// </summary>
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

  /// <summary>
  /// Asserts that a query type should end with "Query".
  /// </summary>
  [Fact]
  public void Query_ShouldHave_NameEndingWith_Query()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .ImplementInterface(typeof(IQuery<>))
      .Should()
      .HaveNameEndingWith("Query", StringComparison.InvariantCultureIgnoreCase)
      .GetResult()
      .ShouldBeSuccessful();
  }

  /// <summary>
  /// Asserts that a query handler should not be public.
  /// </summary>
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

  /// <summary>
  /// Asserts that a query should be sealed.
  /// </summary>
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

  /// <summary>
  /// Asserts that a query handler type should end with "QueryHandler".
  /// </summary>
  [Fact]
  public void QueryHandler_ShouldHave_NameEndingWith_QueryHandler()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .ImplementInterface(typeof(IQueryHandler<,>))
      .Should()
      .HaveNameEndingWith("QueryHandler", StringComparison.InvariantCultureIgnoreCase)
      .GetResult()
      .ShouldBeSuccessful();
  }

  /// <summary>
  /// Asserts that a validator should be sealed.
  /// </summary>
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

  /// <summary>
  /// Asserts that a validator type should end with "Validator".
  /// </summary>
  [Fact]
  public void Validator_ShouldHave_NameEndingWith_Validator()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .Inherit(typeof(AbstractValidator<>))
      .Should()
      .HaveNameEndingWith("Validator", StringComparison.InvariantCultureIgnoreCase)
      .GetResult()
      .ShouldBeSuccessful();
  }

  /// <summary>
  /// Asserts that a validator handler should not be public.
  /// </summary>
  [Fact]
  public void ValidatorHandler_Should_NotBePublic()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .Inherit(typeof(AbstractValidator<>))
      .Should()
      .NotBePublic()
      .GetResult()
      .ShouldBeSuccessful();
  }

  /// <summary>
  /// Asserts that a domain event handler should be sealed.
  /// </summary>
  [Fact]
  public void DomainEventHandler_Should_BeSealed()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .ImplementInterface(typeof(IDomainEventHandler<>))
      .Or()
      .Inherit(typeof(DomainEventHandler<>))
      .Should()
      .BeSealed()
      .GetResult()
      .ShouldBeSuccessful();
  }

  /// <summary>
  /// Asserts that a domain event handler type should end with "DomainEventHandler".
  /// </summary>
  [Fact]
  public void DomainEventHandler_ShouldHave_NameEndingWith_DomainEventHandler()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .ImplementInterface(typeof(IDomainEventHandler<>))
      .Or()
      .Inherit(typeof(DomainEventHandler<>))
      .Should()
      .HaveNameEndingWith("DomainEventHandler", StringComparison.InvariantCultureIgnoreCase)
      .GetResult()
      .ShouldBeSuccessful();
  }

  /// <summary>
  /// Asserts that a domain event handler handler should not be public.
  /// </summary>
  [Fact]
  public void DomainEventHandlerHandler_Should_NotBePublic()
  {
    Types.InAssembly(ApplicationAssembly)
      .That()
      .ImplementInterface(typeof(IDomainEventHandler<>))
      .Or()
      .Inherit(typeof(DomainEventHandler<>))
      .Should()
      .NotBePublic()
      .GetResult()
      .ShouldBeSuccessful();
  }
}
