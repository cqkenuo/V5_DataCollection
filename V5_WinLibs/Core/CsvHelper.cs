using System.Data;
using System.IO;
namespace V5_WinLibs.Core {
    public static class CsvHelper {
        /// <summary>
        /// ��������ΪCsv
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="strFilePath">����·��</param>
        /// <param name="tableheader">��ͷ</param>
        /// <param name="columname">�ֶα���,���ŷָ�</param>
        public static bool dt2csv(DataTable dt, string strFilePath, string tableheader, string columname) {
            try {
                string strBufferLine = "";
                StreamWriter strmWriterObj = new StreamWriter(strFilePath, false, System.Text.Encoding.UTF8);
                strmWriterObj.WriteLine(tableheader);
                strmWriterObj.WriteLine(columname);
                for (int i = 0; i < dt.Rows.Count; i++) {
                    strBufferLine = "";
                    for (int j = 0; j < dt.Columns.Count; j++) {
                        if (j > 0)
                            strBufferLine += ",";
                        strBufferLine += dt.Rows[i][j].ToString();
                    }
                    strmWriterObj.WriteLine(strBufferLine);
                }
                strmWriterObj.Close();
                return true;
            }
            catch {
                return false;
            }
        }

        /// <summary>
        /// ��Csv����DataTable
        /// </summary>
        /// <param name="filePath">csv�ļ�·��</param>
        /// <param name="n">��ʾ��n�����ֶ�title,��n+1���Ǽ�¼��ʼ</param>
        public static DataTable csv2dt(string filePath, int n, DataTable dt) {
            StreamReader reader = new StreamReader(filePath, System.Text.Encoding.UTF8, false);
            int i = 0, m = 0;
            reader.Peek();
            while (reader.Peek() > 0) {
                m = m + 1;
                string str = reader.ReadLine();
                if (m >= n + 1) {
                    string[] split = str.Split(',');

                    System.Data.DataRow dr = dt.NewRow();
                    for (i = 0; i < split.Length; i++) {
                        dr[i] = split[i];
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
    }
}