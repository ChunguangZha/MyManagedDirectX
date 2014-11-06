using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fractal.newClass;
using ChartDirector;
namespace fractal
{
    public partial class ContourPicture : Form
    {
        public ContourPicture()
        {
            InitializeComponent();
        }
        public ContourPicture(int flag1)
        {
            InitializeComponent();
            flag = flag1;
        }
        public double[] x, y, z;
        public int flag;
        public void createSurfaceChart(WinChartViewer viewer)
        {
         
            SurfaceChart c = new SurfaceChart(680, 550, Chart.brushedSilverColor(), 0x888888)
       ;
            c.setRoundedFrame(0xffffff, 20, 0, 20, 0);

            // Add a title to the chart using 20 points Times New Roman Italic font. Set
            // top/bottom margin to 8 pixels.
            ChartDirector.TextBox title = c.addTitle(
                "Surface Created Using Scattered Data Points", "Times New Roman Italic", 20);
            title.setMargin2(0, 0, 8, 8);

            // Add a 2 pixel wide black (000000) separator line under the title
            c.addLine(10, title.getHeight(), c.getWidth() - 10, title.getHeight(), 0x000000,
                2);

            // Set the center of the plot region at (290, 235), and set width x depth x
            // height to 360 x 360 x 180 pixels
            c.setPlotRegion(290, 235, 360, 360, 180);

            // Set the elevation and rotation angles to 45 and -45 degrees
            c.setViewAngle(45, -45);

            // Set the perspective level to 30
            c.setPerspective(30);

            // Set the data to use to plot the chart
            c.setData(x, y, z);

            // Add a color axis (the legend) in which the top right corner is anchored at
            // (660, 80). Set the length to 200 pixels and the labels on the right side.
            ColorAxis cAxis = c.setColorAxis(660, 80, Chart.TopRight, 200, Chart.Right);

            // Set the color axis title with 12 points Arial Bold font
            cAxis.setTitle("Z Title Placeholder", "Arial Bold", 12);

            // Add a bounding box with light grey (eeeeee) background and grey (888888)
            // border. Set the top-left and bottom-right corners to rounded corners of  10
            // pixels radius.
            cAxis.setBoundingBox(0xeeeeee, 0x888888);
            cAxis.setRoundedCorners(10, 0, 10, 0);

            // Set surface grid lines to semi-transparent black (cc000000)
            c.setSurfaceAxisGrid(unchecked((int)0xcc000000));

            // Set contour lines to semi-transparent white (80ffffff)
            c.setContourColor(unchecked((int)0x80ffffff));

            // Set the walls to black in color
            c.setWallColor(0x000000);

            // Set the xyz major wall grid lines to white (ffffff), and minor wall grid lines
            // to grey (888888)
            c.setWallGrid(0xffffff, 0xffffff, 0xffffff, 0x888888, 0x888888, 0x888888);

            // Set the wall thickness to 0
            c.setWallThickness(0, 0, 0);

            // Show only the xy wall, and hide the yz and zx walls.
            c.setWallVisibility(true, false, false);

            // Set the x, y and z axis titles using 12 points Arial Bold font
            c.xAxis().setTitle("X Title\nPlaceholder", "Arial Bold", 12);
            c.yAxis().setTitle("Y Title\nPlaceholder", "Arial Bold", 12);

            // Output the chart
            viewer.Image = c.makeImage();

        }
        public void createChart(WinChartViewer viewer)
        {
            // Create a XYChart object of size 600 x 500 pixels
            XYChart c = new XYChart(600, 500, Chart.brushedSilverColor(), 0x888888);

            // Add a title to the chart using 15 points Arial Bold Italic font
            c.addTitle("等值线图      ", "Arial Bold Italic", 15);

            // Set the plotarea at (75, 40) and of size 400 x 400 pixels. Use
            // semi-transparent black (80000000) dotted lines for both horizontal and
            // vertical grid lines
            c.setPlotArea(75, 40, 400, 400, -1, -1, -1, c.dashLineColor(
                unchecked((int)0x80000000), Chart.DotLine), -1);

            // Set x-axis and y-axis title using 12 points Arial Bold Italic font
            c.xAxis().setTitle("X-Axis Title Place Holder", "Arial Bold Italic", 12);
            c.yAxis().setTitle("Y-Axis Title Place Holder", "Arial Bold Italic", 12);

            // Set x-axis and y-axis labels to use Arial Bold font
            c.xAxis().setLabelStyle("Arial Bold");
            c.yAxis().setLabelStyle("Arial Bold");

            // When auto-scaling, use tick spacing of 40 pixels as a guideline
            c.yAxis().setTickDensity(40);
            c.xAxis().setTickDensity(40);

            // Add a contour layer using the given data
            // ContourLayer layer = c.addContourLayer(dataX, dataY, dataZ);
            //      c.addScatterLayer(x, y, "", Chart.Cross2Shape(0.2), 7, 0x000000);
            ContourLayer layer = c.addContourLayer(x, y, z);
            // Move the grid lines in front of the contour layer
            c.getPlotArea().moveGridBefore(layer);

            // Add a color axis (the legend) in which the top left corner is anchored
            // at (505, 40). Set the length to 400 pixels and the labels on the right
            // side.
            ColorAxis cAxis = layer.setColorAxis(505, 40, Chart.TopLeft, 400, Chart.Right);

            // Add a title to the color axis using 12 points Arial Bold Italic font
            cAxis.setTitle("Color Legend Title Place Holder", "Arial Bold Italic", 12);

            // Set color axis labels to use Arial Bold font
            cAxis.setLabelStyle("Arial Bold");

            // Output the chart
            viewer.Image = c.makeImage();
        }
        private void ContourPicture_Load(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                createSurfaceChart(winChartViewer1);
            }
            else
            {
                createChart(winChartViewer1);
                this.Width = 675;
                this.Height = 575;
               
            }
        }

        private void ContourPicture_FormClosed(object sender, FormClosedEventArgs e)
        {
            fractalF fra = (fractalF)(this.Owner);
            fra.k = 0;
            fra.l = 0;
        }
    }
}
