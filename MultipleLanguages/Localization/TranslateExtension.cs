using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;
using System.Windows;
using System.Windows.Data;
using System.Threading;
using System.ComponentModel;
using System.Reflection;
using System.Collections.ObjectModel;

namespace Localization
{
    [ContentProperty("Parameters")]
    public class TranslateExtension : MarkupExtension
    {
        #region Fields

        private DependencyProperty _property;
        private DependencyObject _target;
        private readonly Collection<BindingBase> _parameters = new Collection<BindingBase>();

        #endregion

        #region Properties

        public Collection<BindingBase> Parameters
        {
            get { return _parameters; }
        }

        private bool IsDataBound
        {
            get { return BindingOperations.IsDataBound(_target, _property); }
        }

        #region UidProperty DProperty

        public static string GetUid(DependencyObject obj)
        {
            return (string)obj.GetValue(UidProperty);
        }

        public static void SetUid(DependencyObject obj, string value)
        {
            obj.SetValue(UidProperty, value);
        }

        public static readonly DependencyProperty UidProperty =
            DependencyProperty.RegisterAttached("Uid", typeof(string), typeof(TranslateExtension), new UIPropertyMetadata(string.Empty));

        #endregion

        #endregion

        #region Overrides

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            IProvideValueTarget service = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            if (service == null)
            {
                throw new InvalidOperationException("IProvideValueTarget service is unavailable");
            }
            DependencyProperty property = service.TargetProperty as DependencyProperty;
            if (property == null)
            {
                throw new ArgumentException("Target property must be of type DependencyProperty");
            }
            DependencyObject target = service.TargetObject as DependencyObject;
            if (target == null)
            {
                return this;
            }

            this._target = target;
            this._property = property;
            //FrameworkElement element = _target as FrameworkElement;
            //if (element != null)
            //{
            //	element.Loaded += element_Loaded;
            //	element.Unloaded += element_Unloaded;
            //}
            //else
            //{
            BindDictionary();
            //}
            return _target.GetValue(_property);
        }

        #endregion

        #region Privates

        void element_Loaded(object sender, RoutedEventArgs e)
        {
            if (!IsDataBound)
            {
                BindDictionary();
            }
        }

        void element_Unloaded(object sender, RoutedEventArgs e)
        {
            if (IsDataBound)
            {
                BindingOperations.ClearBinding(_target, _property);
            }
        }

        private void BindDictionary()
        {
            string uid = GetUid(_target);
            string vid = _property.Name;

            Binding binding = new Binding("Dictionary");
            binding.Source = LanguageContext.Instance;
            binding.Mode = BindingMode.TwoWay;
            LanguageConverter converter = new LanguageConverter(uid, vid);
            if (_parameters.Count == 0)
            {
                binding.Converter = converter;
                BindingOperations.SetBinding(_target, _property, binding);
            }
            else
            {
                MultiBinding multiBinding = new MultiBinding();
                multiBinding.Mode = BindingMode.TwoWay;
                multiBinding.Converter = converter;
                multiBinding.Bindings.Add(binding);
                if (string.IsNullOrEmpty(uid))
                {
                    Binding uidBinding = _parameters[0] as Binding;
                    if (uidBinding == null)
                    {
                        throw new ArgumentException("Uid Binding parameter must be the first, and of type Binding");
                    }
                }
                foreach (Binding parameter in _parameters)
                {
                    multiBinding.Bindings.Add(parameter);
                }
                BindingOperations.SetBinding(_target, _property, multiBinding);
            }
        }

        #endregion

    }
}
