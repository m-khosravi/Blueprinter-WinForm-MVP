using Blueprinter.Core;
using Blueprinter.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blueprinter
{
    public partial class ViewTemplateManager : Form, IViewTemplateManager
    {
        private IViewTemplateManagerPresenter _presenter;
        private readonly BindingSource _data = new BindingSource();
        public ViewTemplateManager()
        {
            InitializeComponent();


        }

        public IViewTemplateManagerPresenter Presenter
        {
            get => _presenter;
            set
            {
                if (_presenter == null)
                {
                    _presenter = value;
                }
            }
        }

        public IEnumerable<TemplateType> TemplateTypes { get; set; }

        public IEnumerable<TemplateInfo> Templates
        {
            get => _data.List.Cast<TemplateInfo>();
            set
            {
                _data.DataSource = value.ToList();
            }
        }

        public void Run()
        {
            TemplateTypeComboBox.DataSource = TemplateTypes;

            var binding = new Binding("Text", _data, "Type",true);
            binding.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
            TemplateTypeComboBox.DataBindings.Add(binding);


            NameTextBox.Bind(_data, nameof(TemplateInfo.Name));
            ContentTextBox.Bind(_data, nameof(TemplateInfo.Content));
            ShortcutTextBox.Bind(_data, nameof(TemplateInfo.Shortcut));
            

            TemplateListBox.DataSource = _data;
            TemplateListBox.DisplayMember = nameof(TemplateInfo.Name);

            ShowDialog();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var template = new TemplateInfo
            {
                Name = "New Template",
            };

            _data.Add(template);

            TemplateListBox.SelectedIndex = TemplateListBox.Items.Count - 1;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var index = TemplateListBox.SelectedIndex;

            if (index < 0)
            {
                return;
            }

            _data.RemoveAt(index);
        }

        private void ViewBlueprintManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            label1.Focus();
            _presenter.Save();
        }
    }
}
