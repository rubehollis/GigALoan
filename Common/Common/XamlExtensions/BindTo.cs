using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using System.Windows.Data;
using System.Windows;
using System.Windows.Input;
using System.Reflection;
using System.Windows.Controls;
using System.ComponentModel;
using System.Globalization;
using System.Collections.ObjectModel;
using Common.QuickMapper;

[assembly: XmlnsDefinition("http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Common.XamlExtensions")]
namespace Common.XamlExtensions
{
    public class BindToExtension : MarkupExtension
    {
        #region private fields

        private Binding _Binding;
        private string _Path;
        private string _MethodName;

        #endregion // private fields

        #region Public Binding Properties

        [DefaultValue("")]
        public object AsyncState { get; set; }

        [DefaultValue(false)]
        public bool BindsDirectlyToSource { get; set; }

        [DefaultValue("")]
        public IValueConverter Converter { get; set; }

        [DefaultValue("")]
        [TypeConverter(typeof(CultureInfoIetfLanguageTagConverter))]
        public CultureInfo ConverterCulture { get; set; }

        [DefaultValue("")]
        public object ConverterParameter { get; set; }

        [DefaultValue("")]
        public string ElementName { get; set; }

        [DefaultValue(false)]
        public bool IsAsync { get; set; }

        private BindingMode _Mode = BindingMode.Default;
        public BindingMode Mode
        {
            get { return _Mode; }
            set { _Mode = value; }
        }

        [DefaultValue(false)]
        public bool NotifyOnSourceUpdated { get; set; }

        [DefaultValue(false)]
        public bool NotifyOnTargetUpdated { get; set; }

        [DefaultValue(false)]
        public bool NotifyOnValidationError { get; set; }

        public PropertyPath Path { get; set; }

        [DefaultValue("")]
        public RelativeSource RelativeSource { get; set; }

        public object Source { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UpdateSourceExceptionFilterCallback UpdateSourceExceptionFilter { get; set; }

        private UpdateSourceTrigger _UpdateSourceTrigger = UpdateSourceTrigger.Default;
        public UpdateSourceTrigger UpdateSourceTrigger 
        {
            get { return _UpdateSourceTrigger; }
            set { _UpdateSourceTrigger = value; }
        }

        [DefaultValue(false)]
        public bool ValidatesOnDataErrors { get; set; }

        [DefaultValue(false)]
        public bool ValidatesOnExceptions { get; set; }

        [DefaultValue(true)]
        public bool ValidatesOnNotifyDataErrors { get; set; }

        [DefaultValue("")]
        public string XPath { get; set; }

        #endregion //Public Binding Properties

        #region Constructors

        public BindToExtension()
        {
            this._Path = "DataContext";
            RelativeSource = new RelativeSource(RelativeSourceMode.Self);
        }

        public BindToExtension(string psPath)
        {
            this._Path = psPath;
        }

        #endregion Constructors

        #region Public Methods

        public void ProcessPath(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrWhiteSpace(_Path))
            {
                _Binding = this.MapTo<Binding>();
                return;
            }

            var Parts = _Path.Split('.').Select(o => o.Trim()).ToArray();

            RelativeSource oRelativeSource = null;
            string sElementName = null;

            var PartIndex = 0;

            if (Parts[0].StartsWith("#"))
            {
                sElementName = Parts[0].Substring(1);
                PartIndex++;
            }
            else if (Parts[0].ToLower() == "ancestors" || Parts[0].ToLower() == "ancestor")
            {
                if (Parts.Length < 2) throw new Exception("Invalid path, expected exactly 2 identifiers ancestors.#Type#.[Path] (e.g. Ancestors.DataGrid, Ancestors.DataGrid.SelectedItem, Ancestors.DataGrid.SelectedItem.Text)");
                int level = 1;
                if (int.TryParse(Parts[1], out level))
                {
                    var sType = Parts[2];
                    var oType = (Type)new System.Windows.Markup.TypeExtension(sType).ProvideValue(serviceProvider);
                    if (oType == null) throw new Exception("Could not find type: " + sType);
                    oRelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, oType, level);
                    PartIndex += 3;
                }
                else
                {
                    var sType = Parts[1];
                    var oType = (Type)new System.Windows.Markup.TypeExtension(sType).ProvideValue(serviceProvider);
                    if (oType == null) throw new Exception("Could not find type: " + sType);
                    oRelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, oType, 1);
                    PartIndex += 2;
                }
            }
            else if (Parts[0].ToLower() == "template" || Parts[0].ToLower() == "templateparent" || Parts[0].ToLower() == "templatedparent" || Parts[0].ToLower() == "templated")
            {
                oRelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent);
                PartIndex++;
            }
            else if (Parts[0].ToLower() == "thiswindow")
            {
                oRelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Window), 1);
                PartIndex++;
            }
            else if (Parts[0].ToLower() == "thisusercontrol")
            {
                oRelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UserControl), 1);
                PartIndex++;
            }
            else if (Parts[0].ToLower() == "this")
            {
                oRelativeSource = new RelativeSource(RelativeSourceMode.Self);
                PartIndex++;
            }

            else if (Parts[0].ToLower() == "prev" || Parts[0].ToLower() == "previous" || Parts[0].ToLower() == "prevdata" || Parts[0].ToLower() == "previousdata")
            {
                oRelativeSource = new RelativeSource(RelativeSourceMode.PreviousData);
                PartIndex++;
            }

            var PartsForPathString = Parts.Skip(PartIndex);
            bool isFunction = false;
            IValueConverter ValueConverter = null;

            if (PartsForPathString.Any())
            {
                var sLastPartForPathString = PartsForPathString.Last();
                if (sLastPartForPathString.EndsWith("()"))
                {
                    PartsForPathString = PartsForPathString.Take(PartsForPathString.Count() - 1);
                    _MethodName = sLastPartForPathString.Remove(sLastPartForPathString.Length - 2);
                    ValueConverter = new CallMethodValueConverter(_MethodName);
                    isFunction = true;
                }
            }

            var path = string.Join(".", PartsForPathString.ToArray());

            if (!string.IsNullOrWhiteSpace(path))
            {
                _Binding = new Binding(path);
                Path = _Binding.Path;
            }
            else
            {
                if (isFunction)
                    _Binding = new Binding();
                else
                   _Binding = new Binding("DataContext");
                Path = _Binding.Path;
            }

            if (sElementName != null)
            {
                ElementName = sElementName;
            }

            if (oRelativeSource != null)
            {
                RelativeSource = oRelativeSource;
            }

            if (ValueConverter != null)
            {
                Converter = ValueConverter;
            }

            this.MapTo(_Binding);
        }

        public override object ProvideValue(IServiceProvider poServiceProvider)
        {
            if (!(poServiceProvider is IXamlTypeResolver)) return null; // NOTE, this is to prevent the design time editor from showing an error related to the user of TypeExtension in ProcessPath
            ProcessPath(poServiceProvider);
            return _Binding.ProvideValue(poServiceProvider);
        }

        #endregion // Public Methods

        #region IValueConverter Class

        private class CallMethodValueConverter : IValueConverter
        {
            private string msMethodName;

            public CallMethodValueConverter(string psMethodName)
            {
                msMethodName = psMethodName;
            }

            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value == null) return null;
                return new CallMethodCommand(value, msMethodName);
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        #endregion // IValueConverter Class

        #region ICommand Class

        private class CallMethodCommand : ICommand
        {
            private readonly object _object;

            private readonly MethodInfo _doMethodInfo;
            private readonly MethodInfo _canDoMethodInfo;

            private readonly PropertyInfo _doCommandPropertyInfo;
            private readonly PropertyInfo _canDoCommandPropertyInfo;

            private readonly PropertyInfo _canDoPropertyInfo;

            public CallMethodCommand(object obj, string psMethodName)
            {
                _object = obj;
                var objectType = obj.GetType();

                _doCommandPropertyInfo = objectType.GetProperty(psMethodName);

                if (_doCommandPropertyInfo != null)
                {
                    if (!_doCommandPropertyInfo.PropertyType.IsSubclassOf(typeof(Delegate)))
                        _doCommandPropertyInfo = null; 
                }
                else
                {
                    _doMethodInfo = _object.GetType().GetMethod(psMethodName);
                    if (_doMethodInfo == null) return;
                }

                _canDoPropertyInfo = objectType.GetProperty("Can" + psMethodName);

                if (_canDoPropertyInfo != null)
                {
                    if (_canDoPropertyInfo.PropertyType == typeof(bool))
                        return;

                    else if (_canDoPropertyInfo.PropertyType.IsSubclassOf(typeof(Delegate)))
                    {
                        _canDoCommandPropertyInfo = _canDoPropertyInfo;
                        _canDoPropertyInfo = null;
                    }
                }
                else
                {
                    _canDoMethodInfo = _object.GetType().GetMethod("Can" + psMethodName);
                }
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public bool CanExecute(object parameter)
            {
                return DynamicCanExecute(parameter);
            }

            public void Execute(object parameter)
            {
                DynamicExecute(parameter);
            }

            private bool CheckMethodInfo(MethodInfo methodInfo, bool isCanCommand)
            {
                if (methodInfo.ReturnType != (isCanCommand ? typeof(bool) : typeof(void)))
                    throw new Exception(string.Format("Command {0} must have a return type of {1}", methodInfo.Name, isCanCommand? "bool" : "void"));

                if (methodInfo.GetParameters().Count() > 1)
                    throw new Exception(string.Format("Command {0} can only take 0 or 1 parameters", methodInfo.Name));

                return methodInfo.GetParameters().Any();
            }

            private bool DynamicCanExecute(dynamic parameter)
            {
                if (_canDoPropertyInfo != null) return (bool)_canDoPropertyInfo.GetValue(_object);
                if (_canDoCommandPropertyInfo != null)
                {
                    Delegate commandDelegate = _canDoCommandPropertyInfo.GetValue(_object) as Delegate;
                    if (commandDelegate == null) return true;
                    var parameters = CheckMethodInfo(commandDelegate.Method, true) ? new[] { parameter } : null;
                    return (bool)commandDelegate.DynamicInvoke(parameters);
                }
                if (_canDoMethodInfo == null) return true;
                var aParameters = CheckMethodInfo(_canDoMethodInfo, true) ? new[] { parameter } : null;
                return (bool)_canDoMethodInfo.Invoke(_object, aParameters);
            }

            private void DynamicExecute(dynamic parameter)
            {
                if (_doCommandPropertyInfo != null)
                {
                    Delegate commandDelegate = _doCommandPropertyInfo.GetValue(_object) as Delegate;
                    if (commandDelegate == null) return;
                    var parameters = CheckMethodInfo(commandDelegate.Method, false) ? new[] { parameter } : null;
                    commandDelegate.DynamicInvoke(parameters);
                }
                if (_doMethodInfo == null) return;
                var aParameters = CheckMethodInfo(_doMethodInfo, false) ? new[] { parameter } : null;
                _doMethodInfo.Invoke(_object, aParameters);
            }
        }

        #endregion // ICommand Class
    }
}
 