using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraPrinting;

namespace sample_6_7 {
  public partial class PrintPreview : DevExpress.XtraEditors.XtraUserControl {
    public PrintPreview() {
      InitializeComponent();
    }

    public PrintPreview(Action<PrintPreview> initAction) : this() {
      this.initAction = initAction;
    }

    Action<PrintPreview> initAction;

    void ShowDocument(Action<DocumentViewer> init) {
      init(documentViewer);
    }

    public void ShowDocument(PrintingSystemBase printingSystem) {
      ShowDocument(dv => dv.DocumentSource = printingSystem);
    }

    private void documentViewer_Load(object sender, EventArgs e) {
      initAction?.Invoke(this);
    }
  }
}
