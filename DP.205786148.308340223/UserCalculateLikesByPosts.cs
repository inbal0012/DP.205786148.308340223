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
    public class UserCalculateLikesByPosts
    {
        public User Users { set; get; }
        public UserUtility UserUtilitys { set; get; }

        public UserCalculateLikesByPosts()
        {
            UserUtilitys = new UserUtility();
        }

        public string MostLikedByTypePosts()
        {
            int maxOfLikes = 0;
            int countOfLikes = 0;
            string keepNameOfTheStar = null;

            foreach (User user in UserUtilitys.LoggedInUser.Friends)
            {
                foreach (Post post in UserUtilitys.LoggedInUser.Posts)
                {
                    if (post.Message != null || post.Caption != null)
                    {
                        countOfLikes = post.LikedBy.Count;

                        if (countOfLikes > maxOfLikes)
                        {
                            maxOfLikes = countOfLikes;
                            keepNameOfTheStar = user.UserName;
                        }
                        ///user.ReFetch(DynamicWrapper.eLoadOptions.Full);
                    }
                }
            }
            return keepNameOfTheStar;
        }
    }
}
