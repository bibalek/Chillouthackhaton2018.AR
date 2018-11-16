using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Extension
{
    public static class StringExtensions
    {
        public static string GetVideoName(this String path)
        {
            int videoNamePos = path.LastIndexOf("/") + 1;
            return path.Remove(0, videoNamePos);
        }
    }
}
