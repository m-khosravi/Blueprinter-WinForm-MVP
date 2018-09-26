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
    public partial class ViewMain : Form, IViewMain
    {
        private IViewMainPresenter _presenter;
        public IViewMainPresenter Presenter
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

        private IEnumerable<BlueprintInfo> _blueprints;
        public IEnumerable<BlueprintInfo> Blueprints
        {
            get => _blueprints;
            set
            {
                _blueprints = value;
                //TODO: Build combobox

                LoadComboBox();
            }
        }

        private void LoadComboBox()
        {
            BlueprintComboBox.Items.Clear();

            foreach (var blue in _blueprints)
            {
                BlueprintComboBox.Items.Add(blue);
                BlueprintComboBox.DisplayMember = nameof(BlueprintInfo.Name);
            }
        }

        public string ProjectPath => BasePathTextBox.Text;

        public string ProjectBlueprint => BlueprintTextBox.Text;

        public ViewMain()
        {
            InitializeComponent();
        }

        private void blueprintManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.RunBluePrintManager();
        }

        private void contentManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.RunTemplateManager();
        }

        public void Run()
        {
            Application.Run(this);
        }

        private void BlueprintComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BlueprintComboBox.SelectedItem is BlueprintInfo item)
            {
                BlueprintTextBox.Text = item.Blueprint;
            }
        }
    }
}
