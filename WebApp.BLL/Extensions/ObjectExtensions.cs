using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WebApp.BLL.Extensions
{
    public static class ObjectExtensions
    {

        #region Copy

        public static TSource CloneObject<TSource>(this TSource from)
            where TSource : class, new()
        {
            return from.CopyObject(new TSource());
        }

        public static TDestination CopyObject<TSource, TDestination>(this TSource from, TDestination to = default(TDestination))
            where TSource : class
            where TDestination : class, new()
        {
            if (to == null)
            {
                to = Activator.CreateInstance<TDestination>();
            }

            if (from == null)
            {
                return to;
            }

            try
            {
                var fromType = from.GetType();
                var toType = to.GetType();

                var fromProps = fromType.GetProperties();
                var toProps = toType.GetProperties();

                var fromFields = fromType.GetFields();
                var toFields = toType.GetFields();


                #region CASE 1. Both objects have props

                if (fromProps.Length > 0 && toProps.Length > 0)
                {
                    foreach (var fromProp in fromProps)
                    {
                        var fromPropType = fromProp.GetType();
                        var toProp = toType.GetProperties().FirstOrDefault(p => p.Name == fromProp.Name);

                        if (toProp != null)
                        {
                            if (toProp.PropertyType.Namespace != "System")
                            {
                                var typeToList = toProp.PropertyType.GetElementType();
                                var fromList = fromProp.GetValue(@from, null) as IList;
                                var fromArray = fromProp.GetValue(@from, null) as Array;
                                Type toListElementType = null;
                                if (toProp.PropertyType.GetGenericArguments().Count() > 0)
                                    toListElementType = toProp.PropertyType.GetGenericArguments()[0];

                                if (!toProp.PropertyType.IsArray && fromList == null)
                                {
                                    var ci = toProp.PropertyType.GetConstructor(new Type[0]);
                                    if (ci != null)
                                    {
                                        toProp.SetValue(to, ci.Invoke(null), null);
                                        toProp.SetValue(to, CopyObject(fromProp.GetValue(@from, null), toProp.GetValue(to, null)), null);
                                        continue;
                                    }
                                }
                                #region Array|List copy

                                if (!toProp.PropertyType.IsArray && fromList != null)
                                //if (toListType != null && fromList != null)
                                {
                                    toProp.SetValue(to, CopyList(fromList, toListElementType), null);
                                    continue;
                                }

                                if (toProp.PropertyType.IsArray && fromArray != null)
                                {
                                    toProp.SetValue(to, CopyArray(fromArray, typeToList), null);
                                    continue;
                                }

                                #endregion
                            }
                            else
                            {
                                try
                                {
                                    var obj = fromProp.GetValue(@from, null);
                                    toProp.SetValue(to, obj, null);
                                }
                                catch { }
                            }
                        }
                    }
                }
                #endregion

                #region CASE 2. 'from' obj have props 'to' have fields
                else
                    if (fromProps.Length > 0 && toFields.Length > 0)
                {
                    foreach (PropertyInfo fromProp in fromProps)
                    {
                        var toProp = toType.GetFields().FirstOrDefault(p => p.Name == fromProp.Name);

                        if (toProp != null)
                        {
                            if (toProp.FieldType.Module.ScopeName != "System")
                            {
                                var typeToList = toProp.FieldType.GetElementType();
                                var fromList = fromProp.GetValue(@from, null) as IList;
                                var fromArray = fromProp.GetValue(@from, null) as Array;

                                if (!toProp.FieldType.IsArray && fromList == null)
                                {
                                    var ci = toProp.FieldType.GetConstructor(new Type[0]);
                                    if (ci != null)
                                    {
                                        toProp.SetValue(to, ci.Invoke(null));
                                        toProp.SetValue(to, CopyObject(fromProp.GetValue(@from, null), toProp.GetValue(to)));
                                        continue;
                                    }
                                }

                                #region Array|List copy

                                if (!toProp.FieldType.IsArray && fromList != null)
                                {
                                    toProp.SetValue(to, CopyList(fromList, typeToList));
                                    continue;
                                }

                                if (toProp.FieldType.IsArray && fromArray != null)
                                {
                                    toProp.SetValue(to, CopyArray(fromArray, typeToList));
                                    continue;
                                }

                                #endregion

                                continue;
                            }
                            else
                            {
                                try
                                {
                                    var obj = fromProp.GetValue(@from, null);
                                    var convertedObj = Convert.ChangeType(obj, toProp.FieldType);
                                    toProp.SetValue(to, obj);
                                }
                                catch { }
                            }
                        }
                    }
                }
                #endregion

                #region CASE 3. 'from' obj have fields 'to' have props
                else
                        if (fromFields.Length > 0 && toProps.Length > 0)
                {
                    foreach (FieldInfo fromField in fromFields)
                    {
                        var toProp = toType.GetProperties().FirstOrDefault(p => p.Name == fromField.Name);

                        if (toProp != null)
                        {
                            if (toProp.PropertyType.Module.ScopeName != "CommonLanguageRuntimeLibrary")
                            {
                                var typeToList = fromField.FieldType.GetElementType();
                                var fromList = fromField.GetValue(@from) as IList;
                                var fromArray = fromField.GetValue(@from) as Array;

                                if (!toProp.PropertyType.IsArray && fromList == null)
                                {
                                    var ci = toProp.PropertyType.GetConstructor(new Type[0]);
                                    if (ci != null)
                                    {
                                        toProp.SetValue(to, ci.Invoke(null), null);
                                        toProp.SetValue(to, CopyObject(fromField.GetValue(@from), toProp.GetValue(to, null)), null);
                                        continue;
                                    }
                                }
                                else
                                {
                                    #region Array|List copy

                                    if (!toProp.PropertyType.IsArray && fromList != null)
                                    {
                                        toProp.SetValue(to, CopyList(fromList, typeToList), null);
                                        continue;
                                    }

                                    if (toProp.PropertyType.IsArray && fromArray != null)
                                    {
                                        toProp.SetValue(to, CopyArray(fromArray, typeToList), null);
                                        continue;
                                    }

                                    #endregion
                                }
                            }
                            else
                            {
                                try
                                {
                                    var obj = fromField.GetValue(@from);
                                    var convertedObj = Convert.ChangeType(obj, toProp.PropertyType);
                                    toProp.SetValue(to, obj, null);
                                }
                                catch { }
                            }
                        }
                    }
                }
                #endregion

            }
            catch //(Exception ex)
            {
            }
            return to;
        }

        public static Array CopyArray(this Array from, Type toType)
        {
            Array toArray = null;
            if (@from != null)
            {
                toArray = Array.CreateInstance(toType, @from.Length);

                for (int i = 0; i < @from.Length; i++)
                {
                    ConstructorInfo ci = toType.GetConstructor(new Type[0]);
                    if (ci != null)
                    {
                        toArray.SetValue(ci.Invoke(null), i);
                        toArray.SetValue(CopyObject(@from.GetValue(i), toArray.GetValue(i)), i);
                    }
                }
            }
            return toArray;
        }

        public static IList CopyList(this IList from, Type toType)
        {
            IList toList = null;
            if (@from != null)
            {
                //toArray = Array.CreateInstance(toType, @from.Count);
                toList = (IList)typeof(List<>).MakeGenericType(toType).GetConstructor(Type.EmptyTypes).Invoke(null);

                for (int i = 0; i < @from.Count; i++)
                {
                    var ci = toType.GetConstructor(new Type[0]);
                    if (ci != null)
                    {
                        //toList.SetValue(ci.Invoke(null), i);
                        //toList.SetValue(CopyObject(@from[i], toList.GetValue(i)), i);
                        var obj = ci.Invoke(null);
                        obj = CopyObject(@from[i], obj);
                        toList.Add(obj);
                    }
                }
            }
            return toList;
        }

        #endregion

    }
}
