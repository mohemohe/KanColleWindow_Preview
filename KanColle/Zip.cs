using System;
using System.Collections.Generic;
using System.IO;
//using System.IO.Packaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace KanColle
{
    public class Zip
    {
        public static void UnZIP(string zipPath, string extPath)
        {
            //展開するZIP書庫のパス
            string zipFileName = zipPath;
            //展開したファイルを保存するフォルダ（存在しないと作成される）
            string targetDirectory = extPath;
            //展開するファイルのフィルタ
            string fileFilter = "";

            //FastZipオブジェクトの作成
            ICSharpCode.SharpZipLib.Zip.FastZip fastZip =
                new ICSharpCode.SharpZipLib.Zip.FastZip();
            //属性を復元するか。デフォルトはfalse
            fastZip.RestoreAttributesOnExtract = true;
            //ファイル日時を復元するか。デフォルトはfalse
            fastZip.RestoreDateTimeOnExtract = true;
            //空のフォルダも作成するか。デフォルトはfalse
            fastZip.CreateEmptyDirectories = true;

            //パスワードが設定されているとき
            //パスワードが設定されている書庫をパスワードを指定せずに展開しようとすると、
            //　例外ZipExceptionがスローされる
            //fastZip.Password = "password";

            //ZIP書庫を展開する
            fastZip.ExtractZip(zipFileName, targetDirectory, fileFilter);
        }
    }
}
