using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuanGua.PatentBus.Common
{
    public class CreateData
    {
        /// <summary>
        /// 生成邀请码（由数字和大小写字母组成的12位）
        /// </summary>
        /// <returns></returns>
        public static string getInviteCode()
        {
            //48-57 65-90 97-122
            StringBuilder id = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < 12; i++)
            {
                char s = '0';
                int j = random.Next(3) % 4;
                switch (j)
                {
                    case 0:
                        //随机生成数字
                        s = (char)(random.Next(57) % (57 - 48 + 1) + 48);
                        break;
                    case 1:
                        //随机生成大写字母
                        s = (char)(random.Next(90) % (90 - 65 + 1) + 65);
                        break;
                    case 2:
                        //随机生成小写字母
                        s = (char)(random.Next(122) % (122 - 97 + 1) + 97);
                        break;
                }
                id.Append(s);
            }
            return id.ToString();
        }

        public static byte[] GetVerifyImage(int nLen, ref string strKey)
        {

            int nBmpWidth = 13 * nLen + 5;
            int nBmpHeight = 25;
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(nBmpWidth, nBmpHeight);

            // 1. 生成随机背景颜色
            int nRed;
            int nGreen;
            int nBlue;
            // 背景的三元色
            //Dim rd As System.Random = New Random(CInt(System.DateTime.Now.Ticks))
            System.Random rd = new Random();
            nRed = rd.Next(255) % 128 + 128;
            nGreen = rd.Next(255) % 128 + 128;
            nBlue = rd.Next(255) % 128 + 128;

            // 2. 填充位图背景
            System.Drawing.Graphics graph = System.Drawing.Graphics.FromImage(bmp);
            graph.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(nRed, nGreen, nBlue)), 0, 0, nBmpWidth, nBmpHeight);


            // 3. 绘制干扰线条，采用比背景略深一些的颜色
            int nLines = 3;
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(nRed - 17, nGreen - 17, nBlue - 17), 2);

            int a = 0;
            while (a < nLines)
            {
                int x1 = rd.Next() % nBmpWidth;
                int y1 = rd.Next() % nBmpHeight;
                int x2 = rd.Next() % nBmpWidth;
                int y2 = rd.Next() % nBmpHeight;
                graph.DrawLine(pen, x1, y1, x2, y2);

                a = a + 1;
            }

            // 采用的字符集，可以随即拓展，并可以控制字符出现的几率
            string strCode = "012345678901234567890123456789";

            // 4. 循环取得字符，并绘制
            string strResult = "";

            int i = 0;
            while (i < nLen)
            {
                int x = (i * 13 + rd.Next(3));
                int y = rd.Next(4) + 1;
                // 确定字体
                System.Drawing.Font font = new System.Drawing.Font("Courier New", 12 + rd.Next() % 4, System.Drawing.FontStyle.Bold);
                char c = strCode[rd.Next(strCode.Length)];
                // 随机获取字符
                strResult = strResult + c.ToString();
                // 绘制字符
                graph.DrawString(c.ToString(), font, new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(nRed - 60 + y * 3, nGreen - 60 + y * 3, nBlue - 40 + y * 3)), x, y);

                i = i + 1;
            }

            // 5. 输出字节流
            System.IO.MemoryStream bstream = new System.IO.MemoryStream();
            bmp.Save(bstream, System.Drawing.Imaging.ImageFormat.Jpeg);
            bmp.Dispose();
            graph.Dispose();

            strKey = strResult;
            byte[] byteReturn = bstream.ToArray();
            bstream.Close();

            return byteReturn;
        }
    }
}
