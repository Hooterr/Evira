using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evira.App.AttachedProperties
{
    public static class SelectedIconProperty
    {
        public static readonly BindableProperty SourceProperty = BindableProperty
         .CreateAttached("Source", typeof(ImageSource), typeof(Image), null);

        public static ImageSource GetSource(BindableObject view) => (ImageSource)view.GetValue(SourceProperty);

        public static void SetSource(BindableObject view, ImageSource value) => view.SetValue(SourceProperty, value);
    }
}
