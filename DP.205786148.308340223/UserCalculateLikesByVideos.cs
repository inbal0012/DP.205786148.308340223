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
    public class UserCalculateLikesByVideos
    {
        public UserUtility UserUtilitys { set; get; }
        //public User Users { set; get; }

        public UserCalculateLikesByVideos()
        {
            UserUtilitys = new UserUtility();
        }

        ///IMostLiked IMostLiked.MostLiked { set; get; }

        public User MostLikedByTypeVideos()
        {
            ///FacebookObjectCollection<User> users = new FacebookObjectCollection<User>();
            int maxOfLikes = 0;
            int likes = 0;
            User NameOfTheStar = null;

            foreach (User user in UserUtilitys.LoggedInUser.Friends)
            {
                foreach (Video video in UserUtilitys.LoggedInUser.Videos)
                {
                    ICollection<User> useWhoDidLike = video.LikedBy;
                    ///like = post.LikedBy.Count;
                    likes = video.LikedBy.Count;

                    if (likes > maxOfLikes)
                    {
                        maxOfLikes = likes;
                        NameOfTheStar = user;
                    }
                }
            }
            return NameOfTheStar;
        }
    }
}
