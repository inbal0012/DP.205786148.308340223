using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace DP._205786148._308340223
{
    public class UserUtility
    {
        //TODO? wrapper for private הורשה לעומת קומפוזיציה

        //private LoginResult m_LoginResult;
        //public LoginResult LoginResult
        //{
        //    set
        //    {
        //        m_LoginResult = value;
        //    }
        //    get
        //    {
        //        return m_LoginResult;
        //    }
        //}
        //private User m_LoggedInUser;
        public User LoggedInUser { set; get; }
        public LoginResult LoginResult { set; get; }
        public AppSettings AppSettings { set; get; }
        //private List<Photo> m_EventPhotos;
        //private Photo m_EventSelectedPhoto;

        public UserUtility()
        {
            AppSettings = AppSettings.LoadFromFile();
        }

        public bool Login()
        {

            bool isLoggedIn = false;

            // Login
            LoginResult = FacebookService.Login("1450160541956417",
                "public_profile",
                "user_birthday",
                "user_friends",
                "user_events",
                //"user_groups" (This permission is only available for apps using Graph API version v2.3 or older.)
                "user_hometown",
                "user_likes",
                "user_location",
                "user_photos",
                "user_posts",
                //"user_status" (This permission is only available for apps using Graph API version v2.3 or older.)
                "user_tagged_places",
                "user_videos",
                // "read_mailbox", (This permission is only available for apps using Graph API version v2.3 or older.)
                "read_page_mailboxes",
                // "read_stream", (This permission is only available for apps using Graph API version v2.3 or older.)
                // "manage_notifications", (This permission is only available for apps using Graph API version v2.3 or older.)
                "manage_pages",
                "publish_pages"
                );
            // These are NOT the complete i_List of permissions. Other permissions for example:
            // "user_birthday", "user_education_history", "user_hometown", "user_likes","user_location","user_relationships","user_relationship_details","user_religion_politics", "user_videos", "user_website", "user_work_history", "email","read_insights","rsvp_event","manage_pages"
            // The documentation regarding facebook login and permissions can be found here: 
            // https://developers.facebook.com/docs/facebook-login/permissions#reference

            // Verify input
            if (!string.IsNullOrEmpty(LoginResult.AccessToken))
            {
                isLoggedIn = true;
                LoggedInUser = LoginResult.LoggedInUser;
                FetchUserInfo();
            }
            return isLoggedIn;
        }
        public bool Connect()
        {
            bool isLoggedIn = false;

            // Connect
            LoginResult = FacebookService.Connect(AppSettings.LastAccessToken);

            // Verify input
            if (!string.IsNullOrEmpty(LoginResult.AccessToken))
            {
                isLoggedIn = true;
                LoggedInUser = LoginResult.LoggedInUser;
            }
            return isLoggedIn;
        }
        public void Logout ()
        {
            FacebookService.Logout(() => { });
        }

        public string GetPictureURL()
        {
            return LoggedInUser.PictureNormalURL;
        }

        public void FetchUserInfo()    //TODO populateUIFromFacebookData
        {
            if (LoggedInUser == null)
            {
                LoggedInUser = LoginResult.LoggedInUser;
            }

            if (LoggedInUser.Posts.Count > 0)
            {
                //textBoxStatus.Text = m_LoggedInUser.Posts[0].Message;
            }

            //dataGridView test
            //dataGridView1.DataSource = m_LoggedInUser.EventsNotYetReplied;
            //TODO dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            //listBoxPosts.Items.Add(m_LoggedInUser.Albums[0].LikedBy);

            //fetchfriends();
            //fetchPosts();
        }

        internal string LoggedInError()
        {
            return LoginResult.ErrorMessage;
        }

        //Matches(new Tuple<string,object>("Gender",User.eGender.male),new Tuple<string,object>("OnlineStatus",User.eOnlineStatus.active),....)
        public FacebookObjectCollection<User> Matches(List<Tuple<string, object>> i_List)
        {
            FacebookObjectCollection<User> searchResults = new FacebookObjectCollection<User>();
            bool isOK;
            foreach (User user in LoggedInUser.Friends)
            {
                isOK = true;
                foreach (var item in i_List)
                {
                    if (!isOK) break;

                    var field = item.Item1;
                    var value = item.Item2;

                    switch (field)
                    {
                        case "Gender":
                            if (!user.Gender.Equals((User.eGender)value))
                            {
                                isOK = false;
                            }
                            break;
                        case "Language":
                            if (user.Languages != null)
                            {
                                isOK = false;
                                foreach (Page Language in user.Languages)
                                {
                                    if (Language.Name.Equals(value))
                                    {
                                        isOK = true;
                                    }
                                }
                            }
                            break;
                        case "RelationshipStatus":
                            if (user.RelationshipStatus != null)
                            {
                                if (!user.RelationshipStatus.Equals(value))
                                {
                                    isOK = false;
                                }
                            }
                            break;
                        case "InterestedIn":
                            if (user.InterestedIn != null)
                            {
                                isOK = false;
                                foreach (User.eGender gender in user.InterestedIn)
                                {
                                    if (gender.Equals(value))
                                    {
                                        isOK = true;
                                    }
                                }
                            }
                            break;
                        case "Religion":
                            if (user.Religion != null)
                            {
                                if (!user.Religion.Equals(value))
                                {
                                    isOK = false;
                                }
                            }
                            break;
                        case "FirstName":
                            if (!user.FirstName.Equals(value))
                            {
                                isOK = false;
                            }
                            break;
                        case "LastName":
                            if (!user.LastName.Equals(value))
                            {
                                isOK = false;
                            }
                            break;
                        case "Location":
                            if (!user.Location.Equals(value))
                            {
                                isOK = false;
                            }
                            break;
                    }
                }

                if (isOK)
                {
                    searchResults.Add(user);
                }
            }
            return searchResults;
        }
    }
}
