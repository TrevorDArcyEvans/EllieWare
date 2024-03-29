﻿namespace Internals.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Reflection;

    static class TypeExtensions
    {
        static readonly TypeNameFormatter _typeNameFormatter = new TypeNameFormatter();

#if !NETFX_CORE
        public static IEnumerable<PropertyInfo> GetAllProperties(this Type type)
        {
            const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            PropertyInfo[] properties = type.GetProperties(bindingFlags);
            if (type.IsInterface)
            {
                return properties.Concat(type.GetInterfaces().SelectMany(x => x.GetProperties(bindingFlags)));
            }

            return properties;
        }
#else
        public static IEnumerable<PropertyInfo> GetAllProperties(this Type type)
        {
            var typeInfo = type.GetTypeInfo();

            return GetAllProperties(typeInfo);
        }

        public static IEnumerable<PropertyInfo> GetAllProperties(this TypeInfo typeInfo)
        {
            if (typeInfo.BaseType != null)
                foreach (var prop in GetAllProperties(typeInfo.BaseType))
                    yield return prop;

            var properties = typeInfo.DeclaredMethods
                .Where(x => x.IsSpecialName && x.Name.StartsWith("get_") && !x.IsStatic)
                .Select(x => typeInfo.GetDeclaredProperty(x.Name.Substring("get_".Length)))
                .ToList();

            if (typeInfo.IsInterface)
            {
                foreach (var prop in properties.Concat(typeInfo.ImplementedInterfaces.SelectMany(x => x.GetTypeInfo().DeclaredProperties)))
                    yield return prop;
                
                yield break;
            }

            foreach (var info in properties)
                yield return info;
        }
#endif

#if !NETFX_CORE
        public static IEnumerable<PropertyInfo> GetAllStaticProperties(this Type type)
        {
            const BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy;

            return type.GetProperties(bindingFlags);
        }

        public static IEnumerable<PropertyInfo> GetStaticProperties(this Type type)
        {
            const BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;

            return type.GetProperties(bindingFlags);
        }
#else 
        public static IEnumerable<PropertyInfo> GetAllStaticProperties(this Type type)
        {
            var info = type.GetTypeInfo();

            if (info.BaseType != null)
                foreach (var prop in GetAllStaticProperties(info.BaseType))
                    yield return prop;

            var props = info.DeclaredMethods
                            .Where(x => x.IsSpecialName && x.Name.StartsWith("get_") && x.IsStatic)
                            .Select(x => info.GetDeclaredProperty(x.Name.Substring("get_".Length)));

            foreach (var propertyInfo in props)
                yield return propertyInfo;
        }

        public static IEnumerable<PropertyInfo> GetStaticProperties(this Type type)
        {
            var info = type.GetTypeInfo();

            var props = info.DeclaredMethods
                            .Where(x => x.IsSpecialName && x.Name.StartsWith("get_") && x.IsStatic)
                            .Select(x => info.GetDeclaredProperty(x.Name.Substring("get_".Length)));

            foreach (var propertyInfo in props)
                yield return propertyInfo;
        }
#endif
        /// <summary>
        /// Determines if a type is neither abstract nor an interface and can be constructed.
        /// </summary>
        /// <param name="type">The type to check</param>
        /// <returns>True if the type can be constructed, otherwise false.</returns>
        public static bool IsConcrete(this Type type)
        {
#if !NETFX_CORE
            return !type.IsAbstract && !type.IsInterface;
#else
            var typeInfo = type.GetTypeInfo();
            return !typeInfo.IsAbstract && !typeInfo.IsInterface;
#endif
        }

        /// <summary>
        /// Determines if a type can be constructed, and if it can, additionally determines
        /// if the type can be assigned to the specified type.
        /// </summary>
        /// <param name="type">The type to evaluate</param>
        /// <param name="assignableType">The type to which the subject type should be checked against</param>
        /// <returns>True if the type is concrete and can be assigned to the assignableType, otherwise false.</returns>
        public static bool IsConcreteAndAssignableTo(this Type type, Type assignableType)
        {
#if !NETFX_CORE
            return IsConcrete(type) && assignableType.IsAssignableFrom(type);
#else
            return IsConcrete(type) && assignableType.GetTypeInfo().IsAssignableFrom(type.GetTypeInfo());
#endif
        }

#if NET35
        public static bool HasFlag(this Enum variable, Enum value)
        {
            if (variable == null)
                return false;

            if (value == null)
                throw new ArgumentNullException("value");

            // Not as good as the .NET 4 version of this function, but should be good enough
            if (!Enum.IsDefined(variable.GetType(), value))
            {
                throw new ArgumentException(string.Format(
                    "Enumeration type mismatch.  The flag is of type '{0}', was expecting '{1}'.",
                    value.GetType(), variable.GetType()));
            }

            ulong num = Convert.ToUInt64(value);
            return ((Convert.ToUInt64(variable) & num) == num);
        }
#endif

        /// <summary>
        /// Determines if a type can be constructed, and if it can, additionally determines
        /// if the type can be assigned to the specified type.
        /// </summary>
        /// <param name="type">The type to evaluate</param>
        /// <typeparam name="T">The type to which the subject type should be checked against</typeparam>
        /// <returns>True if the type is concrete and can be assigned to the assignableType, otherwise false.</returns>
        public static bool IsConcreteAndAssignableTo<T>(this Type type)
        {
#if !NETFX_CORE
            return IsConcrete(type) && typeof(T).IsAssignableFrom(type);
#else
            return IsConcrete(type) && typeof(T).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo());
#endif
        }

        /// <summary>
        /// Determines if the type is a nullable type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>True if the type can be null</returns>
        public static bool IsNullable(this Type type)
        {
#if !NETFX_CORE
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
#else
            var typeInfo = type.GetTypeInfo();
            return typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>).GetTypeInfo();
#endif
        }

        /// <summary>
        /// Determines if the type is a nullable type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="underlyingType">The underlying type of the nullable</param>
        /// <returns>True if the type can be null</returns>
        public static bool IsNullable(this Type type, out Type underlyingType)
        {
#if !NETFX_CORE
            bool isNullable = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
            underlyingType = isNullable ? Nullable.GetUnderlyingType(type) : null;
            return isNullable;
#else
            var typeInfo = type.GetTypeInfo();
            bool isNullable = typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>).GetTypeInfo();
            underlyingType = isNullable ? Nullable.GetUnderlyingType(type) : null;
            return isNullable;
#endif
        }

        /// <summary>
        /// Determines if the type is an open generic with at least one unspecified generic argument
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>True if the type is an open generic</returns>
        public static bool IsOpenGeneric(this Type type)
        {
#if !NETFX_CORE
            return type.IsGenericTypeDefinition || type.ContainsGenericParameters;
#else
            var typeInfo = type.GetTypeInfo();
            return typeInfo.IsGenericTypeDefinition || typeInfo.ContainsGenericParameters;
#endif
        }

        /// <summary>
        /// Determines if a type can be null
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>True if the type can be null</returns>
        public static bool CanBeNull(this Type type)
        {
#if !NETFX_CORE
            return !type.IsValueType || type.IsNullable() || type == typeof(string);
#else
            var typeInfo = type.GetTypeInfo();
            return !typeInfo.IsValueType || type.IsNullable() || typeInfo == typeof(string);
#endif
        }

        public static string GetTypeName(this Type type)
        {
            return _typeNameFormatter.GetTypeName(type);
        }
    }
}

namespace System.Reflection
{
    using Linq;

#if !NETFX_CORE
    static class TypeExtensions
    {
        public static Type GetTypeInfo(this Type type)
        {
            return type;
        }
    }


    static class PropertyInfoExtensions
    {
        const BindingFlags SetValueFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        public static void SetValue(this PropertyInfo propertyInfo, object instance, object value)
        {
            propertyInfo.SetValue(instance, value, SetValueFlags, null, null, null);
        }
    }
#else
    static class TypeInfoExtensions
    {
        public static Type[] GetGenericArguments(this TypeInfo typeInfo)
        {
            return typeInfo.GenericTypeArguments;
        }

        public static Type[] GetInterfaces(this TypeInfo typeInfo)
        {
            return typeInfo.ImplementedInterfaces.ToArray();
        }

        public static MethodInfo GetGetMethod(this PropertyInfo typeInfo, bool includeNonPublic = false)
        {
            return typeInfo.GetMethod;
        }

        public static MethodInfo GetSetMethod(this PropertyInfo typeInfo, bool includeNonPublic = false)
        {
            return typeInfo.SetMethod;
        }
    }
#endif
}
