using System;
using System.Windows.Forms;
using HastaneYonetimRandevuSistemi.Business.Abstract;
using HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject;
using HastaneYonetimRandevuSistemi.Entities.Concrete;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.CustomMethods;
using HastaneYonetimRandevuSistemi.WinFormAppUI.Library.ExceptionHandling;

namespace HastaneYonetimRandevuSistemi.WinFormAppUI.SecretaryForms
{
    public partial class SecretaryUpdateForm : Form
    {
        private static readonly ISecretaryService SecretaryService;

        private readonly Secretary _secretary;

        static SecretaryUpdateForm()
        {
            SecretaryService = InstanceFactory.GetInstance<ISecretaryService>();
        }

        public SecretaryUpdateForm(int secretaryId)
        {
            _secretary = SecretaryService.GetById(secretaryId);
            InitializeComponent();
        }

        private void SecretaryUpdateForm_Load(object sender, EventArgs e)
        {
            SetSecretaryInfo();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var secretary = GetSecretaryInstance();
            var result = CrudHandler.AddOrUpdate(() => SecretaryService.Update(secretary));
            MyMethods.ShowMessageBox(result);
            if (!result.IsSuccess) return;
            Close();
            (Application.OpenForms[nameof(SecretaryForm)] as SecretaryForm)?.UpdateForm();
        }

        private void Password_TextChanged(object sender, EventArgs e) =>
            btnUpdate.Enabled = MyMethods.PasswordCompare(tbPassword.Text, tbPasswordAgain.Text);

        // TODO Burada Validation işlemi yeni nesne üretilmese de yapılıyor!
        private Secretary GetSecretaryInstance()
        {
            _secretary.FirstName = tbName.Text;
            _secretary.LastName = tbSurname.Text;
            _secretary.TrIdentityNo = tbTrIdentityNo.Text;
            _secretary.Password = tbPassword.Text;
            return _secretary;
        }

        private void SetSecretaryInfo()
        {
            tbName.Text = _secretary.FirstName;
            tbSurname.Text = _secretary.LastName;
            tbTrIdentityNo.Text = _secretary.TrIdentityNo;
            tbPassword.Text = _secretary.Password;
        }
    }
}
