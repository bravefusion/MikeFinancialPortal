﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace MikeFinancialPortal.Helpers
{
    public class AttachmentHelper
    {
        public static bool IsWebFriendlyAttachment(HttpPostedFileBase file)
        {
            if (file == null)
                return false;
            if (file.ContentLength > 10 * 1024 * 1024 || file.ContentLength < 1024)
                return false;
            try
            {
                using (var img = Image.FromStream(file.InputStream))
                {
                    return ImageFormat.Jpeg.Equals(img.RawFormat) ||
                           ImageFormat.Png.Equals(img.RawFormat) ||
                           ImageFormat.Gif.Equals(img.RawFormat);
                }
            }
            catch
            {
                return false;
            }
        }
    }
}