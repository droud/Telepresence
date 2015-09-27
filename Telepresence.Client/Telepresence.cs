using iConfServer.NET.HelperClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telepresence.Client
{
    public partial class Telepresence : Form
    {
        public Telepresence()
        {
            InitializeComponent();
        }

        private string _client_ip = null;

        private Queue<string> _messages = new Queue<string>();
        private void Message(string message)
        {
            _messages.Enqueue(message);
            while (_messages.Count > 128)
                _messages.Dequeue();

            Invoke(new MethodInvoker(delegate {
                _rtbLog.Lines = _messages.Reverse().ToArray();
            }));
        }

        #region Server Stuff


        private void _iCServer_VideoPreviewStarted(int videoWidth, int videoHeight, string deviceName)
        {
            Message("Server: Video preview started: " + videoWidth + "x" + videoHeight + " from: " + deviceName);

            Invoke(new MethodInvoker(delegate {
                _iCServer.VideoRateControl = iConfServer.NET.iConfServerDotNet.RateControl.ConstantBitRate;
                _iCServer.SetEncoderProperties(VideoCodecs.VP8, 20, 256000, 0, 0, 0);

                if (_iCServer.IsListening == false)
                {
                    // listen for connections
                    _iCServer.Listen(true, _iCServer.GetLocalIp()[0].ToString(), 9990, 17860, 17861);
                }
            }));
        }

        private void _iCServer_CannotRunGraph()
        {
            Message("Server: Cannot run graph, is something using the camera?");
        }

        private void _iCServer_ClientConnectionLost(int socketHandle)
        {
            Message("Server: Client connection lost: " + socketHandle);
        }

        private void _iCServer_ClientDisconnected(object sender, string ipAddress, int port)
        {
            Message("Server: Client disconnected: " + ipAddress + ":" + port);
        }

        private void _iCServer_IncomingCall(object sender, string authenticationData, int socketHandle, string callbackid, string callbackipaddress, int callbackvideoport, int callbackaudiotcpport, int callbackaudiudpport)
        {
            Message("Server: Incoming call: " + authenticationData + ", " + socketHandle + ", " + callbackid + ", " + callbackipaddress + ", " + callbackvideoport + ", " + callbackaudiotcpport + ", " + callbackaudiudpport);

            // here we can differentiate whether it's a client or a screensaver calling
            if ("Client".Equals(authenticationData))
            {
                _client_ip = callbackipaddress;

                _iCServer.AcceptCall("Client", socketHandle);

                // call back to complete the circuit
                Invoke(new MethodInvoker(delegate
                {
                    _txtAddress.Text = callbackipaddress;
                    _iCClient.Call(callbackipaddress, callbackvideoport, 0, 0, "Client", callbackid, _iCServer.GetLocalIp()[0].ToString(), 0, 0, 0, "");
                }));
            }
            else
            {
                if (_client_ip != null)
                {
                    _iCServer.AcceptCall(_client_ip, socketHandle);
                }
                else
                {
                    _iCServer.AcceptCall(_iCServer.GetLocalIp()[0].ToString(), socketHandle);
                }
            }
        }
        
        private void _iCServer_TextMessageReceived(string messageReceived)
        {
            Message("Server: Text message received: " + messageReceived);
        }

        private void _iCServer_Log(string logMessage)
        {
            Message("Server: Log: " + logMessage);
        }

        #endregion

        #region Client Stuff

        private void _iCClient_ClientDisconnected(object sender, string ipAddress, int port)
        {
            Message("Client: Client disconnected: " + ipAddress + ":" + port);
        }

        private void _iCClient_SocketError(Exception ex)
        {
            Message("Client: Socket error: " + ex.ToString());
        }

        private void _iCClient_CallAccepted(string acceptMessage)
        {
            Message("Client: Call accepted: " + acceptMessage);
        }

        private void _iCClient_CallRejected(string RejectionMessage)
        {
            Message("Client: Call rejected: " + RejectionMessage);
        }

        private void _iCClient_TextMessageReceived(string messageReceived)
        {
            Message("Client: Text message received" + messageReceived);
        }

        private void _iCClient_Log(string logMessage)
        {
            Message("Client: Log: " + logMessage);
        }

        #endregion

        private void Telepresence_Load(object sender, EventArgs e)
        {
            // set up server
            _iCServer.InitializeAudioSystem(iConfServer.NET.iConfServerDotNet.audioType.DirectSound, -1, -1, 16000, 10);
            _iCServer.EnableEchoCancellation(true);

            //select the first available video device
            _iCServer.SelectVideoDevice(0);
            ArrayList lst = _iCServer.GetVideoSizes();

            //start previewing video using the 320x240 video size 
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].Equals("320x240"))
                {
                    _iCServer.StartPreview(i);
                }
            }

            // show the local ip in the remote address
            _txtAddress.Text = _iCServer.GetLocalIp()[0].ToString();
        }

        private void _btnConnect_Click(object sender, EventArgs e)
        {
            // lots of values to provide
            string remote_ip = _txtAddress.Text;
            int remote_video_port = 9990;
            int video_width = 0;
            int video_height = 0;
            string authentication = "Client";
            string callback_id = _iCServer.CallBackId;
            string local_ip = _iCServer.GetLocalIp()[0].ToString();
            int local_video_port = 9990;
            int local_audio_tcp_port = 17860;
            int local_audio_udp_port = 17861;
            string video_codec = "";

            _iCClient.Call(remote_ip, remote_video_port, video_width, video_height, authentication, callback_id, local_ip, local_video_port, local_audio_tcp_port, local_audio_udp_port, video_codec);

            // save this so we can connect screensaver later
            _client_ip = remote_ip;
        }

        private void Telepresence_FormClosing(object sender, FormClosingEventArgs e)
        {
            //stop listening
            _iCServer.Listen(false, _iCServer.GetLocalIp()[0].ToString(), 9990, 17860, 17861);

            //stop the video preview
            _iCServer.StopPreview();
        }

        private void _btnDisconnect_Click(object sender, EventArgs e)
        {
            _iCClient.Disconnect();
            _iCClient.ClearImage();
        }
    }
}
