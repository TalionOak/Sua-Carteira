using Sua_Carteira.Classes;
using Sua_Carteira.Forms;

namespace Sua_Carteira {
  public partial class FormMainMenu : Form {

    private Button currentButton;
    private Random random;
    private int tempIndex;
    private Form activeForm;

    public FormMainMenu() {
      InitializeComponent();
      random = new Random();
    }

    private Color SelectThemeColor() {
      int index = random.Next(ThemeColor.ColorList.Count);
      while(tempIndex == index) {
       index =  random.Next(ThemeColor.ColorList.Count);
      }
      tempIndex = index;
      string color = ThemeColor.ColorList[index];
      return ColorTranslator.FromHtml(color);
    }

    private void ActivateButton(object btnSender) {
      if(btnSender != null) {
        if(currentButton != (Button) btnSender) {
          DisableButton();
          Color color = SelectThemeColor();
          currentButton = (Button) btnSender;
          currentButton.BackColor = color;
          currentButton.ForeColor = Color.Black;
          currentButton.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
          panelTitleBar.BackColor = ThemeColor.ChangeColorBrigtness(color, -0.3);
          ThemeColor.PrimaryColor = color;
          ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrigtness(color, -0.3);
          btnCloseChildForm.Visible = true;
        }
      }
    }

    private void DisableButton() {
      foreach(Control previousBtn in panelLeft.Controls) {
        if(previousBtn.GetType() == typeof(Button)) {
          previousBtn.BackColor = Color.FromArgb(54, 194, 255);
          previousBtn.ForeColor = Color.Black;
          previousBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        }
      }
    }

    private void OpenChieldForm(Form childForm, object btnSender) {

      if(activeForm != null) {
        activeForm.Close();
      }

      ActivateButton(btnSender);
      activeForm = childForm;
      childForm.TopLevel = false;
      childForm.FormBorderStyle = FormBorderStyle.None;
      childForm.Dock = DockStyle.Fill;
      panelDesktopPanel.Controls.Add(childForm);
      panelDesktopPanel.Tag = childForm;
      childForm.BringToFront();
      childForm.Show();
      lblTitle.Text = childForm.Text;

    }

    private void btnDispesas_Click(object sender, EventArgs e) {
      OpenChieldForm(new FormDespesas(), sender);
    }

    private void btnContas_Click(object sender, EventArgs e) {
      OpenChieldForm(new FormContas(), sender);
    }

    private void btnGraficos_Click(object sender, EventArgs e) {
      OpenChieldForm(new FormContas(), sender);
    }

    private void btnCategorias_Click(object sender, EventArgs e) {
      OpenChieldForm(new FormContas(), sender);
    }

    private void btnPagamentosRegulares_Click(object sender, EventArgs e) {
      OpenChieldForm(new FormContas(), sender);
    }

    private void btnLembrete_Click(object sender, EventArgs e) {
      OpenChieldForm(new FormContas(), sender);
    }

    private void btnMoedas_Click(object sender, EventArgs e) {
      OpenChieldForm(new FormContas(), sender);
    }

    private void btnConfiguracoes_Click(object sender, EventArgs e) {
      OpenChieldForm(new FormContas(), sender);
    }

    private void btnCloseChildForm_Click(object sender, EventArgs e) {
      if(activeForm != null) {
        activeForm.Close();
        Reset();
      }
    }

    private void Reset() {
      DisableButton();
      lblTitle.Text = "HOME";
      panelTitleBar.BackColor = Color.FromArgb(0, 150, 130);
      currentButton = null;
      btnCloseChildForm.Visible = false;
    }

    private void FormMainMenu_Load(object sender, EventArgs e) {

    }
  }
}