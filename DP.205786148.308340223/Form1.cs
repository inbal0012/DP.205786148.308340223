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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            //FacebookService.s_CollectionLimit = 100;

            m_AppSettings = AppSettings.LoadFromFile();

            this.StartPosition = FormStartPosition.Manual;

            this.Size = m_AppSettings.LastWindowSize;
            this.Location = m_AppSettings.LastWindowLocation;
            this.checkBoxRememberUser.Checked = m_AppSettings.RememberUser;
            if (m_AppSettings.RememberUser && !string.IsNullOrEmpty(m_AppSettings.LastAccessToken))
            {
                m_LoginResult = FacebookService.Connect(m_AppSettings.LastAccessToken);
                m_LoggedInUser = m_LoginResult.LoggedInUser;
                fetchUserInfo();
            }
        }
        
        User m_LoggedInUser;
        AppSettings m_AppSettings;
        LoginResult m_LoginResult;

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            loginAndInit();
        }

        private void loginAndInit()
        {
            m_LoginResult = FacebookService.Login("316225058978221",
                "email",
                "groups_access_member_info",
                "publish_to_groups",
                "user_age_range",
                "user_birthday",
                "user_events",
                "user_friends",
                "user_gender",
                "user_hometown",
                "user_likes",
                "user_link",
                "user_location",
                "user_photos",
                "user_posts",
                "user_tagged_places",
                "user_videos"
                );
            // These are NOT the complete list of permissions. Other permissions for example:
            // "user_birthday", "user_education_history", "user_hometown", "user_likes","user_location","user_relationships","user_relationship_details","user_religion_politics", "user_videos", "user_website", "user_work_history", "email","read_insights","rsvp_event","manage_pages"
            // The documentation regarding facebook login and permissions can be found here: 
            // https://developers.facebook.com/docs/facebook-login/permissions#reference
            
            if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
            {
                m_LoggedInUser = m_LoginResult.LoggedInUser;
                fetchUserInfo();
            }
            else
            {
                //MessageBox.Show(m_LoginResult.ErrorMessage);
            }
            
            //todo buttonLogin.Text = "Logout";
        }

        private void fetchUserInfo()    //TODO populateUIFromFacebookData
        {
            this.Text = string.Format("Logged in as " + m_LoggedInUser.FirstName + " " + m_LoggedInUser.LastName);

            foreach (Control controler in this.Controls)
            {
                controler.Visible = true;
            }

            picture_smallPictureBox.LoadAsync(m_LoggedInUser.PictureNormalURL);
            if (m_LoggedInUser.Posts.Count > 0)
            {
                //textBoxStatus.Text = m_LoggedInUser.Posts[0].Message;
            }

            //dataGridView test
            dataGridView1.DataSource = m_LoggedInUser.Albums;
            //TODO dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);

            fetchfriends();
            fetchPosts();
        }

        private void fetchfriends()
        {
            listBoxFriends.Items.Clear();
            listBoxFriends.DisplayMember = "Name";
            foreach (User friend in m_LoggedInUser.Friends)
            {
                listBoxFriends.Items.Add(friend);
                friend.ReFetch(DynamicWrapper.eLoadOptions.Full);
            }

            if (m_LoggedInUser.Friends.Count == 0)
            {
                MessageBox.Show("No Friends to retrieve :(");
            }
        }

        private void fetchPosts()
        {
            foreach (Post post in m_LoggedInUser.Posts)
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

            if (m_LoggedInUser.Posts.Count == 0)
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

            if (this.checkBoxRememberUser.Checked)
            {

                m_AppSettings.LastWindowSize = this.Size;
                m_AppSettings.LastWindowLocation = this.Location;
                m_AppSettings.RememberUser = this.checkBoxRememberUser.Checked;
                m_AppSettings.LastAccessToken = m_LoginResult.AccessToken;
            }
            else
            {
                m_AppSettings = new AppSettings();
            }

            m_AppSettings.SaveToFile();

        }
    }
}
