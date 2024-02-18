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
			if (File.Exists(source_file_path)) {
				dest_partialpath = dest_partialpath.Replace("%USERNAME%",Environment.GetEnvironmentVariable("USERNAME"));
				dest_partialpath = dest_partialpath.Replace("%USERPROFILE%",Environment.GetEnvironmentVariable("USERPROFILE"));
				driveinfos = DriveInfo.GetDrives();
				string dest_file_path = null;
				if (driveinfos!=null) {
					if (driveinfos.Length>0) {
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
					else {
						write("GetDrives failed to get drives.");
						goButton.Enabled=true;
					}
				}
				else {
					write("GetDrives failed to access drive list.");
					goButton.Enabled=true;
				}
			}
			else {
				MessageBox.Show("The source file '"+source_file_path+"' could not be found. This location is hard-coded.",my_name);
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
