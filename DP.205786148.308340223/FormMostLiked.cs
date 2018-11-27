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
    public partial class FormMostLiked : Form
    {
        public FormMostLiked()
        {
            InitializeComponent();
            UserUtilitys = new UserUtility();
        }
        
        public UserUtility UserUtilitys { set; get; }
        public UserCalculateLikesByPosts UserCalculateLikesByPosts { set; get; }
        public UserCalculateLikesByVideos UserCalculateLikesByVideo { set; get; }
        public UserCalculateLikesByPhotos UserCalculateLikesByPhoto { set; get; }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonPhotos_CheckedChanged(object sender, EventArgs e)
        {
            UserCalculateLikesByPhoto = new UserCalculateLikesByPhotos();
            UserCalculateLikesByPhoto.UserUtilitys.LoggedInUser = UserUtilitys.LoggedInUser;
            UserCalculateLikesByPhoto.MostLikedByTypeVideos();
            MessageBox.Show(string.Format("you are the winner {0}", UserCalculateLikesByPhoto.MostLikedByTypeVideos()));
        }

        private void radioButtonVideos_CheckedChanged(object sender, EventArgs e)
        {
            UserCalculateLikesByVideo = new UserCalculateLikesByVideos();
            UserCalculateLikesByVideo.UserUtilitys = UserUtilitys;
            ///i_MostLiked.MostLikedByTypeVideos();
            UserCalculateLikesByVideo.MostLikedByTypeVideos();
            MessageBox.Show(string.Format("you are the winner {0}", UserCalculateLikesByVideo.MostLikedByTypeVideos().UserName));
        }

        private void radioButtonEvents_CheckedChanged(object sender, EventArgs e)///Change!!!!!!!
        {

        }

        private void radioButtonPosts_CheckedChanged(object sender, EventArgs e)
        {
            UserCalculateLikesByPosts = new UserCalculateLikesByPosts();
            UserCalculateLikesByPosts.UserUtilitys = UserUtilitys;
            UserCalculateLikesByPosts.MostLikedByTypePosts();
            MessageBox.Show(UserUtilitys.LoggedInUser.UserName);
        }

        private void displaySelectedFriend()
        {
            if (listBox1.SelectedItems.Count == 1)
            {
                User selectedFriend = listBox1.SelectedItem as User;
                if (selectedFriend.PictureNormalURL != null)
                {
                    pictureBox1.LoadAsync(selectedFriend.PictureNormalURL);
                }
                else
                {
                    ///picture_smallPictureBox.Image = picture_smallPictureBox.ErrorImage;
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaySelectedFriend();
        }

        //public void fetchPhotos()
        //{
        //    foreach(Post photos in UserUtilitys.LoggedInUser.Posts)
        //    {
        //        if(photos.Message != null || photos.Caption != null)
        //        {

        //        }
        //        else
        //        {
        //            listBoxPosts.Items.Add(string.Format("[{0}]", post.Type));
        //        }
        //    }
        //}
    }
}
