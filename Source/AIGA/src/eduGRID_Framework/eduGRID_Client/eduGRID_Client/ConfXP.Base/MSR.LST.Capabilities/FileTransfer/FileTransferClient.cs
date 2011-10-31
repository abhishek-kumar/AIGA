using System;
using System.IO;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using MSR.LST.ConferenceXP;

namespace MSR.LST.ConferenceXP
{
    public class FileTransferClient : CapabilityForm
    {
        public FileTransferClient() {}

        // This prevents the form from showing up
        protected override void SetVisibleCore(bool value) {}

        private FileTransferCapability fileTransferCapability = null;

        #region ICapabilityForm

        public override void AddCapability(ICapability capability)
        {
            base.AddCapability (capability);

            if (fileTransferCapability == null)
            {
                fileTransferCapability = (FileTransferCapability)capability;
                fileTransferCapability.ObjectReceived += 
                    new CapabilityObjectReceivedEventHandler(ObjectReceived);
            }
        }

        public override bool RemoveCapability(ICapability capability)
        {
            bool ret = base.RemoveCapability (capability);

            if (ret)
            {
                fileTransferCapability.ObjectReceived -= 
                    new CapabilityObjectReceivedEventHandler(ObjectReceived);
                fileTransferCapability = null;
            }

            return ret;
        }

        #endregion

        private Type GetCapability(byte[] fileData)
        {
            Type[] types = null;

            try
            {
                types = Assembly.Load(fileData).GetTypes();
            }
            catch { return null; }

            foreach (Type tBaseType in types)
            {
                Type tICapability = tBaseType.GetInterface("MSR.LST.ConferenceXP.ICapability");
                if (tICapability != null)
                {
                    try
                    {
                        Capability.PayloadTypeAttribute attrPT = (Capability.PayloadTypeAttribute)
                            Attribute.GetCustomAttribute(tBaseType, typeof(Capability.PayloadTypeAttribute));

                        if (attrPT == null)
                            continue;

                        return tBaseType;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.StackTrace, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return null;
        }

        private void ObjectReceived(object capability, ObjectReceivedEventArgs ea)
        {
            if (ea.Data is FileObject)
            {
                FileObject fileObject = ea.Data as FileObject;
                FileInfo fileInfo = new FileInfo(fileObject.Name);

                Type tCapability = null;
//              if (fileInfo.Extension.ToLower() == ".dll")
//                  tCapability = GetCapability(fileObject.Data);

                ItemReceivedDialog dlgFileReceived = null;

                if (tCapability != null)
                {
                    Capability.NameAttribute attrName = (Capability.NameAttribute)
                        Attribute.GetCustomAttribute(tCapability, typeof(Capability.NameAttribute));

                    Capability.PayloadTypeAttribute attrPT = (Capability.PayloadTypeAttribute)
                        Attribute.GetCustomAttribute(tCapability, typeof(Capability.PayloadTypeAttribute));

                    dlgFileReceived = new ItemReceivedDialog("Capability received", "A user has just sent you a capability");
                    dlgFileReceived.Button1Label = "&Install";
                    dlgFileReceived.FileIconTip = "Capability name: " + attrName.Name + Environment.NewLine +
                        "Payload type: " + attrPT.PayloadType.ToString() + Environment.NewLine;
                }
                else
                {
                    dlgFileReceived = new ItemReceivedDialog("File received", "A user has just sent you a file");
                }

                dlgFileReceived.Image = Image.FromStream(
                    System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MSR.LST.ConferenceXP.Images.FileReceived.gif"));
                dlgFileReceived.From = ea.Participant.Name;
                dlgFileReceived.Avatar = ea.Participant.Icon;
                dlgFileReceived.AvatarTip = "IP: " + ea.Participant.RtpParticipant.IPAddress.ToString() + Environment.NewLine +
                    "Id: " + ea.Participant.Identifier + Environment.NewLine + 
                    "Email: " + ea.Participant.Email + Environment.NewLine +
                    "Phone: " + ea.Participant.Phone;
                dlgFileReceived.File = fileInfo.Name;
                dlgFileReceived.FileIcon = fileObject.Icon;
                dlgFileReceived.FileIconTip += "File size: " + ((double)fileObject.Data.Length / 1024.0).ToString("#,#.00") + " KB";
                dlgFileReceived.Time = DateTime.Now.ToString("h:mm:ss tt");
                if (dlgFileReceived.ShowDialog() != DialogResult.OK)
                    return;

                if (tCapability != null)
                {
                    MessageBox.Show("Not yet implemented");
                }
                else
                {
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.FileName = fileInfo.Name;
                    if (Directory.Exists(fileInfo.DirectoryName))
                        saveDialog.InitialDirectory = fileInfo.DirectoryName;
                    saveDialog.Filter = "All files (*.*)|*.*";
                    saveDialog.CheckPathExists = true;
                    saveDialog.OverwritePrompt = true;
                    saveDialog.RestoreDirectory = true;
                    if (saveDialog.ShowDialog() != DialogResult.OK)
                        return;

                    FileStream fileStream = File.OpenWrite(saveDialog.FileName);
                    fileStream.Write(fileObject.Data, 0, fileObject.Data.Length);
                    fileStream.Close();
                }
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing (e);

            if (fileTransferCapability != null && fileTransferCapability.IsPlaying)
                fileTransferCapability.StopPlaying();
        }


    }
}
