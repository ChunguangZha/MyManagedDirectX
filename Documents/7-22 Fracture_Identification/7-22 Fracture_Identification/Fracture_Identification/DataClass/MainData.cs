using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fractal.newClass;
using ChartDirector;
using System.Windows.Forms;

namespace Fracture_Identification
{
    class MainData
    {
        private double minX = 0;
        private double maxX = 0;
        private double minY = 0;
        private double maxY = 0;
        public int NX, NY;
        public LayerDataClass layerData = null;
        private List<data3> layerDataandBoundary = new List<data3>();
        public WellDataClass wellData = null;
        public FaultDataClass faultData = null;
        public RoseDataClass RoseData = null;
        public List<data3> boundarydata = null;//原始边界数据
        public bool bDisplayLayerdata = false;
        public bool bDisplayfaultdata = false;
        public bool bDisplayWelldata = false;
        public bool bDisplayRosedata = false;
        public bool bDisplayBoundarydata = false;

        double MaxX, MinX, MaxY, MinY;
        public List<data3> minCur = new List<data3>();//最小主曲率
        public List<data3> maxCur = new List<data3>();//最大主曲率

        public double E, v, thickness;//构造应力算法参数
        public List<data3> minStress = new List<data3>();//最小主应力
        public List<data3> maxStress = new List<data3>();//最大主应力
        public List<data3> maxShear = new List<data3>();//最大剪应力
        //public data3 faultData = new data3();
        double[] x, y, z;//地层数据
        public void DisplayLayer(WinChartViewer viewer)
        {  
            //if (layerData == null)
            //{
            //    return;
            //}   
            if (layerData == null || layerData.Datalist.Count < 1)
            {
                return;
            }
            layerDataandBoundary.Clear();
            data3 dd = new data3();
            for (int i = 0; i < layerData.Datalist.Count; i++)
            {
                dd.xx = layerData.Datalist[i].xx;
                dd.yy = layerData.Datalist[i].yy;
                dd.zz = layerData.Datalist[i].zz;
                layerDataandBoundary.Add(dd);
            }
            if (boundarydata != null && bDisplayBoundarydata)
            {
                layerDataandBoundary = WGinCurve(layerDataandBoundary, boundarydata);
            }

            x = new double[layerDataandBoundary.Count];
            y = new double[layerDataandBoundary.Count];
            z = new double[layerDataandBoundary.Count];

            for (int i = 0; i < layerDataandBoundary.Count; i++)
            {                
                x[i] = layerDataandBoundary[i].xx;
                y[i] = layerDataandBoundary[i].yy;
                z[i] = layerDataandBoundary[i].zz;
            }

            if (wellData != null)
            {
                for (int i = 0; i < wellData.bDisplay.Count; i++)
                {
                    if (wellData.bDisplay[i] == true)
                    {
                        bDisplayWelldata = true;
                        break;
                    }
                }
            }
            if (faultData != null)
            {
                for (int i = 0; i < faultData.bDisplay.Count; i++)
                {
                    if (faultData.bDisplay[i] == true)
                    {
                        bDisplayfaultdata = true;
                        break;
                    }
                }
            }

            if (bDisplayLayerdata && bDisplayWelldata&&bDisplayfaultdata)
            {
                createAddSandianAndFault(viewer); return;
            }
            else if (bDisplayLayerdata && bDisplayWelldata)
            {
                createChartAddsandian(viewer); return;
            }
            else if (bDisplayLayerdata && bDisplayfaultdata)
            {
                createChartAddFault(viewer); return;
            }
            else if (bDisplayLayerdata)
            {
                createChart(viewer); return;
            }
            else if (bDisplayRosedata)
            {
                createRoseChart(viewer);
            }
            else
            {
                createDefaultChart(viewer);
            }
        }
        public void createSurfaceChart(WinChartViewer viewer)
        {
            //List<int> indexofdisplaywells = new List<int>();
            //for (int i = 0; i < wellData.bDisplay.Count; i++)
            //{
            //    if (wellData.bDisplay[i])
            //    {
            //        indexofdisplaywells.Add(i);
            //    }
            //}
            //double[] xx = new double[indexofdisplaywells.Count];
            //double[] yy = new double[indexofdisplaywells.Count];

            //for (int i = 0; i < indexofdisplaywells.Count; i++)
            //{
            //    xx[i] = wellData.DataList[indexofdisplaywells[i]].xx;
            //    yy[i] = wellData.DataList[indexofdisplaywells[i]].yy;
            //}

            SurfaceChart c = new SurfaceChart(680, 550, Chart.brushedSilverColor(), 0x888888);

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

      
            c.setWallVisibility(true, false, false);
            c.xAxis().setTitle("X Title\nPlaceholder", "Arial Bold", 12);
            c.yAxis().setTitle("Y Title\nPlaceholder", "Arial Bold", 12);
         
            viewer.Chart = c;

        }
        public void createDefaultChart(WinChartViewer viewer)
        {
            XYChart c1 = new XYChart(600, 500, Chart.brushedSilverColor(), 0x888888);
            c1.addTitle("画图      ", "Arial Bold Italic", 15);
            c1.setPlotArea(75, 40, 400, 400, -1, -1, -1, c1.dashLineColor(
                unchecked((int)0x80000000), Chart.DotLine), -1);
            c1.setClipping();
            c1.xAxis().setTitle("X-Axis Title Place Holder", "Arial Bold Italic", 12);
            c1.yAxis().setTitle("Y-Axis Title Place Holder", "Arial Bold Italic", 12);
            c1.xAxis().setLabelStyle("Arial Bold");
            c1.yAxis().setLabelStyle("Arial Bold");
            c1.yAxis().setTickDensity(40);
            c1.xAxis().setTickDensity(40);
            viewer.Chart = c1;
        }
        public void createRoseChart(WinChartViewer viewer)
        {
            double[] xx = new double[RoseData.Datalist.Count];
            double[] yy = new double[RoseData.Datalist.Count];
            for (int i = 0; i < RoseData.Datalist.Count; i++)
            {
                xx[i] = RoseData.Datalist[i].xx;
                yy[i] = RoseData.Datalist[i].yy;
            }
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
            for (int i = 0; i < yy.Length; ++i)
            {
                c.angularAxis().addZone(xx[i], xx[i] + 15, 0, yy[i],
                    0x33ff33, 0x008000);
            }

            // Add an Transparent invisible layer to ensure the axis is auto-scaled
            // using the data
            c.addLineLayer(yy, Chart.Transparent);
            viewer.Chart = c;
        }
        public void createChart(WinChartViewer viewer)
        {
            List<double> xx = new List<double>();
            List<double> yy = new List<double>();

            //x = new double[layerDataandBoundary.Count];
            //y = new double[layerDataandBoundary.Count];
            //z = new double[layerDataandBoundary.Count];

            for (int i = 0; i < layerDataandBoundary.Count; i++)
            {
                xx.Add(layerDataandBoundary[i].xx);
                yy.Add(layerDataandBoundary[i].yy);
                //x[i] = layerDataandBoundary[i].xx;
                //y[i] = layerDataandBoundary[i].yy;
                //z[i] = layerDataandBoundary[i].zz;
            }
            XYChart c1 = new XYChart(600, 500, Chart.brushedSilverColor(), 0x888888);
            c1.addTitle("等值线图      ", "Arial Bold Italic", 15);
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
                c1.xAxis().setLinearScale(xScaleMin, xScaleMax);
                c1.xAxis().setRounding(false, false);
                c1.yAxis().setLinearScale(yScaleMin, yScaleMax);
                c1.yAxis().setRounding(false, false);
            }
            viewer.Chart = c1;
        }
        public void createChartAddsandian(WinChartViewer viewer)//等值线加井位图
        {
            //double[] xx = new double[wellData.DataList.Count];
            //double[] yy = new double[wellData.DataList.Count];
            //string[] zz = new string[wellData.DataList.Count];
            //double[] ww = new double[wellData.DataList.Count];            
            List<int> indexofdisplaywells = new List<int>();
            for (int i = 0; i < wellData.bDisplay.Count; i++)
            {
                if (wellData.bDisplay[i])
                {
                    indexofdisplaywells.Add(i);
                }
            }
            double[] xx = new double[indexofdisplaywells.Count];
            double[] yy = new double[indexofdisplaywells.Count];
            string[] zz = new string[indexofdisplaywells.Count]; 
            double[] ww = new double[indexofdisplaywells.Count];
            for (int i = 0; i < indexofdisplaywells.Count; i++)
            {
                xx[i] = wellData.DataList[indexofdisplaywells[i]].xx;
                yy[i] = wellData.DataList[indexofdisplaywells[i]].yy;
                zz[i] = wellData.DataList[indexofdisplaywells[i]].zz;
                ww[i] = wellData.DataList[indexofdisplaywells[i]].ww;               
            }
            XYChart c = new XYChart(600, 500, Chart.brushedSilverColor(), 0x888888);
            c.addTitle("等值线图      ", "Arial Bold Italic", 15);
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
            ScatterLayer layerdian1 = c.addScatterLayer(xx, yy, "", Chart.CircleSymbol, 2, Chart.CircleSymbol);
            ScatterLayer layerdian = c.addScatterLayer(xx, yy, "", Chart.CircleSymbol, 4, unchecked((int)0x803333ff), unchecked((int)0x803333ff));//Chart.Cross2Shape(20.),x000000,unchecked((int)0xff3333), unchecked((int)0xff33330)
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
                c.xAxis().setLinearScale(xScaleMin, xScaleMax);
                c.xAxis().setRounding(false, false);
                c.yAxis().setLinearScale(yScaleMin, yScaleMax);
                c.yAxis().setRounding(false, false);
            }
            // Output the chart
            viewer.Chart = c;


            //   viewer.Image = c.makeImage();
        }
        public void createAddSandianAndFault(WinChartViewer viewer)
        {
            //double[] xx = new double[wellData.DataList.Count];
            //double[] yy = new double[wellData.DataList.Count];
            //string[] zz = new string[wellData.DataList.Count];
            //double[] ww = new double[wellData.DataList.Count];
            //for (int i = 0; i < xx.Length; i++)
            //{
            //    xx[i] = wellData.DataList[i].xx;
            //    yy[i] = wellData.DataList[i].yy;
            //    zz[i] = wellData.DataList[i].zz;
            //    ww[i] = wellData.DataList[i].ww;
            //}
            List<int> indexofdisplaywells = new List<int>();
            for (int i = 0; i < wellData.bDisplay.Count; i++)
            {
                if (wellData.bDisplay[i])
                {
                    indexofdisplaywells.Add(i);
                }
            }
            double[] xx = new double[indexofdisplaywells.Count];
            double[] yy = new double[indexofdisplaywells.Count];
            string[] zz = new string[indexofdisplaywells.Count];
            double[] ww = new double[indexofdisplaywells.Count];
            for (int i = 0; i < indexofdisplaywells.Count; i++)
            {
                xx[i] = wellData.DataList[indexofdisplaywells[i]].xx;
                yy[i] = wellData.DataList[indexofdisplaywells[i]].yy;
                zz[i] = wellData.DataList[indexofdisplaywells[i]].zz;
                ww[i] = wellData.DataList[indexofdisplaywells[i]].ww;
            }
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
            ScatterLayer layerdian = c.addScatterLayer(xx, yy, "", Chart.CircleSymbol, 4, unchecked((int)0x803333ff), unchecked((int)0x803333ff)); // Chart.GlassSphereShape,0xff3333, 0xff33330  c.addScatterLayer(xx, yy, "", Chart.Cross2Shape(0.2), 7, 0x000000);
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
            for (int i = 0; i < faultData.DataList.Count; i++)
            {
                List<double> dx = new List<double>();
                List<double> dy = new List<double>();
                if (faultData.bDisplay[i])
                {
                    for (int j = 0; j < faultData.DataList[i].Count; j++)
                    {
                        dx.Add(faultData.DataList[i][j].xx);
                        dy.Add(faultData.DataList[i][j].yy);
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

            for (int i = 0; i < faultData.DataList.Count; i++)
            {
                List<double> dx = new List<double>();
                List<double> dy = new List<double>();
                if (faultData.bDisplay[i])
                {
                    for (int j = 0; j < faultData.DataList[i].Count; j++)
                    {
                        dx.Add(faultData.DataList[i][j].xx);
                        dy.Add(faultData.DataList[i][j].yy);
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

        public void unDisplayLayer(WinChartViewer viewer)
        {
            if (layerData == null)
            {
                return;
            }
            else if (bDisplayLayerdata)
            {
                createChart(viewer);
            }
            else
            {
                createChart(viewer); return;
            }

            if (bDisplayLayerdata && bDisplayWelldata && bDisplayfaultdata)
            {
                createAddSandianAndFault(viewer); return;
            }
            else if (bDisplayLayerdata && bDisplayWelldata)
            {
                createChartAddsandian(viewer); return;
            }
            else if (bDisplayLayerdata && bDisplayfaultdata)
            {
                createChartAddFault(viewer); return;
            }
        }

        public void PrincipalCurvaturesFI()
        {
            if (layerData == null)
            {
                MessageBox.Show("请先读入地层数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //double[] x = new double[NX];
            //double[] y = new double[NY];
            double[,] z = new double[NY, NX];
            double[,] maxpcur = new double[NY, NX];
            double[,] minpcur = new double[NY, NX];
            double dx, dy;
            for (int i = 0; i < NY; i++)
            {
                for (int j = 0; j < NX; j++)
                {
                    z[i, j] = layerData.Datalist[i * NX + j].zz;
                }
            }
            dx = Math.Abs(layerData.Datalist[1].xx - layerData.Datalist[0].xx);
            dy = Math.Abs(layerData.Datalist[NX].yy - layerData.Datalist[0].yy);

            if (dx == 0 || dy == 0)
            {
                MessageBox.Show("网格数据错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double dfdxx, dfdyy, dfdxdy, tmp1, tmp2, res1, res2;

            # region 中间区域主曲率
            for (int i = 1; i < NY - 1; i++)
            {
                for (int j = 1; j < NX - 1; j++)
                {
                    dfdxx = 0; dfdyy = 0; dfdxdy = 0;
                    dfdxx = (z[i, j - 1] - z[i, j] - z[i, j] + z[i, j + 1]) / dx / dx;
                    dfdyy = (z[i - 1, j] - z[i, j] - z[i, j] + z[i + 1, j]) / dy / dy;
                    dfdxdy = (z[i + 1, j + 1] - z[i - 1, j + 1] - z[i + 1, j - 1] + z[i - 1, j - 1]) / 4 / dx / dy;
                    if (dfdxx == 0)
                    {
                        MessageBox.Show("dfdxx==0", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (dfdyy == 0)
                    {
                        MessageBox.Show("dfdyy==0", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (dfdxdy == 0)
                    {
                        MessageBox.Show("dfdxdy==0", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dfdxx = 1.0 / dfdxx;
                    dfdyy = 1.0 / dfdyy;
                    dfdxdy = 1.0 / dfdxdy;
                    tmp1 = 0; tmp2 = 0;
                    tmp1 = (dfdxx + dfdyy) / 2;
                    tmp2 = Math.Sqrt((dfdxx - dfdyy) * (dfdxx - dfdyy) / 4 + dfdxdy * dfdxdy);

                    res1 = tmp1 + tmp2;
                    res2 = tmp1 - tmp2;
                    if (res1 > res2)
                    {
                        maxpcur[i, j] = res1;
                        minpcur[i, j] = res2;
                    }
                    else
                    {
                        maxpcur[i, j] = res2;
                        minpcur[i, j] = res1;
                    }
                }
            }

            #endregion

            for (int j = 1; j < NX - 1; j++)
            {
                maxpcur[0, j] = maxpcur[1, j];
                minpcur[0, j] = minpcur[1, j];
                maxpcur[NY - 1, j] = maxpcur[NY - 2, j];
                minpcur[NY - 1, j] = minpcur[NY - 2, j];
            }
            for (int i = 0; i < NY; i++)
            {
                maxpcur[i, 0] = maxpcur[i, 1];
                minpcur[i, 0] = minpcur[i, 1];
                maxpcur[i, NX - 1] = maxpcur[i, NX - 2];
                minpcur[i, NX - 1] = minpcur[i, NX - 2];
            }
            data3 d1 = new data3();
            data3 d2 = new data3();
            for (int i = 0; i < NY; i++)
            {
                for (int j = 0; j < NX; j++)
                {
                    d1.xx = layerData.Datalist[i * NX + j].xx;
                    d1.yy = layerData.Datalist[i * NX + j].yy;

                    d2.xx = d1.xx;
                    d2.yy = d1.yy;

                    d1.zz = maxpcur[i, j];
                    d2.zz = minpcur[i, j];

                    maxCur.Add(d1);
                    minCur.Add(d2);
                }
            }
        }

        public void PlainStressFI()
        {
            if (layerData == null)
            {
                MessageBox.Show("请先读入地层数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            

            frmPlainStressPara PlainStressParaForm = new frmPlainStressPara();
            if (PlainStressParaForm.ShowDialog() == DialogResult.OK)
            {
                E = PlainStressParaForm.Para_E;
                v = PlainStressParaForm.Para_V;
                thickness = PlainStressParaForm.Para_Thickness;
            }
            else
            {
                return;
            }
            //E = 10000;
            //v = 0.24;
            //thickness = 10;
            if (E <= 0 || v <= 0 || thickness <= 0)
            {
                return;
            }
            //double[] x = new double[NX];
            //double[] y = new double[NY];
            double[,] z = new double[NY, NX];
            double[,] maxtecstr = new double[NY, NX];
            double[,] minptecstr = new double[NY, NX];
            double[,] maxs = new double[NY, NX];
            //double[,] maxtecstr = new double[NY, NX];
            //double[,] minptecstr = new double[NY, NX];
            double dx, dy;
            for (int i = 0; i < NY; i++)
            {
                for (int j = 0; j < NX; j++)
                {
                    z[i, j] = layerData.Datalist[i * NX + j].zz;
                }
            }
            dx = Math.Abs(layerData.Datalist[1].xx - layerData.Datalist[0].xx);
            dy = Math.Abs(layerData.Datalist[NX].yy - layerData.Datalist[0].yy);

            if (dx == 0 || dy == 0)
            {
                MessageBox.Show("网格数据错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double dfdxx, dfdyy, dfdxdy, tmp1, tmp2, res1, res2;
            double sigmaxx, sigmayy, sigmaxy;
            # region 中间区域主曲率
            for (int i = 1; i < NY - 1; i++)
            {
                for (int j = 1; j < NX - 1; j++)
                {
                    dfdxx = 0; dfdyy = 0; dfdxdy = 0;
                    dfdxx = (z[i, j - 1] - z[i, j] - z[i, j] + z[i, j + 1]) / dx / dx;
                    dfdyy = (z[i - 1, j] - z[i, j] - z[i, j] + z[i + 1, j]) / dy / dy;
                    dfdxdy = (z[i + 1, j + 1] - z[i - 1, j + 1] - z[i + 1, j - 1] + z[i - 1, j - 1]) / 4 / dx / dy;
                    if (dfdxx == 0)
                    {
                        MessageBox.Show("dfdxx==0", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (dfdyy == 0)
                    {
                        MessageBox.Show("dfdyy==0", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (dfdxdy == 0)
                    {
                        MessageBox.Show("dfdxdy==0", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dfdxx = 1.0 / dfdxx;
                    dfdyy = 1.0 / dfdyy;
                    dfdxdy = 1.0 / dfdxdy;
                    sigmaxx = E * thickness / 2 / (1 - v * v) * (dfdxx + dfdyy * v);
                    sigmayy = E * thickness / 2 / (1 - v * v) * (dfdyy + dfdxx * v);
                    sigmaxy = E * thickness / 2 / (1 + v) * dfdxdy;
                    tmp1 = 0; tmp2 = 0;
                    tmp1 = (sigmaxx + sigmayy) / 2;
                    tmp2 = Math.Sqrt((sigmaxx - sigmayy) * (sigmaxx - sigmayy) / 4 + sigmaxy * sigmaxy);

                    res1 = tmp1 + tmp2;
                    res2 = tmp1 - tmp2;
                    if (res1 > res2)
                    {
                        maxtecstr[i, j] = res1;
                        minptecstr[i, j] = res2;
                    }
                    else
                    {
                        maxtecstr[i, j] = res2;
                        minptecstr[i, j] = res1;
                    }
                    maxs[i, j] = (maxtecstr[i, j] - minptecstr[i, j]) / 2;
                }
            }

            #endregion

            for (int j = 1; j < NX - 1; j++)
            {
                maxtecstr[0, j] = maxtecstr[1, j];
                minptecstr[0, j] = minptecstr[1, j];
                maxtecstr[NY - 1, j] = maxtecstr[NY - 2, j];
                minptecstr[NY - 1, j] = minptecstr[NY - 2, j];
                maxs[0, j] = maxs[1, j];
                maxs[NY - 1, j] = maxs[NY - 2, j];
            }
            for (int i = 0; i < NY; i++)
            {
                maxtecstr[i, 0] = maxtecstr[i, 1];
                minptecstr[i, 0] = minptecstr[i, 1];
                maxtecstr[i, NX - 1] = maxtecstr[i, NX - 2];
                minptecstr[i, NX - 1] = minptecstr[i, NX - 2];
                maxs[i, 0] = maxs[i, 1];
                maxs[i, NX - 1] = maxs[i, NX - 2];
            }
            data3 d1 = new data3();
            data3 d2 = new data3();
            data3 d3 = new data3();
            for (int i = 0; i < NY; i++)
            {
                for (int j = 0; j < NX; j++)
                {
                    d1.xx = layerData.Datalist[i * NX + j].xx;
                    d1.yy = layerData.Datalist[i * NX + j].yy;

                    d2.xx = d1.xx;
                    d2.yy = d1.yy;
                    d3.xx = d1.xx;
                    d3.yy = d1.yy;

                    d1.zz = maxtecstr[i, j];
                    d2.zz = minptecstr[i, j];
                    d3.zz = maxs[i, j];

                    maxStress.Add(d1);
                    minStress.Add(d2);
                    maxShear.Add(d3);
                }
            }
        }

        private List<data3> WGinCurve(List<data3> ld, List<data3> ld1)//判断ld网格数据是否在闭合曲线ld1中
        {
            List<data3> fitY = new List<data3>();
            int sumJO = 0;
            int flagXianShang = 0;//如果在点在边界线上，不做处理
            int[] lenthXY = new int[2];
            lenthXY = data3.GetXYsumList(ld);
            int flag = 0;
            //一个点连一条射线如果与曲线相交为奇数个点（y值相等，曲线x点值小于或等于网格点的x值），则该点在曲线内；否则，则该点在曲线外
            //遇到连续曲线y值与求指点y值相等，则通过flag来判断只算作一次
            for (int i = 0; i < lenthXY[1]; i++)//数据横着读取，y值不变，x值变化
            {
                for (int j = 0; j < lenthXY[0]; j++)
                {
                    for (int k = 0; k < ld1.Count - 1; k++)
                    {

                        if ((ld1[k].yy < ld[i * lenthXY[0] + j].yy && ld[i * lenthXY[0] + j].yy < ld1[k + 1].yy) || (ld1[k].yy > ld[i * lenthXY[0] + j].yy && ld[i * lenthXY[0] + j].yy > ld1[k + 1].yy))
                        {

                            if (ld1[k].xx < ld[i * lenthXY[0] + j].xx && ld1[k + 1].xx < ld[i * lenthXY[0] + j].xx)
                            {
                                sumJO++;
                            }
                            if ((ld1[k].xx <= ld[i * lenthXY[0] + j].xx && ld[i * lenthXY[0] + j].xx <= ld1[k + 1].xx) || (ld1[k].xx >= ld[i * lenthXY[0] + j].xx && ld[i * lenthXY[0] + j].xx >= ld1[k + 1].xx))
                            {
                                flagXianShang = 1;
                            }
                        }
                        while (ld1[k++].yy == ld[i * lenthXY[0] + j].yy)//如果有两个连续的曲线值等于数据点值，只算一次sumJO
                        {
                            flag++;
                            if (ld1[k].xx < ld[i * lenthXY[0] + j].xx && flag == 1)
                            {
                                sumJO++;
                            }
                            if (ld1[k].xx == ld[i * lenthXY[0] + j].xx)
                            {
                                flagXianShang = 1;
                            }
                        }
                        k = k - 1;
                    }

                    if (sumJO % 2 == 0 && flagXianShang == 0)
                    {
                        data3 newData = new data3();
                        newData.xx = 0;
                        newData.yy = 0;
                        newData.zz = 0;
                        ld[i * lenthXY[0] + j] = newData;
                    }
                    sumJO = 0;
                    flag = 0;
                    if (flagXianShang == 1)
                    {
                        flagXianShang = 0;
                    }
                }
            }

            for (int i = 0; i < ld.Count; i++)//数据横着读取，y值不变，x值变化
            {
                while (i < ld.Count && ld[i].xx == 0 && ld[i].yy == 0 && ld[i].zz == 0)
                {
                    ld.RemoveAt(i);
                }
            }

            for (int i = 0; i < ld.Count; i++)//去除与曲线上y值(最大值，最小值)相同，但x值不同的点
            {
                for (int j = 0; j < ld1.Count - 1; j++)
                {
                    if ((ld[i].yy == ld1[j].yy && ld1[j].yy == maxY) || (ld[i].yy == ld1[j].yy && ld1[j].yy == minY))
                    {
                        if (ld[i].xx != ld1[j].xx)
                        {
                            data3 newData = new data3();
                            newData.xx = 0;
                            newData.yy = 0;
                            newData.zz = 0;
                            ld[i] = newData;
                        }
                    }
                }
            }
            for (int i = 0; i < ld.Count; i++)//数据横着读取，y值不变，x值变化
            {
                while (i < ld.Count && ld[i].xx == 0 && ld[i].yy == 0 && ld[i].zz == 0)
                {
                    ld.RemoveAt(i);
                }
            }
            return ld;
        }
    }
}
