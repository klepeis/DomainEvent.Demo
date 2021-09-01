using DomainEvent.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace DomainEvent.Infrastructure
{
    //https://udidahan.com/2009/06/14/domain-events-salvation/

    public static class DomainEvents
    {
        [ThreadStatic]
        private static List<Delegate> _actions;

        private static IServiceProvider _serviceProvider { get; set; }

        public static void Configure(IApplicationBuilder app)
        {
            
            _serviceProvider = app.ApplicationServices;
        }

        /// <summary>
        /// This method is used to register a listener.
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="callback"></param>
        public static void Register<TEvent>(Action<TEvent> callback) where TEvent : IDomainEvent
        {
            if (_actions == null)
            {
                _actions = new List<Delegate>();
            }

            _actions.Add(callback);
        }

        public static void ClearCallbacks()
        {
            _actions = null;
        }

        /// <summary>
        /// This method is used to raise an even to cause something to happen at another part of the domain.
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="args"></param>
        public static void Raise<TEvent>(TEvent args) where TEvent : IDomainEvent
        {
            if (_serviceProvider != null)
            {
                using (var scope = _serviceProvider.CreateScope())
                { 
                    foreach (var handler in scope.ServiceProvider.GetServices<IHandles<TEvent>>())
                    {
                        handler.Handle(args);
                    }
                }
            }

            if (_actions != null)
            {
                foreach(var action in _actions)
                {
                    if(_actions is Action<TEvent>)
                    {
                        ((Action<TEvent>)action)(args);
                    }
                }
            }
        }
    }
}
