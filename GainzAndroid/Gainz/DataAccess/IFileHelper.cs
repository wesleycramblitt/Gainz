using System;
using System.Collections.Generic;
using System.Text;

namespace Gains.DataAccess
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
