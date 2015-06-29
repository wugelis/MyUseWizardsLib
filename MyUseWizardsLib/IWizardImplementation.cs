using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TemplateWizard;
using EnvDTE;
using System.Windows.Forms;
using System.IO;
using MyUseWizardsLib.Data;
using System.Data;

namespace MyUseWizardsLib
{
    public class IWizardImplementation : IWizard
    {
        private frmORMappingWindow inputORMForm;
        private UserInputForm inputForm = null;
        private frmSettings settingForm = null;
        private string defaultTable;

        // This method is called before opening any item that 
        // has the OpenInEditor attribute.
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        #region 建立供 Model 使用的 Entity 檔案
        /// <summary>
        /// 建立供 Model 使用的 Entity 檔案
        /// </summary>
        /// <param name="ClassDef">Class 內容定義</param>
        /// <param name="ClassFillPath">要建立的 Class 檔案的完整路徑</param>
        /// <returns>傳回建立的 CS 檔案路徑</returns>
        private void CreateModelCSFile(string ClassDef, string ClassFullPath)
        {
            FileStream fs = new FileStream(ClassFullPath, FileMode.Create);
            try
            {
                StreamWriter sw = new StreamWriter(fs);
                try {
                    sw.WriteLine(ClassDef);
                }
                finally {
                    sw.Close();
                }
            }
            finally
            {
                fs.Close();
            }
        }
        #endregion

        #region 當整個專案完成 Generator 時所引發的事件.
        /// <summary>
        /// 當整個專案正在進行 Generator 時所引發的事件.
        /// </summary>
        /// <param name="project">Visual Studio IDE 工具中，目前專案 Projects 集合</param>
        public void ProjectFinishedGenerating(Project project)
        {
            ProjectItem folder = null;
            ProjectItem viewFolder = null;

            var result = from item in project.ProjectItems.OfType<ProjectItem>().AsEnumerable()
                         where item.Name=="Models"
                         select item;
            
            if (result.FirstOrDefault() == null)
            {
                folder = project.ProjectItems.AddFolder("Models");
            }
            else
            {
                //若這個目錄已經存在，則直接取得這個目錄.
                folder = result.FirstOrDefault();
            }

            var resultView = folder.ProjectItems.OfType<ProjectItem>().Where(c => c.Name == "ViewModels");
            if(resultView.FirstOrDefault()==null)
            {
                viewFolder = folder.ProjectItems.AddFolder("ViewModels");
            }
            else
            {
                viewFolder = resultView.FirstOrDefault();
            }

            foreach (string node in frmORMappingWindow.SelectedTables)
            {
                //MessageBox.Show(string.Format("node={0}", node));
                string ClassName = node.Replace(" ", "_");
                //MessageBox.Show(string.Format("ClassName={0}", ClassName));
                ClassDef clsDef = new ClassDef();
                SQLStore store = new SQLStore();
                string ClassDefined = ClassDef.GetClassTemplate;
                ClassDefined = ClassDefined.Replace("$(NAMESPACE_DEF)$", string.Format("{0}.Models.ViewModels", project.Name));
                ClassDefined = ClassDefined.Replace("$(CLASS_DEF)$", clsDef.GetClassDef(store.GetNoDataDataTableByName(string.Format("[{0}]", node)), ClassName));
                //產生等會使用的暫存檔名
                string TempCSPath = Path.Combine(
                    Environment.GetEnvironmentVariable("temp"),
                    string.Format("{0}.cs", ClassName));

                //MessageBox.Show(TempCSPath);

                if(!Directory.Exists(Path.GetDirectoryName(TempCSPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(TempCSPath));
                }
                //建立暫存的 Class 檔案
                CreateModelCSFile(ClassDefined, TempCSPath);
                //加入暫存的 Class 檔案
                viewFolder.ProjectItems.AddFromFileCopy(TempCSPath);
                //刪除掉暫存檔案
                try {
                    File.Delete(TempCSPath);
                }
                catch (Exception ex) { } //刪除暫存檔案若失敗不處理任何訊息.
            }

            #region 使用預設Table建立View的資料夾
            ProjectItem defViewFolder = null;

            var result2 = from item in project.ProjectItems.OfType<ProjectItem>().AsEnumerable()
                         where item.Name == "Views"
                         select item;

            if (result2.FirstOrDefault() != null)
            {
                var defualtView = result2.FirstOrDefault();
                defViewFolder = defualtView.ProjectItems.AddFolder(defaultTable);
            }
            #endregion
        }
        #endregion

        #region This method is only called for item templates,
        /// <summary>
        /// This method is only called for item templates,
        /// not for project templates.
        /// </summary>
        /// <param name="projectItem">代表專案中的一個項目</param>
        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            //projectItem.ProjectItems.AddFolder("Models");
        }
        #endregion

        #region This method is called after the project is created.
        /// <summary>
        /// This method is called after the project is created.
        /// </summary>
        public void RunFinished()
        {
            frmORMappingWindow.SelectedTables.Clear();
        }
        #endregion

        #region (RunStart事件)開始產生新的專案.
        /// <summary>
        /// (RunStart事件)開始產生新的專案.
        /// </summary>
        /// <param name="automationObject">目前執行的 Visual Studio 的執行個體.</param>
        /// <param name="replacementsDictionary">專案的所有文字檔案內容</param>
        /// <param name="runKind">指定會定義範本精靈可建立之不同範本的常數</param>
        /// <param name="customParams"></param>
        public void RunStarted(object automationObject,
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind, object[] customParams)
        {
            try
            {
                inputORMForm = new frmORMappingWindow();
                DialogResult result = inputORMForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    settingForm = new frmSettings();
                    settingForm.ShowDialog();

                    defaultTable = frmSettings.SelectedTableName;

                    //Add table name from Screen.
                    replacementsDictionary.Add("$custommessage$", defaultTable);
                    //加入主要鍵值條件
                    replacementsDictionary.Add("$Key$", frmSettings.SelectedKey);
                    //取出剛才設為 Key 條件的 DataColumn 的 DataType.
                    DataColumn col = frmSettings.SelectedTableColumns.Where(c => c.ColumnName == frmSettings.SelectedKey).FirstOrDefault();
                    string keyType = GetGeneralDataType(col.DataType);
                    replacementsDictionary.Add("$KeyType$", keyType);
                    //寫入連線字串
                    replacementsDictionary.Add("$DataSource$", frmORMappingWindow.ConnectionInfo.DataSourceName);
                    replacementsDictionary.Add("$InitialCatalog$", frmORMappingWindow.ConnectionInfo.Initial_Catalog);
                    replacementsDictionary.Add("$UserID$", frmORMappingWindow.ConnectionInfo.UserId);
                    if (MessageBox.Show("是否要將資料庫連線密碼寫入在 web.config 中？", "Gelis 簡單 ORM 產生器. v0.7", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        replacementsDictionary.Add("$Password$", frmORMappingWindow.ConnectionInfo.Password);
                    }
                    else
                    {
                        replacementsDictionary.Add("$Password$", "");
                    }
                }
                else
                    throw new WizardCancelledException("Is Cancel!!!.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                frmORMappingWindow.ConnectionInfo.IsConnect = false;
                settingForm.Dispose();
                settingForm = null;
            }
        }
        #endregion

        #region 使用Type回傳對應的 Type 字串.
        /// <summary>
        /// 回傳對應的 Type 字串.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string GetGeneralDataType(Type type)
        {
            string result = string.Empty;
            switch (type.ToString())
            {
                case "System.String":
                    result = "string";
                    break;
                case "System.Int32":
                    result = "int";
                    break;
                case "System.DateTime":
                    result = "DateTime";
                    break;
                case "System.Byte[]":
                    result = "byte[]";
                    break;
                case "System.Decimal":
                    result = "decimal";
                    break;
                case "System.Guid":
                    result = "Guid";
                    break;
                default:
                    result = type.ToString();
                    break;
            }
            return result;
        }
        #endregion

        // This method is only called for item templates,
        // not for project templates.
        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }

}
