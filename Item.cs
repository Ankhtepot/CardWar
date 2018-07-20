using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardWar {
    public abstract class Item {
        //user: change name of form where is /*update me*/
        //user: add >this.Controls.Add( >instance name<.PB );< into Load method of the form
        public string name;
        public PictureBox PB;
        public MovData movData;
        private Rectangle size;
        private Image baseImage;

        //constructors
        public Item() : this("def", new Rectangle(0, 0, 10, 10)) { }

        public Item(string name, Rectangle size) {
            this.name = name;
            this.size = size;
            movData = new MovData();
        }

        public override string ToString() {
            return this.name;
        }

        //miniclass to operate with data for moving
        public class MovData {
            public int actualPoint;
            public int speed;
            public Point[] path;

            public MovData() {
                this.path = new Point[] { new Point(0, 0) };
                this.speed = 1;
                this.actualPoint = 1;
            }
        }

        //public function to be processed in collection
        public virtual void Move() {
            if (movData.actualPoint < movData.path.GetUpperBound(0)) {
                movData.actualPoint++;
                //Console.WriteLine("movData.path["+movData.actualPoint+"] = "+ movData.path[movData.actualPoint].X+","+ movData.path[movData.actualPoint].Y+")." );
                SetLocations(movData.path[movData.actualPoint]);
            } else {
                SetLocations(movData.path[movData.actualPoint]);
                movData.actualPoint = 0;
                /*update me*/
                frMain.movList.Remove(this);
            }
        }

        public void SetLocations(Point loc) {
            PB.Location = loc;
            this.size.Location = loc;
        }

        public void SetBaseImage(Image img) {
            this.baseImage = img;
        }

        public void SetSize(Rectangle sz) {
            this.size = sz;
        }

        /// <summary>
        /// Set visual properties for this object
        /// this base method is fit for simple graphic object with 1 image, for
        /// more complicated objects its intended to be overriden
        /// </summary>
        /// <param name="img" sets inicial image of an object and base image for rotation purposes></param>
        /// <param name="x" distance from the left border of form></param>
        /// <param name="y" distance from the top border of form></param>
        public virtual void SetVisuals(Image img, int x = 0, int y = 0) {
            this.PB = new PictureBox();
            this.PB.Image = img;
            this.PB.Visible = true;
            this.PB.Enabled = true;
            this.size.Location = new Point(x, y);
            this.PB.Location = this.size.Location;
            this.PB.Image = img;
            this.PB.Size = this.size.Size;
            this.PB.SizeMode = PictureBoxSizeMode.Normal;
            this.baseImage = img;
        }

        //sets moving: endPoint is corner or middle of object specified by startPoint variable
        public void SetMove(Point endPoint, enMoveOn movingForm, bool rotateWanted = true,
            int speed = 1, enLocationType endPointType = enLocationType.center) {
            /*update me*/
            frMain.movList.Remove(this);
            Point startPoint = GetLocation(enLocationType.topLeft);
            //transform of endPoint depending on endPointType selection (so that startPoint and endPoint mark same location of PB)
            switch (endPointType) {
                case (enLocationType.center): {
                        endPoint = new Point(endPoint.X - PB.Width / 2, endPoint.Y - PB.Height / 2);
                    }; break;
                case (enLocationType.topLeft): { }; break;
                case (enLocationType.topRight): {
                        endPoint = new Point(endPoint.X - PB.Width, endPoint.Y);
                    }; break;
                case (enLocationType.bottomLeft): {
                        endPoint = new Point(endPoint.X, endPoint.Y - PB.Height);
                    }; break;
                case (enLocationType.bottomRight): {
                        endPoint = new Point(endPoint.X - PB.Width, endPoint.Y - PB.Height);
                    }; break;
            }
            int pointsOnLine = (int)Math.Sqrt(Math.Pow((endPoint.Y - startPoint.Y), 2)
                + Math.Pow((endPoint.X - startPoint.X), 2));
            movData.actualPoint = 0;
            movData.speed = speed;
            switch (movingForm) {
                case enMoveOn.Line:  movData.path = GetPointsOnLine(startPoint,
                 endPoint, pointsOnLine / movData.speed); break;
                case enMoveOn.PointToPoint: movData.path = new Point[]{endPoint }; break;
                    //TODO more moving algorhitms 
            }
            //Console.WriteLine("SetMove: startPoint{0}, endPoint:{1}.",startPoint.ToString(), endPoint.ToString());
            /*update me*/
            frMain.movList.Add(this);
            if (rotateWanted) RotateImage(countAngle(startPoint, endPoint), Color.Transparent);
        }

        public Point GetLocation(enLocationType locType) {
            Point result = new Point(0, 0);
            switch (locType) {
                case enLocationType.center: {
                        result = new Point(this.size.Location.X + (this.size.Width / 2), this.size.Location.Y + (this.size.Height / 2));
                    }; break;
                case enLocationType.topLeft: {
                        result = this.size.Location;
                    }; break;
                case enLocationType.topRight: {
                        result = new Point(this.size.Location.X + this.size.Size.Width, this.size.Location.Y);
                    }; break;
                case enLocationType.bottomLeft: {
                        result = new Point(this.size.Location.X, this.size.Location.Y + this.size.Height);
                    }; break;
                case enLocationType.bottomRight: {
                        result = new Point(this.size.Location.X + this.size.Size.Width, this.size.Location.Y + this.size.Height);
                    }; break;
            }
            return result;
        }

        public enum enLocationType {
            center = 1, topLeft = 2, bottomLeft = 3,
            topRight = 4, bottomRight = 5
        }

        //returns where is top left corner according to center of object
        private Point centerToLocation(Point originP) {
            Point tempLoc = new Point(0, 0);
            tempLoc.X = originP.X - (this.size.Width / 2);
            tempLoc.Y = originP.Y - (this.size.Height / 2);
            return tempLoc;
        }

        //kudos to author of this nice method to get array of points between 2 coordinates
        //and kudos to Stackoverflow
        private Point[] GetPointsOnLine(Point startPoint, Point endPoint, int quantity) {
            var points = new Point[quantity];
            int ydiff = endPoint.Y - startPoint.Y, xdiff = endPoint.X - startPoint.X;
            double slope = (double)(endPoint.Y - startPoint.Y) / (endPoint.X - startPoint.X);
            double x, y;

            --quantity;

            for (double i = 0; i < quantity; i++) {
                y = slope == 0 ? 0 : ydiff * (i / quantity);
                x = slope == 0 ? xdiff * (i / quantity) : y / slope;
                points[(int)i] = new Point((int)Math.Round(x) + startPoint.X, (int)Math.Round(y) + startPoint.Y);
            }

            points[quantity] = endPoint;
            return points;
        }

        private double countAngle(Point beg, Point end) {
            double result = 0.0;
            double sideX = end.X - beg.X;
            double sideY = end.Y - beg.Y;
            double radians = Math.Atan(sideY / sideX);
            result = radians * (180 / Math.PI);
            if (sideX <= 0 && sideY > 0) result += 180.0; //leftbottom q
            if (sideX <= 0 && sideY < 0) result += 180.0; //leftupper q            
            //Console.WriteLine("Angle from points: " + result.ToString());
            return result;
        }

        public enum enMoveOn {
            Line = 1,
            Elipsis = 2,
            Custom = 3,
            PointToPoint = 4
        }

        //Modified rotation method for images from Stackoverflow, god bless the author
        public void RotateImage(double angleDegrees, Color backgroundColor, bool upsizeOk = true,
                                   bool clipOk = false) {
            Image inputImage = this.baseImage;
            // Test for zero rotation and return a clone of the input image
            if (angleDegrees == 0f)
                this.PB.Image = (Bitmap)inputImage.Clone();

            // Set up old and new image dimensions, assuming upsizing not wanted and clipping OK
            int oldWidth = inputImage.Width;
            int oldHeight = inputImage.Height;
            int newWidth = oldWidth;
            int newHeight = oldHeight;
            float scaleFactor = 1f;

            // If upsizing wanted or clipping not OK calculate the size of the resulting bitmap
            if (upsizeOk || !clipOk) {
                double angleRadians = angleDegrees * Math.PI / 180d;
                double cos = Math.Abs(Math.Cos(angleRadians));
                double sin = Math.Abs(Math.Sin(angleRadians));
                newWidth = (int)Math.Round(oldWidth * cos + oldHeight * sin);
                newHeight = (int)Math.Round(oldWidth * sin + oldHeight * cos);
            }

            // If upsizing not wanted and clipping not OK need a scaling factor
            if (!upsizeOk && !clipOk) {
                scaleFactor = Math.Min((float)oldWidth / newWidth, (float)oldHeight / newHeight);
                newWidth = oldWidth;
                newHeight = oldHeight;
            }

            // Create the new bitmap object. If background color is transparent it must be 32-bit, 
            //  otherwise 24-bit is good enough.
            Bitmap newBitmap = new Bitmap(newWidth, newHeight, backgroundColor == Color.Transparent ?
                                      PixelFormat.Format32bppArgb : PixelFormat.Format24bppRgb);
            newBitmap.SetResolution(inputImage.HorizontalResolution, inputImage.VerticalResolution);

            // Create the Graphics object that does the work
            using (Graphics graphicsObject = Graphics.FromImage(newBitmap)) {
                graphicsObject.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsObject.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphicsObject.SmoothingMode = SmoothingMode.HighQuality;

                // Fill in the specified background color if necessary
                if (backgroundColor != Color.Transparent)
                    graphicsObject.Clear(backgroundColor);

                // Set up the built-in transformation matrix to do the rotation and maybe scaling
                graphicsObject.TranslateTransform(newWidth / 2f, newHeight / 2f);

                if (scaleFactor != 1f)
                    graphicsObject.ScaleTransform(scaleFactor, scaleFactor);

                graphicsObject.RotateTransform((float)angleDegrees);
                graphicsObject.TranslateTransform(-oldWidth / 2f, -oldHeight / 2f);

                // Draw the result 
                graphicsObject.DrawImage(inputImage, 0, 0);
            }

            this.PB.Image = newBitmap;
        }


    }
}
