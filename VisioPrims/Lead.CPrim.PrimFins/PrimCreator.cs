/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: PrimCreator.cs
 * Author: Victor
 * Description: 框架对象创建类，每个基元相同，保持不变
 * CreateTime: 2022-09-21
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 3.3.22.0904 -> 
 * <Author> (Victor)    <Time> (20220921)
 * 1、初版1.0
******************************************************************************/

using System.Xml;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimFinsNet
{
    public class PrimCreator : IPrimCreator
    {
        public IPrimTypeAttributes ConcretePrimTypeAttributes => new PrimTypeAttributes();
        public IPrim Create()
        {
            return new Prim();
        }
        public IPrim Create(XmlNode taskPrimConfig)
        {
            return new Prim(taskPrimConfig);
        }
    }
}