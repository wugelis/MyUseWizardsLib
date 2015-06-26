using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MyUseWizardsLib.Data
{
    /// <summary>
    /// 產生類別敘述定義
    /// </summary>
    public class ClassDef
    {
        public static string GetClassTemplate
        {
            get
            {
                return @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace $(NAMESPACE_DEF)$
{
	$(CLASS_DEF)$
}";
            }
        }
        /// <summary>
        /// 透過 DataTable 產生類別敘述定義
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string GetClassDef(DataTable dt)
        {
            return GetClassDef(dt, null);
        }
        /// <summary>
        /// 透過 DataTable 產生類別敘述定義
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ClassName">自訂類別名稱</param>
        /// <returns></returns>
        public string GetClassDef(DataTable dt, string ClassName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("public class {0}", ClassName==null?dt.TableName:ClassName));
            sb.AppendLine("\t{");

            foreach (DataColumn col in dt.Columns)
            {
                switch (col.DataType.ToString())
                {
                    case "System.String":
                        sb.AppendLine(string.Format("\t\tpublic {0} {1} {{get; set;}}", "string", col.ColumnName));
                        break;
                    case "System.Int32":
                        sb.AppendLine(string.Format("\t\tpublic {0} {1} {{get; set;}}", "int", col.ColumnName));
                        break;
                    case "System.DateTime":
                        sb.AppendLine(string.Format("\t\tpublic {0} {1} {{get; set;}}", "DateTime", col.ColumnName));
                        break;
                    case "System.Byte[]":
                        sb.AppendLine(string.Format("\t\tpublic {0} {1} {{get; set;}}", "byte[]", col.ColumnName));
                        break;
                    case "System.Decimal":
                        sb.AppendLine(string.Format("\t\tpublic {0} {1} {{get; set;}}", "decimal", col.ColumnName));
                        break;
                    case "System.Guid":
                        sb.AppendLine(string.Format("\t\tpublic {0} {1} {{get; set;}}", "Guid", col.ColumnName));
                        break;
                    default:
                        sb.AppendLine(string.Format("\t\tpublic {0} {1} {{get; set;}}", "object", col.ColumnName));
                        break;
                }
            }
            sb.AppendLine("\t}");
            return sb.ToString();
        }
    }
}
