// <copyright file="ExtenderTest.cs">Copyright ©  2015</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickConverter;

namespace QuickConverter.Tests
{
    /// <summary>此類別包含 Extender 的參數化單元測試</summary>
    [PexClass(typeof(Extender))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ExtenderTest
    {
        /// <summary>ToBoolEx(Object) 的測試虛設常式</summary>
        [PexMethod]
        public bool ToBoolExTest(object o)
        {
            bool result = Extender.ToBoolEx(o);
            return result;
            // TODO: 將判斷提示加入 方法 ExtenderTest.ToBoolExTest(Object)
        }
    }
}
