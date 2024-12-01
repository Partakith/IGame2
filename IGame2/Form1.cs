using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IGame2.ResizableForm;
using static IGame2.MoveDropDrag;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;
using SharpDX.XInput;
using System.Drawing.Drawing2D;
using IGame2.Properties;
using IGame2.Themes;
using System.Runtime.CompilerServices;


namespace IGame2
{
    public partial class Form1 : Form
    {
        private ResizableForm resizableForm;
        private string gamesDirectory = Path.Combine(Application.StartupPath, "Games");

        private XboxController xboxController;
        private Timer controllerTimer;

        public static PictureBox controllerStateElement;

        public static dynamic QcontrolBar;
        public static dynamic QcontrolLeft;
        public static dynamic QcontrolRight;
        public static dynamic QaddBtn;
        public static dynamic QlibraryBtn;
        public static dynamic QrefreshBtn;
        public static dynamic QsettingsBtn;

        public Form1()
        {
            InitializeComponent();

            // Initialize ResizableForm to make the form resizable
            resizableForm = new ResizableForm(this);

            // Add Mouse event handlers to Form
            this.MouseDown += resizableForm.OnMouseDown;
            this.MouseMove += resizableForm.OnMouseMove;
            this.MouseUp += resizableForm.OnMouseUp;

            controlBar.MouseDown += MoveDropDrag.InitiateDrag;


            InitializeGameLibraryPanel();

            // 1. In the Form Designer (or Constructor), ensure gameLibrary is focusable:
            gameLibrary.TabStop = true;  // Allow the panel to receive focus

            xboxController = new XboxController(gameLibrary);

            this.Click += new EventHandler(FocusME);

            // Load the SVG document
            //_svgDocument = SvgDocument.Open(Path.Combine(Application.StartupPath, "Assets\\my_retro.svg"));

            // Set up a timer or resize event to regenerate the image when the form resizes
            //this.Resize += (sender, args) => RedrawSvg();

            var holdPaneWidth = basePane.Width;
            var holdPaneHeight = basePane.Height;
            var holdPaneColor = basePane.BackColor;
            var holdPaneLoc = new Point(basePane.Location.X - 5,basePane.Location.Y - 5);
            var holdPaneAnchor = basePane.Anchor;
            //this.Controls.Remove(basePane);
            var basePaneB = new RoundedPanel();
            basePaneB.Width = holdPaneWidth + 10;
            basePaneB.Height = holdPaneHeight + 10;
            basePaneB.BackColor = holdPaneColor;
            basePaneB.Location = holdPaneLoc;
            basePaneB.Anchor = holdPaneAnchor;
            this.Controls.Add(basePaneB);
            basePaneB.SendToBack();

            closeBtn.MouseEnter += new EventHandler(Enter1ForeColor);
            closeBtn.MouseLeave += new EventHandler(ExitForeColor);
            maxiBtn.MouseEnter += new EventHandler(Enter2ForeColor);
            maxiBtn.MouseLeave += new EventHandler(ExitForeColor);
            miniBtn.MouseEnter += new EventHandler(Enter3ForeColor);
            miniBtn.MouseLeave += new EventHandler(ExitForeColor);

            gameLibrary.MouseClick += new MouseEventHandler(GLClicked);

            controllerStateElement = new PictureBox();
            controllerStateElement = setControllerState;
            setControllerState = controllerStateElement;

            //Theme
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Ensure the form starts with a minimum size
            this.MinimumSize = new System.Drawing.Size(515, 420);  // Adjust minimum size as needed
                                                                   //this.MaximumSize = new System.Drawing.Size(800, 800);  // Adjust maximum size as needed

            // Make sure the panel has focus when the form loads
            gameLibrary.Focus();

            

            // Set up a Timer to poll the controller every 50 ms
            controllerTimer = new Timer();
            controllerTimer.Interval = 50;
            controllerTimer.Tick += ControllerTimer_Tick;
            controllerTimer.Start();



            // RedrawSvg();
            controlRight.Controls.Add(closeBtn);
            controlRight.Controls.Add(maxiBtn);
            controlRight.Controls.Add(miniBtn);
            miniBtn.Location = new Point(30,6);
            maxiBtn.Location = new Point(70,6);
            closeBtn.Location = new Point(110, 6);


            if (File.Exists(Application.StartupPath + "\\Config\\HotKeys.txt")) {
                checkKeys.Checked = true;
            }

            horiHide.Visible = false;


            // Theme =========================
            // Bitmap cLeft = Resources.my_retro;
            // Bitmap cRight = Resources.my_retro_b;
            // var cLeftThemed = Theme.ApplyHueShiftWG(cLeft, -40);
            // var cRightThemed = Theme.ApplyHueShiftWG(cRight, -40);
            // controlLeft.BackgroundImage = cLeftThemed;
            // controlRight.BackgroundImage = cRightThemed;
            QcontrolBar = this.controlBar;
            QaddBtn = this.addBtn;
            QsettingsBtn = this.settingsBtn;
            QrefreshBtn = this.refreshBtn;
            QlibraryBtn = this.libraryBtn;
            QcontrolLeft = this.controlLeft;
            QcontrolRight = this.controlRight;
            //Theme.setTheme(Color.Red);
            if (File.Exists(Application.StartupPath + "\\Config\\redTheme.txt")) { this.useRedTheme.Checked = true; }
            // ===============================

        }

        public void GLClicked(object s, MouseEventArgs e) { XboxController.ControllerActive = true; }


        protected override async void OnResize(EventArgs e)
        {

            base.OnResize(e);
            gameLibrary.Visible = false;

            if (justSized == false){
                ResizeFlex();
            }
            

            // this.Invalidate(); // Repaint on resize to adjust the corners

        }

        public bool justSized = false;
        public async void ResizeFlex() 
        {
            justSized = true;
            await Task.Delay(3500);
            gameLibrary.Controls.Clear();
            LoadGames();
            xboxController = new XboxController(gameLibrary);
            if (gameLibrary.HorizontalScroll.Visible == true) { horiHide.Visible = true; }
            else { horiHide.Visible = false; }
            justSized = false;
            gameLibrary.Visible = true;
        }

        private void Enter3ForeColor(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                // Change the ForeColor to a random color or a specific color
                control.ForeColor = Color.DarkBlue; // Change this to any color you want
            }
        }

        private void Enter2ForeColor(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                // Change the ForeColor to a random color or a specific color
                control.ForeColor = Color.Yellow; // Change this to any color you want
            }
        }

        private void Enter1ForeColor(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                // Change the ForeColor to a random color or a specific color
                control.ForeColor = Color.Red; // Change this to any color you want
            }
        }
        private void ExitForeColor(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                // Change the ForeColor to a random color or a specific color
                control.ForeColor = Color.Silver; // Change this to any color you want
            }
        }

        private void RedrawSvg()
        {
            /*
            PictureBox myRetroLogo = new PictureBox();
            try { controlBar.Controls.Remove(myRetroLogo); }
            catch { }
            // Get the current size of the form or control
            var width = 148;
            var height = controlBar.Height;

            // Rasterize the SVG at the current form size
            _rasterizedSvgBitmap = _svgDocument.Draw(width, height);
            
            myRetroLogo.Image = _rasterizedSvgBitmap;
            myRetroLogo.BackColor = Color.Transparent;
            myRetroLogo.SizeMode = PictureBoxSizeMode.Zoom;
            controlBar.Controls.Add(myRetroLogo);
            // Trigger a repaint to display the new bitmap
            this.Invalidate(); */
   

        }

        // Override the OnPaint method to render the rasterized SVG
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

           
        }

        private void ControllerTimer_Tick(object sender, EventArgs e)
        {
            if (xboxController.IsConnected())
            {
                xboxController.Update();
            }
            else
            {
              //  MessageBox.Show("Xbox Controller Not Connected");
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
           // MessageBox.Show("Override Event Active");
            UnhookWindowsHookEx(_hookID);
            Environment.Exit(0);
            base.OnClosing(e);           
            this.Close();
        }

        private void FocusME(object s, EventArgs e) {
            this.Focus();
        }

        private void webBtn_Click(object sender, EventArgs e)
        {

            gameLibrary.SendToBack();          
        }

        private void libraryBtn_Click(object sender, EventArgs e)
        {
            basePane.BringToFront();
            XboxController.ControllerActive = true;
        }

      



        private void InitializeGameLibraryPanel()
        {
            // Ensure the games directory exists
            if (!Directory.Exists(gamesDirectory))
            {
                Directory.CreateDirectory(gamesDirectory);
            }

            // Load games from text files on program start
            LoadGames();
        }



        private void AddGameImage(string imagePath)
        {
            // Ask the user for the game name
            string gameName = PromptForGameName();
            if (string.IsNullOrEmpty(gameName)) return;  // If the user canceled the prompt, don't add the game.

            // Create the text file for this game
            string gameTextFilePath = Path.Combine(gamesDirectory, $"{gameName}.txt");

            // Create a new PictureBox to display the game image
            PictureBox gameImage = new PictureBox
            {
                Image = Image.FromFile(imagePath), // Load the image from file
                Size = new Size(180, 240),  // Fixed size of the image box
                SizeMode = PictureBoxSizeMode.Zoom,  // Fit image inside the PictureBox, maintaining aspect ratio
                Margin = new Padding(10),  // Optional margin between the image boxes
                BackColor = Color.FromArgb(0, 0, 0),
                Tag = gameTextFilePath,
            };

            // Store the game image click event handler
            gameImage.MouseClick += (sender, e) => OnGameImageClick(gameTextFilePath, sender, e);

            // Add the game image to the game library panel
            gameLibrary.Controls.Add(gameImage);

            // Write the game information to the text file (image path and name)
            File.WriteAllLines(gameTextFilePath, new[] { imagePath, gameName, string.Empty });

            // Arrange the images
            ArrangeGameImages();
        }

        private string PromptForGameName()
        {
            // Ask the user for the game name using the custom InputDialog
            return InputDialog.ShowDialog("Enter the game name:");
        }

        public static void OnGameImageClick(string gameTextFilePath, object s, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                // Read the game information from the text file
                if (File.Exists(gameTextFilePath))
                {
                    var lines = File.ReadAllLines(gameTextFilePath);

                    // Check if the third line exists and is not empty
                    if (lines.Length > 2 && !string.IsNullOrEmpty(lines[2]))
                    {
                        // There is a third line, open the game from the specified file path
                        string gameFilePath = lines[2];
                        System.Diagnostics.Process.Start(gameFilePath); // Open the game file
                    }
                    else
                    {
                        // No third line exists or it's empty, prompt the user to select a game file
                        string selectedFilePath = SelectGameFile();
                        if (!string.IsNullOrEmpty(selectedFilePath))
                        {
                            // Ensure that we have at least 3 lines and write the selected file path to the third line
                            if (lines.Length < 3)
                            {
                                var updatedLines = new List<string>(lines);
                                // Make sure we add a blank line for the third and fourth lines if they don't exist
                                while (updatedLines.Count < 3)
                                {
                                    updatedLines.Add(string.Empty);
                                }
                                updatedLines[2] = selectedFilePath; // Place the selected file path in the third line
                                File.WriteAllLines(gameTextFilePath, updatedLines);
                            }
                            else
                            {
                                lines[2] = selectedFilePath; // Update the third line
                                File.WriteAllLines(gameTextFilePath, lines);
                            }
                        }
                    }
                }
            }
            if (e.Button == MouseButtons.Right) {
                // Show a MessageBox with Yes and No buttons
                DialogResult result = MessageBox.Show(
                    "Edit Game Information File? [Change image/sort-title/gamefile]",    // Message to display
                    "Game Edit",                     // Title of the MessageBox
                    MessageBoxButtons.YesNo,       // Buttons to show (Yes and No)
                    MessageBoxIcon.Question        // Icon type (Optional)
                );

                // Handle the response
                if (result == DialogResult.Yes)
                {
                    Process.Start(gameTextFilePath);
                }
                else if (result == DialogResult.No)
                {
                    
                }
            }
        }

        private static string SelectGameFile()
        {
            // Prompt the user to select a file
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a Game File";
                openFileDialog.Filter = "All Files|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
            }
            return string.Empty;
        }

        private void LoadGames()
        {
            // Loop through all text files in the "Games" directory
            foreach (var filePath in Directory.GetFiles(gamesDirectory, "*.txt"))
            {
                var lines = File.ReadAllLines(filePath);
                if (lines.Length > 0)
                {
                    string imagePath = lines[0];
                    string gameName = lines.Length > 1 ? lines[1] : Path.GetFileNameWithoutExtension(filePath);

                    // Create the PictureBox for the game
                    PictureBox gameImage = new PictureBox
                    {
                        Image = Image.FromFile(imagePath),
                        Size = new Size(180, 240),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Margin = new Padding(10),
                        BackColor = Color.FromArgb(0, 0, 0),
                        Tag = filePath,
                    };

                    // Store the game image click event handler
                    gameImage.MouseClick += (sender, e) => OnGameImageClick(filePath, sender, e);

                    // Add the game image to the game library panel
                    gameLibrary.Controls.Add(gameImage);
                }
            }

            // Arrange the images
            ArrangeGameImages();
        }


        private void ArrangeGameImages()
        {
            int x = 10;  // Initial X position (starting from left)
            int y = 10;  // Initial Y position (starting from top)
            int maxWidth = gameLibrary.ClientSize.Width;  // Max width of the gameLibrary panel

            foreach (Control control in gameLibrary.Controls)
            {
                if (control is PictureBox pictureBox)
                {
                    // Check if the image will exceed the panel width, if so, wrap to the next line
                    if (x + pictureBox.Width > maxWidth)
                    {
                        // Move to the next row
                        x = 10;
                        y += pictureBox.Height + 10;  // 10 is the padding between rows
                    }

                    // Position the picture box
                    pictureBox.Location = new Point(x, y);

                    // Move to the next position (next image)
                    x += pictureBox.Width + 10;  // 10 is the padding between images
                }
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select a File",  // Set dialog title
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff|All Files|*.*",  // File types filter
                InitialDirectory = @"C:\",  // Initial directory (optional)
                Multiselect = false  // Allow only one file selection
            };

            // Show the dialog and check if the user clicked OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Retrieve the file path
                string filePath = openFileDialog.FileName;
                AddGameImage(filePath);
                //MessageBox.Show($"File selected: {filePath}");
            }
            else
            {
                MessageBox.Show("No file selected.");
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maxiBtn_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) { this.WindowState = FormWindowState.Normal; }
            else { this.WindowState = FormWindowState.Maximized; }
        }

        private void miniBtn_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) { this.WindowState = FormWindowState.Normal; }
            else { this.WindowState = FormWindowState.Minimized; }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            gameLibrary.Controls.Clear();
            LoadGames();
        }

        private void assBtn_Click(object sender, EventArgs e)
        {
            // Step 1: Let user select a file (any file with a custom extension)
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "All Files (*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = fileDialog.FileName;
                string extension = Path.GetExtension(selectedFile).ToLower();

                // Step 2: Let user select the program (any executable)
                OpenFileDialog programDialog = new OpenFileDialog();
                programDialog.Filter = "Executable Files (*.exe)|*.exe|All files (*.*)|*.*";
                if (programDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedProgram = programDialog.FileName;

                    // Step 3: Set file association in registry
                    SetFileAssociation(extension, selectedProgram);
                }
            }
        }

        private void SetFileAssociation(string extension, string programPath)
        {
            try
            {
                // Generate a unique ProgID based on the file extension (e.g., "MyApp.GBA" for .gba files)
                string progID = "UserProgram_" + extension.TrimStart('.');

                // Step 1: Create registry entry for the file extension (.ext) and link it to ProgID
                string extensionKeyPath = @"HKEY_CLASSES_ROOT\" + extension;
                Registry.SetValue(extensionKeyPath, "", progID); // Associate the file extension with the ProgID

                // Step 2: Create a new ProgID key under HKEY_CLASSES_ROOT, linking it to the program
                string progIDKeyPath = @"HKEY_CLASSES_ROOT\" + progID;
                Registry.SetValue(progIDKeyPath, "", "User Associated Program");

                // Step 3: Set the command to open files with the selected program
                string commandKeyPath = progIDKeyPath + @"\shell\open\command";
                Registry.SetValue(commandKeyPath, "", $"\"{programPath}\" \"%1\""); // Command to run the program with the file

                // Step 4: Optionally, you can set a description for the program
                string descriptionKeyPath = progIDKeyPath;
                Registry.SetValue(descriptionKeyPath, "Description", "User Associated Program");

                MessageBox.Show($"File association for {extension} set to open with {programPath}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error setting file association: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region KeyboardHook
        // Low-End Keyboard Hook for Hotkeys ===========================================================================
        //==============================================================================================================
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        private LowLevelKeyboardProc _proc;
        private IntPtr _hookID = IntPtr.Zero;



        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            try { UnhookWindowsHookEx(_hookID); Environment.Exit(0); } catch { }
        }

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);

        string currentKey;
        bool showKeyRef;
        bool showColorRef;

        private IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
       
                if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN && doHook == true)
                {
                    int vkCode = Marshal.ReadInt32(lParam);
                    // Handle the key press here
                    Console.WriteLine("Global key pressed: " + ((Keys)vkCode).ToString());
                    currentKey = ((Keys)vkCode).ToString();
                    if (showKeyRef == true) { MessageBox.Show(((Keys)vkCode).ToString()); }

                    if (((Keys)vkCode).ToString() == "RShiftKey" && showColorRef == true) //Join Tercessuinotlim
                    {

                    };
                    if (currentKey == "23423434") //Join Tercessuinotlim
                    {


                    };

                    if (((Keys)vkCode).ToString() == "Up") //Join Tercessuinotlim
                    {
                        gameLibrary.AutoScrollPosition = new Point(0, gameLibrary.VerticalScroll.Value - 20);
                    };
                    if (((Keys)vkCode).ToString() == "Down") //Join Tercessuinotlim
                    {
                        gameLibrary.AutoScrollPosition = new Point(0, gameLibrary.VerticalScroll.Value + 20);
                    };
                    if (((Keys)vkCode).ToString() == "Left") //Join Tercessuinotlim
                    {

                    };
                    if (((Keys)vkCode).ToString() == "Right") //Join Tercessuinotlim
                    {

                    };
                    if (((Keys)vkCode).ToString() == "NumLock") //Join Tercessuinotlim
                    {
                  
                    };


            }
                return CallNextHookEx(_hookID, nCode, wParam, lParam);
            
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(
            int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr CallNextHookEx(
            IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        // Low-End Keyboard Hook for Hotkeys ===========================================================================
        //==============================================================================================================
        #endregion

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            settingsMenu.BringToFront();
        }

        public bool doHook = false;
        private void checkKeys_CheckedChanged(object sender, EventArgs e)
        {
            if (checkKeys.Checked) { doHook = true;   // Custom Keyboard / Hook
                _proc = HookCallback;
                // base.OnLoad(e);
                _hookID = SetHook(_proc);

                if (Directory.Exists(Application.StartupPath + "\\Config"))
                {
                    File.WriteAllText(Application.StartupPath + "\\Config\\HotKeys.txt","");
                }
                else {
                    Directory.CreateDirectory(Application.StartupPath + "\\Config");
                    File.WriteAllText(Application.StartupPath + "\\Config\\HotKeys.txt", "");
                }
            }
            else { doHook = false; UnhookWindowsHookEx(_hookID); File.Delete(Application.StartupPath + "\\Config\\HotKeys.txt"); }
        }    

        private void gameLibrary_Paint(object sender, PaintEventArgs e)
        {

        }

        public static bool cState = true;
        private void setControllerState_Click(object sender, EventArgs e)
        {
            if (cState != true) { cState = true; }
            else { cState = false; }
        }

        private void useRedTheme_CheckedChanged(object sender, EventArgs e)
        {
            if (this.useRedTheme.Checked == true) {

                this.useBlueTheme.Checked = false;
                try { File.Delete(Application.StartupPath + "\\Config\\blueTheme.txt"); }
                catch { }
                if (Directory.Exists(Application.StartupPath + "\\Config"))
                {
                    File.WriteAllText(Application.StartupPath + "\\Config\\redTheme.txt", "");
                }
                else
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\Config");
                    File.WriteAllText(Application.StartupPath + "\\Config\\redTheme.txt", "");
                }
                Theme.setTheme(Color.Red);
            }
            else { File.Delete(Application.StartupPath + "\\Config\\redTheme.txt"); }
        }

        private void useBlueTheme_CheckedChanged(object sender, EventArgs e)
        {
            if (this.useBlueTheme.Checked == true)
            {
                this.useRedTheme.Checked = false;
                try { File.Delete(Application.StartupPath + "\\Config\\redTheme.txt"); }
                catch { }
                if (Directory.Exists(Application.StartupPath + "\\Config"))
                {
                    File.WriteAllText(Application.StartupPath + "\\Config\\blueTheme.txt", "");
                }
                else
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\Config");
                    File.WriteAllText(Application.StartupPath + "\\Config\\blueTheme.txt", "");
                }
                Theme.setTheme(Color.Blue);
            }
            else { File.Delete(Application.StartupPath + "\\Config\\blueTheme.txt"); }
        }
    }

    public class InputDialog : Form
    {
        private Label label;
        private TextBox textBox;
        private Button okButton;
        private Button cancelButton;
        public string UserInput { get; private set; }

        public InputDialog(string prompt)
        {
            // Initialize form components
            this.Text = "Input";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Label to show the prompt
            label = new Label
            {
                Text = prompt,
                Location = new System.Drawing.Point(15, 20),
                Width = 260
            };

            // TextBox to enter the input
            textBox = new TextBox
            {
                Location = new System.Drawing.Point(15, 50),
                Width = 260
            };

            // OK Button
            okButton = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new System.Drawing.Point(120, 90)
            };

            // Cancel Button
            cancelButton = new Button
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Location = new System.Drawing.Point(200, 90)
            };

            // Add controls to the form
            this.Controls.Add(label);
            this.Controls.Add(textBox);
            this.Controls.Add(okButton);
            this.Controls.Add(cancelButton);
        }

        public static string ShowDialog(string prompt)
        {
            using (var dialog = new InputDialog(prompt))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.textBox.Text;  // Return the input text
                }
                return string.Empty;  // If canceled, return an empty string
            }
        }
    }

    public class XboxController
    {
        private Controller controller;
        private bool isConnected;

        private int currentSelectionIndex;
        private List<PictureBox> gameImages;  // Store dynamically created game images
        private Panel MgameLibrary;
        public XboxController(Panel gameLibrary)
        {
            controller = new Controller(UserIndex.One); // Controller index 0 (first controller)
            isConnected = controller.IsConnected;

            //gameLibrary = gameLibrary;
            this.gameImages = new List<PictureBox>();

            // Retrieve all PictureBox controls from the gameLibrary panel
            foreach (Control control in gameLibrary.Controls)
            {
                if (control is PictureBox pictureBox)
                {
                    gameImages.Add(pictureBox);
                }
            }

            this.currentSelectionIndex = 0;  // Start with the first ImageBox
            MgameLibrary = gameLibrary;
        }

        public void Update()
        {
            if (isConnected)
            {
                try
                {
                    var state = controller.GetState();
                    HandleInput(state);
                }
                catch { }
                if (Form1.cState != true) { Form1.controllerStateElement.Image = Resources.ctrl_off; }
                else { Form1.controllerStateElement.Image = Resources.ctrl_on; }

            }
            else { }
        }

        public static bool hasPressed = false;
        private async void HandleInput(State state)
        {
            await Task.Delay(200);
            // Handle button presses
            

            // Example for joystick movement
            float leftX = state.Gamepad.LeftThumbX;
            float leftY = state.Gamepad.LeftThumbX;



            if (hasPressed == false && ControllerActive == true && Form1.cState == true)
            {
                // Move through ImageBoxes
                if (leftX < -20000)  // Joystick moved left
                {
                    hasPressed = true;
                    SelectPreviousImageBox();
                    // await Task.Delay(300);
                }
                else if (leftX > 20000)  // Joystick moved right
                {
                    hasPressed = true;
                    SelectNextImageBox();
                    // await Task.Delay(300);
                }
                // Handle D-Pad input (Up, Down, Left, Right)
                if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp))
                {
                    hasPressed = true;
                    SelectPreviousImageBox();  // Move up in the list of images
                  //  await Task.Delay(300);  // Delay between D-Pad presses to control speed
                    
                }
                else if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown))
                {
                    hasPressed = true;
                    SelectNextImageBox();  // Move down in the list of images
                   // await Task.Delay(300);  // Delay between D-Pad presses to control speed
                    
                }
                else if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft))
                {
                    hasPressed = true;
                    SelectPreviousImageBox();  // Move left (if applicable, depending on layout)
                 //   await Task.Delay(300);  // Delay between D-Pad presses to control speed
                    hasPressed = true;
                }
                else if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight))
                {
                    hasPressed = true;
                    SelectNextImageBox();  // Move right (if applicable, depending on layout)
                  //  await Task.Delay(300);  // Delay between D-Pad presses to control speed
                    hasPressed = true;
                }
                else if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder))
                {
                    hasPressed = true;
                    MgameLibrary.AutoScrollPosition = new Point(0, MgameLibrary.VerticalScroll.Value - 20);
                  //  await Task.Delay(300);  // Delay between D-Pad presses to control speed
                    hasPressed = true;
                }
                else if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder))
                {
                    hasPressed = true;
                    MgameLibrary.AutoScrollPosition = new Point(0, MgameLibrary.VerticalScroll.Value + 20);
                  //  await Task.Delay(300);  // Delay between D-Pad presses to control speed
                    hasPressed = true;
                }
                if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A))
                {
                    //MessageBox.Show("A Button Pressed!");
                    hasPressed = true;
                    TriggerButtonPress();
                }

                if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B))
                {
                    //MessageBox.Show("B Button Pressed!");
                    hasPressed = true;
                    TriggerButtonPress();
                }
            }
            await Task.Delay(1800);
            hasPressed = false;
           


        }

        public bool IsConnected()
        {
            return isConnected;
        }
        public static bool ControllerActive = true;
        private void TriggerButtonPress()
        {
            // Get the selected PictureBox
            var selectedImageBox = gameImages[currentSelectionIndex];

            // Safely invoke the Click event handler on the UI thread
            selectedImageBox.Invoke((MethodInvoker)(() =>
            {
                // Retrieve the stored game text file path from the Tag property
                var gameTextFilePath = selectedImageBox.Tag as string;

                if (!string.IsNullOrEmpty(gameTextFilePath))
                {
                    // Create a mock MouseEventArgs to simulate a left-click
                    var mouseEventArgs = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);

                    // Manually call the OnGameImageClick handler
                    Form1.OnGameImageClick(gameTextFilePath, selectedImageBox, mouseEventArgs);
                    ControllerActive = false;
                }
                else
                {
                    MessageBox.Show(selectedImageBox.Tag as string);
                }
            }));
        }


        private void SelectPreviousImageBox()
        {
            if (currentSelectionIndex > 0)
            {
                currentSelectionIndex--;
                FocusImageBox();
            }
        }

        private void SelectNextImageBox()
        {
            if (currentSelectionIndex < gameImages.Count - 1)
            {
                currentSelectionIndex++;
                FocusImageBox();
            }
        }

        private void FocusImageBox()
        {
            // Unfocus all previous selections (Optional visual feedback)
            foreach (var imgBox in gameImages)
            {
                imgBox.BorderStyle = BorderStyle.FixedSingle;  // Reset border style
            }

            // Focus the current selected ImageBox
            PictureBox focusedImageBox = gameImages[currentSelectionIndex];
            focusedImageBox.BorderStyle = BorderStyle.Fixed3D;  // Change border style to highlight it
        }
    }

    public class RoundedPanel : Panel
    {
        private int _borderRadius = 20; // You can adjust the border radius here

        public int BorderRadius
        {
            get => _borderRadius;
            set
            {
                _borderRadius = value;
                this.Invalidate(); // Repaint the panel when border radius changes
            }
        }

        public RoundedPanel()
        {
            // Set this property to ensure custom drawing happens.
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
        }

        protected override async void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.Invalidate(); // Repaint on resize to adjust the corners

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Create a rounded rectangle path
            using (GraphicsPath path = new GraphicsPath())
            {
                // Draw a rounded rectangle for the panel's client area
                path.AddArc(0, 0, _borderRadius, _borderRadius, 180, 90); // Top left corner
                path.AddArc(this.Width - _borderRadius - 1, 0, _borderRadius, _borderRadius, 270, 90); // Top right corner
                path.AddArc(this.Width - _borderRadius - 1, this.Height - _borderRadius - 1, _borderRadius, _borderRadius, 0, 90); // Bottom right corner
                path.AddArc(0, this.Height - _borderRadius - 1, _borderRadius, _borderRadius, 90, 90); // Bottom left corner
                path.CloseFigure();

                // Set the region of the panel to the rounded rectangle
                this.Region = new Region(path);

                // Fill the panel with a background color (optional)
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                // Optionally, draw a border with rounded corners
                using (Pen pen = new Pen(Color.FromArgb(43,43,43))) // You can change the border color here
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
    }
}
