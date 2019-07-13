using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace iSalesDeskPlus.Utils.Behaviors
{
    public class FloatingAmount : Behavior<Label>
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(double), typeof(FloatingAmount), null, propertyChanged: OnNumberChanged);

        public double Text
        {
            get { return (double)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public Label AssociatedObject { get; private set; }

        static void OnNumberChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var behavior = (FloatingAmount)bindable;
            if (behavior.AssociatedObject == null)
            {
                return;
            }

            var number = behavior.Text.ToString(CultureInfo.InvariantCulture);
            var decimalValue = number.Substring(number.IndexOf("."));
            var fs = new FormattedString();

            fs.Spans.Add(new Span { Text = behavior.Text.ToString("C0"), FontSize = behavior.AssociatedObject.FontSize });
            fs.Spans.Add(new Span { Text = decimalValue.Length > 2 ? decimalValue.Substring(0, 3) : decimalValue, FontSize = behavior.AssociatedObject.FontSize / 2 + 1 });

            behavior.AssociatedObject.VerticalTextAlignment = TextAlignment.Start;
            behavior.AssociatedObject.FormattedText = fs;
        }

        protected override void OnAttachedTo(Label bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;

            if (bindable.BindingContext != null)
            {
                BindingContext = bindable.BindingContext;
            }

            bindable.BindingContextChanged += OnBindingContextChanged;
        }

        protected override void OnDetachingFrom(Label bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= OnBindingContextChanged;
            AssociatedObject = null;
        }

        void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }
    }
}

