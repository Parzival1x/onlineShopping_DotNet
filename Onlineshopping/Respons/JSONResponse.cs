using System;
using System.Collections.Generic;
using System.Text;

namespace Onlineshopping.Respons
{
    public class JSONResponse
    {
        public JSONResponse()
        {
            Status = ResponseConstants.Fail;
        }
        public int Status { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
        public int TotalCount { get; set; }
        public string Description { get; set; }
        public long UpdatedSyncTime { get; set; }
    }
}
