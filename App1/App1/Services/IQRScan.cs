using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services
{
    public interface IQRScan
    { 
       Task<string> ScanAsync();
    }
}
