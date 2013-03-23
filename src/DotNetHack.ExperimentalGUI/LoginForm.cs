﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Thrift.Protocol;
using Thrift.Transport;
using DotNetHack.RPC;

namespace DotNetHack.ExperimentalGUI
{
    /// <summary>
    /// LoginForm
    /// </summary>
    public partial class LoginForm : Form
    {
        /// <summary>
        /// LoginForm
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Authentication operation. On success spawns the main form and passes along the user identifier.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAuthenticate_Click(object sender, EventArgs e)
        {

            // TODO: Pull all of this into a cohesive location.

            TTransport transport = new TSocket("localhost", 9090);
            TProtocol protocol = new TBinaryProtocol(transport);
            DNHService.Client client = new DNHService.Client(protocol);

            try
            {
                transport.Open();

                var authResponse = client.Authenticate(textBoxUserName.Text, (textBoxUserName.Text + maskedTextBoxPassword.Text).ToHashString());

                if (authResponse.ID < 0)
                {
                    buttonAuthenticate.ForeColor = Color.Red;
                    toolStripStatusLabel.Text = authResponse.Message;
                }
                else 
                {
                    buttonAuthenticate.ForeColor = Color.Green;
                    toolStripStatusLabel.Text = "Success!";
                }
            }
            catch (Exception ex)
            {
                buttonAuthenticate.ForeColor = Color.Red;
                toolStripStatusLabel.Text = ex.Message;
            }
            finally
            {
                transport.Close();
            }
        }

        /// <summary>
        /// The exit button for this undecorated form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
