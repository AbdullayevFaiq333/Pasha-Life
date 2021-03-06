using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanel.Utils
{
    public static class Extensions
    {
        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image/");
        }
        public static bool IsPdf(this IFormFile file)
        {
            return file.ContentType.Contains("pdf/");
        }
        public static bool IsSizeAllowed(this IFormFile file, int kb)
        {
            return file.Length < 2000 * kb;
        }
    }
}
