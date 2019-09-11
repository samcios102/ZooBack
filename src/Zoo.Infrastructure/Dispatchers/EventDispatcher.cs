using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Zoo.Application.Events;

namespace Zoo.Infrastructure.Dispatchers
{
     internal class EventDispatcher : IEventDispatcher
     {
         private readonly IServiceProvider _serviceProvider;
         public EventDispatcher(IServiceProvider serviceProvider)
         {
             _serviceProvider = serviceProvider;
         }
 
         public Task DispatchAsync <TEvent>(TEvent @event) where TEvent : IEvent
         {
             var handler = _serviceProvider.GetService<IEventHandler<TEvent>>();
             return handler.HandleAsync(@event);
         }
         
     }
 }