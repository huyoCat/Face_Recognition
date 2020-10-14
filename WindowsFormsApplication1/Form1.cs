using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Drawing.Imaging;
using Baidu.Aip.Face;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Drawing.Drawing2D;
using System.Windows.Forms.VisualStyles;
using VisioForge.Shared.MediaFoundation.OPM;
using System.Runtime.InteropServices.ComTypes;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private int ImageCount;
        private List<string> ImagePaths = new List<string>();
        private int nowCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btOpen_Click(object sender, EventArgs e)
        {

            try
            {
                if (DialogResult.OK == openFileDialog1.ShowDialog())
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                    foreach (string Path in Directory.GetFiles(
                        Path.GetDirectoryName(openFileDialog1.FileName)))
                    {
                        ImagePaths.Add(Path);
                    }
                    if (ImagePaths.Count != 0)
                    {
                        ImageCount = ImagePaths.Count;
                    }
                }
            }
            catch(OutOfMemoryException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btNext_Click(object sender, EventArgs e)
        {

            if (nowCount < ImageCount)
            {
                this.pictureBox1.Image = Bitmap.FromFile(ImagePaths[nowCount]);
                nowCount++;
                this.CutPicture.Hide();
            }

        }

        private void btRotate90_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            this.pictureBox1.Refresh();
        }

        private void btRotate180_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            this.pictureBox1.Refresh();
        }

        private void btRec_Click(object sender, EventArgs e)
        {
            Painting();
        }
        public string ReadImg(string img)
        {
            return Convert.ToBase64String(File.ReadAllBytes(img));
        }

        /// <summary>
        /// 画框
        /// </summary>
        public void Painting()
        {
            //this.pictureBox1.Image = Bitmap.FromFile(ImagePaths[nowCount]);
            Bitmap bitMap = new Bitmap(pictureBox1.Image);
            // 设置APPID/AK/SK
            var API_KEY = "你的API_KEY";
            var SECRET_KEY = "你的SECRET_KEY";
            var client = new Face(API_KEY, SECRET_KEY);
            client.Timeout = 60000;  // 修改超时时间
            client.AppId = "你的APPID";
            string guidName = Guid.NewGuid() + ".Jpeg";
            bitMap.Save(guidName, ImageFormat.Jpeg);
            var image = ReadImg(guidName);
            var imageType = "BASE64";
            var options = new Dictionary<string, object>{
                {"face_field","face_shape"},
                {"max_face_num", 5}};
            try
            {
                var result = client.Detect(image, imageType, options);
                RootObject list = JsonConvert.DeserializeObject<RootObject>(result.ToString());
                Graphics gobj = pictureBox1.CreateGraphics();
                Pen redPen = new Pen(Color.Red, 1);
                for (int i = 0; i < (int)double.Parse(list.result.face_num); i++)
                {
                    Double a = double.Parse(list.result.face_list[i].location.left);
                    Double b = double.Parse(list.result.face_list[i].location.top);
                    Double c = double.Parse(list.result.face_list[i].location.width);
                    Double d = double.Parse(list.result.face_list[i].location.height);
                    Rectangle myRectangle = new Rectangle((int)a, (int)b, (int)c, (int)d);
                    gobj.DrawRectangle(redPen, myRectangle);

                    this.CutPicture.Show();
                    CutPicture.Image = CutPic(pictureBox1.Image, (int)a, (int)b, (int)c, (int)d);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("未检测到人脸");
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            //pictureBox1.Image = Bitmap.FromFile(ImagePaths[nowCount]);
            Bitmap bitMap = new Bitmap(pictureBox1.Image);
            //CutPic(bitMap);
            // 设置APPID/AK/SK
            var API_KEY = "你的API_KEY";
            var SECRET_KEY = "你的SECRET_KEY";
            var client = new Face(API_KEY, SECRET_KEY);
            client.Timeout = 60000;  // 修改超时时间
            client.AppId = "你的AppId";
            string guidName = Guid.NewGuid() + ".Jpeg";
            bitMap.Save(guidName, ImageFormat.Jpeg);
            var image = ReadImg(guidName);
            var imageType = "BASE64";
            var options = new Dictionary<string, object>{
                {"face_field","face_shape"},
                {"max_face_num", 5}};
            var result = client.Detect(image, imageType, options);
            RootObject list = JsonConvert.DeserializeObject<RootObject>(result.ToString());
            for (int i = 0; i < (int)double.Parse(list.result.face_num); i++)
            {
                Double a = double.Parse(list.result.face_list[i].location.left);
                Double b = double.Parse(list.result.face_list[i].location.top);
                Double c = double.Parse(list.result.face_list[i].location.width);
                Double d = double.Parse(list.result.face_list[i].location.height);
                CutPicture.Image = CutPic(pictureBox1.Image, (int)a, (int)b, (int)c, (int)d);
                DialogResult dr = MessageBox.Show("确定保存人脸？", "保存提示", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    SaveFileDialog saveImageName = new SaveFileDialog();

                    if (saveImageName.ShowDialog() == DialogResult.OK)
                    {
                        CutPicture.Image.Save(saveImageName.FileName);
                    }
                }
            }
            bitMap.Dispose();

        }

        public Image CutPic(Image img,int a,int b,int c,int d)
        {
            Bitmap pic = new Bitmap(img);
            Bitmap resultBitmap = new Bitmap(c, d);
            using (Graphics g = Graphics.FromImage(resultBitmap))
            {
                Rectangle resultRectangle = new Rectangle(0, 0, c, d);
                Rectangle sourceRectangle = new Rectangle(a, b, c, d);
                g.DrawImage(pic, resultRectangle, sourceRectangle, GraphicsUnit.Pixel);
            }
            pic.Dispose();
            return resultBitmap;
        }      

        public class Location
        {
            public string left { get; set; }
            public string top { get; set; }
            public string width { get; set; }
            public string height { get; set; }
            public string rotation { get; set; }
        }

        public class Angle
        {
            public string yaw { get; set; }
            public string pitch { get; set; }
            public string roll { get; set; }
        }

        public class Landmark
        {
            public string x { get; set; }
            public string y { get; set; }
        }

        public class Landmark72
        {
            public string x { get; set; }
            public string y { get; set; }
        }

        public class Face_list
        {
            public string face_token { get; set; }
            public Location location { get; set; }
            public string face_probability { get; set; }
            public Angle angle { get; set; }
            public List<Landmark> landmark { get; set; }
            public List<Landmark72> landmark72 { get; set; }
        }

        public class Result
        {
            public string face_num { get; set; }
            public List<Face_list> face_list { get; set; }
        }

        public class RootObject
        {
            public string error_code { get; set; }
            public string error_msg { get; set; }
            public string log_id { get; set; }
            public string timestamp { get; set; }
            public string cached { get; set; }
            public Result result { get; set; }
        }

    }
}
