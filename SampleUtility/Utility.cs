#region Namespaces
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
#endregion Namespaces

namespace SampleUtility
{
    public class Utility
    {
        #region DataTableToJSONWithJSONNet
        /// <summary>
        /// DataTableToJSONWithJSONNet
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static string DataTableToJSONWithJSONNet(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }
        #endregion
    }
}
