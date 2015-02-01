using System.Security.Cryptography;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{
	private Thread Background = null;

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();

		treeSearchResults.AppendColumn ("Hash of File Contents", new CellRendererText (), "text", 0);
		treeSearchResults.AppendColumn ("File Paths", new CellRendererText (), "text", 1);

		btnSelectPath.Clicked += HandleChoosePathClicked;
		btnSearch.Clicked += HandleSearchClicked;
		btnCancelSearch.Clicked += HandleCancelSearchClicked;
	}

	void HandleCancelSearchClicked (object sender, EventArgs e)
	{
		Console.WriteLine ("Aborting search");

		Background.Abort ();

		btnSearch.Sensitive = true;
		btnCancelSearch.Sensitive = false;
	}

	void HandleSearchClicked (object sender, EventArgs e)
	{
		Console.WriteLine ("Preparing background search thread...");

		Background = new Thread (new ThreadStart (delegate {
			Console.WriteLine("Search thread started");
			Application.Invoke(delegate {
				btnSearch.Sensitive = false;
				btnCancelSearch.Sensitive = true;
			});

			try {
				RunSearch(lblSearchPath.LabelProp);
			}
			catch(IOException ex) {
				DisplayErrorDialog("An input/output error occurred during the search:\n\n{0}", ex.Message);
			}
			catch(UnauthorizedAccessException ex) {
				DisplayErrorDialog("Unable to search this directory due to a permissions issue:\n\n{0}", ex.Message);
			}

			Application.Invoke(delegate {
				btnSearch.Sensitive = true;
				btnCancelSearch.Sensitive = false;
				Background = null;
			});

			Console.WriteLine("Search thread stopping");
		}));

		Background.Start ();
	}

	void HandleChoosePathClicked (object sender, EventArgs e)
	{
		var path = QueryUserForSearchFolder ();

		if (path != null) {
			lblSearchPath.LabelProp = path;
			btnSearch.Sensitive = true;
		}
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		if (Background != null) {
			Background.Abort ();
			Background = null;
		}

		Application.Quit ();
		a.RetVal = true;
	}

	private void DisplayErrorDialog(string format, params object[] args)
	{
		Application.Invoke (delegate {
			var dialog = new MessageDialog (this, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, false, format, args);
			dialog.Run ();
			dialog.Destroy ();
		});
	}

	private void RunSearch(String path)
	{
		const UInt32 updatePeriod = 1000;
		UInt32 updateCounter = 0;
		UInt64 examinedCount = 0;

		Console.WriteLine ("Beginning search from {0}", path);

		var results = new Dictionary<String, List<String>> ();

		var directories = new Stack<String> (50);
		directories.Push (path);

		var changed = false;

		//foreach (var filename in Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories)) {
		while(directories.Count > 0) {
			var folder = directories.Pop ();

			foreach (var subfolder in Directory.EnumerateDirectories (folder, "*", SearchOption.TopDirectoryOnly)) {
				try {
					Directory.GetDirectories(subfolder);
					directories.Push (subfolder);
				} catch (UnauthorizedAccessException) {
					Console.WriteLine ("Skipping path: '{0}' due to permissions", subfolder);
				}
			}

			foreach (var filename in Directory.EnumerateFiles(folder, "*", SearchOption.TopDirectoryOnly)) {
				try {
					Console.WriteLine ("Looking at file '{0}'...", filename);
					var hash = CalculateFileHash (filename);
					Console.WriteLine ("  Hash: {0}", hash);

					lock (results) {
						if (results.ContainsKey (hash)) {
							results [hash].Add (filename);
							changed = true;
						} else {
							var newEntry = new List<String> (1);
							newEntry.Add (filename);
							results.Add (hash, newEntry);
						}
					}
				} catch (IOException ex) {
					Console.WriteLine ("IO Exception ({0}): {1}", filename, ex);
				} catch (UnauthorizedAccessException ex) {
					Console.WriteLine ("Unauthorised Access ({0}): {1}", filename, ex);
				}

				examinedCount++;

				Application.Invoke (delegate {
					lblPath.LabelProp = String.Format("Current Path: {0}", folder);
					lblFileCount.LabelProp = String.Format("File Examined: {0}", examinedCount);
				});

				updateCounter++;
				if (updateCounter >= updatePeriod && changed) {
					changed = false;
					updateCounter = 0;

					DisplayResults (results);
				}
			}
		}

		DisplayResults (results);
	}

	private String CalculateFileHash(String path)
	{
		using (var md5 = MD5.Create())
		{
			using (var stream = File.OpenRead(path))
			{
				return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
			}
		}
	}

	private void DisplayResults(Dictionary<String, List<String>> results)
	{
		Console.WriteLine ("Displaying results");

		var store = new TreeStore (typeof(String), typeof(String));

		lock (results) {
			foreach (var hash in results.Keys) {
				if (results [hash].Count > 1) {
					var iter = store.AppendValues (hash, "");
					foreach (var filename in results[hash]) {
						store.AppendValues (iter, "", filename);
					}
				}
			}
		}

		Application.Invoke (delegate {
			treeSearchResults.Model = store;
			treeSearchResults.ExpandAll ();
			treeSearchResults.QueueDraw ();
		});
	}

	private String QueryUserForSearchFolder()
	{
		String result = null;

		FileChooserDialog dialog = new FileChooserDialog ("Select a Folder to Search", this, FileChooserAction.SelectFolder, "Select", ResponseType.Ok, "Cancel", ResponseType.Cancel);
		dialog.Show ();

		if (dialog.Run () == (int) ResponseType.Ok) {
			result = dialog.Filename;
		}

		dialog.Destroy ();

		return result;
	}
}
