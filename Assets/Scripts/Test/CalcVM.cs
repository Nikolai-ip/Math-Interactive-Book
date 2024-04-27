using System.Globalization;
using Abstract.ViewModel;
using ReactiveData;

namespace Test
{
    public class CalcVM:ViewModel
    {
        private string _val1;
        private string _val2;
        private string _sign;
        private StringReactiveProperty Result { get; } = new();
        private CalcModel _calc;
        
        [BindingAction]
        private void OnFirstValue(Property val)
        {
            if (val.GetValue() is string newValue)
            {
                _val1 = newValue;
            }
        }
        [BindingAction]
        private void OnSecondValue(Property val)
        { 
            if (val.GetValue() is string newValue)
            {
                _val2 = newValue;
            }
        }
        [BindingAction]
        private void OnSign(Property val)
        {
            if (val.GetValue() is string newValue)
            {
                _sign = newValue;
            }
        }
        [BindingAction]
        private void OnResultButton(Property val)
        {
            var result = _calc.Calc(double.Parse(_val1), double.Parse(_val2), _sign[0]);
            if (result != null) 
                Result.Value = new StringProp(result.Value.ToString(CultureInfo.InvariantCulture));
            else
            {
                Result.Value = new StringProp("Error");
            }
        }
        
    }
}