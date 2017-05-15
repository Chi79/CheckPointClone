using CheckPoint.DTO;
using Reader.DataAccessREST;
using Reader.DataAccessREST.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReaderViews
{
    public partial class LoginView : Form
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private async void btnGet_Click(object sender, EventArgs e)
        {
            //get tag id
            //fetch associated attendee
            //if exists, then insert datetime.now
            //change status to attended
            //return success message

            var tagId = "2"; //this is fetched from the reader

            var attendee = await RESTCalls.GetSingleAttendee(tagId);

            await RESTCalls.UpdateAttendeeWithStampAndStatus(attendee.TagId, DateTime.Now, (int)AttendeeStatus.HasAttended);

            Attendee attendee1 = await RESTCalls.GetSingleAttendee(tagId);

            txtShow.Text = attendee1.TimeAttended.ToString();
            //var client = await RESTCalls.GetSingleClient("carecopter");
            //txtShow.AppendText(client.FirstName + Environment.NewLine);
            //txtShow.AppendText(client.Address + Environment.NewLine);


            //await RESTCalls.UpdateAttendeeWithStampAndStatus("12",DateTime.Now, 1);

            //var Updatedclient = await RESTCalls.GetSingleClient("carecopter");

            //txtShow.AppendText(Updatedclient.FirstName + Environment.NewLine);
            //txtShow.AppendText(Updatedclient.Address + Environment.NewLine);

        }
    }
}
