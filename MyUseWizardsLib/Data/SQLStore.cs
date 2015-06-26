using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MyUseWizardsLib.Data
{
    public class SQLStore: DAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public DataTable GetNoDataDataTableByName(string TableName)
        {
            return Query(
                string.Format(@"select TOP 0 A.* from {0} A", TableName)).Tables[0];
        }
    }
}
