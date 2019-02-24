using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AnywhereChecklist.Apps.Helper
{
    static class BindingHelper
    {
        static internal BindableProperty CreateProperty<T, TSource>(string PropertyName,
                                object DefaultValue = null, Action<TSource, T, T> propertyChanged = null)
            where TSource : BindableObject
        {
            return BindableProperty.Create(PropertyName, typeof(T),
                                typeof(TSource), defaultValue: DefaultValue,
                                propertyChanged: (obj, oldVal, newVal)
                                        => propertyChanged((TSource)obj, (T)oldVal, (T)newVal));
        }
    }
}
