using FileGenerator.AddIn.Generators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spackle.Testing;
using System;

namespace FileGenerator.Tests.AddIn.Generators
{
	[TestClass]
	public sealed class ContextNullExceptionTests
		: ExceptionTests<ContextNullException, ArgumentException>
	{
		private const string Message = "That method was visited!";

		public ContextNullExceptionTests()
			: base(ContextNullExceptionTests.Message)
		{
		}

		[TestMethod]
		public void CreateException()
		{
			this.CreateExceptionTest();
		}

		[TestMethod]
		public void CreateExceptionWithMessage()
		{
			this.CreateExceptionWithMessageTest();
		}

		[TestMethod]
		public void CreateExceptionWithMessageAndInnerException()
		{
			this.CreateExceptionWithMessageAndInnerExceptionTest();
		}

		[TestMethod]
		public void RoundtripException()
		{
			this.RoundtripExceptionTest();
		}
	}
}
