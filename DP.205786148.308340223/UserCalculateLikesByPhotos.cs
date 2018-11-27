using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace DP._205786148._308340223
{
    public class UserCalculateLikesByPhotos
    {
        public UserUtility UserUtilitys { set; get; }

        public UserCalculateLikesByPhotos()
        {
            UserUtilitys = new UserUtility();
        }

        //IMostLiked IMostLiked.MostLiked { set; get; }

        public string MostLikedByTypeVideos()
        {
            UserUtilitys = new UserUtility();
            FacebookObjectCollection<User> users = new FacebookObjectCollection<User>();
            int maxOfLikes = 0;
            int likes = 0;
            string keepNameOfTheStar = null;

            foreach (User user in UserUtilitys.LoggedInUser.Friends)
            {
                foreach (Photo photo in user.PhotosTaggedIn)
                {
                    ICollection<User> useWhoDidLike = photo.LikedBy;

                    if ((photo.m_Images != null) &&
                        photo.LikedBy != null)
                    {
                        ///like = photo.LikedBy.Count;
                        likes = photo.LikedBy.Count;

                        if (likes > maxOfLikes)
                        {
                            maxOfLikes = likes;
                            keepNameOfTheStar = user.UserName;
                        }
                    }
                }
            }
            return keepNameOfTheStar;
        }
    }
}
