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
    public partial class ViewBlueprintManager : Form, IViewBlueprintManager
    {
        private IViewBlueprintManagerPresenter _presenter;
        private readonly BindingSource _data = new BindingSource();
        public ViewBlueprintManager()
        {
            InitializeComponent();
        }

        public IViewBlueprintManagerPresenter Presenter
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

        public IEnumerable<BlueprintInfo> BluePrints
        {
            get => _data.List.Cast<BlueprintInfo>();
            set
            {
                _data.DataSource = value.ToList();
            }
        }

        public void Run()
        {
            NameTextBox.Bind(_data, nameof(BlueprintInfo.Name));
            ContentTextBox.Bind(_data, nameof(BlueprintInfo.Blueprint));

            BlueprintListBox.DataSource = _data;
            BlueprintListBox.DisplayMember = nameof(BlueprintInfo.Name);

            ShowDialog();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var blueprint = new BlueprintInfo
            {
                Name = "New BluePrint",
            };

            _data.Add(blueprint);

            BlueprintListBox.SelectedIndex = BlueprintListBox.Items.Count - 1;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var index = BlueprintListBox.SelectedIndex;

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
