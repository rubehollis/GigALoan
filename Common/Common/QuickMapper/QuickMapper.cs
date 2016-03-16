using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.QuickMapper
{
    public static class QuickMapper
    {
        #region Extension Methods

        public static TDestination MapTo<TDestination>(this object Source, params string[] includeProperties) where TDestination : new()
        {
            return Map(Source, new TDestination(), includeProperties);
        }

        public static TDestination MapTo<TDestination>(this object Source, TDestination Destination, params string[] includeProperties)
        {
            return Map(Source, Destination, includeProperties);
        }

        public static T2 Map<T1, T2>(T1 Source, T2 Destination, params string[] includeProperties)
        {
            if ((Source.GetType().Name == "ICollection`1" || Source.GetType().GetInterface("ICollection`1") != null) &&
                (Destination.GetType().Name == "ICollection`1" || Destination.GetType().GetInterface("ICollection`1") != null))
            {
                var destinationGenericType = Destination.GetType();
                var destinationGenericArg = destinationGenericType.GetGenericArguments()[0];
                return DoMapCollection(Source, Destination, destinationGenericArg, includeProperties);
            }
            return DoMap(Source, Destination, includeProperties);
        }

        #endregion // Extension Methods

        #region Private Members

        static private object[] _ctorParams = new object[] { };

        private static dynamic DoMapCollection(dynamic source, dynamic destination, Type destinationGenericArg, params string[] includeProperties)
        {
            if (destinationGenericArg.GetConstructor(Type.EmptyTypes) != null)
            {
                foreach (var src in source)
                {
                    var dest = System.Activator.CreateInstance(destinationGenericArg, _ctorParams);
                    destination.Add(DoMap(src, dest, includeProperties));
                }
            }
            return destination;
        }

        private static dynamic DoMap(object source, object destination, params string[] includeProperties)
        {
            foreach (var destinationProperty in destination.GetType().GetProperties())
            {
                if (destinationProperty.SetMethod == null)
                    continue;

                var sourceProperty = source.GetType().GetProperty(destinationProperty.Name);

                if (sourceProperty == null)
                    continue;

                if (sourceProperty.PropertyType == destinationProperty.PropertyType)
                {
                    var sourceValue = sourceProperty.GetValue(source);
                    if (sourceValue == null)
                        continue;

                    destinationProperty.SetValue(destination, sourceValue);
                    continue;
                }

                if (includeProperties.Any())
                {
                    if (includeProperties.Where(x => x == destinationProperty.Name).Any())
                    {
                        var sourceValue = sourceProperty.GetValue(source);

                        if (sourceValue == null)
                            continue;

                        if (destinationProperty.PropertyType.GetConstructor(Type.EmptyTypes) != null)
                        {
                            var destinationMapValue = System.Activator.CreateInstance(destinationProperty.PropertyType, _ctorParams);
                            destinationProperty.SetValue(destination, Map(sourceValue, destinationMapValue));
                            continue;
                        }
                    }
                }
            }
            return destination;
        }

        #endregion // Private Members

        #region XML Extension Methods

        public static TDestination XmlMapTo<TDestination>(this XElement Source, string ElementChildName = null) where TDestination : new()
        {
            if (ElementChildName == null || !Source.HasElements)
                return MapXML(Source, new TDestination());

            var element = Source.Descendants(ElementChildName).FirstOrDefault();
            return MapXML(element, new TDestination());
        }

        public static TDestination XmlMapTo<TDestination>(this XElement Source, TDestination Destination, string ElementChildName = null) where TDestination : new()
        {
            if (ElementChildName == null || !Source.HasElements)
                return MapXML(Source, Destination);

            var element = Source.Descendants(ElementChildName).FirstOrDefault();
            return MapXML(element, Destination);
        }

        public static TDestination XmlMapTo<TDestination>(this XDocument Source, string ElementName = null) where TDestination : new()
        {
            TDestination destination = new TDestination();
            if (ElementName == null || !Source.Descendants().Any())
                return MapXML(Source.Root, destination);

            var element = Source.Descendants(ElementName).FirstOrDefault();
            return MapXML(element, destination);
        }

        public static TDestination XmlMapTo<TDestination>(this XDocument Source, TDestination Destination, string ElementName = null) where TDestination : new()
        {
            if (ElementName == null || !Source.Descendants().Any())
                return MapXML(Source.Root, Destination);

            var element = Source.Descendants(ElementName).FirstOrDefault();
            return MapXML(element, Destination);
        }

        public static T2 MapXML<T2>(XElement Source, T2 Destination)
        {
            if (Source.HasElements && (Destination.GetType().Name == "ICollection`1" || Destination.GetType().GetInterface("ICollection`1") != null))
            {
                var destinationGenericType = Destination.GetType();
                var destinationGenericArg = destinationGenericType.GetGenericArguments()[0];
                return DoMapXMLCollection(Source, Destination, destinationGenericArg);
            }
            return DoMapXML(Source, Destination);
        }

        #endregion // XML Extension Methods

        #region XML Private Members

        private static dynamic DoMapXMLCollection(XElement source, dynamic destination, Type destinationGenericArg)
        {
            if (destinationGenericArg.GetConstructor(Type.EmptyTypes) != null)
            {
                foreach (var src in source.Elements())
                {
                    var dest = System.Activator.CreateInstance(destinationGenericArg, _ctorParams);
                    destination.Add(DoMapXML(src, dest));
                }
            }
            return destination;
        }

        public static dynamic DoMapXML(XElement source, object destination)
        {
            foreach (var destinationProperty in destination.GetType().GetProperties())
            {
                if (destinationProperty.SetMethod == null)
                    continue;

                var sourceElement = source.Element(destinationProperty.Name);
                if (sourceElement == null)
                    continue;

                if (sourceElement.HasElements)
                {
                    if (destinationProperty.PropertyType.GetConstructor(Type.EmptyTypes) != null)
                    {
                        var destinationPropertyObj = System.Activator.CreateInstance(destinationProperty.PropertyType, _ctorParams);
                        destinationProperty.SetValue(destination, MapXML(sourceElement, destinationPropertyObj));
                        continue;
                    }
                }

                if (destinationProperty.PropertyType == typeof(byte[]))
                {
                    var sourceBytes = Convert.FromBase64String(sourceElement.Value);
                    destinationProperty.SetValue(destination, sourceBytes);
                    continue;
                }

                Type underlyingDestType = null;

                if (destinationProperty.PropertyType.IsGenericType && destinationProperty.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    underlyingDestType = Nullable.GetUnderlyingType(destinationProperty.PropertyType);

                dynamic convertedSourceValue;
                try
                {
                    convertedSourceValue = Convert.ChangeType(sourceElement.Value, underlyingDestType != null ? underlyingDestType : destinationProperty.PropertyType);
                }
                catch (InvalidCastException)
                {
                    continue;
                }
                destinationProperty.SetValue(destination, convertedSourceValue);
            }
            return destination;
        }

        #endregion // Private Members
    }

}
