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
    public partial class FormSearch : Form
    {
        public UserUtility UserUtilitys { set; get; }

        public FormSearch()
        {
            InitializeComponent();
            UserUtilitys = new UserUtility();
        }

        private void FormSearch_Load(object sender, EventArgs e)
        {
            //Gender
            comboBoxGender.Items.AddRange(new object[] { User.eGender.female, User.eGender.male });
            //Languages
            if (UserUtilitys.LoggedInUser.Languages != null)
            {
                foreach (Page language in UserUtilitys.LoggedInUser.Languages)
                {
                    comboBoxLanguage.Items.AddRange(new object[] { language.Name });
                }
            }
            else
            {
                comboBoxLanguage.Items.AddRange(new object[] {
                    "English",
                    "Hebrew",
                    "Arabic",
                    "French",
                    "Spanish",
                    "Russian",
                    "Chinese",
                    "German"
                });
            }
            //RelationshipStatus
            comboBoxRelationshipStatus.Items.AddRange(new object[] {
                "Single",
                "InARelationship",
                "Enagaged",
                "Married",
                "ItsComplicated",
                "InAnOpenRelationship",
                "Widowed",
                "Separated",
                "Divorced",
                "InACivilUnion",
                "InADomesticPartnership"
                });
            //InterestedIn
            comboBoxInterestedIn.Items.AddRange(new object[] { User.eGender.female, User.eGender.male });
            //Religion
            comboBoxReligion.Items.AddRange(new object[] {
                "Christianity",
                "Islam",
                "Hinduism",
                "Buddhism",
                "Taoism",
                "Sikhism",
                "Judaism",
                "Jainism"
            });

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var param = CreateParam();
            FacebookObjectCollection<User> SearchResults = UserUtilitys.Matches(param);
            showResults(SearchResults);
        }

        private List<Tuple<string, object>> CreateParam()
        {
            var param = new List<Tuple<string, object>>();
            //Gender
            if (comboBoxGender.SelectedIndex != -1)
            {
                param.Add(new Tuple<string, object>("Gender", comboBoxGender.SelectedIndex));
            }
            //Language
            if (comboBoxLanguage.Text != "Language")
            {
                param.Add(new Tuple<string, object>("Language", comboBoxLanguage.Text));
            }
            //RelationshipStatus
            if (comboBoxRelationshipStatus.Text != "Relationship Status")
            {
                param.Add(new Tuple<string, object>("RelationshipStatus", comboBoxRelationshipStatus.Text));
            }
            //InterestedIn
            if (comboBoxInterestedIn.SelectedIndex != -1)
            {
                param.Add(new Tuple<string, object>("InterestedIn", comboBoxInterestedIn.Text));
            }
            //Religion
            if (comboBoxReligion.Text != "Religion")
            {
                param.Add(new Tuple<string, object>("Religion", comboBoxReligion.Text));
            }
            //First Name
            if (textBoxFirstName.Text != "First Name")
            {
                param.Add(new Tuple<string, object>("FirstName", textBoxFirstName.Text));
            }
            //LastName
            if (textBoxLastName.Text != "Last Name")
            {
                param.Add(new Tuple<string, object>("FirstName", textBoxFirstName.Text));
            }
            //Location
            if (checkBoxLocation.Checked)
            {
                param.Add(new Tuple<string, object>("Location", UserUtilitys.LoggedInUser.Location.Name));
            }

            return param;
        }

        private void showResults(FacebookObjectCollection<User> i_SearchResults)
        {
            listBox1.Items.Clear();

            if (i_SearchResults.Count == 0)
            {
                MessageBox.Show("Nothing to show :(");
            }

            foreach (User user in i_SearchResults)
            {
                listBox1.Items.Add(string.Format(user.FirstName + " " + user.LastName));
            }
        }

        private void comboBoxGender_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {
            //Do nothing
        }
        private void textBoxFirstName_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxFirstName.SelectAll();
        }
        private void textBoxFirstName_Leave(object sender, EventArgs e)
        {
            if (textBoxFirstName.Text == "")
            {
                textBoxFirstName.Text = "First Name";
            }
        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {
            //Do nothing
        }
        private void textBoxLastName_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxLastName.SelectAll();
        }
        private void textBoxLastName_Leave(object sender, EventArgs e)
        {
            if (textBoxLastName.Text == "")
            {
                textBoxLastName.Text = "First Name";
            }
        }

        private void checkBoxLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (UserUtilitys.LoggedInUser.Location == null && checkBoxLocation.Checked == true)
            {
                checkBoxLocation.Checked = false;
                MessageBox.Show("Your location is unavalible. \nCan't sort by location");
            }
        }
    }
}
