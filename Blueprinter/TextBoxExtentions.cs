using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blueprinter
{
    public static class TextBoxExtentions
    {
        public static void Bind(this TextBox textbox,BindingSource data,string propertyName)
        {
            var binding = new Binding(nameof(TextBox.Text), data, propertyName);
            binding.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;

            textbox.DataBindings.Add(binding);
        }
    }
}
