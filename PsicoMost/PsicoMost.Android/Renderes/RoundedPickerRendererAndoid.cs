﻿using System;
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

[assembly: ExportRenderer(typeof(RoundedPicker), typeof(RoundedPickerRendererAndoid))]
namespace PsicoMost.Droid.Renderes
{
    public class RoundedPickerRendererAndoid : PickerRenderer
    {
        public RoundedPickerRendererAndoid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Picker> e)
        {
            base.OnElementChanged(e);


             if(e.OldElement == null)
            {
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetCornerRadius(50);              
                gradientDrawable.SetStroke(5, Android.Graphics.Color.Rgb(0,150,136));
                gradientDrawable.SetColor(Android.Graphics.Color.White);

                Control.SetBackground(gradientDrawable);

                Control.SetAllCaps(false);

                Control.SetPadding(40, Control.PaddingTop, Control.PaddingRight,
                    Control.PaddingBottom);

            }

        }
    }
}