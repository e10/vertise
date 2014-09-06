using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Vertise.Core.Abstractions;

namespace Vertise.Core.Helpers {
    public class BackendDatabaseHelper {
        public static void InjectModels(DbModelBuilder modelBuilder) {
            List<Type> types = ReflectionHelper.GetClassesThatImplementingType(typeof(IHasModelConfiguration)).ToList();
            foreach(Type type in types) {
                MethodInfo method = type.GetMethod("InjectModelConfiguration", BindingFlags.NonPublic | BindingFlags.Static);
                if(method != null) {
                    method.Invoke(null, new object[] { modelBuilder });
                }
            }
        }
    }
    public static class ReflectionHelper {
        public static IList<Type> GetTypesThatImplementingType(Type type) {
            IList<Type> types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(type.IsAssignableFrom)
                .ToList();
            return types;
        }

        public static IList<Type> GetClassesThatImplementingType(Type type) {
            IList<Type> types = GetTypesThatImplementingType(type);
            types = types.Where(x => x.IsClass && !x.IsAbstract).ToList();
            return types;
        }

        public static bool CheckAttributeExistAndReturnValue<T, V>(this PropertyInfo property, Expression<Func<T, V>> expression, out V result)
            where T : Attribute {
            var exist = false;
            result = default(V);
            var attributes = property.GetCustomAttributes(true);
            foreach(var o in attributes) {
                var attr = o as T;
                if(attr != null) {
                    var prop = attr.GetType().GetProperty(ExpressionHelper.GetExpressionText(expression));
                    result = (V)prop.GetValue(attr);
                    return true;
                }
            }

            return exist;
        }

        public static bool HasAttribute<T>(this PropertyInfo property)
            where T : Attribute {
            var attributes = property.GetCustomAttributes(typeof(T), true);
            return attributes.Any();
        }
    }
}