using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Zoo.Application.Commands;

namespace Zoo.Api
{
    public static class Extensions
    {
        public static TCommand Bind<TCommand>(this TCommand model, Expression<Func<TCommand, Guid>> expression, Guid id) where TCommand : ICommand
        {
            var memberExpression = expression.Body as MemberExpression;
            
            
            if (memberExpression is null)
            {
                memberExpression = ((UnaryExpression)expression.Body).Operand as MemberExpression;
            }
            
            var propertyName = memberExpression.Member.Name.ToLowerInvariant();
            
            
            var modelType = model.GetType();
            var field = modelType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .SingleOrDefault(x => x.Name.ToLowerInvariant().StartsWith($"<{propertyName}>"));
            
            if (field is null)
            {
                return model;
            }
            field.SetValue(model, id);

            return model;
        }
    }
}