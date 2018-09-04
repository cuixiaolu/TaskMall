using System;
using System.Drawing;
using System.IO;

namespace TaskMall.Web
{
    public class VCodeHelper
    {/// <summary>
     /// 数字随机数
     /// </summary>
     /// <returns></returns>
        private string GetRndNum()
        {
            string code = string.Empty;
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                code += random.Next(9);
            }
            return code;
        }
        /// <summary>
        /// 英文随机
        /// </summary>
        /// <returns></returns>
        private string GetRndStr()
        {
            string Vchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] VcArray = Vchar.Split(',');
            string checkCode = string.Empty;
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                int t = rand.Next(VcArray.Length);
                checkCode += VcArray[t];
            }
            return checkCode;
        }
        /// <summary>
        /// 中文随机
        /// </summary>
        /// <returns></returns>
        private string GetRndCh()
        {
            System.Text.Encoding gb = System.Text.Encoding.Default;//获取GB2312编码页（表）
            object[] bytes = CreateRegionCode(4);//生4个随机中文汉字编码
            string[] str = new string[4];
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                //根据汉字编码的字节数组解码出中文汉字
                str[i] = gb.GetString((byte[])Convert.ChangeType(bytes[i], typeof(byte[])));
                sb.Append(str[i].ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// 产生随机中文字符
        /// </summary>
        /// <param name="strlength"></param>
        /// <returns></returns>
        private static object[] CreateRegionCode(int strlength)
        {
            //定义一个字符串数组储存汉字编码的组成元素
            string[] rBase = new String[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
            Random rnd = new Random();
            object[] bytes = new object[strlength];

            for (int i = 0; i < strlength; i++)
            {
                //区位码第1位
                int r1 = rnd.Next(11, 14);
                string str_r1 = rBase[r1].Trim();
                //区位码第2位
                rnd = new Random(r1 * unchecked((int)DateTime.Now.Ticks) + i);
                int r2;
                if (r1 == 13)
                {
                    r2 = rnd.Next(0, 7);
                }
                else
                {
                    r2 = rnd.Next(0, 16);
                }
                string str_r2 = rBase[r2].Trim();

                //区位码第3位
                rnd = new Random(r2 * unchecked((int)DateTime.Now.Ticks) + i);//更换随机种子
                int r3 = rnd.Next(10, 16);
                string str_r3 = rBase[r3].Trim();

                //区位码第4位
                rnd = new Random(r3 * unchecked((int)DateTime.Now.Ticks) + i);
                int r4;
                if (r3 == 10)
                {
                    r4 = rnd.Next(1, 16);
                }
                else if (r3 == 15)
                {
                    r4 = rnd.Next(0, 15);
                }
                else
                {
                    r4 = rnd.Next(0, 16);
                }
                string str_r4 = rBase[r4].Trim();
                //定义两个字节变量存储产生的随机汉字区位码
                byte byte1 = Convert.ToByte(str_r1 + str_r2, 16);
                byte byte2 = Convert.ToByte(str_r3 + str_r4, 16);

                //将两个字节变量存储在字节数组中
                byte[] str_r = new byte[] { byte1, byte2 };

                //将产生的一个汉字的字节数组放入object数组中
                bytes.SetValue(str_r, i);
            }
            return bytes;
        }

        public static string GetNumAndStr(int length)
        {
            string str = string.Empty;
            string Vchar = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,m,n,p" +
            ",q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,P,Q" +
            ",R,S,T,U,V,W,X,Y,Z";

            string[] VcArray = Vchar.Split(new Char[] { ',' });//拆分成数组
            string[] num = new string[length];

            int temp = -1;//记录上次随机数值，尽量避避免生产几个一样的随机数

            Random rand = new Random();
            //采用一个简单的算法以保证生成随机数的不同
            for (int i = 1; i < length + 1; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
                }

                int t = rand.Next(59);

                temp = t;
                str += VcArray[t];
                // num[i - 1] = VcArray[t]; 
            }
            return str;
        }
        /// <summary>
        /// 画图片的背景图+干扰线 
        /// </summary>
        /// <param name="checkCode"></param>
        /// <returns></returns>
        private Bitmap CreateImages(string checkCode, string type)
        {
            int step = 0;
            if (type == "ch")
            {
                step = 5;//中文字符，边界值做大
            }
            int iwidth = (int)(checkCode.Length * (13 + step));
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(iwidth, 22);
            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);//清除背景色
            Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };//定义随机颜色
            string[] font = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };
            Random rand = new Random();

            for (int i = 0; i < 50; i++)
            {
                int x1 = rand.Next(image.Width);
                int x2 = rand.Next(image.Width);
                int y1 = rand.Next(image.Height);
                int y2 = rand.Next(image.Height);
                g.DrawLine(new Pen(Color.LightGray, 1), x1, y1, x2, y2);//根据坐标画线
            }

            for (int i = 0; i < checkCode.Length; i++)
            {
                int cindex = rand.Next(7);
                int findex = rand.Next(5);

                Font f = new System.Drawing.Font(font[findex], 10, System.Drawing.FontStyle.Bold);
                Brush b = new System.Drawing.SolidBrush(c[cindex]);
                int ii = 4;
                if ((i + 1) % 2 == 0)
                {
                    ii = 2;
                }
                g.DrawString(checkCode.Substring(i, 1), f, b, 3 + (i * (12 + step)), ii);

            }
            g.DrawRectangle(new Pen(Color.Silver, 0), 0, 0, image.Width - 1, image.Height - 1);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            return image;
        }

        public static string CreateImage(string randomcode)
        {
            int mapwidth = (int)(randomcode.Length * 16);
            Bitmap map = new Bitmap(mapwidth, 28);//创建图片背景
            Graphics graph = Graphics.FromImage(map);
            MemoryStream ms = new MemoryStream();
            try
            {
                int randAngle = 45; //随机转动角度
                graph.Clear(Color.AliceBlue);//清除画面，填充背景
                //graph.DrawRectangle(new Pen(Color.Black, 0), 0, 0, map.Width - 1, map.Height - 1);//画一个边框
                //graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//模式

                Random rand = new Random();

                //背景噪点生成
                Pen blackPen = new Pen(Color.LightGray, 0);
                for (int i = 0; i < 50; i++)
                {
                    int x = rand.Next(0, map.Width);
                    int y = rand.Next(0, map.Height);
                    graph.DrawRectangle(blackPen, x, y, 1, 1);
                }

                //验证码旋转，防止机器识别
                char[] chars = randomcode.ToCharArray();//拆散字符串成单字符数组

                //文字距中
                StringFormat format = new StringFormat(StringFormatFlags.NoClip);
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                //定义颜色
                Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
                //定义字体
                string[] font = { "Impact", "Verdana", "Comic Sans MS", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "Segoe Script" };
                int cindex = rand.Next(7);

                for (int i = 0; i < chars.Length; i++)
                {
                    int findex = rand.Next(5);

                    Font f = new System.Drawing.Font(font[findex], 14, System.Drawing.FontStyle.Bold);//字体样式(参数2为字体大小)
                    Brush b = new System.Drawing.SolidBrush(c[cindex]);

                    Point dot = new Point(14, 14);
                    //graph.DrawString(dot.X.ToString(),fontstyle,new SolidBrush(Color.Black),10,150);//测试X坐标显示间距的
                    float angle = rand.Next(-randAngle, randAngle);//转动的度数

                    graph.TranslateTransform(dot.X, dot.Y);//移动光标到指定位置
                    graph.RotateTransform(angle);
                    graph.DrawString(chars[i].ToString(), f, b, 1, 1, format);
                    //graph.DrawString(chars[i].ToString(),fontstyle,new SolidBrush(Color.Blue),1,1,format);
                    graph.RotateTransform(-angle);//转回去
                    graph.TranslateTransform(-2, -dot.Y);//移动光标到指定位置，每个字符紧凑显示，避免被软件识别
                }
                //生成图片

                var imgType = System.Drawing.Imaging.ImageFormat.Png;
                map.Save(ms, imgType);

                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);

                String strbaser64 = Convert.ToBase64String(arr);
                return "data:image/png;base64," + strbaser64;
            }
            finally
            {
                map.Dispose();
                graph.Dispose();
                ms.Close();
                ms.Dispose();
            }
        }

    }
}