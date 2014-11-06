using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ChartDirector;
using fractal.newClass;
using Fracture_Identification;
namespace Fracture_Identification
{
    public partial class mapForm : Form
    {
        public mapForm()
        {
            InitializeComponent();
        }
        public mapForm(int flag1)
        {
            InitializeComponent();
            flag = flag1;
        }
        private double minX = 0;
        private double maxX = 0;
        private double minY = 0;
        private double maxY = 0;
        public double[] x, y, z;//画图数据x,y,z
        private double[] xx, yy,ww;//新加散点数据
        private string[] zz;
        List<List<data3>> lld = new List<List<data3>>();
    //    private double[] xFault, yFault;
        // Internal variables to keep track of mouse positions during dragging of navigateWindow. 
        private int mouseDownXCoor;
        private int mouseDownYCoor;
        public int flag;
        public double MaxX, MinX, MaxY, MinY;//画图数据x,y最小值，最大值
        int xPix, yPix;
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
            //if ((MaxX - MinX) > (MaxY - MinY))
            //{
            //    xPix = 360;
            //    yPix = (int)((MaxY - MinY) * xPix / (MaxX - MinX));
            //}
            //else
            //{
            //    yPix = 360;
            //    xPix = (int)((MaxX - MinX) * yPix / (MaxY - MinY));
            //}
            //c.setPlotRegion(290, 235, xPix, yPix, 180);
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
            viewer.Chart = c;

        }
        public void createChart(WinChartViewer viewer)
        {
            /*int totalxp, totalyp;
            if ((MaxX - MinX) > (MaxY - MinY))
            {
                totalxp = 600;
                totalyp = (int)((MaxY - MinY) * totalxp / (MaxX - MinX));
            }
            else
            {
                totalyp = 500;
                totalxp = (int)((MaxX - MinX) * totalyp / (MaxY - MinY));
            }*/

            // Add a title to the chart using 15 points Arial Bold Italic font
            XYChart c1 = new XYChart(600, 500, Chart.brushedSilverColor(), 0x888888);
            c1.addTitle("等值线图      ", "Arial Bold Italic", 15);
         /*   if ((MaxX - MinX) > (MaxY - MinY))
            {
                xPix = 400;
                yPix = (int)((MaxY - MinY) * xPix / (MaxX - MinX));
            }
            else
            {
                yPix = 400;
                xPix = (int)((MaxX - MinX) * yPix / (MaxY - MinY));
            }*/
            c1.setPlotArea(75, 40, 400, 400, -1, -1, -1, c1.dashLineColor(
                unchecked((int)0x80000000), Chart.DotLine), -1);
            c1.setClipping();
            c1.xAxis().setTitle("X-Axis Title Place Holder", "Arial Bold Italic", 12);
            c1.yAxis().setTitle("Y-Axis Title Place Holder", "Arial Bold Italic", 12);
            c1.xAxis().setLabelStyle("Arial Bold");
            c1.yAxis().setLabelStyle("Arial Bold");
            c1.yAxis().setTickDensity(40);
            c1.xAxis().setTickDensity(40);
            ContourLayer layer = c1.addContourLayer(x, y, z);
            // Move the grid lines in front of the contour layer
            c1.getPlotArea().moveGridBefore(layer);

            // Add a color axis (the legend) in which the top left corner is anchored
            // at (505, 40). Set the length to 400 pixels and the labels on the right
            // side.
            ColorAxis cAxis = layer.setColorAxis(505, 40, Chart.TopLeft, 400, Chart.Right);

            // Add a title to the color axis using 12 points Arial Bold Italic font
            cAxis.setTitle("Color Legend Title Place Holder", "Arial Bold Italic", 12);

            // Set color axis labels to use Arial Bold font
            cAxis.setLabelStyle("Arial Bold");
            if (maxX == minX)
            {
                // The axis scale has not yet been set up. So this is the first time the chart is
                // drawn and it is drawn with no zooming. We can use auto-scaling to determine the
                // axis-scales, then remember them for future use. 

                // Explicitly auto-scale axes so we can get the axis scales
                c1.layout();

                // Save the axis scales for future use
                minX = c1.xAxis().getMinValue();
                maxX = c1.xAxis().getMaxValue();
                minY = c1.yAxis().getMinValue();
                maxY = c1.yAxis().getMaxValue();
            }
            else
            {
                // Compute the zoomed-in axis scales using the overall axis scales and ViewPort size
                double xScaleMin = minX + (maxX - minX) * viewer.ViewPortLeft;
                double xScaleMax = minX + (maxX - minX) * (viewer.ViewPortLeft +
                    viewer.ViewPortWidth);
                double yScaleMin = maxY - (maxY - minY) * (viewer.ViewPortTop +
                    viewer.ViewPortHeight);
                double yScaleMax = maxY - (maxY - minY) * viewer.ViewPortTop;
                //double yScaleMin = minY + (maxY - minY) * viewer.ViewPortLeft;
                //double yScaleMax = minY + (maxY - minY) * (viewer.ViewPortLeft +
                //    viewer.ViewPortWidth);
                // *** use the following formula if you are using a log scale axis ***
                // double xScaleMin = minX * Math.Pow(maxX / minX, viewer.ViewPortLeft);
                // double xScaleMax = minX * Math.Pow(maxX / minX, viewer.ViewPortLeft + 
                //	  viewer.ViewPortWidth);
                // double yScaleMin = maxY * Math.Pow(minY / maxY, viewer.ViewPortTop + 
                //	  viewer.ViewPortHeight);
                // double yScaleMax = maxY * Math.Pow(minY / maxY, viewer.ViewPortTop);

                // Set the axis scales
                c1.xAxis().setLinearScale(xScaleMin, xScaleMax);
                c1.xAxis().setRounding(false, false);
                c1.yAxis().setLinearScale(yScaleMin, yScaleMax);
                c1.yAxis().setRounding(false, false);
            }
            // Output the chart
            viewer.Chart = c1;
        }
        public void createChartAddsandian(WinChartViewer viewer)//等值线加井位图
        {
            /*int totalxp, totalyp;
            if ((MaxX - MinX) > (MaxY - MinY))
            {
                totalxp = 600;
                totalyp = (int)((MaxY - MinY) * totalxp / (MaxX - MinX));
            }
            else
            {
                totalyp = 500;
                totalxp = (int)((MaxX - MinX) * totalyp / (MaxY - MinY));
            }*/
            // Create a XYChart object of size 600 x 500 pixels
            XYChart c = new XYChart(600, 500, Chart.brushedSilverColor(), 0x888888);

            // Add a title to the chart using 15 points Arial Bold Italic font
            c.addTitle("等值线图      ", "Arial Bold Italic", 15);

            // Set the plotarea at (75, 40) and of size 400 x 400 pixels. Use
            // semi-transparent black (80000000) dotted lines for both horizontal and
            // vertical grid lines

            /*   if ((MaxX - MinX) > (MaxY - MinY))
               {
                   xPix = 400;
                   yPix = (int)((MaxY - MinY) * xPix / (MaxX - MinX));
               }
               else
               {
                   yPix = 400;
                   xPix = (int)((MaxX - MinX) * yPix / (MaxY - MinY));
               }*/
            c.setPlotArea(75, 40, 400, 400, -1, -1, -1, c.dashLineColor(
                unchecked((int)0x80000000), Chart.DotLine), -1);
            c.setClipping();
            // Set x-axis and y-axis title using 12 points Arial Bold Italic font
            c.xAxis().setTitle("X-Axis Title Place Holder", "Arial Bold Italic", 12);
            c.yAxis().setTitle("Y-Axis Title Place Holder", "Arial Bold Italic", 12);

            // Set x-axis and y-axis labels to use Arial Bold font
            c.xAxis().setLabelStyle("Arial Bold");
            c.yAxis().setLabelStyle("Arial Bold");
            // When auto-scaling, use tick spacing of 40 pixels as a guideline
            c.yAxis().setTickDensity(40);
            c.xAxis().setTickDensity(40);
            ScatterLayer layerdian1=c.addScatterLayer(xx, yy, "", Chart.CircleSymbol, 2, Chart.CircleSymbol);
            ScatterLayer layerdian = c.addScatterLayer(xx, yy, "",Chart.CircleSymbol, 4,unchecked((int)0x803333ff), unchecked((int)0x803333ff));//Chart.Cross2Shape(20.),x000000,unchecked((int)0xff3333), unchecked((int)0xff33330)
            layerdian.setSymbolScale(ww);
            layerdian1.addExtraField(zz);

             // Set the data label format to display the extra field
            layerdian1.setDataLabelFormat("{field0}");

            // Use 8pts Arial Bold to display the labels
            ChartDirector.TextBox textbox = layerdian1.setDataLabelStyle("Arial Bold", 6);

            // Set the background to purple with a 1 pixel 3D border
            textbox.setBackground(0xffffff, Chart.Transparent, 0);

            // Put the text box 4 pixels to the right of the data point
            textbox.setAlignment(Chart.Left);
            textbox.setPos(2, 0);


            // Add a contour layer using the given data
            // ContourLayer layer = c.addContourLayer(dataX, dataY, dataZ);
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
            if (maxX == minX)
            {
                // The axis scale has not yet been set up. So this is the first time the chart is
                // drawn and it is drawn with no zooming. We can use auto-scaling to determine the
                // axis-scales, then remember them for future use. 

                // Explicitly auto-scale axes so we can get the axis scales
                c.layout();

                // Save the axis scales for future use
                minX = c.xAxis().getMinValue();
                maxX = c.xAxis().getMaxValue();
                minY = c.yAxis().getMinValue();
                maxY = c.yAxis().getMaxValue();
            }
            else
            {
                // Compute the zoomed-in axis scales using the overall axis scales and ViewPort size
                double xScaleMin = minX + (maxX - minX) * viewer.ViewPortLeft;
                double xScaleMax = minX + (maxX - minX) * (viewer.ViewPortLeft +
                    viewer.ViewPortWidth);
                double yScaleMin = maxY - (maxY - minY) * (viewer.ViewPortTop +
                    viewer.ViewPortHeight);
                double yScaleMax = maxY - (maxY - minY) * viewer.ViewPortTop;
                // *** use the following formula if you are using a log scale axis ***
                // double xScaleMin = minX * Math.Pow(maxX / minX, viewer.ViewPortLeft);
                // double xScaleMax = minX * Math.Pow(maxX / minX, viewer.ViewPortLeft + 
                //	  viewer.ViewPortWidth);
                // double yScaleMin = maxY * Math.Pow(minY / maxY, viewer.ViewPortTop + 
                //	  viewer.ViewPortHeight);
                // double yScaleMax = maxY * Math.Pow(minY / maxY, viewer.ViewPortTop);

                // Set the axis scales
                c.xAxis().setLinearScale(xScaleMin, xScaleMax);
                c.xAxis().setRounding(false, false);
                c.yAxis().setLinearScale(yScaleMin, yScaleMax);
                c.yAxis().setRounding(false, false);
            }
            // Output the chart
            viewer.Chart = c;


         //   viewer.Image = c.makeImage();
        }
        public void createChartAddFault(WinChartViewer viewer)//等值线加断层线
        {
            XYChart c = new XYChart(600, 500, Chart.brushedSilverColor(), 0x888888);
            c.addTitle("等值线图      ", "Arial Bold Italic", 15);
            c.setPlotArea(75, 40, 400, 400, -1, -1, -1, c.dashLineColor(
                unchecked((int)0x80000000), Chart.DotLine), -1);
            c.setClipping();
            c.xAxis().setTitle("X-Axis Title Place Holder", "Arial Bold Italic", 12);
            c.yAxis().setTitle("Y-Axis Title Place Holder", "Arial Bold Italic", 12);
            c.xAxis().setLabelStyle("Arial Bold");
            c.yAxis().setLabelStyle("Arial Bold");

            for (int i = 0; i < lld.Count; i++)
            {
                List<double> dx = new List<double>();
                List<double> dy = new List<double>();
                for (int j = 0; j < lld[i].Count; j++)
                {
                    dx.Add(lld[i][j].xx);
                    dy.Add(lld[i][j].yy);
                }
                double[] dx1 = new double[dx.Count];
                double[] dy1 = new double[dy.Count];
                for (int k = 0; k < dx.Count; k++)
                {
                    dx1[k] = dx[k];
                    dy1[k] = dy[k];
                }
                LineLayer layer0 = c.addLineLayer2();
                layer0.addDataSet(dy1, 0x0033, "数据点");//.setDataSymbol(
                // Chart.GlassSphere2Shape, 11);
                layer0.setXData(dx1);
                layer0.setLineWidth(1);
            }
         

            c.yAxis().setTickDensity(40);
            c.xAxis().setTickDensity(40);

            ContourLayer layer = c.addContourLayer(x, y, z);
            c.getPlotArea().moveGridBefore(layer);
            ColorAxis cAxis = layer.setColorAxis(505, 40, Chart.TopLeft, 400, Chart.Right);
            cAxis.setTitle("Color Legend Title Place Holder", "Arial Bold Italic", 12);
            cAxis.setLabelStyle("Arial Bold");
   //         c.addScatterLayer(x, y, "数据点", Chart.Cross2Shape(0.2), 7, 0xff9933);
            if (maxX == minX)
            {

                c.layout();

                // Save the axis scales for future use
                minX = c.xAxis().getMinValue();
                maxX = c.xAxis().getMaxValue();
                minY = c.yAxis().getMinValue();
                maxY = c.yAxis().getMaxValue();
            }
            else
            {
                double xScaleMin = minX + (maxX - minX) * viewer.ViewPortLeft;
                double xScaleMax = minX + (maxX - minX) * (viewer.ViewPortLeft +
                    viewer.ViewPortWidth);
                double yScaleMin = maxY - (maxY - minY) * (viewer.ViewPortTop +
                    viewer.ViewPortHeight);
                double yScaleMax = maxY - (maxY - minY) * viewer.ViewPortTop;

                c.xAxis().setLinearScale(xScaleMin, xScaleMax);
                c.xAxis().setRounding(false, false);
                c.yAxis().setLinearScale(yScaleMin, yScaleMax);
                c.yAxis().setRounding(false, false);
            }
            // Output the chart
            viewer.Chart = c;
        }
        public void createAddSandianAndFault(WinChartViewer viewer)
        {
            XYChart c = new XYChart(600, 500, Chart.brushedSilverColor(), 0x888888);
            c.addTitle("等值线图      ", "Arial Bold Italic", 15);
            c.setPlotArea(75, 40, 400, 400, -1, -1, -1, c.dashLineColor(
                unchecked((int)0x80000000), Chart.DotLine), -1);
            c.setClipping();
            c.xAxis().setTitle("X-Axis Title Place Holder", "Arial Bold Italic", 12);
            c.yAxis().setTitle("Y-Axis Title Place Holder", "Arial Bold Italic", 12);
            c.xAxis().setLabelStyle("Arial Bold");
            c.yAxis().setLabelStyle("Arial Bold");
            ScatterLayer layerdian1 = c.addScatterLayer(xx, yy, "", Chart.CircleSymbol, 2, Chart.CircleSymbol);
            ScatterLayer layerdian = c.addScatterLayer(xx, yy, "", Chart.CircleSymbol, 4,unchecked((int)0x803333ff), unchecked((int)0x803333ff)); // Chart.GlassSphereShape,0xff3333, 0xff33330  c.addScatterLayer(xx, yy, "", Chart.Cross2Shape(0.2), 7, 0x000000);
            layerdian.setSymbolScale(ww);
            layerdian1.addExtraField(zz);

            // Set the data label format to display the extra field
            layerdian1.setDataLabelFormat("{field0}");

            // Use 8pts Arial Bold to display the labels
            ChartDirector.TextBox textbox = layerdian1.setDataLabelStyle("Arial Bold", 6);

            // Set the background to purple with a 1 pixel 3D border
            textbox.setBackground(0xffffff, Chart.Transparent, 0);

            // Put the text box 4 pixels to the right of the data point
            textbox.setAlignment(Chart.Top);
            textbox.setPos(2, 0);
            for (int i = 0; i < lld.Count; i++)
            {
                List<double> dx = new List<double>();
                List<double> dy = new List<double>();
                for (int j = 0; j < lld[i].Count; j++)
                {
                    dx.Add(lld[i][j].xx);
                    dy.Add(lld[i][j].yy);
                }
                double[] dx1 = new double[dx.Count];
                double[] dy1 = new double[dy.Count];
                for (int k = 0; k < dx.Count; k++)
                {
                    dx1[k] = dx[k];
                    dy1[k] = dy[k];
                }
                LineLayer layer0 = c.addLineLayer2();
                layer0.addDataSet(dy1, 0x0033, "数据点");//.setDataSymbol(
                // Chart.GlassSphere2Shape, 11);
                layer0.setXData(dx1);
                layer0.setLineWidth(1);
            }


            c.yAxis().setTickDensity(40);
            c.xAxis().setTickDensity(40);

            ContourLayer layer = c.addContourLayer(x, y, z);
            c.getPlotArea().moveGridBefore(layer);
            ColorAxis cAxis = layer.setColorAxis(505, 40, Chart.TopLeft, 400, Chart.Right);
            cAxis.setTitle("Color Legend Title Place Holder", "Arial Bold Italic", 12);
            cAxis.setLabelStyle("Arial Bold");
            //         c.addScatterLayer(x, y, "数据点", Chart.Cross2Shape(0.2), 7, 0xff9933);
            if (maxX == minX)
            {

                c.layout();

                // Save the axis scales for future use
                minX = c.xAxis().getMinValue();
                maxX = c.xAxis().getMaxValue();
                minY = c.yAxis().getMinValue();
                maxY = c.yAxis().getMaxValue();
            }
            else
            {
                double xScaleMin = minX + (maxX - minX) * viewer.ViewPortLeft;
                double xScaleMax = minX + (maxX - minX) * (viewer.ViewPortLeft +
                    viewer.ViewPortWidth);
                double yScaleMin = maxY - (maxY - minY) * (viewer.ViewPortTop +
                    viewer.ViewPortHeight);
                double yScaleMax = maxY - (maxY - minY) * viewer.ViewPortTop;

                c.xAxis().setLinearScale(xScaleMin, xScaleMax);
                c.xAxis().setRounding(false, false);
                c.yAxis().setLinearScale(yScaleMin, yScaleMax);
                c.yAxis().setRounding(false, false);
            }
            // Output the chart
            viewer.Chart = c;
        }
        public void createLineChart(WinChartViewer viewer)
        {
            XYChart c = new XYChart(600, 400);
            c.setBackground(c.linearGradientColor(0, 0, 0, 100, 0x99ccff, 0xffffff),
                0x888888);
            c.setRoundedFrame();
            c.setDropShadow();

            // Add a title using 18 pts Times New Roman Bold Italic font. #Set top
            // margin to 16 pixels.
            c.addTitle("Product Line Order Backlog", "Times New Roman Bold Italic",
                18).setMargin2(0, 0, 16, 0);

            // Set the plotarea at (60, 80) and of 510 x 275 pixels in size. Use
            // transparent border and dark grey (444444) dotted grid lines
            PlotArea plotArea = c.setPlotArea(60, 80, 510, 275, -1, -1,
                Chart.Transparent, c.dashLineColor(0x444444, 0x000101), -1);
            c.setClipping();
            // Add a legend box where the top-center is anchored to the horizontal
            // center of the plot area at y = 45. Use horizontal layout and 10 points
            // Arial Bold font, and transparent background and border.
            LegendBox legendBox = c.addLegend(plotArea.getLeftX() +
                plotArea.getWidth() / 2, 45, false, "Arial Bold", 10);
            legendBox.setAlignment(Chart.TopCenter);
            legendBox.setBackground(Chart.Transparent, Chart.Transparent);

            // Set x-axis tick density to 75 pixels and y-axis tick density to 30
            // pixels. ChartDirector auto-scaling will use this as the guidelines
            // when putting ticks on the x-axis and y-axis.
            c.yAxis().setTickDensity(30);
            c.xAxis().setTickDensity(75);

            // Set all axes to transparent
            c.xAxis().setColors(Chart.Transparent);
            c.yAxis().setColors(Chart.Transparent);

            // Set the x-axis margins to 15 pixels, so that the horizontal grid lines
            // can extend beyond the leftmost and rightmost vertical grid lines
            c.xAxis().setMargin(15, 15);

            // Set axis label style to 8pts Arial Bold
            c.xAxis().setLabelStyle("Arial Bold", 8);
            c.yAxis().setLabelStyle("Arial Bold", 8);
            c.yAxis2().setLabelStyle("Arial Bold", 8);

            // Add axis title using 10pts Arial Bold Italic font
            c.yAxis().setTitle("y值", "Arial Bold Italic", 10);

            // Add the first data series
            LineLayer layer0 = c.addLineLayer2();
            layer0.addDataSet(y, 0xff0000, "数据点").setDataSymbol(
                Chart.GlassSphere2Shape, 11);
            layer0.setXData(x);
            layer0.setLineWidth(3);
            if (maxX == minX)
            {
                c.layout();

                // Save the axis scales for future use
                minX = c.xAxis().getMinValue();
                maxX = c.xAxis().getMaxValue();
                minY = c.yAxis().getMinValue();
                maxY = c.yAxis().getMaxValue();
            }
            else
            {
                double xScaleMin = minX + (maxX - minX) * viewer.ViewPortLeft;
                double xScaleMax = minX + (maxX - minX) * (viewer.ViewPortLeft +
                    viewer.ViewPortWidth);
                double yScaleMin = maxY - (maxY - minY) * (viewer.ViewPortTop +
                    viewer.ViewPortHeight);
                double yScaleMax = maxY - (maxY - minY) * viewer.ViewPortTop;

                c.xAxis().setLinearScale(xScaleMin, xScaleMax);
                c.xAxis().setRounding(false, false);
                c.yAxis().setLinearScale(yScaleMin, yScaleMax);
                c.yAxis().setRounding(false, false);
            }
            SetMenuVisable(flag);
            viewer.Chart = c;

            //include tool tip for the chart
            //viewer.ImageMap = c.getHTMLImageMap("clickable", "",
            //    "title='Backlog of {dataSetName} at {x|mm/dd/yyyy}: US$ {value}M'");

        }
        public void createSanDianChart(WinChartViewer viewer)
        {
     
            XYChart c = new XYChart(650, 400);
            c.setBackground(c.linearGradientColor(0, 0, 0, 100, 0x99ccff, 0xffffff),
                0x888888);
            c.setRoundedFrame();
            c.setDropShadow();

            PlotArea plotArea = c.setPlotArea(100, 80, 510, 275, -1, -1,
                Chart.Transparent, c.dashLineColor(0x444444, 0x000101), -1);
            c.setClipping();
            LegendBox legendBox = c.addLegend(plotArea.getLeftX() +
               plotArea.getWidth() / 2, 45, false, "Arial Bold", 10);
            legendBox.setAlignment(Chart.TopCenter);
            legendBox.setBackground(Chart.Transparent, Chart.Transparent);
            // Add a title to the chart using 18 pts Times Bold Itatic font.
            c.addTitle("Genetically Modified Predator",
                "Times New Roman Bold Italic", 18);
            c.yAxis().setTickDensity(30);
            c.xAxis().setTickDensity(75);
            c.xAxis().setMargin(15, 15);
            // Add a title to the y axis using 12 pts Arial Bold Italic font
            c.yAxis().setTitle("y坐标", "Arial Bold Italic", 12);

            // Add a title to the x axis using 12 pts Arial Bold Italic font
            c.xAxis().setTitle("x坐标", "Arial Bold Italic", 12);

            // Set the axes line width to 3 pixels
            c.xAxis().setWidth(3);
            c.yAxis().setWidth(3);

            c.addScatterLayer(x, y, "数据点", Chart.Cross2Shape(0.2), 7, 0xff9933);
            if (maxX == minX)
            {

                c.layout();

                // Save the axis scales for future use
                minX = c.xAxis().getMinValue();
                maxX = c.xAxis().getMaxValue();
                minY = c.yAxis().getMinValue();
                maxY = c.yAxis().getMaxValue();
            }
            else
            {
                double xScaleMin = minX + (maxX - minX) * viewer.ViewPortLeft;
                double xScaleMax = minX + (maxX - minX) * (viewer.ViewPortLeft +
                    viewer.ViewPortWidth);
                double yScaleMin = maxY - (maxY - minY) * (viewer.ViewPortTop +
                    viewer.ViewPortHeight);
                double yScaleMax = maxY - (maxY - minY) * viewer.ViewPortTop;

                c.xAxis().setLinearScale(xScaleMin, xScaleMax);
                c.xAxis().setRounding(false, false);
                c.yAxis().setLinearScale(yScaleMin, yScaleMax);
                c.yAxis().setRounding(false, false);
            }
            // Output the chart
            SetMenuVisable(flag);
            viewer.Chart = c;

            //include tool tip for the chart
      //      viewer.ImageMap = c.getHTMLImageMap("clickable", "",
       //         "title='[{dataSetName}] Weight = {x} kg, Length = {value} cm'");
        }
        public void createRoseChart(WinChartViewer viewer)
        {
            // Create a PolarChart object of size 460 x 460 pixels, with a silver
            // background and a 1 pixel 3D border
            PolarChart c = new PolarChart(460, 460, Chart.silverColor(), 0x000000, 1)
                ;

            // Add a title to the chart at the top left corner using 15pts Arial Bold
            // Italic font. Use white text on deep blue background.
            c.addTitle("Polar Vector Chart Demonstration", "Arial Bold Italic", 15,
                0xffffff).setBackground(0x000080);

            // Set plot area center at (230, 240) with radius 180 pixels and white
            // background
            c.setPlotArea(230, 240, 180, 0xffffff);

            // Set the grid style to circular grid
            c.setGridStyle(false);

            // Set angular axis as 0 - 360, with a spoke every 30 units
            c.angularAxis().setLinearScale(0, 360, 30);

            // Add sectors to the chart as sector zones
            for (int i = 0; i < y.Length; ++i)
            {
                c.angularAxis().addZone(x[i], x[i] + 15, 0, y[i],
                    0x33ff33, 0x008000);
            }

            // Add an Transparent invisible layer to ensure the axis is auto-scaled
            // using the data
            c.addLineLayer(y, Chart.Transparent);
            SetMenuVisable(flag);
            viewer.Chart = c;       
        }
        private void SetMenuVisable(int sflag)
        {
            if (sflag==0||sflag == 4 || sflag == 5 || sflag == 6)
            {
                this.添加ToolStripMenuItem.Visible = true;
            }
            else
            {
                this.添加ToolStripMenuItem.Visible = false;
            }
        }
        private void mapForm_Load(object sender, EventArgs e)
        {
            if (flag == 0)
            {
              //  createChart(winChartViewer1);
                winChartViewer1.updateViewPort(true, true);
            }
            else if (flag == 1)
            {
                createSurfaceChart(winChartViewer1);
            }
            else if (flag == 2)
            {
                createLineChart(winChartViewer1);
            }
            else if (flag == 3)
            {
                createSanDianChart(winChartViewer1);
            }
            else
            {
                createRoseChart(winChartViewer1);
            }
        }

        private void winChartViewer1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void 井坐标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<DataStr4> ll = new List<DataStr4>();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt(XY)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<string> ls = new List<string>();
                System.IO.StreamReader str = null;
                try
                {
                    str = new System.IO.StreamReader(ofd.FileName);
                    while (!str.EndOfStream)
                    {
                        ls.Add(str.ReadLine());
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    ll.Clear();
                    string line = "";
                    DataStr4 dd = new DataStr4();
                    for (int i = 0; i < ls.Count; i++)
                    {
                        line = ls[i].Trim();
                        string[] splitStr = line.Split(' ', '\t');
                        dd.xx = Convert.ToDouble(splitStr[0]);
                        dd.yy = Convert.ToDouble(splitStr[1]);
                        dd.zz = Convert.ToString(splitStr[2]);
                        try
                        {
                            dd.ww = Convert.ToDouble(splitStr[3]);
                        }
                        catch
                        {
                            dd.ww = 0;
                        }
                        ll.Add(dd);
                    }
                    xx = new double[ll.Count];
                    yy = new double[ll.Count];
                    zz = new string[ll.Count];
                    ww = new double[ll.Count];
                    for (int i = 0; i < xx.Length; i++)
                    {
                        xx[i] = ll[i].xx;
                        yy[i] = ll[i].yy;
                        zz[i] = ll[i].zz;
                        ww[i] = ll[i].ww;
                    }
                    //      c1.addScatterLayer(x, y, "", Chart.Cross2Shape(0.2), 7, 0x000000);
                    //      winChartViewer1.Image = c1.makeImage();
                    //      Update(winChartViewer1);
                    if (flag != 5)
                    {
                        createChartAddsandian(winChartViewer1);
                        flag = 4;
                    }
                    if (flag == 5)
                    {
                        createAddSandianAndFault(winChartViewer1);
                        flag = 6;
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void 断层线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<data3> ll = new List<data3>();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt(XY)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                
                List<string> ls = new List<string>();
                System.IO.StreamReader str = null;
                try
                {
                    str = new System.IO.StreamReader(ofd.FileName);
                    while (!str.EndOfStream)
                    {
                        ls.Add(str.ReadLine());
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    ll.Clear();
                    string line = "";
                    data3 dd = new data3();
                    for (int i = 0; i < ls.Count; i++)
                    {
                        line = ls[i].Trim();
                        string[] splitStr = line.Split(' ', '\t');
                        dd.xx = Convert.ToDouble(splitStr[0]);
                        dd.yy = Convert.ToDouble(splitStr[1]);
                        dd.zz = Convert.ToDouble(splitStr[2]);
                        ll.Add(dd);
                    }
                    // xFault = new double[ll.Count];
                    // yFault = new double[ll.Count];
                    //for (int i = 0; i < xFault.Length; i++)
                    //{
                    //    xFault[i] = ll[i].xx;
                    //    yFault[i] = ll[i].yy;
                    //}
                    int len = 1;
                    List<double> li = new List<double>();
                    li.Add(ll[0].zz);
                    for (int i = 0; i < ll.Count - 1; i++)
                    {
                        if (ll[i].zz != ll[i + 1].zz)
                        {
                            len++; 
                            li.Add(ll[i + 1].zz);
                        }
                    }
                    for (int i = 0; i < len; i++)
                    {
                        List<data3> le = new List<data3>();
                        for (int j = 0; j < ll.Count; j++)
                        {
                            if (ll[j].zz == li[i])
                            {
                                le.Add(ll[j]);
                            }
                        }
                        lld.Add(le);
                    }              
                    if (flag != 4)
                    {
                        createChartAddFault(winChartViewer1);
                        flag = 5;
                    }
                    if (flag == 4)
                    {
                        createAddSandianAndFault(winChartViewer1);
                        flag = 6;
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pointerPB_CheckedChanged(object sender, EventArgs e)
        {
            pointerPB.BackColor = pointerPB.Checked ? Color.PaleGreen : pointerPB.Parent.BackColor;
            if (pointerPB.Checked)
            winChartViewer1.MouseUsage = WinChartMouseUsage.ScrollOnDrag;
        }

        private void zoomInPB_CheckedChanged(object sender, EventArgs e)
        {
            zoomInPB.BackColor = zoomInPB.Checked ? Color.PaleGreen : zoomInPB.Parent.BackColor;
            if (zoomInPB.Checked)
            winChartViewer1.MouseUsage = WinChartMouseUsage.ZoomIn;
        }

        private void zoomOutPB_CheckedChanged(object sender, EventArgs e)
        {
            zoomOutPB.BackColor = zoomOutPB.Checked ? Color.PaleGreen : zoomOutPB.Parent.BackColor;
            if (zoomOutPB.Checked)
            winChartViewer1.MouseUsage = WinChartMouseUsage.ZoomOut;
        }

        private void winChartViewer1_ViewPortChanged(object sender, WinViewPortEventArgs e)
        {
            if (!navigateWindow.Capture)
            {
                // We need to update the navigator window size and position only if the view port 
                // changes are not caused by the navigateWindow itself.
                navigateWindow.Left = (int)Math.Round(winChartViewer1.ViewPortLeft *
                    navigatePad.ClientSize.Width);
                navigateWindow.Top = (int)Math.Round(winChartViewer1.ViewPortTop *
                    navigatePad.ClientSize.Height);
                navigateWindow.Width = (int)Math.Max(1.0, winChartViewer1.ViewPortWidth *
                    navigatePad.ClientSize.Width);
                navigateWindow.Height = (int)Math.Max(1.0, winChartViewer1.ViewPortHeight *
                    navigatePad.ClientSize.Height);
            }

            // Synchronize the zoom bar value with the view port width/height
            zoomBar.Value = (int)Math.Round(Math.Min(winChartViewer1.ViewPortWidth,
                winChartViewer1.ViewPortHeight) * zoomBar.Maximum);

            // Update chart and image map if necessary
            if (e.NeedUpdateChart&&flag==0)
                createChart(winChartViewer1);
            else if (e.NeedUpdateChart && flag == 1)
            {
                createSurfaceChart(winChartViewer1);
            }
            else if(e.NeedUpdateChart&&flag==2)
            {
                createLineChart(winChartViewer1);
            }
            else if (e.NeedUpdateChart && flag == 3)
            {
                createSanDianChart(winChartViewer1);
            }
            else if (e.NeedUpdateChart && flag == 4)
            {
                createChartAddsandian(winChartViewer1);
            }
            else if (e.NeedUpdateChart && flag == 5)
            {
                createChartAddFault(winChartViewer1);
            }
            else if (e.NeedUpdateChart && flag == 6)
            {
                createAddSandianAndFault(winChartViewer1);
            }
            if (e.NeedUpdateImageMap&&flag==0)
               updateImageMap(winChartViewer1);
        }

        private void zoomBar_ValueChanged(object sender, EventArgs e)
        {
            //Remember the center point
            double centerX = winChartViewer1.ViewPortLeft + winChartViewer1.ViewPortWidth / 2;
            double centerY = winChartViewer1.ViewPortTop + winChartViewer1.ViewPortHeight / 2;

            //Aspect ratio and zoom factor
            double aspectRatio = winChartViewer1.ViewPortWidth / winChartViewer1.ViewPortHeight;
            double zoomTo = ((double)zoomBar.Value) / zoomBar.Maximum;

            //Zoom while respecting the aspect ratio
            winChartViewer1.ViewPortWidth = zoomTo * Math.Max(1, aspectRatio);
            winChartViewer1.ViewPortHeight = zoomTo * Math.Max(1, 1 / aspectRatio);

            //Adjust ViewPortLeft and ViewPortTop to keep center point unchanged
            winChartViewer1.ViewPortLeft = centerX - winChartViewer1.ViewPortWidth / 2;
            winChartViewer1.ViewPortTop = centerY - winChartViewer1.ViewPortHeight / 2;

            //update the chart, but no need to update the image map yet, as the chart is still 
            //zooming and is unstable
            winChartViewer1.updateViewPort(true, false);
        }

        private void navigateWindow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // Save the mouse coordinates to keep track of how far the navigateWindow has been 
                // dragged.
                mouseDownXCoor = e.X;
                mouseDownYCoor = e.Y;
            }
        }

        private void navigateWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // Is currently dragging - move the navigateWindow based on the distances dragged
                int newLabelLeft = Math.Max(0, navigateWindow.Left + e.X - mouseDownXCoor);
                int newLabelTop = Math.Max(0, navigateWindow.Top + e.Y - mouseDownYCoor);

                // Ensure the navigateWindow is within the navigatePad container
                if (newLabelLeft + navigateWindow.Width > navigatePad.ClientSize.Width)
                    newLabelLeft = navigatePad.ClientSize.Width - navigateWindow.Width;
                if (newLabelTop + navigateWindow.Height > navigatePad.ClientSize.Height)
                    newLabelTop = navigatePad.ClientSize.Height - navigateWindow.Height;

                // Update the navigateWindow position as it is being dragged
                navigateWindow.Left = newLabelLeft;
                navigateWindow.Top = newLabelTop;

                // Update the WinChartViewer ViewPort as well
                winChartViewer1.ViewPortLeft = ((double)navigateWindow.Left) /
                    navigatePad.ClientSize.Width;
                winChartViewer1.ViewPortTop = ((double)navigateWindow.Top) /
                    navigatePad.ClientSize.Height;

                // Update the chart, but no need to update the image map yet, as the chart is still 
                // scrolling and is unstable
                winChartViewer1.updateViewPort(true, false);
            }
        }

        private void winChartViewer1_ClickHotSpot(object sender, WinHotSpotEventArgs e)
        {
            // We show the pop up dialog only when the mouse action is not in zoom-in or zoom-out mode.
            if ((winChartViewer1.MouseUsage != WinChartMouseUsage.ZoomIn)
                && (winChartViewer1.MouseUsage != WinChartMouseUsage.ZoomOut))
                new FrmParameterView().Display(sender, e);
        }

        private void winChartViewer1_MouseEnter(object sender, EventArgs e)
        {
            updateImageMap(winChartViewer1);	
        }
        private void updateImageMap(WinChartViewer viewer)
        {
            // Include tool tip for the chart
            if (winChartViewer1.ImageMap == null)
            {
                //winChartViewer1.ImageMap = winChartViewer1.Chart.getHTMLImageMap("clickable", "",
                //    "title='[{dataSetName}] Alpha = {x}, Beta = {value}'");
                winChartViewer1.ImageMap = winChartViewer1.Chart.getHTMLImageMap("clickable", "", "title='(x, y)=({x},{value})'");
            }
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createChart(winChartViewer1);
            flag = 0;
        }
    }
}
