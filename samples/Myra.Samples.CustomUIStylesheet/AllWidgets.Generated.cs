/* Generated by MyraPad at 12/6/2023 3:31:56 AM */
using Myra;
using Myra.Graphics2D;
using Myra.Graphics2D.TextureAtlases;
using Myra.Graphics2D.UI;
using Myra.Graphics2D.Brushes;
using Myra.Graphics2D.UI.Properties;
using FontStashSharp.RichText;
using AssetManagementBase;

#if STRIDE
using Stride.Core.Mathematics;
#elif PLATFORM_AGNOSTIC
using System.Drawing;
using System.Numerics;
using Color = FontStashSharp.FSColor;
#else
// MonoGame/FNA
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endif

namespace Myra.Samples.CustomUIStylesheet
{
	partial class AllWidgets: HorizontalSplitPane
	{
		private void BuildUI()
		{
			var label1 = new Label();
			label1.Text = "Button:";

			_image = new Image();
			_image.Id = "_image";

			var label2 = new Label();
			label2.Text = "Button";

			var horizontalStackPanel1 = new HorizontalStackPanel();
			horizontalStackPanel1.Widgets.Add(_image);
			horizontalStackPanel1.Widgets.Add(label2);

			_button = new Button();
			_button.Id = "_button";
			Grid.SetColumn(_button, 1);
			_button.Content = horizontalStackPanel1;

			_textButtonLabel = new Label();
			_textButtonLabel.Text = "Text Button:";
			_textButtonLabel.Id = "_textButtonLabel";
			Grid.SetRow(_textButtonLabel, 1);

			var label3 = new Label();
			label3.Text = "Button 2";

			_textButton = new Button();
			_textButton.Id = "_textButton";
			Grid.SetColumn(_textButton, 1);
			Grid.SetRow(_textButton, 1);
			_textButton.Content = label3;

			var label4 = new Label();
			label4.Text = "Image Button:";
			Grid.SetRow(label4, 2);

			var image1 = new Image();

			_imageButton = new Button();
			_imageButton.Id = "_imageButton";
			Grid.SetColumn(_imageButton, 1);
			Grid.SetRow(_imageButton, 2);
			_imageButton.Content = image1;

			var label5 = new Label();
			label5.Text = "This is checkbox";

			var checkButton1 = new CheckButton();
			Grid.SetRow(checkButton1, 3);
			Grid.SetColumnSpan(checkButton1, 2);
			checkButton1.Content = label5;

			var label6 = new Label();
			label6.Text = "Horizontal Slider:";
			Grid.SetRow(label6, 4);

			var horizontalSlider1 = new HorizontalSlider();
			Grid.SetColumn(horizontalSlider1, 1);
			Grid.SetRow(horizontalSlider1, 4);

			var label7 = new Label();
			label7.Text = "Combo View:";
			Grid.SetRow(label7, 5);

			var label8 = new Label();
			label8.Text = "Red";
			label8.TextColor = Color.Red;

			var label9 = new Label();
			label9.Text = "Green";
			label9.TextColor = Color.Lime;

			var label10 = new Label();
			label10.Text = "Blue";
			label10.TextColor = Color.Blue;

			var comboView1 = new ComboView();
			comboView1.Width = 200;
			Grid.SetColumn(comboView1, 1);
			Grid.SetRow(comboView1, 5);
			comboView1.Widgets.Add(label8);
			comboView1.Widgets.Add(label9);
			comboView1.Widgets.Add(label10);

			var label11 = new Label();
			label11.Text = "Text Field:";
			Grid.SetRow(label11, 6);

			var textBox1 = new TextBox();
			Grid.SetColumn(textBox1, 1);
			Grid.SetRow(textBox1, 6);

			var label12 = new Label();
			label12.Text = "List View:";
			Grid.SetRow(label12, 7);

			var label13 = new Label();
			label13.Text = "Red";
			label13.TextColor = Color.Red;

			var label14 = new Label();
			label14.Text = "Green";
			label14.TextColor = Color.Lime;

			var label15 = new Label();
			label15.Text = "Blue";
			label15.TextColor = Color.Blue;

			var listView1 = new ListView();
			listView1.Width = 200;
			Grid.SetColumn(listView1, 1);
			Grid.SetRow(listView1, 7);
			listView1.Widgets.Add(label13);
			listView1.Widgets.Add(label14);
			listView1.Widgets.Add(label15);

			var label16 = new Label();
			label16.Text = "Tree";
			Grid.SetRow(label16, 8);

			_gridRight = new Grid();
			_gridRight.ColumnSpacing = 8;
			_gridRight.RowSpacing = 8;
			_gridRight.DefaultRowProportion = new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Auto,
			};
			_gridRight.ColumnsProportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Auto,
			});
			_gridRight.ColumnsProportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Fill,
			});
			_gridRight.Id = "_gridRight";
			_gridRight.Widgets.Add(label1);
			_gridRight.Widgets.Add(_button);
			_gridRight.Widgets.Add(_textButtonLabel);
			_gridRight.Widgets.Add(_textButton);
			_gridRight.Widgets.Add(label4);
			_gridRight.Widgets.Add(_imageButton);
			_gridRight.Widgets.Add(checkButton1);
			_gridRight.Widgets.Add(label6);
			_gridRight.Widgets.Add(horizontalSlider1);
			_gridRight.Widgets.Add(label7);
			_gridRight.Widgets.Add(comboView1);
			_gridRight.Widgets.Add(label11);
			_gridRight.Widgets.Add(textBox1);
			_gridRight.Widgets.Add(label12);
			_gridRight.Widgets.Add(listView1);
			_gridRight.Widgets.Add(label16);

			var scrollViewer1 = new ScrollViewer();
			scrollViewer1.ShowHorizontalScrollBar = false;
			scrollViewer1.Content = _gridRight;

			var label17 = new Label();
			label17.Text = "Vertical Slider:";

			var verticalSlider1 = new VerticalSlider();
			verticalSlider1.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Center;
			Grid.SetRow(verticalSlider1, 1);

			var grid1 = new Grid();
			grid1.RowSpacing = 8;
			grid1.ColumnsProportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Fill,
			});
			grid1.RowsProportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Auto,
			});
			grid1.RowsProportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Fill,
			});
			grid1.Widgets.Add(label17);
			grid1.Widgets.Add(verticalSlider1);

			var label18 = new Label();
			label18.Text = "Progress Bars:";

			_horizontalProgressBar = new HorizontalProgressBar();
			_horizontalProgressBar.Id = "_horizontalProgressBar";
			Grid.SetRow(_horizontalProgressBar, 1);

			_verticalProgressBar = new VerticalProgressBar();
			_verticalProgressBar.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Center;
			_verticalProgressBar.Id = "_verticalProgressBar";
			Grid.SetRow(_verticalProgressBar, 2);

			var grid2 = new Grid();
			grid2.RowSpacing = 8;
			grid2.ColumnsProportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Fill,
			});
			grid2.RowsProportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Auto,
			});
			grid2.RowsProportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Auto,
			});
			grid2.RowsProportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Fill,
			});
			grid2.Widgets.Add(label18);
			grid2.Widgets.Add(_horizontalProgressBar);
			grid2.Widgets.Add(_verticalProgressBar);

			var verticalSplitPane1 = new VerticalSplitPane();
			verticalSplitPane1.Widgets.Add(grid1);
			verticalSplitPane1.Widgets.Add(grid2);

			
			Widgets.Add(scrollViewer1);
			Widgets.Add(verticalSplitPane1);
		}

		
		public Image _image;
		public Button _button;
		public Label _textButtonLabel;
		public Button _textButton;
		public Button _imageButton;
		public Grid _gridRight;
		public HorizontalProgressBar _horizontalProgressBar;
		public VerticalProgressBar _verticalProgressBar;
	}
}
