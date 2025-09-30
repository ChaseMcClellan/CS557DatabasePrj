namespace CS557DatabasePrj
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //init DB
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //psudocode when we implement
            /*
             * if(findandreturnUser(txtUsername.text,txtPassword.text) != null){
                    if(user.role == 1){open Userform;}
                    else if (user.role == 2) {open Tellerform;}
                    else if (user.role == 3) {open adminForm;}
            }else{lblAlert.hidden == true} //invalid user if method returns null then show lblAlert saying wrong credentials 
               }
             
            */
        }
    }
}
