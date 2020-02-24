/// <summary>
/// SeePixelDimensions
/// Quick way to see what dimensions a window is
/// /// as you resize it. Hands-on method of getting a feel
/// /// for what dimensions you need various elements to be
/// /// for GUI design.
/// Functions are separated into namespaces for simpler
/// /// separation into a class hierarchy.
/// </summary>

using System;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
using MainWindowSpace;
using DimensionsLabel;
using OnlyPanel;

namespace MainWindowSpace 
{
/// <summary>
/// The main window upon which every panel is drawn.
/// </summary>
    public class MainWindw : Form 
    {
/// <summary>
/// Create the window using default dimensions.
/// </summary>
        private void CreateWindw() 
        {
            // Create the main window.
            // Inheriting properties from parent class Form,
            // // so no need to put xxx.Text or anything
            Text = "See Pixel Dimensions";
            Width = 1100; //Window's starting width
            Height = 800; //Window's starting height
            AutoSize = false;

            PutPanel();

            this.SizeChanged += new EventHandler(this.WinSizeChanged);
        }

/// <summary>
/// Set up Event Handler for when user changes the window size.
/// </summary>
/// <param name="sender">
/// Source of the event.
/// </param>
/// <param name="e">
/// Object with no event data.
/// </param>
        private void WinSizeChanged(object sender, System.EventArgs e)
        {
            
            PutPanel();
            
        }
        
/// <summary>
/// Create a panel upon which to draw the dimensions of the window.
/// </summary>
        private void PutPanel() 
        {
            Controls.Clear();

            MainPanel mainPanel = new MainPanel();
            mainPanel.DrawPanel(Width, Height);
            
            Controls.Add(mainPanel);               
        }
        
/// <summary>
/// Draw the window.
/// </summary>
        public void DrawWindow()
        {
            CreateWindw();
        }

    }
}

namespace OnlyPanel
{
/// <summary>
/// Define the panel.
/// </summary>
    public class MainPanel : Panel
    {
    
/// <summary>
/// Draw the panel depending on the size of the parent window.
/// </summary>
/// <param name="parentWindowWidth">
/// Width of the parent window upon which the panel will be drawn.
/// </param>
/// <param name="parentWindowHeight">
/// Height of the parent window upon which the panel will be drawn.
/// </param>
        public void DrawPanel(int parentWindowWidth, int parentWindowHeight)
        {
            Width = parentWindowWidth;
            Height = parentWindowHeight;

            BorderStyle = BorderStyle.FixedSingle;

            //Loop PutLabel as long as window is open
            PutLabel();

            this.SizeChanged += new EventHandler(this.PanelSizeChanged);
        }

/// <summary>
/// Change the dimensions written on the panel when panel size changes.
/// </summary>
/// <param name="sender">
/// Source of the event.
/// </param>
/// <param name="e">
/// Object with no event data.
/// </param>
        private void PanelSizeChanged(object sender, System.EventArgs e)
        {
            PutLabel();
        }

/// <summary>
/// Write the dimensions of the panel onto the panel.
/// </summary>
        private void PutLabel() 
        {
            Controls.Clear();

            DimLabel dimLabel = new DimLabel();
            dimLabel.DrawLabel(Width, Height);
            
            Controls.Add(dimLabel);
                        
        }

    }
}

namespace DimensionsLabel 
{
/// <summary>
/// Define what dimensions will be displayed within the window.
/// </summary>

    public class DimLabel : Label 
    {
    
/// <summary>
/// Define what numbers the label will say in the panel.
/// </summary>
/// <param name="parentWindowWidth">
/// Width of the parent window upon which the panel will be drawn.
/// </param>
/// <param name="parentWindowHeight">
/// Height of the parent window upon which the panel will be drawn.
/// </param>
        public void DrawLabel(int parentWindowWidth, int parentWindowHeight)
        {
            BorderStyle = BorderStyle.FixedSingle;
            Location = new Point((parentWindowWidth/2 - (Width/2)), (parentWindowHeight/2) - (Height/2));
            AutoSize = true;

            Text = "Window Size: (" + parentWindowWidth + ", " + parentWindowHeight + ")";
        }
    
    } 
}

namespace Main 
{
/// <summary>
/// Where the program is executed.
/// </summary>
	public class ExecuteWindow 
    {
    
/// <summary>
/// Creates and draws the final window.
/// </summary>
		public static void Main(string[] args) 
        {
			// Start up the window.
			MainWindw mw = new MainWindw();
            mw.DrawWindow();
            mw.ShowDialog();
		}

	}
}