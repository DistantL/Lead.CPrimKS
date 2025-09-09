using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// FileInfo扩展<br/>
    /// 调用时需要捕获异常<br/>
    /// </summary>
    public static class FileInfoEx
    {
        /// <summary>
        /// 获取FileInfo<br/>
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static FileInfo GetFileInfo(this string path)
        {
            try
            {
                return new FileInfo(path);
            }
            catch (ArgumentNullException)
            {
                LogHelper.Warn($"{nameof(FileInfoEx)}.{nameof(GetFileInfo)}：{nameof(path)} = {path}，参数为空");
            }
            catch (SecurityException)
            {
                LogHelper.Warn($"{nameof(FileInfoEx)}.{nameof(GetFileInfo)}：{nameof(path)} = {path}，无权限");
            }
            catch (ArgumentException)
            {
                LogHelper.Warn($"{nameof(FileInfoEx)}.{nameof(GetFileInfo)}：{nameof(path)} = {path}，文件名为空，仅包含空格，或包含无效字符");
            }
            catch (UnauthorizedAccessException)
            {
                LogHelper.Warn($"{nameof(FileInfoEx)}.{nameof(GetFileInfo)}：{nameof(path)} = {path}，访问被拒绝");
            }
            catch (PathTooLongException)
            {
                LogHelper.Warn($"{nameof(FileInfoEx)}.{nameof(GetFileInfo)}：{nameof(path)} = {path}，路径大于248个字符，或者文件名大于260个字符");
            }
            catch (Exception e)
            {
                throw e;
            }

            return null;
        }
    }
}
