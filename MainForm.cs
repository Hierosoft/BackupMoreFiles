/*
 * Created by SharpDevelop.
 * User: Owner
 * Date: 12/8/2016
 * Time: 8:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace BackupMoreFiles
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private DriveInfo[] driveinfos = null;
		private DriveInfo destDI = null;
		private string source_folder_path = "%USERPROFILE%\\Documents\\";
		private string source_file_path = null;
		private string dest_partialpath = "Backup-NETBOX\\C\\Users\\%USERNAME%\\Documents";
		private string file_name = "safe.hc";
		private static readonly string my_name = "Backup MoreFiles";
		private ArrayList excludeDrivePaths = new ArrayList();
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			excludeDrivePaths.Add("A:");
			excludeDrivePaths.Add("B:");
			excludeDrivePaths.Add("C:");
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void write(string msg) {
			outputListBox.Items.Add(msg);
			Application.DoEvents();
		}
		
		bool IsUsableDrivePath(string path) {
			bool result=true;
			foreach (string this_path in excludeDrivePaths) {
				if (path.ToLower().StartsWith(this_path.ToLower())) {
					result=false;
					break;
				}
			}
			return result;
		}
		
		public static bool CompareFiles(string filePath1, string filePath2)
	    {
	        // Check if the files exist
	        if (!File.Exists(filePath1) || !File.Exists(filePath2))
	        {
	            throw new FileNotFoundException("One or both of the files do not exist.");
	        }
	
	        // Get file sizes
	        FileInfo fileInfo1 = new FileInfo(filePath1);
	        FileInfo fileInfo2 = new FileInfo(filePath2);
	
	        if (fileInfo1.Length != fileInfo2.Length)
	        {
	            return false; // Files differ in size
	        }
	
	        // Open file streams for reading
	        using (FileStream fs1 = new FileStream(filePath1, FileMode.Open, FileAccess.Read),
	                          fs2 = new FileStream(filePath2, FileMode.Open, FileAccess.Read))
	        {
	            const int bufferSize = 8; // 8 bytes for 64-bit chunk
	            byte[] buffer1 = new byte[bufferSize];
	            byte[] buffer2 = new byte[bufferSize];
	
	            int bytesRead1, bytesRead2;
	
	            // Read and compare chunks of 8 bytes
	            while ((bytesRead1 = fs1.Read(buffer1, 0, bufferSize)) > 0)
	            {
	                bytesRead2 = fs2.Read(buffer2, 0, bytesRead1);
	
	                // If the number of bytes read from fs2 differs, files are different
	                if (bytesRead2 != bytesRead1)
	                {
	                    return false; // Files differ
	                }
	
	                // If bytesRead1 is 8, compare 64-bit integers
	                if (bytesRead1 == bufferSize)
	                {
	                    long value1 = BitConverter.ToInt64(buffer1, 0);
	                    long value2 = BitConverter.ToInt64(buffer2, 0);
	
	                    if (value1 != value2)
	                    {
	                        return false; // Files differ
	                    }
	                }
	                else
	                {
	                    // Compare remaining bytes
	                    if (!CompareChunks(buffer1, buffer2, bytesRead1))
	                    {
	                        return false; // Files differ
	                    }
	                }
	            }
	        }
	
	        return true; // Files are identical
	    }
	
	    private static bool CompareChunks(byte[] chunk1, byte[] chunk2, int bytesRead)
	    {
	        for (int i = 0; i < bytesRead; i++)
	        {
	            if (chunk1[i] != chunk2[i])
	            {
	                return false;
	            }
	        }
	        return true;
	    }
		void GoButtonClick(object sender, EventArgs e)
		{
			goButton.Enabled=false;
			outputListBox.Items.Clear();
			Application.DoEvents();
			destDI = null;
			mainTabControl.SelectedTab = logTabPage;
			
			source_folder_path = source_folder_path.Replace("%USERNAME%",Environment.GetEnvironmentVariable("USERNAME"));
			source_folder_path = source_folder_path.Replace("%USERPROFILE%",Environment.GetEnvironmentVariable("USERPROFILE"));
			source_file_path = Path.Combine(source_folder_path, file_name);
			write("Checking for "+source_file_path);
			if (!File.Exists(source_file_path)) {
				MessageBox.Show("The source file '"+source_file_path+"' could not be found. This location is hard-coded.",my_name);
				return;
			}
			dest_partialpath = dest_partialpath.Replace("%USERNAME%",Environment.GetEnvironmentVariable("USERNAME"));
			dest_partialpath = dest_partialpath.Replace("%USERPROFILE%",Environment.GetEnvironmentVariable("USERPROFILE"));
			driveinfos = DriveInfo.GetDrives();
			string dest_file_path = null;
			if (driveinfos == null) {
				write("GetDrives failed to access drive list.");
				goButton.Enabled=true;
				return;
			}
			if (driveinfos.Length <= 0) {
				write("GetDrives failed to get drives.");
				goButton.Enabled=true;
				return;
			}
			foreach (DriveInfo di in driveinfos) {
				if (IsUsableDrivePath(di.RootDirectory.FullName)) {
					write("Checking "+di.RootDirectory.FullName+"...");
					try {
						dest_file_path = Path.Combine( Path.Combine(di.RootDirectory.FullName, dest_partialpath), file_name);
						//write("looking for "+dest_file_path);
						if (File.Exists(dest_file_path)) {
							//write(di.RootDirectory.FullName);
							destDI=di;
							break;
						}
						else {
							dest_file_path=null;
							destDI=null;
						}
					}
					catch { dest_file_path=null; destDI=null;} //don't care
				}//end if IsUsableDrivePath
			}
			if (dest_file_path!=null&&destDI!=null) {
				write("Found a "+file_name+" on drive "+destDI.RootDirectory.FullName);
				write(String.Format("Comparing to {0} (this may take a while)...", file_name));
				Application.DoEvents();  // Show the "write" message since we are blocking GUI thread with io
				// FIXME: Do not block GUI thread
				if (CompareFiles(source_file_path, dest_file_path)) {
					write(String.Format("There was no change to {0} since the last backup.", file_name));
					return;
				}
				string first_path = dest_file_path+".1st";
				string bak_path = dest_file_path+".bak";
				try {
					if (!File.Exists(first_path)) {
						write("Making first backup copy...");
						File.Move(dest_file_path, first_path);
					}
					else {
						if (File.Exists(bak_path)) {
							write("Purging old bak file...");
							File.Delete(bak_path);
						}
						if (File.Exists(dest_file_path)) {
							write("Moving old file to retroactive copy...");
							File.Move(dest_file_path, bak_path);
						}
					}
					write("Copying new file, please wait...");
					File.Copy(source_file_path, dest_file_path);
					write("The backup operation finished successfully.");
					goButton.Enabled=true;
				}
				catch (Exception exn) {
					write("Could not finish making 1st/bak file for "+file_name+": ");
					write(exn.ToString());
					goButton.Enabled=true;
				}
			}
			else {
				MessageBox.Show(my_name+" could not find a backup drive where the file "+file_name+" resides in subfolder " +
				                "'"+dest_partialpath+"'. Please make sure you plug in the backup drive and have run your real backup at least once, then try again.",my_name);
				mainTabControl.SelectedTab = toolsTabPage;
				goButton.Enabled=true;
			}
		}
		
		void SaveLogToolStripMenuItemClick(object sender, EventArgs e)
		{
			saveFileDialog1.DefaultExt="txt";
			saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
			DialogResult dlgresult = saveFileDialog1.ShowDialog();
			if (dlgresult == DialogResult.OK) {
				//DialogResult drConfirm = DialogResult.OK;
				//if (File.Exists(saveFileDialog1.FileName)) {
				//	drConfirm=MessageBox.Show("Do you want to overwrite "+saveFileDialog1.FileName+"?", my_name, MessageBoxButtons.OKCancel);
				//}
				//if (drConfirm==DialogResult.OK) {
					StreamWriter oStream = new StreamWriter(saveFileDialog1.FileName);
					foreach (var this_var in outputListBox.Items) {
						oStream.WriteLine(this_var.ToString());
					}
					oStream.Close();
				//}
			}
			else {
				write("Save log was cancelled by user.");
			}
		}
	}
}
