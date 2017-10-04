﻿using System;
using System.Threading.Tasks;
using FluentAssertions;
using Neutronium.MVVMComponents.Relay;
using NSubstitute;
using Xunit;

namespace Neutronium.Components.Tests
{
    public class RelaySimpleCommandTest
    {
        private Action _Action;
        private RelaySimpleCommand _RelaySimpleCommand;

        public RelaySimpleCommandTest() 
        {
            _Action = Substitute.For<Action>();
            _RelaySimpleCommand = new RelaySimpleCommand(_Action);
        }

        [Fact]
        public void Execute_without_argument_call_action() 
        {
            _RelaySimpleCommand.Execute();

            _Action.Received(1).Invoke();
        }

        [Fact]
        public void Execute_with_argument_call_action() 
        {
            _RelaySimpleCommand.Execute(null);

            _Action.Received(1).Invoke();
        }

        [Theory]
        [InlineData(null)]
        [InlineData(25)]
        public void CanExecute_returns_true(object argument) 
        {
            var canExecute = _RelaySimpleCommand.CanExecute(argument);

            canExecute.Should().BeTrue();
        }
    }
}
