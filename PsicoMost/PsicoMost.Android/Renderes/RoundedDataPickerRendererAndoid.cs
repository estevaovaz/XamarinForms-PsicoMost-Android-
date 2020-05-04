using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PsicoMost.Controls;
using PsicoMost.Droid.Renderes;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RoundedDataPicker), typeof(RoundedDataPickerRendererAndoid))]
namespace PsicoMost.Droid.Renderes
{
    public class RoundedDataPickerRendererAndoid : DatePickerRenderer
    {
        public RoundedDataPickerRendererAndoid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);


             if(e.OldElement == null)
            {
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetCornerRadius(50);
                gradientDrawable.SetStroke(5, Android.Graphics.Color.Rgb(0,150,136));
                gradientDrawable.SetColor(Android.Graphics.Color.White);
                
                Control.SetBackground(gradientDrawable);
               // Control.SetTextColor(Android.Graphics.Color.Black);
                                            
                Control.SetPadding(40, Control.PaddingTop, Control.PaddingRight,
                    Control.PaddingBottom);

            }

        }

       /* protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals(nameof(Element.IsEnabled)) && Control != null)
            {
                if (Element.IsEnabled)
                {
                    //Set the text color when the DatePicker is enabled
                    Control.SetTextColor(Android.Graphics.Color.Black);
                }
                else
                {
                    //Set the text color when the DatePicker is disabled
                    Control.SetTextColor(Android.Graphics.Color.Gray);
                }
            }
        }*/
    }
}