using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GanoOlasilik
{
    public partial class FormWait : Form
    {
        public Action Worker { get; set; }

        public FormWait(Action worker)
        {
            InitializeComponent();
            Worker = worker ?? throw new ArgumentNullException();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => this.Close(), TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
