using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace DP._205786148._308340223
{
    public partial class FormMain : Form
    {
        FormMostLiked m_MostLikedForm;
        FormSearch m_SearchForm;
        UserUtility m_UserUtility;

        public FormMain()
        {
            InitializeComponent();
            m_UserUtility = new UserUtility();
            //FacebookService.s_CollectionLimit = 100;

            this.StartPosition = FormStartPosition.Manual;

            this.Size = m_UserUtility.AppSettings.LastWindowSize;
            this.Location = m_UserUtility.AppSettings.LastWindowLocation;
            this.checkBoxRememberUser.Checked = m_UserUtility.AppSettings.RememberUser;
            if (m_UserUtility.AppSettings.RememberUser && !string.IsNullOrEmpty(m_UserUtility.AppSettings.LastAccessToken))
            {
                if (m_UserUtility.Connect())
                {
                    m_UserUtility.FetchUserInfo();
                    loggedInUIChanges();
                }
                else
                {
                    MessageBox.Show(m_UserUtility.LoggedInError());
                }
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (buttonLogin.Text == "Login")
            {
                m_UserUtility.Login();
                loggedInUIChanges();
                m_UserUtility.FetchUserInfo();
            }
            else if (buttonLogin.Text == "Logout")
            {
                logOutUIChanged();
            }
        }

        private void loggedInUIChanges ()
        {
            this.Text = string.Format("Logged in as " + m_UserUtility.LoggedInUser.FirstName + " " + m_UserUtility.LoggedInUser.LastName);
            //this.Text += string.Format(" from " + m_UserUtility.LoggedInUser.Hometown.Name);
            buttonLogin.Text = "Logout";

            foreach (Control controler in this.Controls)
            {
                controler.Visible = true;
            }

            fetchPosts();

            dataGridView1.DataSource = m_UserUtility.LoggedInUser.Friends;
        }

        private void logOutUIChanged()
        {
            m_UserUtility.AppSettings.RememberUser = false;
            m_UserUtility.AppSettings.LastAccessToken = null;
            this.checkBoxRememberUser.Checked = m_UserUtility.AppSettings.RememberUser;

            foreach (Control controler in this.Controls)    //hide controllers 
            {
                if (!controler.Equals(buttonLogin) && !controler.Equals(checkBoxRememberUser))
                {
                    controler.Visible = false;
                }
            }

            m_UserUtility.Logout();

            buttonLogin.Text = "Login";
            this.Text = "Please Login";
        }
        
        private void fetchfriends()
        {
            listBoxFriends.Items.Clear();
            listBoxFriends.DisplayMember = "Name";
            
            foreach (User friend in m_UserUtility.LoggedInUser.Friends)
            {
                listBoxFriends.Items.Add(friend);
                friend.ReFetch(DynamicWrapper.eLoadOptions.Full);
            }

            if (m_UserUtility.LoggedInUser.Friends.Count == 0)
            {
                MessageBox.Show("No Friends to retrieve :(");
            }
        }

        private void fetchPosts()
        {
            foreach (Post post in m_UserUtility.LoggedInUser.Posts)
            {
                if (post.Message != null)
                {
                    listBoxPosts.Items.Add(post.Message);
                }
                else if (post.Caption != null)
                {
                    listBoxPosts.Items.Add(post.Caption);
                }
                else
                {
                    listBoxPosts.Items.Add(string.Format("[{0}]", post.Type));
                }
                foreach (var like in post.LikedBy)
                {
                    listBoxPosts.Items.Add((string.Format("\t" + like.Name)));
                }
            }

            if (m_UserUtility.LoggedInUser.Posts.Count == 0)
            {
                MessageBox.Show("No Posts to retrieve :(");
            }
        }

        private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaySelectedFriend();
        }

        private void displaySelectedFriend()
        {
            if (listBoxFriends.SelectedItems.Count == 1)
            {
                User selectedFriend = listBoxFriends.SelectedItem as User;
                if (selectedFriend.PictureNormalURL != null)
                {
                    pictureBoxFriend.LoadAsync(selectedFriend.PictureNormalURL);
                }
                else
                {
                    picture_smallPictureBox.Image = picture_smallPictureBox.ErrorImage;
                }
            }
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            m_UserUtility.AppSettings.RememberUser = this.checkBoxRememberUser.Checked;
            if (this.checkBoxRememberUser.Checked)
            {
                m_UserUtility.AppSettings.LastWindowSize = this.Size;
                m_UserUtility.AppSettings.LastWindowLocation = this.Location;
                m_UserUtility.AppSettings.LastAccessToken = m_UserUtility.LoginResult.AccessToken;
            }
            
            m_UserUtility.AppSettings.SaveToFile();

        }

        private void buttonMostLiked_Click(object sender, EventArgs e)
        {
            m_MostLikedForm = new FormMostLiked();
            m_MostLikedForm.UserUtilitys.LoggedInUser = m_UserUtility.LoggedInUser;
            m_MostLikedForm.Show();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            m_SearchForm = new FormSearch();
            m_SearchForm.UserUtilitys.LoggedInUser = m_UserUtility.LoggedInUser;
            m_SearchForm.Show();
        }
    }
}
