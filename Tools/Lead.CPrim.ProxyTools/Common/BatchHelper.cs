using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.Common
{
    /// <summary>
    /// 批处理
    /// </summary>
    public static class BatchHelper
    {
        /// <summary>
        /// 通过批处理删除文件
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="day"></param>
        public static string GetBatchStringForDeleteFiles(this string dir, int day)
        {
            if (string.IsNullOrWhiteSpace(dir) || !Directory.Exists(dir) || day < 1)
            {
                return dir;
            }

            return $@"
                @echo off
                setlocal enabledelayedexpansion

                set ""target_path={dir}""  
                set days_old={day}                       

                if not exist ""%target_path%"" 
                (
                    echo [ERROR] Path not found: %target_path%
                    exit /b 1
                )

                forfiles /p ""%target_path%"" /s /m * /d -%days_old% /c ""cmd /c del @path /q /f 2>nul""

                for /f ""delims="" %%d in ('dir ""%target_path%"" /ad /b /s ^| sort /r 2^>nul') do 
                (
                    rd ""%%d"" 2>nul
                )

                endlocal
                exit
                    ";
        }
    }
}
