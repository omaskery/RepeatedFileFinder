
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.VBox vbox1;
	
	private global::Gtk.HBox hbox1;
	
	private global::Gtk.Label label1;
	
	private global::Gtk.Label lblSearchPath;
	
	private global::Gtk.Button btnSelectPath;
	
	private global::Gtk.HBox hbox2;
	
	private global::Gtk.VBox vbox2;
	
	private global::Gtk.Button btnSearch;
	
	private global::Gtk.Button btnCancelSearch;
	
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	
	private global::Gtk.TreeView treeSearchResults;
	
	private global::Gtk.Statusbar statusbar1;
	
	private global::Gtk.Label lblPath;
	
	private global::Gtk.Label lblFileCount;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		this.BorderWidth = ((uint)(10));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.label1 = new global::Gtk.Label ();
		this.label1.Name = "label1";
		this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Search Directory:");
		this.hbox1.Add (this.label1);
		global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label1]));
		w1.Position = 0;
		w1.Expand = false;
		w1.Fill = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.lblSearchPath = new global::Gtk.Label ();
		this.lblSearchPath.Name = "lblSearchPath";
		this.lblSearchPath.LabelProp = global::Mono.Unix.Catalog.GetString ("<Select a Directory to Search>");
		this.hbox1.Add (this.lblSearchPath);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.lblSearchPath]));
		w2.Position = 1;
		// Container child hbox1.Gtk.Box+BoxChild
		this.btnSelectPath = new global::Gtk.Button ();
		this.btnSelectPath.CanFocus = true;
		this.btnSelectPath.Name = "btnSelectPath";
		this.btnSelectPath.UseUnderline = true;
		this.btnSelectPath.Label = global::Mono.Unix.Catalog.GetString ("Choose Directory");
		this.hbox1.Add (this.btnSelectPath);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.btnSelectPath]));
		w3.Position = 2;
		w3.Expand = false;
		w3.Fill = false;
		this.vbox1.Add (this.hbox1);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
		w4.Position = 0;
		w4.Expand = false;
		w4.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox2 = new global::Gtk.HBox ();
		this.hbox2.Name = "hbox2";
		this.hbox2.Spacing = 6;
		this.hbox2.BorderWidth = ((uint)(3));
		// Container child hbox2.Gtk.Box+BoxChild
		this.vbox2 = new global::Gtk.VBox ();
		this.vbox2.Name = "vbox2";
		this.vbox2.Spacing = 6;
		// Container child vbox2.Gtk.Box+BoxChild
		this.btnSearch = new global::Gtk.Button ();
		this.btnSearch.Sensitive = false;
		this.btnSearch.CanFocus = true;
		this.btnSearch.Name = "btnSearch";
		this.btnSearch.UseUnderline = true;
		this.btnSearch.Label = global::Mono.Unix.Catalog.GetString ("Start Search");
		this.vbox2.Add (this.btnSearch);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.btnSearch]));
		w5.Position = 0;
		// Container child vbox2.Gtk.Box+BoxChild
		this.btnCancelSearch = new global::Gtk.Button ();
		this.btnCancelSearch.Sensitive = false;
		this.btnCancelSearch.CanFocus = true;
		this.btnCancelSearch.Name = "btnCancelSearch";
		this.btnCancelSearch.UseUnderline = true;
		this.btnCancelSearch.Label = global::Mono.Unix.Catalog.GetString ("Cancel Search");
		this.vbox2.Add (this.btnCancelSearch);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.btnCancelSearch]));
		w6.Position = 1;
		this.hbox2.Add (this.vbox2);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.vbox2]));
		w7.Position = 0;
		w7.Expand = false;
		w7.Fill = false;
		// Container child hbox2.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.treeSearchResults = new global::Gtk.TreeView ();
		this.treeSearchResults.CanFocus = true;
		this.treeSearchResults.Name = "treeSearchResults";
		this.GtkScrolledWindow.Add (this.treeSearchResults);
		this.hbox2.Add (this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.GtkScrolledWindow]));
		w9.Position = 1;
		this.vbox1.Add (this.hbox2);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox2]));
		w10.Position = 1;
		// Container child vbox1.Gtk.Box+BoxChild
		this.statusbar1 = new global::Gtk.Statusbar ();
		this.statusbar1.Name = "statusbar1";
		this.statusbar1.Spacing = 6;
		this.statusbar1.HasResizeGrip = false;
		// Container child statusbar1.Gtk.Box+BoxChild
		this.lblPath = new global::Gtk.Label ();
		this.lblPath.Name = "lblPath";
		this.lblPath.LabelProp = global::Mono.Unix.Catalog.GetString ("Current Path: ---");
		this.statusbar1.Add (this.lblPath);
		global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.statusbar1 [this.lblPath]));
		w11.Position = 1;
		// Container child statusbar1.Gtk.Box+BoxChild
		this.lblFileCount = new global::Gtk.Label ();
		this.lblFileCount.Name = "lblFileCount";
		this.lblFileCount.LabelProp = global::Mono.Unix.Catalog.GetString ("Files Examined: ---");
		this.statusbar1.Add (this.lblFileCount);
		global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.statusbar1 [this.lblFileCount]));
		w12.Position = 2;
		w12.Expand = false;
		this.vbox1.Add (this.statusbar1);
		global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.statusbar1]));
		w13.Position = 2;
		w13.Expand = false;
		w13.Fill = false;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 714;
		this.DefaultHeight = 487;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
	}
}
