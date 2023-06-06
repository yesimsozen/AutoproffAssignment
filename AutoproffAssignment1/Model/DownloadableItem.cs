using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoproffAssignment1.Model
{
    public abstract class DownloadableItem : GeneralFeatures
    {
        public string DownloadFormat { get; set; }
    }
}
