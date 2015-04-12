using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace PasswordCreator.Models
{
    using ItemsType = ObservableCollection<PasswordItem>;
    class PasswordModel
    {
        // パスワード管理アイテムのコレクション
        private readonly ItemsType _passwordItems = new ItemsType();
        public ItemsType PasswordItems {
            get
            {
                return _passwordItems;
            }
        }

        // DBアクセスクラス
        private static DatabaseContext _dataContext = new DatabaseContext();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PasswordModel()
        {
            Renew(null);
        }

        /// <summary>
        /// 管理データ追加
        /// </summary>
        /// <param name="row">追加する管理アイテムのインスタンス</param>
        public void Add(PasswordItem row)
        {
            _dataContext.Passwords.Add(row);
            _passwordItems.Add(row);
        }
        /// <summary>
        /// 管理データ削除
        /// </summary>
        /// <param name="row">削除する管理アイテムのインスタンス</param>
        public void Remove(PasswordItem row)
        {
            _dataContext.Passwords.Remove(row);
            _passwordItems.Remove(row);
        }
        /// <summary>
        /// 管理データの全取得
        /// </summary>
        /// <param name="keywords">
        /// 検索キーワード
        ///     空白区切りで複数指定可能（AND検索)
        ///     指定しない場合、全データを取得
        /// </param>
        public void Renew(string keywords)
        {    
           IEnumerable<PasswordItem> extracts = _dataContext.Passwords;

            if (!string.IsNullOrEmpty(keywords))
            {
                foreach (string keyword in keywords.Split(' '))
                {
                    extracts = extracts.Where(item => item.SiteName.Contains(keyword) ||
                                                      (item.Url ?? "").Contains(keyword) ||
                                                      item.UserId.Contains(keyword) ||
                                                      (item.Password ?? "").Contains(keyword) ||
                                                      (item.Category ?? "").Contains(keyword) ||
                                                      (item.Note ?? "").Contains(keyword));
                }
            }
            _passwordItems.Clear();
            foreach (PasswordItem x in extracts)
            {
                _passwordItems.Add(x);
            }
        }
        /// <summary>
        /// 管理データの個別取得
        /// </summary>
        /// <param name="sitename">管理対象名</param>
        /// <param name="userid">ユーザID</param>
        /// <returns>取得した管理アイテム</returns>
        public PasswordItem PickUp(string sitename, string userid)
        {
            IEnumerable<PasswordItem> extracts = 
               _dataContext.Passwords.Where(item => item.SiteName == sitename && item.UserId == userid);

            if (extracts.Any())
            {
                return extracts.First();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// DBへの変更の保存
        /// </summary>
        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }
        /// <summary>
        /// 追加・編集用の新管理アイテムの取得
        /// </summary>
        /// <param name="source">編集対象の管理アイテム(指定しなくても良い)</param>
        /// <returns>管理アイテム</returns>
        public PasswordItem NewSitePassword(PasswordItem source)
        {
            PasswordItem r = new PasswordItem();
            if (source != null)
            {
                r.SetProperties(source);
            }
            return r;
        }
        /// <summary>
        /// インポート処理
        /// </summary>
        /// <param name="filename">インポート元のファイル名</param>
        public void Import(string filename)
        {
            CsvFile.Import(_dataContext, filename);
        }
        /// <summary>
        /// エクスポート処理
        /// </summary>
        /// <param name="filename">エクスポート先のファイル名</param>
        public void Export(string filename)
        {
            CsvFile.Export(_dataContext, filename);
        }
    }
}
