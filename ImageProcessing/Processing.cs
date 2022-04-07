using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ImageProcessing
{
    class Processing
    {
        public Processing()
        {

        }
        public static bool ConvertToGray(Bitmap bitmap)
        {
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color c1 = bitmap.GetPixel(i, j);
                    int r1 = c1.R;
                    int g1 = c1.G;
                    int b1 = c1.B;
                    // Формула для расчета нового цвета
                    int gray = (byte)(.2126 * r1 + .7152 * g1 + .0722 * b1);
                    r1 = gray;
                    g1 = gray;
                    b1 = gray;
                    bitmap.SetPixel(i, j, Color.FromArgb(r1, g1, b1));
                }
            }
            return true;
        }

        public static bool Blur(Bitmap bitmap, int winSize)
        {
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    try
                    {
                        int count = 0;
                        int avgR = 0, avgG = 0, avgB = 0;
                        // Суммирование значений по каналам для вычисления среднего с проверкой на выход за границы изображения
                        if (i - winSize >= 0)
                        {
                            Color prevX = bitmap.GetPixel(i - winSize, j);
                            avgR += prevX.R;
                            avgG += prevX.G;
                            avgB += prevX.B;
                            count++;

                        }
                        if (i + winSize < bitmap.Width)
                        {
                            Color nextX = bitmap.GetPixel(i + winSize, j);
                            avgR += nextX.R;
                            avgG += nextX.G;
                            avgB += nextX.B;
                            count++;
                        }
                        if (j - winSize >= 0)
                        {
                            Color prevY = bitmap.GetPixel(i, j - winSize);
                            avgR += prevY.R;
                            avgG += prevY.G;
                            avgB += prevY.B;
                            count++;
                        }
                        if (j + winSize < bitmap.Height)
                        {
                            Color nextY = bitmap.GetPixel(i, j + winSize);
                            avgR += nextY.R;
                            avgG += nextY.G;
                            avgB += nextY.B;
                            count++;
                        }

                        avgR = (avgR / count);
                        avgG = (avgG / count);
                        avgB = (avgB / count);

                        bitmap.SetPixel(i, j, Color.FromArgb(avgR, avgG, avgB));
                    }
                    catch
                    {

                    }

                }
            }
            return true;
        }

        public static bool Sobel(Bitmap Image, Bitmap Image2)
        {
            BitmapData ImageData, ImageData2;
            byte[] buffer, buffer2;
            IntPtr pointer, pointer2;
            int b, g, r, r_x, g_x, b_x, r_y, g_y, b_y, grayscale, location, location2;
            sbyte weight_x, weight_y;
            sbyte[,] weights_x;
            sbyte[,] weights_y;

            // Матрицы Собеля
            weights_x = new sbyte[,] { { 1, 0, -1 }, { 2, 0, -2 }, { 1, 0, -1 } };
            weights_y = new sbyte[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

            // Блокируем объекты Bitmap в системной области
            ImageData = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            ImageData2 = Image2.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            buffer = new byte[ImageData.Stride * Image.Height];
            buffer2 = new byte[ImageData.Stride * Image.Height];
            pointer = ImageData.Scan0;
            pointer2 = ImageData2.Scan0;
            Marshal.Copy(pointer, buffer, 0, buffer.Length);
            for (int y = 0; y < Image.Height; y++)
            {
                for (int x = 0; x < Image.Width * 3; x += 3)
                {
                    r_x = g_x = b_x = 0; // Обнуление градиентов в x-направленных значениях
                    r_y = g_y = b_y = 0; // Обнуление градиентов в y-направленных значениях
                    location = x + y * ImageData.Stride; // Получение местоположения каждого пикселя
                    for (int yy = -(int)Math.Floor(weights_y.GetLength(0) / 2.0d), yyy = 0; yy <= (int)Math.Floor(weights_y.GetLength(0) / 2.0d); yy++, yyy++)
                    {
                        if (y + yy >= 0 && y + yy < Image.Height) // Чтобы не выйти за границы массива
                        {
                            for (int xx = -(int)Math.Floor(weights_x.GetLength(1) / 2.0d) * 3, xxx = 0; xx <= (int)Math.Floor(weights_x.GetLength(1) / 2.0d) * 3; xx += 3, xxx++)
                            {
                                if (x + xx >= 0 && x + xx <= Image.Width * 3 - 3)  // Чтобы не выйти за границы массива
                                {
                                    location2 = x + xx + (yy + y) * ImageData.Stride; 
                                    weight_x = weights_x[yyy, xxx];
                                    weight_y = weights_y[yyy, xxx];
                                    // Прмиенение веса ко всем каналам
                                    b_x += buffer[location2] * weight_x;
                                    g_x += buffer[location2 + 1] * weight_x; 
                                    r_x += buffer[location2 + 2] * weight_x;
                                    b_y += buffer[location2] * weight_y;
                                    g_y += buffer[location2 + 1] * weight_y;
                                    r_y += buffer[location2 + 2] * weight_y;
                                }
                            }
                        }
                    }
                    // Получение значения каждого канала
                    b = (int)Math.Sqrt(Math.Pow(b_x, 2) + Math.Pow(b_y, 2));
                    g = (int)Math.Sqrt(Math.Pow(g_x, 2) + Math.Pow(g_y, 2));
                    r = (int)Math.Sqrt(Math.Pow(r_x, 2) + Math.Pow(r_y, 2));

                    if (b > 255) b = 255;
                    if (g > 255) g = 255;
                    if (r > 255) r = 255;

                    grayscale = (b + g + r) / 3;

                    buffer2[location] = (byte)grayscale;
                    buffer2[location + 1] = (byte)grayscale;
                    buffer2[location + 2] = (byte)grayscale;
                }
            }
            Marshal.Copy(buffer2, 0, pointer2, buffer.Length);
            Image.UnlockBits(ImageData);
            Image2.UnlockBits(ImageData2);
            return true;
        }
    }
    
}
