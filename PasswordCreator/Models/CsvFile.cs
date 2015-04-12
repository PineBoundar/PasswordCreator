using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace PasswordCreator.Models
{
    static class CsvFile
    {
        const int importFieldCount = 5;

        /// <summary>
        /// 指定ファイルへのエクスポート処理
        /// </summary>
        /// <param name="context">エクスポートデータ取得用のDBアクセサ</param>
        /// <param name="filename">エクスポート先のファイル名</param>
        public static void Export(DatabaseContext context, string filename)
        {
            Encoding encode = Encoding.GetEncoding("Shift_JIS");
            using (StreamWriter sw = new StreamWriter(filename, false, encode))
            {
                Func<string, string> dqot = (str) => { return "\"" + (str ?? "").Replace("\"", "\"\"") + "\""; };

                string header = string.Format(
                    "{0},{1},{2},{3},{4},{5},{6}",
                    dqot("SiteName"),
                    dqot("Url"),
                    dqot("UserId"),
                    dqot("Password"),
                    dqot("Note"),
                    dqot("Category"),
                    dqot("Date")
                );
                sw.WriteLine(header);

                foreach (PasswordItem x in context.Passwords)
                {

                    string s = string.Format(
                        "{0},{1},{2},{3},{4},{5},{6}",
                        dqot(x.SiteName),
                        dqot(x.Url),
                        dqot(x.UserId),
                        dqot(x.Password),
                        dqot(x.Note),
                        dqot(x.Category),
                        dqot(x.Date.ToString())
                    );
                    sw.WriteLine(s);
                }
            }
        }
        
        /// <summary>
        /// 指定CSVファイルからのインポート処理
        /// </summary>
        /// <param name="context">インポートデータ入力用のDBアクセサ</param>
        /// <param name="filename">インポート元のファイル名</param>
        public static void Import(DatabaseContext context, string filename)
        {
            List<PasswordItem> rows = GetImportRows(filename);
            foreach (PasswordItem x in rows)
            {
                context.Passwords.Add(x);
            }
            context.SaveChanges();
        }

        /// <summary>
        /// CSVデータからエンティティクラス群への変換処理
        /// </summary>
        /// <param name="filename">インポート元のファイル名</param>
        /// <returns>エンティティクラスのリスト</returns>
        private static List<PasswordItem> GetImportRows(string filename)
        {
            List<PasswordItem> list = new List<PasswordItem>();
            Encoding encode = Encoding.GetEncoding("Shift_JIS");
            using (TextFieldParser perser = new TextFieldParser(filename, encode))
            {
                perser.TextFieldType = FieldType.Delimited;
                perser.SetDelimiters(",");
                perser.HasFieldsEnclosedInQuotes = true;
                perser.TrimWhiteSpace = false;
                while (!perser.EndOfData)
                {
                    string[] fields = perser.ReadFields();
                    PasswordItem row = CreateModel(fields);
                    list.Add(row);
                }
            }
            return list;
        }
        /// <summary>
        /// CSV行を元にしたエンティティクラスの生成処理
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        private static PasswordItem CreateModel(string[] fields)
        {
            if (fields.Length < importFieldCount)
            {
                throw new ImportDataException(null);
            }
            var q =
                from x in fields
                where x == null
                select x;

            if (q.Any()) throw new ImportDataException(null);

            PasswordItem password_item = new PasswordItem();
            try
            {
                password_item.SiteName = fields[0];
                password_item.Url = fields[1];
                password_item.UserId = fields[2];
                password_item.Password = fields[3];
                password_item.Category = fields[4];
                password_item.Note = (fields.Length == 6) ? fields[5] : "";
                password_item.Date = DateTime.Now;
            }
            catch(Exception ex)
            {
                string csvline = string.Join(",", fields);
                ex.Data["Caused"] = csvline;
                throw new ImportDataException(ex);
            }
            return password_item;
        }
    }
}
