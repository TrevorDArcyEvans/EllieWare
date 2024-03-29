﻿namespace Internals.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using Reflection;


    class DynamicObjectConverter<T, TImplementation> :
        ObjectConverter
        where TImplementation : T, new()
        where T : class
    {
        readonly ObjectConverterCache _cache;
        readonly ObjectMapper<TImplementation>[] _converters;
        readonly ReadWritePropertyCache<TImplementation> _propertyCache;

        public DynamicObjectConverter(ObjectConverterCache cache)
        {
            _cache = cache;
            _propertyCache = new ReadWritePropertyCache<TImplementation>();
            _converters = _propertyCache
                .Select(property => GetDictionaryToObjectConverter(property, property.Property.PropertyType))
                .ToArray();
        }

        public object GetObject(ObjectValueProvider valueProvider)
        {
            var implementation = new TImplementation();

            for (int i = 0; i < _converters.Length; i++)
                _converters[i].ApplyTo(implementation, valueProvider);

            return implementation;
        }

        ObjectMapper<TImplementation> GetDictionaryToObjectConverter(
            ReadWriteProperty<TImplementation> property, Type valueType)
        {
            Type underlyingType = Nullable.GetUnderlyingType(valueType);
            if (underlyingType != null)
            {
                Type converterType =
                    typeof(NullableValueObjectMapper<,>).MakeGenericType(typeof(TImplementation),
                        underlyingType);

                return (ObjectMapper<TImplementation>)Activator.CreateInstance(converterType, property);
            }

            if (valueType.IsEnum)
                return new EnumObjectMapper<TImplementation>(property);

            if (valueType.IsArray)
            {
                Type elementType = valueType.GetElementType();
                if (elementType.IsValueType || elementType == typeof(string))
                {
                    Type valueConverterType = typeof(ValueArrayObjectMapper<,>).MakeGenericType(
                        typeof(TImplementation), elementType);
                    return (ObjectMapper<TImplementation>)Activator.CreateInstance(valueConverterType, property);
                }

                ObjectConverter elementConverter = _cache.GetConverter(elementType);

                Type converterType = typeof(ObjectArrayObjectMapper<,>).MakeGenericType(typeof(TImplementation),
                    elementType);
                return
                    (ObjectMapper<TImplementation>)Activator.CreateInstance(converterType, property, elementConverter);
            }

            if (valueType.IsValueType || valueType == typeof(string))
                return new ValueObjectMapper<TImplementation>(property);

            if (valueType.ClosesType(typeof(IEnumerable<>)))
            {
                if (valueType.ClosesType(typeof(IDictionary<,>)))
                {
                    Type[] genericArguments = valueType.GetClosingArguments(typeof(IDictionary<,>)).ToArray();

                    Type keyType = genericArguments[0];
                    Type elementType = genericArguments[1];


                    if (keyType.IsValueType || keyType == typeof(string))
                    {
                        if (elementType.IsValueType || elementType == typeof(string))
                        {
                            Type valueConverterType =
                                typeof(ValueValueDictionaryObjectMapper<,,>).MakeGenericType(typeof(TImplementation),
                                    keyType, elementType);
                            return (ObjectMapper<TImplementation>)Activator.CreateInstance(valueConverterType, property);
                        }
                        else
                        {
                            ObjectConverter elementConverter = _cache.GetConverter(elementType);
                            Type valueConverterType =
                                typeof(ValueObjectDictionaryObjectMapper<,,>).MakeGenericType(typeof(TImplementation),
                                    keyType, elementType);
                            return
                                (ObjectMapper<TImplementation>)
                                Activator.CreateInstance(valueConverterType, property, elementConverter);
                        }
                    }

                    throw new InvalidOperationException("A dictionary with a reference type key is not supported: "
                                                        + property.Property.Name);
                }


                if (valueType.ClosesType(typeof(IList<>)) || valueType.ClosesType(typeof(IEnumerable<>)))
                {
                    Type[] genericArguments = valueType.GetClosingArguments(typeof(IEnumerable<>)).ToArray();
                    Type elementType = genericArguments[0];

                    if (elementType.IsValueType || elementType == typeof(string))
                    {
                        Type valueConverterType =
                            typeof(ValueListObjectMapper<,>).MakeGenericType(typeof(TImplementation),
                                elementType);

                        return (ObjectMapper<TImplementation>)Activator.CreateInstance(valueConverterType, property);
                    }

                    ObjectConverter elementConverter = _cache.GetConverter(elementType);

                    Type converterType = typeof(ObjectListObjectMapper<,>).MakeGenericType(typeof(TImplementation),
                        elementType);

                    return (ObjectMapper<TImplementation>)Activator.CreateInstance(converterType, property,
                        elementConverter);
                }
            }

            return new ObjectObjectMapper<TImplementation>(property, _cache.GetConverter(valueType));
        }
    }
}